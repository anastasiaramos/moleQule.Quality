using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeCorrectorViewForm : InformeCorrectorForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeCorrectorViewForm";
		public new static Type Type { get { return typeof(InformeCorrectorViewForm); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private InformeCorrectorInfo _entity;

        public override InformeCorrectorInfo EntityInfo { get { return _entity; } }

		#endregion
		
        #region Factory Methods

        public InformeCorrectorViewForm(long oid) : this(oid, null) {}

        public InformeCorrectorViewForm(long oid, Form parent)
            : base(oid, true, parent)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INFORME_ACCION_CORRECTORA_TITLE + " " + EntityInfo.Codigo.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }


        public InformeCorrectorViewForm(Auditoria auditoria, InformeCorrector entity, Form parent)
            : base (entity.Oid, true, parent)
        {
            InitializeComponent();
            _entity = entity.GetInfo(true);
            _auditoria = auditoria;
            _informe = _auditoria.Informes.GetItem(_entity.OidInformeDiscrepancia);
            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.INFORME_ACCION_CORRECTORA_TITLE + " " + EntityInfo.Codigo.ToUpper();
            }
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
        }

        #endregion

        #region Style & Source

        /// <summary>Da formato visual a los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
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

			
			Datos_AccionCorrectoras.DataSource = AccionCorrectoraList.SortList(_entity.Acciones, "Codigo", ListSortDirection.Ascending);
            Bar.Grow();
			
			
            base.RefreshMainData();
        }

        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {

                case "AccionesCorrectoras_Grid":
                    {
                        foreach (DataGridViewRow row in AccionesCorrectoras_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            AccionCorrectoraInfo info = (AccionCorrectoraInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                Discrepancia item = _informe.Discrepancias.GetItem(info.OidDiscrepancia);
                                if (item != null)
                                {
                                    row.Cells["Numero"].Value = item.Numero;
                                    row.Cells["FechaDebida"].Value = item.FechaDebida.ToShortDateString();
                                    row.Cells["FechaCierre"].Value = item.FechaCierre.ToShortDateString();
                                }
                            }
                        }

                    } break;

            }
        }
		
        #endregion

        #region Validation & Format

        /// <summary>
        /// Asigna formato deseado a los controles del objeto cuando éste es modificado
        /// </summary>
        protected override void FormatData()
        {
        }

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
