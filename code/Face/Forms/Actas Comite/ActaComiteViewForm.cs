using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Application;
using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;

namespace moleQule.Face.Quality
{
    public partial class ActaComiteViewForm : ActaComiteForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private ActaComiteInfo _entity;

        public override ActaComiteInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private ActaComiteViewForm() : this(-1) { }

        public ActaComiteViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.ACTA_COMITE_EDIT_TITLE + " " + EntityInfo.Titulo.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ActaComiteInfo.Get(oid, true);
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
            Imprimir_Button.Enabled = true;
            Imprimir_Button.Visible = true;
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            //_timer.Record("RefreshMainData begin");

            Datos.DataSource = _entity;
            Bar.Grow();

            base.RefreshMainData();
            Bar.FillUp();
            //_timer.Record("RefreshMainData end");
        }

        public override void RefreshSecondaryData()
        {
            Datos_Puntos.DataSource = _entity.PuntosActas;
            Bar.Grow();
        }

        #endregion

        #region Validation & Format

        #endregion


        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion
    }

}
