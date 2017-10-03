using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Hipatia;

using moleQule.Face;
using moleQule.Face.Hipatia;

namespace moleQule.Face.Quality
{
    public partial class InformeCorrectorForm : Skin01.ItemMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "InformeCorrectorForm";
		public static Type Type { get { return typeof(InformeCorrectorForm); } }

        protected override int BarSteps { get { return base.BarSteps + 0; } }
        protected Auditoria _auditoria;
        protected InformeDiscrepancia _informe;
		
        public virtual InformeCorrector Entity { get { return null; } set { } }
        public virtual InformeCorrectorInfo EntityInfo { get { return null; } }

		
        #endregion

        #region Factory Methods

        public InformeCorrectorForm() : this(-1) {}

        public InformeCorrectorForm(long oid) : this(oid, false, null) {}

		public InformeCorrectorForm(bool isModal) : this(-1, isModal, null) {}

        public InformeCorrectorForm(long oid, bool isModal, Form parent)
            : base(oid, isModal, parent)
        {
            InitializeComponent();
        }
		
        #endregion

        #region Style & Source

        /// <summary>Da formato a los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            Docs_BT.Visible = true;
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos principal
		/// y las listas hijas a los origenes de datos correspondientes
        /// </summary>
        protected override void RefreshMainData()
        {
			
        }

        /// <summary>
        /// Asigna los datos a los origenes de datos secundarios
        /// </summary>
        public override void RefreshSecondaryData()
		{
			
        }
		
		#endregion

        #region Validation & Format

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //    InformeCorrectorReportMng reportMng = new InformeCorrectorReportMng(AppContext.ActiveSchema);
        //    ReportViewer.SetReport(reportMng.GetReport(EntityInfo);
        //    ReportViewer.ShowDialog();
        //}

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Docs_BT_Click
        /// </summary>
        protected override void DocumentsAction()
        {
            try
            {
                AgenteEditForm form = new AgenteEditForm(typeof(InformeCorrector), EntityInfo as IAgenteHipatia);
                form.ShowDialog();
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(typeof(InformeCorrector), EntityInfo as IAgenteHipatia);
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Events

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            //SetDependentControlSource(ID_GB.Name);
        }

		
		private void AccionesCorrectoras_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e) {}

        private void AccionesCorrectoras_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(AccionesCorrectoras_Grid.Name);
        }
		
        #endregion
    }
}
