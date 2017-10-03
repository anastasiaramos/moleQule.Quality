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
    public partial class InformeDiscrepanciaViewForm : InformeDiscrepanciaForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeDiscrepanciaViewForm";
		public new static Type Type { get { return typeof(InformeDiscrepanciaViewForm); } }

		protected override int BarSteps { get { return base.BarSteps + 3; } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private InformeDiscrepanciaInfo _entity;

        public override InformeDiscrepanciaInfo EntityInfo { get { return _entity; } }

		#endregion
		
        #region Factory Methods

        public InformeDiscrepanciaViewForm(long oid) : this(oid, null) {}

        public InformeDiscrepanciaViewForm(long oid, Form parent)
            : base(oid, true, parent)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INFORME_DISCREPANCIA_TITLE + " " + EntityInfo.Codigo.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        public InformeDiscrepanciaViewForm(InformeDiscrepancia entity, Auditoria auditoria, Form parent)
            : base (entity.Oid, true, parent)
        {
            InitializeComponent();
            _entity = entity.GetInfo(true);
            _auditoria = auditoria;
            if (EntityInfo != null)
            {
                SetFormData();
                this.Text = Resources.Labels.INFORME_DISCREPANCIA_TITLE + " " + EntityInfo.Codigo.ToUpper();
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

			
			Datos_Discrepancias.DataSource = DiscrepanciaList.SortList(_entity.Discrepancias, "Codigo", ListSortDirection.Ascending);
            Bar.Grow();
			
			
            base.RefreshMainData();
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
                            DiscrepanciaInfo info = (DiscrepanciaInfo)row.DataBoundItem;
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
