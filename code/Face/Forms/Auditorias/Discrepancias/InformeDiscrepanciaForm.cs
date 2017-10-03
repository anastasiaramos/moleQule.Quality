using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Hipatia;

using moleQule.Face;
using moleQule.Face.Skin01;
using moleQule.Face.Hipatia;


namespace moleQule.Face.Quality
{
    public partial class InformeDiscrepanciaForm : ItemMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "InformeDiscrepanciaForm";
		public static Type Type { get { return typeof(InformeDiscrepanciaForm); } }

        protected Auditoria _auditoria;

        protected override int BarSteps { get { return base.BarSteps + 0; } }
		
        public virtual InformeDiscrepancia Entity { get { return null; } set { } }
        public virtual InformeDiscrepanciaInfo EntityInfo { get { return null; } }

		
        #endregion

        #region Factory Methods

        public InformeDiscrepanciaForm() : this(-1) {}

        public InformeDiscrepanciaForm(long oid) : this(oid, false, null) {}

		public InformeDiscrepanciaForm(bool isModal) : this(-1, isModal, null) {}

        public InformeDiscrepanciaForm(long oid, bool isModal, Form parent)
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

        #region Actions
        
        /// <summary>
        /// Implementa Docs_BT_Click
        /// </summary>
        protected override void DocumentsAction()
        {
            try
            {
                AgenteEditForm form = new AgenteEditForm(typeof(InformeDiscrepancia), EntityInfo as IAgenteHipatia);
                form.ShowDialog();
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(typeof(InformeDiscrepancia), EntityInfo as IAgenteHipatia);
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //    InformeDiscrepanciaReportMng reportMng = new InformeDiscrepanciaReportMng(AppContext.ActiveSchema);
        //    ReportViewer.SetReport(reportMng.GetReport(EntityInfo);
        //    ReportViewer.ShowDialog();
        //}

        #endregion

        #region Buttons

        private void Edit_BT_Click(object sender, EventArgs e)
        {
            DateTime fecha_comunicacion = DateTime.Today;

            for(int i = _auditoria.Historial.Count-1; i>= 0; i--)
            {
                HistoriaAuditoria item = _auditoria.Historial[i];
                if (item.EstadoAuditoria == EstadoAuditoria.DISCREPANCIAS_NOTIFICADAS)
                {
                    fecha_comunicacion = item.Fecha;
                    break;
                }
            }

            DiscrepanciaActionForm form = new DiscrepanciaActionForm(true, Entity, _auditoria, fecha_comunicacion);
            form.ShowDialog();

            Datos_Discrepancias.ResetBindings(false);
        }

        #endregion

        #region Events

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            //SetDependentControlSource(ID_GB.Name);
        }

		
		private void Discrepancias_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e) {}

        private void Discrepancias_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Discrepancias_Grid.Name);
        }
		
        #endregion

    }
}
