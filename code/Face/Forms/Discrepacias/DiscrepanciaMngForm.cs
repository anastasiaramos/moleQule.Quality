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
    public partial class DiscrepanciaMngForm : DiscrepanciaMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "DiscrepanciaMngForm";
        public static Type Type { get { return typeof(DiscrepanciaMngForm); } }
        public override Type EntityType { get { return typeof(Discrepancia); } }

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        protected Discrepancia _entity;

        #endregion

        #region Factory Methods

        public DiscrepanciaMngForm() : this(false, null) { }

        public DiscrepanciaMngForm(Form parent) : this(false, parent) { }

        public DiscrepanciaMngForm(bool isModal, Form parent) : this(isModal, parent, null) { }

        public DiscrepanciaMngForm(bool isModal, Form parent, DiscrepanciaList list)
            : base(isModal, parent, list)
        {
            InitializeComponent();
            SetView(molView.Normal);
            // Parche para poder abrir el formulario en modo diseño y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;
            SetMainDataGridView(Tabla);
            Datos.DataSource = DiscrepanciaList.NewList().GetSortedList();

            base.SortProperty = Numero.DataPropertyName;

            this.Text = Resources.Labels.DISCREPANCIA_TITLE;
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

        #region Style & Source

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

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            if (Tabla == null) return;

            base.FormatControls();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Numero.Tag = 1;
            cols.Add(Numero);

            ControlsMng.MaximizeColumns(Tabla, cols);
            SetGridFormat();
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));

            Fields_CB.Text = Numero.HeaderText;

        }

        /// <summary>
        /// Toma la lista de bancos de la base de datos y rellena la tabla.
        /// </summary>
        protected override void RefreshMainData()
        {
            PgMng.Grow(string.Empty, "Discrepancia");

            _selectedOid = ActiveOID;

            switch (DataType)
            {
                case EntityMngFormTypeData.Default:
                    List = DiscrepanciaList.GetList(false);
                    break;

                case EntityMngFormTypeData.ByParameter:
                    _sorted_list = List.GetSortedList();
                    break;
            }

            PgMng.Grow(string.Empty, "Lista de Discrepancias");
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

        /// <summary>Imprime la lista del objetos
        /// <returns>void</returns>
        /// </summary>
        public override void PrintList()
        {
            /*DiscrepanciaReportMng reportMng = new DiscrepanciaReportMng(AppContext.ActiveSchema);
			
            DiscrepanciaListRpt report = reportMng.GetListReport(list);
			
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


        protected new SortedBindingList<DiscrepanciaInfo> Localize(FilterItem item)
        {
            SortedBindingList<DiscrepanciaInfo> list = null;
            DiscrepanciaList sourceList = null;

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

    public partial class DiscrepanciaMngBaseForm : Skin06.EntityMngSkinForm<DiscrepanciaList, DiscrepanciaInfo>
    {
        public DiscrepanciaMngBaseForm()
            : this(false, null, null) { }

        public DiscrepanciaMngBaseForm(bool isModal, Form parent, DiscrepanciaList lista)
            : base(isModal, parent, lista) { }
    }
}
