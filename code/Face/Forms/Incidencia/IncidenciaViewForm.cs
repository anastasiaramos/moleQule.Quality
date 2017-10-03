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
    public partial class IncidenciaViewForm : IncidenciaForm
    {

        #region Attributes & Properties
		
        public new const string ID = "IncidenciaViewForm";
		public new static Type Type { get { return typeof(IncidenciaViewForm); } }

		protected override int BarSteps { get { return base.BarSteps + 2; } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private IncidenciaInfo _entity;

        public override IncidenciaInfo EntityInfo { get { return _entity; } }

		#endregion
		
        #region Factory Methods

        public IncidenciaViewForm(long oid) : this(oid, null) {}

        public IncidenciaViewForm(long oid, Form parent)
            : base(oid, true, parent)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INCIDENCIA_DETAIL_TITLE + " " + EntityInfo.Texto.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = IncidenciaInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
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
			
            base.RefreshMainData();
            Bar.FillUp();
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
