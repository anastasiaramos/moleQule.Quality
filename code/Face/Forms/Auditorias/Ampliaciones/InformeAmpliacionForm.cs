using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Hipatia;

using moleQule.Face.Hipatia;
using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class InformeAmpliacionForm : Skin01.ItemMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "InformeAmpliacionForm";
		public static Type Type { get { return typeof(InformeAmpliacionForm); } }

        protected override int BarSteps { get { return base.BarSteps + 0; } }
        protected Auditoria _auditoria;
        protected InformeDiscrepancia _informe;
		
        public virtual InformeAmpliacion Entity { get { return null; } set { } }
        public virtual InformeAmpliacionInfo EntityInfo { get { return null; } }

		
        #endregion

        #region Factory Methods

        public InformeAmpliacionForm() : this(-1) {}

        public InformeAmpliacionForm(long oid) : this(oid, false, null) {}

		public InformeAmpliacionForm(bool isModal) : this(-1, isModal, null) {}

        public InformeAmpliacionForm(long oid, bool isModal, Form parent)
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
        //    InformeAmpliacionReportMng reportMng = new InformeAmpliacionReportMng(AppContext.ActiveSchema);
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
                AgenteEditForm form = new AgenteEditForm(typeof(InformeAmpliacion), EntityInfo as IAgenteHipatia);
                form.ShowDialog();
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(typeof(InformeAmpliacion), EntityInfo as IAgenteHipatia);
                    form.ShowDialog();
                }
            }
        }
        
        #endregion

        #region Buttons

        private void Edit_BT_Click(object sender, EventArgs e)
        {
            AmpliacionActionForm form = new AmpliacionActionForm(Entity, _informe, _auditoria);
            form.ShowDialog();

            Datos_Ampliaciones.ResetBindings(false);
        }

        #endregion

        #region Events

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            //SetDependentControlSource(ID_GB.Name);
        }

		
		private void Ampliaciones_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e) {}

        private void Ampliaciones_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Ampliaciones_Grid.Name);
        }
		
        #endregion

    }
}
