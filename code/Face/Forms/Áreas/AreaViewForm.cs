using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class AreaViewForm : AreaForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private AreaInfo _entity;

        public override AreaInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private AreaViewForm() : this(-1) { }

        public AreaViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();

            SetFormData();

            this.Text = Resources.Labels.AREA_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = AreaInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
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
            Bar.FillUp();
        }

        #endregion

        #region Validation & Format

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
