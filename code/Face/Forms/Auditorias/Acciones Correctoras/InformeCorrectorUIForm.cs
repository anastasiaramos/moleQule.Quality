using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeCorrectorUIForm : InformeCorrectorForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeCorrectorUIForm";
		public new static Type Type { get { return typeof(InformeCorrectorUIForm); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected InformeCorrector _entity;

        public override InformeCorrector Entity { get { return _entity; } set { _entity = value; } }
        public override InformeCorrectorInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected InformeCorrectorUIForm() : this(-1, true) { }

        public InformeCorrectorUIForm(bool isModal) : this(-1, isModal) { }

        public InformeCorrectorUIForm(long oid) : this(oid, true) { }

        public InformeCorrectorUIForm(long oid, bool ismodal)
            : base(oid, ismodal, null)
        {
            InitializeComponent();
        }

        public InformeCorrectorUIForm(long oid, bool ismodal, Form parent, Auditoria auditoria)
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

            _entity.Fecha = DateTime.Today;
			Datos_AccionCorrectoras.DataSource = AccionesCorrectoras.SortList(_entity.Acciones, "Codigo", ListSortDirection.Ascending);
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
                
				case "AccionesCorrectoras_Grid":
                    {
                        foreach (DataGridViewRow row in AccionesCorrectoras_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            AccionCorrectora info = (AccionCorrectora)row.DataBoundItem;
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

        protected override void SaveAction()
        {
            _action_result = DialogResult.OK;
        }

        #endregion

        #region Buttons

        private void Edit_BT_Click(object sender, EventArgs e)
        {
            AccionCorrectoraActionForm form = new AccionCorrectoraActionForm(_entity, _informe, _auditoria);
            form.ShowDialog();

            Datos_AccionCorrectoras.ResetBindings(false);
        }

        #endregion

        #region Events

        private void InformeCorrectorUIForm_FormClosing(object sender, FormClosingEventArgs e)
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
