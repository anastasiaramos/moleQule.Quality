using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeAmpliacionViewForm : InformeAmpliacionForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeAmpliacionViewForm";
		public new static Type Type { get { return typeof(InformeAmpliacionViewForm); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private InformeAmpliacionInfo _entity;

        public override InformeAmpliacionInfo EntityInfo { get { return _entity; } }

		#endregion
		
        #region Factory Methods

        public InformeAmpliacionViewForm(long oid) : this(oid, null) {}

        public InformeAmpliacionViewForm(long oid, Form parent)
            : base(oid, true, parent)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INFORME_AMPLIACION_TITLE + " " + EntityInfo.Codigo.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        
        public InformeAmpliacionViewForm(Auditoria auditoria, InformeAmpliacion entity, Form parent)
            : base (entity.Oid, true, parent)
        {
            InitializeComponent();
            _entity = entity.GetInfo(true);
            _auditoria = auditoria;
            _informe = _auditoria.Informes.GetItem(_entity.OidInformeDiscrepancia);
            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.INFORME_AMPLIACION_TITLE + " " + EntityInfo.Codigo.ToUpper();
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

			
			Datos_Ampliaciones.DataSource = AmpliacionList.SortList(_entity.Ampliaciones, "Codigo", ListSortDirection.Ascending);
            Bar.Grow();
			
			
            base.RefreshMainData();
        }
		
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {

                case "Ampliaciones_Grid":
                    {
                        foreach (DataGridViewRow row in Ampliaciones_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            AmpliacionInfo info = (AmpliacionInfo)row.DataBoundItem;
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
