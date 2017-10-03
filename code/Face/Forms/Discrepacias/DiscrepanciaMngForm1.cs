using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class DiscrepanciaMngForm : Skin02.EntityLMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "DiscrepanciaMngForm";
        public static Type Type { get { return typeof(DiscrepanciaMngForm); } }
        public override Type EntityType { get { return typeof(Discrepancia); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Discrepancia _entity;

        private new SortedBindingList<DiscrepanciaInfo> _filter_results = null;
        private new SortedBindingList<DiscrepanciaInfo> _sorted_list = null;
        private new SortedBindingList<DiscrepanciaInfo> _search_results = null;
        private InformeDiscrepanciaList _informes = null;
        private AuditoriaList _auditorias = null;

        private new DiscrepanciaList List 
        { 
            get { return _item_list as DiscrepanciaList; }
            set { _item_list = value; _sorted_list = (value as DiscrepanciaList).GetSortedList(); }
        }
        private new SortedBindingList<DiscrepanciaInfo> SortedList { get { return _sorted_list; } }
        private new DiscrepanciaList FilteredList { get { return DiscrepanciaList.GetList(_filter_results); } }
        internal SortedBindingList<DiscrepanciaInfo> CurrentList { get { return (Datos.List as SortedBindingList<DiscrepanciaInfo>); } }

		/// <summary>
		/// Devuelve el OID del objeto activo seleccionado de la tabla
		/// </summary>
		/// <returns></returns>
		public override long ActiveOID { get { return ActiveItem != null ? ActiveItem.Oid : -1; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public DiscrepanciaInfo ActiveItem { get { return (Datos.Current != null) ? Datos.Current as DiscrepanciaInfo : null; } }
		
        public override long ActiveFoundOID { get { return (DatosSearch.Current != null) ? ((DiscrepanciaInfo)(DatosSearch.Current)).Oid : -1; } }

        public override string SortProperty { get { return this.GetGridSortProperty(Tabla); } }
        public override ListSortDirection SortDirection { get { return this.GetGridSortDirection(Tabla); } }
		
		#endregion
		
		#region Factory Methods

		public DiscrepanciaMngForm()
            : this(false) {}

		public DiscrepanciaMngForm(bool isModal)
            : this(isModal, null) { }

        public DiscrepanciaMngForm(Form parent)
            : this(false, parent) { }
		
		public DiscrepanciaMngForm(bool isModal, Form parent)
			: this(isModal, parent, null) {}
		
		public DiscrepanciaMngForm(bool isModal, Form parent, DiscrepanciaList list)
			: base(isModal, parent, list)
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
			Tabla.Visible = Discrepancia.CanGetObject();
            Add_Button.Enabled = Discrepancia.CanAddObject();
            Edit_Button.Enabled = Discrepancia.CanEditObject();
            Delete_Button.Enabled = Discrepancia.CanDeleteObject();
            Print_Button.Enabled = Discrepancia.CanGetObject();
            View_Button.Enabled = Discrepancia.CanGetObject();
		}

		#endregion

		#region Source
		
        protected void SetMainList(SortedBindingList<DiscrepanciaInfo> list, bool order)
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

		protected override void RefreshMainData()
		{
			Bar.Grow(string.Empty, "Discrepancia");
			
			_selected_oid = ActiveOID;			
			
			switch (DataType)
            { 
                case EntityMngFormTypeData.Default:
                    List = DiscrepanciaList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            } 
			Bar.Grow(string.Empty, "Lista de Discrepancias");
        }

        public override void RefreshSecondaryData()
        {
            _auditorias = AuditoriaList.GetList(false); 
            Bar.Grow(string.Empty, "Discrepancia");

            _informes = InformeDiscrepanciaList.GetList(false);
            Bar.Grow(string.Empty, "Discrepancia");
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
                        DiscrepanciaList listA = DiscrepanciaList.GetList(_filter_results);
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
                        DiscrepanciaList listD = DiscrepanciaList.GetList(_filter_results);
                        listD.RemoveItem(ActiveOID);
                        _filter_results = listD.GetSortedList();
                    }
                    break;
            }

            _entity = null;
            RefreshSources();
        }
				
		protected override void Select(long oid)
		{
			int foundIndex = Datos.IndexOf(List.GetItem(oid));
			Datos.Position = foundIndex;
		}

		protected override void SetFilter(bool on)
		{
			try
			{
                SetMainList(on ? _filter_results : _sorted_list, true);
			}
			catch (Exception)
			{
                SetMainList(_sorted_list, true);
			}
			
			base.SetFilter(on);
		}

		#endregion

		#region Style & Format

		public override void FormatControls()
		{
            if (Tabla == null) return;
			
			base.FormatControls();

			List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Texto.Tag = 0.5;
            Observaciones.Tag = 0.5;

            cols.Add(Texto);
            cols.Add(Observaciones);

            ControlsMng.MaximizeColumns(Tabla, cols);

            ControlsMng.OrderByColumn(Tabla, Codigo, ListSortDirection.Ascending);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Codigo.HeaderText;
			
            Print_Button.Visible = false;
            Add_Button.Visible = false;
		}
		
		protected override void SetRowFormat(DataGridViewRow row)
        {
            /*if (row.IsNewRow) return;
            DiscrepanciaInfo item = (DiscrepanciaInfo)row.DataBoundItem;*/
        }
		
		#endregion

        #region Actions

		/// <summary>
		/// Abre el formulario para ver item
		/// <returns>void</returns>
		/// </summary>
		public override void OpenViewForm()
		{			
			try
            {
                DiscrepanciaInfo discrepancia = DiscrepanciaInfo.Get(ActiveOID);
                if (discrepancia == null) return;
                InformeDiscrepanciaInfo informe = InformeDiscrepanciaInfo.Get(discrepancia.OidInforme);
				AddForm(new AuditoriaViewForm(informe.OidAuditoria));
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
                DiscrepanciaInfo discrepancia = DiscrepanciaInfo.Get(ActiveOID);
                if (discrepancia == null) return;
                InformeDiscrepanciaInfo informe = InformeDiscrepanciaInfo.Get(discrepancia.OidInforme);
                AuditoriaEditForm form = new AuditoriaEditForm(informe.OidAuditoria);
                if(form.Entity != null)
                    AddForm(form);
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

		/// <summary>Imprime la lista del objetos
		/// <returns>void</returns>
		/// </summary>
		public override void PrintList() 
		{
			/*DiscrepanciaReportMng reportMng = new DiscrepanciaReportMng(AppContext.ActiveSchema);
			
			DiscrepanciaListRpt report = reportMng.GetListReport(List);
			
			if (report != null)
			{
				ReportViewer.SetReport(report);
				ReportViewer.ShowDialog();
			}
			else
			{
				MessageBox.Show(moleQule.Face.Resources.Messages.NO_DATA_REPORTS,
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
				column_name = ControlsMng.GetCurrentColumn(Tabla).Name;
			
            _filter_results = Localize(value, column_name); 
            return _filter_results != null; 
        }

        protected new SortedBindingList<DiscrepanciaInfo> Localize(object value, string column_name)
        {
            SortedBindingList<DiscrepanciaInfo> list = null;

            DiscrepanciaList sourceList = null;

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
					criteria = GetCriteria(column_name, value, _operation);
                    break;
            }

            switch (column_name)
            {
                default:
                    criteria = GetCriteria(column_name, value, _operation);
                    break;
            }

            switch (related)
            {
                case "none":
                    list = sourceList.GetSortedSubList(criteria);
                    break;
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
