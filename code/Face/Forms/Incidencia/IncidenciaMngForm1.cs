using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;
using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class IncidenciaMngForm : Skin02.EntityLMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "IncidenciaMngForm";
        public static Type Type { get { return typeof(IncidenciaMngForm); } }
        public override Type EntityType { get { return typeof(Incidencia); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Incidencia _entity;

        private new SortedBindingList<IncidenciaInfo> _filter_results = null;
        private new SortedBindingList<IncidenciaInfo> _sorted_list = null;
        private new SortedBindingList<IncidenciaInfo> _search_results = null;

        /// <summary>
        ///  Lista de objetos de sólo lectura
        /// </summary>
        internal new IncidenciaList List
        {
            get { return _item_list as IncidenciaList; }
            set { _item_list = value; _sorted_list = (value as IncidenciaList).GetSortedList(); }
        }
        internal new SortedBindingList<IncidenciaInfo> SortedList { get { return _sorted_list; } }
        internal new IncidenciaList FilteredList { get { return IncidenciaList.GetList(_filter_results); } }
        internal SortedBindingList<IncidenciaInfo> CurrentList { get { return (Datos.List as SortedBindingList<IncidenciaInfo>); } } 
		

		/// <summary>
		/// Devuelve el OID del objeto activo seleccionado de la tabla
		/// </summary>
		/// <returns></returns>
		public override long ActiveOID { get { return Datos.Current != null ? ((IncidenciaInfo)Datos.Current).Oid : -1; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public IncidenciaInfo ActiveItem { get { return (Datos.Current != null) ? (IncidenciaInfo)Datos.Current : null; } }
		
        public override long ActiveFoundOID { get { return (DatosSearch.Current != null) ? ((IncidenciaInfo)(DatosSearch.Current)).Oid : -1; } }

        public override string SortProperty { get { return this.GetGridSortProperty(Tabla); } }
        public override ListSortDirection SortDirection { get { return this.GetGridSortDirection(Tabla); } }
		
		#endregion
		
		#region Factory Methods

		public IncidenciaMngForm()
            : this(false) {}

        public IncidenciaMngForm(bool isModal)
            : this(isModal, null) { }

        public IncidenciaMngForm(Form parent)
            : this(false, parent) { }

		public IncidenciaMngForm(bool isModal, Form parent)
			: base(isModal, parent)
		{
            InitializeComponent();
            SetView(molView.Normal);

            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            TablaBase = Tabla;

            base.SortProperty = Codigo.DataPropertyName;
        }
		
		#endregion

        #region Business Methods

        protected override Type GetColumnType(string column_name)
        {
            return Tabla.Columns[column_name] != null ? Tabla.Columns[column_name].ValueType : null;
        }
        
        protected override string GetColumnProperty(string column_name)
        {
            return Tabla.Columns[column_name] != null ? Tabla.Columns[column_name].DataPropertyName : null;
        }

        #endregion
		
		#region Autorizacion

		/// <summary>Aplica las reglas de validación de usuarios al formulario.
		/// <returns>void</returns>
		/// </summary>
		protected override void ApplyAuthorizationRules() 
		{
			Tabla.Visible = Incidencia.CanGetObject();
            Add_Button.Enabled = Incidencia.CanAddObject();
            Edit_Button.Enabled = Incidencia.CanEditObject();
            Delete_Button.Enabled = Incidencia.CanDeleteObject();
            Print_Button.Enabled = Incidencia.CanGetObject();
            View_Button.Enabled = Incidencia.CanGetObject();
		}

		#endregion

		#region Style & Source

		/// <summary>Formatea los controles del formulario
		/// <returns>void</returns>
		/// </summary>
		public override void FormatControls()
		{
            if (Tabla == null) return;
            base.FormatControls();

            HideAction(molAction.Print);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Observaciones.Tag = 0.75;
            Agente.Tag = 0.25;
            cols.Add(Observaciones);
            cols.Add(Agente);

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Codigo.HeaderText;

		}

        protected void SetMainList(SortedBindingList<IncidenciaInfo> list, bool order)
        {
            base.SortProperty = SortProperty;
            base.SortDirection = SortDirection;

            int currentColumn = (Tabla.CurrentCell != null) ? Tabla.CurrentCell.ColumnIndex : -1;

            Datos.DataSource = list;
            Datos.ResetBindings(true);

            if (order)
            {
                ControlsMng.OrderByColumn(Tabla, Tabla.Columns[base.SortProperty], base.SortDirection, true);
            }

            if (currentColumn != -1) ControlsMng.SetCurrentCell(Tabla, currentColumn);

            SetGridFormat();
        }


        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            Bar.Grow(string.Empty, "Incidencia");

            _selected_oid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = IncidenciaList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }
            Bar.Grow(string.Empty, "Lista de Incidencias");
        }

        protected override void RefreshSources()
        {
            switch (FilterType)
            {
                case IFilterType.None:
                    SetMainList(_sorted_list, true);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;

                case IFilterType.Filter:
                    SetMainList(_filter_results, true);
                    PgMng.Grow(string.Empty, "Ordenar Lista");
                    break;
            }
            base.RefreshSources();
        }

        public override void UpdateList()
        {
            switch (_current_action)
            {
                case molAction.Add:
                    if (_entity == null) return;
                    List.AddItem(_entity.GetInfo(false));
                    if (FilterType == IFilterType.Filter)
                    {
                        IncidenciaList listA = IncidenciaList.GetList(_filter_results);
                        listA.AddItem(_entity.GetInfo(false));
                        _filter_results = listA.GetSortedList();
                    }
                    break;

                case molAction.Edit:
                case molAction.Lock:
                case molAction.Unlock:
                    if (_entity == null) return;
                    ActiveItem.CopyFrom(_entity);
                    break;

                case molAction.Delete:
                    if (ActiveItem == null) return;
                    List.RemoveItem(ActiveOID);
                    if (FilterType == IFilterType.Filter)
                    {
                        IncidenciaList listD = IncidenciaList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            _entity = null;
            RefreshSources();
        }
				
		/// <summary>
		/// Selecciona un elemento de la tabla
		/// </summary>
		/// <param name="oid">Identificar del elemento</param>
		protected override void Select(long oid)
        {
            int foundIndex = Datos.IndexOf(List.GetItem(oid));
            Datos.Position = foundIndex;
		}

		/// <summary>
		/// Filtra la tabla
		/// </summary>
		/// <param name="oid">Identificar del elemento</param>
		protected override void SetFilter(bool on)
        {
            try
            {
                SetMainList(on ? _filter_results : List.GetSortedList(), true);
            }
            catch (Exception)
            {
                SetMainList(_sorted_list, true);
            }

            base.SetFilter(on);
		} 

		#endregion

        #region Actions

        /// <summary>
        /// Abre el formulario para añadir item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenAddForm()
        {
            try
            {
                IncidenciaAddForm form = new IncidenciaAddForm();
                AddForm(form);
                _entity = form.Entity;
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
		}

		/// <summary>
		/// Abre el formulario para ver item
		/// <returns>void</returns>
		/// </summary>
		public override void OpenViewForm()
		{			
			try
			{
				AddForm(new IncidenciaViewForm(ActiveOID));
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(ex.BusinessException.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
		}

        /// <summary>
        /// Abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenEditForm() 
        {   
            try
            {
                IncidenciaEditForm form = new IncidenciaEditForm(ActiveOID);
                if (form.EntityInfo != null)
                {
                    AddForm(form);
                    _entity = form.Entity;
                }
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE, 
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE, 
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
            }
        }

		/// <summary>
		/// Abre el formulario para borrar item
		/// <returns>void</returns>
		/// </summary>
		public override void DeleteObject(long oid)
		{
			if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
								moleQule.Face.Resources.Labels.ADVISE_TITLE,
								MessageBoxButtons.YesNoCancel, 
								MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
                    
                    Incidencia.Delete(oid);
                    _action_result = DialogResult.OK;

                    //Se eliminan todos los formularios de ese objeto
                    foreach (ItemMngBaseForm form in _list_active_form)
                    {
                        if (form.Oid == oid)
                        {
                            form.Dispose();
                            break;
                        }
                    }
				}
				catch (Csla.DataPortalException ex)
				{
					MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
				}
			}
		}

		/// <summary>Duplica un objeto y abre el formulario para editar item
		/// <returns>void</returns>
		/// </summary>
		public override void DuplicateObject(long oid) 
		{
			try
			{
                    Incidencia old = Incidencia.Get(oid);
                    Incidencia dup = old.CloneAsNew();
                    old.CloseSession();
					
                    AddForm(new IncidenciaAddForm(dup));
			}
			catch (iQException ex)
			{
				MessageBox.Show(ex.Message,
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message,
								moleQule.Face.Resources.Labels.ERROR_TITLE, 
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}

			RefreshList();
		}

		/// <summary>Imprime la lista del objetos
		/// <returns>void</returns>
		/// </summary>
		public override void PrintList() 
		{
			/*IncidenciaReportMng reportMng = new IncidenciaReportMng(AppContext.ActiveSchema);
			
			IncidenciaListRpt report = reportMng.GetListReport(list);
			
			if (report != null)
			{
				ReportViewer.SetReport(report);
				ReportViewer.ShowDialog();
			}
			else
			{
				MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
								moleQule.Face.Resources.Labels.ADVISE_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}*/
		}

        protected override bool DoFind(object value) 
        {
            _search_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _search_results != null; 
        }

        protected override bool DoFilter(object value) 
        {
            _filter_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _filter_results != null; 
        }
        
        protected override bool DoFilterByFirst(string value, string column_name)
        {
            if (column_name == null)
                column_name = ControlsMng.GetCurrentColumn(Tabla).DataPropertyName;

            _filter_results = Localize(value, column_name);
            return _filter_results != null;
        }

        protected new SortedBindingList<IncidenciaInfo> Localize(object value, string column_name)
        {
            SortedBindingList<IncidenciaInfo> list = null;
            IncidenciaList sourceList = null;

            switch (FilterType)
            {
                case IFilterType.None:
                    if (List == null)
                    {
                        MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = List;
                    break;

                case IFilterType.Filter:
                    if (FilteredList == null)
                    {
                        MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = FilteredList;
                    break;
            }

            FCriteria criteria = null;
            string related = "none";

            switch (column_name)
            {
                default:
                    {
                        criteria = GetCriteria(column_name, value, _operation);
                    } break;
            }

            switch (related)
            {
                case "none":
                    {
                        list = sourceList.GetSortedSubList(criteria);
                    } break;
            }

            if (list.Count == 0)
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                return sourceList.GetSortedList();
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            AddFilterLabel(column_name, value);

            Tabla.Focus();

            return list;
        }

		#endregion

		#region Events
		
		private void Tabla_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterByKey(e.KeyChar.ToString());
		}

        private void Tabla_DoubleClick(object sender, EventArgs e)
        {
            ExecuteAction(molAction.Default);
        }

        private void Tabla_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlsMng.SetCurrentCell(Tabla);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText; 
        }
        
        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
            Fields_CB.Text = ControlsMng.GetCurrentColumn(Tabla).HeaderText;
        }
		
		#endregion

    }
}
