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
    public partial class ClaseAuditoriaViewForm : ClaseAuditoriaForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private ClaseAuditoriaInfo _entity;

        public override ClaseAuditoriaInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private ClaseAuditoriaViewForm() : this(-1) { }

        public ClaseAuditoriaViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();

            SetFormData();

            this.Text = Resources.Labels.CLASE_AUDITORIA_EDIT_TITLE + " " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ClaseAuditoriaInfo.Get(oid, true);
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
            
            Add_TI.Enabled = false;
            Edit_TI.Enabled = false;
            Delete_TI.Enabled = false;
            View_TI.Enabled = true;

            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;

            Datos_Auditorias.DataSource = _entity.TipoAuditorias;
            Bar.Grow(string.Empty, "ClaseAuditorias");
        }

        protected override void VerAction()
        {
            if (Datos_Auditorias.Current == null) return;

            TipoAuditoriaViewForm form = new TipoAuditoriaViewForm(Datos_Auditorias.Current as TipoAuditoriaInfo);
            form.ShowDialog();
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
