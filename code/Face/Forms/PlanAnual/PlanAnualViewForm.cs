using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class PlanAnualViewForm : PlanAnualForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private PlanAnualInfo _entity;

        public override PlanAnualInfo EntityInfo { get { return _entity; } }

        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveOID
        {
            get
            {
                return Clases_Grid.CurrentRow != null ? ((Plan_TipoInfo)Datos_Planes_Tipos.Current).OidTipo : 0;
            }
        }


        /// <summary>
        /// Añade una lista de valores de combobox a la lista de combos
        /// </summary>
        protected override void AddComboList()
        {
            if (_source_list.CombosListCount < Clases_Grid.Rows.Count - 1)
            {
                for (long i = _source_list.CombosListCount; i < Clases_Grid.Rows.Count; i++)
                {
                    _source_list.AddCombosList(((Plan_TipoInfo)Clases_Grid.Rows[(int)i].DataBoundItem).OidClase);
                    ((DataGridViewComboBoxCell)(Clases_Grid["TipoAuditoria_CBC", (int)i])).DataSource = _source_list.GetCombosList((int)i);

                }
            }
                    
        }


        protected override void OpenClaseAuditoriaForm()
        {
            TipoAuditoriaInfo tipo = _tipos.GetItem(ActiveOID);
            ClaseAuditoriaInfo clase = _clases.GetItem(tipo.OidClaseAuditoria);
            Plan_TipoAuditoriaViewForm form = new Plan_TipoAuditoriaViewForm(tipo,
                Datos_Planes_Tipos.Current as Plan_TipoInfo);
            if (form.Entity != null)
                form.ShowDialog();
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private PlanAnualViewForm() : this(-1) { }

        public PlanAnualViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.PLAN_ANUAL_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlanAnualInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Bar.Grow();

            Csla.SortedBindingList<Plan_TipoInfo> lista = new Csla.SortedBindingList<Plan_TipoInfo>(_entity.PlanesTipos);
            lista.ApplySort("Orden", ListSortDirection.Ascending);

            Datos_Planes_Tipos.DataSource = lista;
            Bar.Grow();

            for(int i = 0; i < lista.Count; i++)
            {
                _source_list.AddCombosList(((Plan_TipoInfo)Clases_Grid.Rows[(int)i].DataBoundItem).OidClase);
                ((DataGridViewComboBoxCell)(Clases_Grid["TipoAuditoria_CBC", (int)i])).DataSource = _source_list.GetCombosList((int)i);
            }

            SetUnlinkedGridValues(Clases_Grid.Name);

            base.RefreshMainData();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            foreach (DataGridViewRow row in Clases_Grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    //_source_list_t.AddCombosList(((ClaseTeorica)row.DataBoundItem).OidModulo);
                    ((DataGridViewComboBoxCell)(row.Cells["TipoAuditoria_CBC"])).DataSource = _source_list.GetCombosList(row.Index);

                    TipoAuditoriaInfo tipo = _tipos.GetItem(((Plan_TipoInfo)row.DataBoundItem).OidTipo);
                    if (tipo != null)
                    {
                        ClaseAuditoriaInfo clase = _clases.GetItem(tipo.OidClaseAuditoria);
                        row.Cells[0].Value = clase.Tipo;
                        row.Cells[1].Value = clase.Numero;
                    }
                }
            }
        }
        
        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

            #region Events

            #endregion
    }
}

