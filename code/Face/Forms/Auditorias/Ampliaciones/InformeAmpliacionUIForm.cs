using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeAmpliacionUIForm : InformeAmpliacionForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeAmpliacionUIForm";
		public new static Type Type { get { return typeof(InformeAmpliacionUIForm); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected InformeAmpliacion _entity;

        public override InformeAmpliacion Entity { get { return _entity; } set { _entity = value; } }
        public override InformeAmpliacionInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected InformeAmpliacionUIForm() : this(-1, true) { }

        public InformeAmpliacionUIForm(bool isModal) : this(-1, isModal) { }

        public InformeAmpliacionUIForm(long oid) : this(oid, true) { }

        public InformeAmpliacionUIForm(long oid, bool ismodal)
            : base(oid, ismodal, null)
        {
            InitializeComponent();
        }

        public InformeAmpliacionUIForm(long oid, bool ismodal, Form parent, Auditoria auditoria)
            : base(oid, ismodal, parent)
        {
            InitializeComponent();
            _auditoria = auditoria;
        }

        #endregion

        #region Style & Source

        /// <summary>Da formato a los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
            ShowStatusBar(moleQule.Face.Resources.Messages.STATUS_GENERICO);
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos principal
		/// y las listas hijas a los origenes de datos correspondientes
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Bar.Grow();
			
			Datos_Ampliaciones.DataSource = Ampliaciones.SortList(_entity.Ampliaciones, "Codigo", ListSortDirection.Ascending);
            Bar.Grow();
						
            base.RefreshMainData();
        }
		
		/// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            /*switch (controlName)
            {
                case "ID_GB":
                    {
                        NIF_RB.Checked = (EntityInfo.TipoId == (long)TipoId.NIF);
                        NIE_RB.Checked = (EntityInfo.TipoId == (long)TipoId.NIE);
                        DNI_RB.Checked = (EntityInfo.TipoId == (long)TipoId.DNI);

                    } break;
            }*/
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
                            Ampliacion info = (Ampliacion)row.DataBoundItem;
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
        /// Valida datos de entrada
        /// </summary>
        protected override void ValidateInput()
        {	
        }
		
        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _action_result = DialogResult.OK;
        }

        #endregion

        #region Events
		
		private void InformeAmpliacionUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                if (DialogResult.No == MessageBox.Show(moleQule.Face.Resources.Messages.CANCEL_CONFIRM,
                                                        moleQule.Face.Resources.Labels.CONFIRM_TITLE,
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                    return;
                }

            Cerrar();
        }
		
        #endregion
    }
}
