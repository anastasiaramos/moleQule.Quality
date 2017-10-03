using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Application;
using moleQule.Library.Quality;
using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class PlanAnualMngForm : PlanAnualMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "PlanAnualMngForm";
        public static Type Type { get { return typeof(PlanAnualMngForm); } }
        public override Type EntityType { get { return typeof(PlanAnual); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected PlanAnual _entity;

        #endregion

        #region Factory Methods

        public PlanAnualMngForm() : this(false, null) { }

        public PlanAnualMngForm(Form parent) : this(false, parent) { }

        public PlanAnualMngForm(bool isModal, Form parent) : this(isModal, parent, null) { }

        public PlanAnualMngForm(bool isModal, Form parent, PlanAnualList list)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            SetMainDataGridView(Tabla);
            Datos.DataSource = PlanAnualList.NewList().GetSortedList();

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
            Tabla.Visible = PlanAnual.CanGetObject();
            Add_Button.Enabled = PlanAnual.CanAddObject();
            Edit_Button.Enabled = PlanAnual.CanEditObject();
            Delete_Button.Enabled = PlanAnual.CanDeleteObject();
            Print_Button.Enabled = PlanAnual.CanGetObject();
            View_Button.Enabled = PlanAnual.CanGetObject();
        }

        #endregion

        #region Style & Source

        protected void SetMainList(SortedBindingList<PlanAnualInfo> list, bool order)
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

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Codigo.Tag = 1;
            cols.Add(Codigo);

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Codigo.HeaderText;

        }

        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "PlanAnual");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = PlanAnualList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }

            PgMng.Grow(string.Empty, "Lista de PlanAnuals");
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
                        PlanAnualList listA = PlanAnualList.GetList(_filter_results);
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
                        PlanAnualList listD = PlanAnualList.GetList(_filter_results);
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
                SetMainList(on ? _filter_results : _sorted_list, true);
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
                PlanAnualAddForm form = new PlanAnualAddForm();
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
                AddForm(new PlanAnualViewForm(ActiveOID));
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
                PlanAnualEditForm form = new PlanAnualEditForm(ActiveOID);
                if (form.Entity != null)
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
            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                    MessageBoxButtons.YesNoCancel,
            //                    MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                try
                {
                    PlanAnual.Delete(oid);
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
            //}
        }

        /// <summary>Duplica un objeto y abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void DuplicateObject(long oid)
        {
            try
            {
                PlanAnual old = PlanAnual.Get(oid, true);
                PlanAnual dup = old.CloneAsNew();
                old.CloseSession();

                AddForm(new PlanAnualAddForm(dup));
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
            /*PlanAnualReportMng reportMng = new PlanAnualReportMng(AppContext.ActiveSchema);
			
            PlanAnualListRpt report = reportMng.GetListReport(list);
			
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
            FilterItem fItem = new FilterItem();
            fItem.Column = ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name;
            fItem.Value = value;
            fItem.FilterProperty = FilterProperty;
            fItem.Operation = _operation;
            _search_results = Localize(fItem);
            return _search_results != null;
        }

        protected override bool DoFilter(FilterItem fItem)
        {
            _filter_results = Localize(fItem);
            return _filter_results != null;
        }


        protected new SortedBindingList<PlanAnualInfo> Localize(FilterItem item)
        {
            SortedBindingList<PlanAnualInfo> list = null;
            PlanAnualList sourceList = null;

            switch (FilterType)
            {
                case IFilterType.None:
                    if (List == null)
                    {
                        MessageBox.Show(Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = List;
                    break;

                case IFilterType.Filter:
                    if (FilteredList == null)
                    {
                        MessageBox.Show(Face.Resources.Messages.NO_RESULTS);
                        return null;
                    }
                    sourceList = FilteredList;
                    break;
            }

            if (item.FilterProperty == IFilterProperty.All)
            {
                FCriteria criteria = GetCriteria(string.Empty, item.Value, null, item.Operation);
                list = sourceList.GetSortedSubList(criteria, _properties_list);
            }
            else
            {
                FCriteria criteria = GetCriteria(item.Column, item.Value, null, item.Operation);
                list = sourceList.GetSortedSubList(criteria, _properties_list);
            }

            if (list.Count == 0)
            {
                MessageBox.Show(Face.Resources.Messages.NO_RESULTS);
                return sourceList.GetSortedList();
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            AddFilterLabel(item);

            return list;
        }

        #endregion

    }

    public partial class PlanAnualMngBaseForm : Skin06.EntityMngSkinForm<PlanAnualList, PlanAnualInfo>
    {
        public PlanAnualMngBaseForm()
            : this(false, null, null) { }

        public PlanAnualMngBaseForm(bool isModal, Form parent, PlanAnualList lista)
            : base(isModal, parent, lista) { }
    }
}
