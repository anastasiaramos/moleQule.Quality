using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Quality;
using moleQule.Library.Application.Tools;

namespace moleQule.Face.Quality
{
    public partial class PlanAnualForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        protected ClaseAuditoriaList _clases = null;
        protected TipoAuditoriaList _tipos = null;

        protected DataSourceList _source_list;

        public virtual PlanAnual Entity { get { return null; } set { } }
        public virtual PlanAnualInfo EntityInfo { get { return null; } }

        /// <summary>
        /// Devuelve el objeto activo de la tabla
        /// </summary>
        /// <returns></returns>
        public Plan_Tipo CurrentPlanTipo { get { return Clases_Grid.CurrentRow != null ? ((Plan_Tipo)Clases_Grid.CurrentRow.DataBoundItem) : null; } }


        /// <summary>
        /// Devuelve el OID del módulo activo seleccionado en la fila actual
        /// </summary>
        /// <returns></returns>
        public long ActiveComboClase
        {
            get
            {
                return Clases_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_ComboClases.Current).Oid : -1;
            }
        }

        /// <summary>
        /// Devuelve el OID del submódulo activo seleccionado en la fila actual
        /// </summary>
        /// <returns></returns>
        public long ActiveComboTipo
        {
            get
            {
                return Clases_Grid.CurrentRow != null ? _source_list.GetCurrentChild(Clases_Grid.CurrentRow.Index).Oid : -1;

            }
        }

        /// <summary>
        /// Añade una lista de valores de combobox a la lista de combos
        /// </summary>
        protected virtual void AddComboList() { throw new iQImplementationException("No se ha definido AddComboList"); }

        protected virtual void OpenClaseAuditoriaForm() { }

        #endregion

        #region Factory Methods

        public PlanAnualForm() : this(-1, true) { }

        public PlanAnualForm(bool isModal) : this(-1, isModal) { }

        public PlanAnualForm(long oid) : this(oid, true) { }

        public PlanAnualForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        public override void RefreshSecondaryData()
        {
            _clases = ClaseAuditoriaList.GetList(false);
            Library.Quality.HComboBoxSourceList combo_clases = new Library.Quality.HComboBoxSourceList(_clases, false);
            Datos_ComboClases.DataSource = combo_clases;
            Bar.Grow();

            _tipos = TipoAuditoriaList.GetList();
            combo_clases.Childs = new Library.Quality.HComboBoxSourceList(_tipos);
            Bar.Grow();

            _source_list = new DataSourceList(combo_clases);
            Datos_ComboClases.DataSource = _source_list.CBList;
            Bar.Grow();
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        protected override void PrintAction()
        {
            moleQule.Library.Application.Tools.WordExporter word = new moleQule.Library.Application.Tools.WordExporter();

            word.ExportInformePlanAnual(EntityInfo);
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        private void Clases_Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_source_list == null) return;
            AddComboList();
            SetUnlinkedGridValues(Clases_Grid.Name);
        }


        private void Clases_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (Clases_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Clase_CBC":
                    {
                        if (ActiveComboClase > 0 && Clases_Grid["Clase_CBC", e.RowIndex].Value != null)
                        {
                            //se está modificando una línea ya existente
                            if (_source_list.CombosListCount > e.RowIndex)
                                _source_list.UpdateCombosList(e.RowIndex, ActiveComboClase);
                            else //hay que añadir un nuevo datasource a la lista
                                _source_list.AddCombosList(ActiveComboClase);

                            CurrentPlanTipo.OidClase = ActiveComboClase;

                            ((DataGridViewComboBoxCell)(Clases_Grid["TipoAuditoria_CBC", e.RowIndex])).DataSource = _source_list.GetCombosList(e.RowIndex);
                        }
                    } break;

                case "TipoAuditoria_CBC":
                    {
                        if (ActiveComboTipo > 0 && Clases_Grid["TipoAuditoria_CBC", e.RowIndex].Value != null)
                        {
                            TipoAuditoriaInfo tipo = _tipos.GetItem(ActiveComboTipo);
                            ClaseAuditoriaInfo clase = _clases.GetItem(tipo.OidClaseAuditoria);
                            Clases_Grid["Tipo", e.RowIndex].Value = clase.Tipo;
                            Clases_Grid["Numero", e.RowIndex].Value = clase.Numero;

                            CurrentPlanTipo.OidTipo = ActiveComboTipo;
                        }

                    } break;
            }
            SetUnlinkedGridValues(Clases_Grid.Name);
        }

        private void Clases_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void Clases_Grid_DoubleClick(object sender, EventArgs e)
        {
            OpenClaseAuditoriaForm();
        }

        private void Clases_Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this is PlanAnualViewForm) return;

            long oid_plan_tipo = ((Plan_Tipo)e.Row.DataBoundItem).Oid;

            //Eliminamos el datasource asociado
            if (_source_list.CombosListCount > e.Row.Index)
                _source_list.DeleteCombosList(e.Row.Index);

            SetUnlinkedGridValues(Clases_Grid.Name);
        }

        #endregion




    }
}


