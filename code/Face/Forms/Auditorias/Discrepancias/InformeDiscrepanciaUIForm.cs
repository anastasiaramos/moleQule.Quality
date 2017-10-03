using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeDiscrepanciaUIForm : InformeDiscrepanciaForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeDiscrepanciaUIForm";
		public new static Type Type { get { return typeof(InformeDiscrepanciaUIForm); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected InformeDiscrepancia _entity;

        public override InformeDiscrepancia Entity { get { return _entity; } set { _entity = value; } }
        public override InformeDiscrepanciaInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected InformeDiscrepanciaUIForm() : this(-1, true) { }

        public InformeDiscrepanciaUIForm(bool isModal) : this(-1, isModal) { }

        public InformeDiscrepanciaUIForm(long oid) : this(oid, true) { }

        public InformeDiscrepanciaUIForm(long oid, bool ismodal)
            : base(oid, ismodal, null) { }
       
                
        public InformeDiscrepanciaUIForm(long oid, bool ismodal, Form parent, Auditoria auditoria)
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
			
			Datos_Discrepancias.DataSource = Discrepancias.SortList(_entity.Discrepancias, "Codigo", ListSortDirection.Ascending);
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
				case "Discrepancias_Grid":
                    {
                        foreach (DataGridViewRow row in Discrepancias_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Discrepancia info = (Discrepancia)row.DataBoundItem;
                            if (info != null)
                            {
                                CuestionAuditoria cuestion = _auditoria.Cuestiones.GetItem(info.OidCuestion);
                                if (cuestion != null)
                                    row.Cells["Cuestion"].Value = cuestion.Numero;
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
		
		private void InformeDiscrepanciaUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_action_result != DialogResult.OK)
                if (DialogResult.No == MessageBox.Show(moleQule.Face.Resources.Messages.CANCEL_CONFIRM,
                                                        moleQule.Face.Resources.Labels.CONFIRM_TITLE,
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                    return;
                }

            //if (this is InformeDiscrepanciaAddForm)
                //_auditoria.Informes.Remove(Entity);
            Cerrar();
        }
		
        #endregion
    }
}
