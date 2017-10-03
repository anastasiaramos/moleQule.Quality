using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Face.Skin01;

using moleQule.Library.Application;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class Plan_TipoAuditoriaViewForm : Plan_TipoAuditoriaActionForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps; } }

        public new const string ID = "Plan_TipoAuditoriaViewForm";
        public new static Type Type { get { return typeof(Plan_TipoAuditoriaViewForm); } }

        protected TipoAuditoriaInfo _tipo;
        protected Plan_TipoInfo _entity;
        public Plan_TipoInfo Entity { get { return _entity; } }

        #endregion

        #region Factory Methods

        public Plan_TipoAuditoriaViewForm(TipoAuditoriaInfo tipo, Plan_TipoInfo entity)
            : this(true, tipo, entity) { }

        public Plan_TipoAuditoriaViewForm(bool IsModal, TipoAuditoriaInfo tipo, Plan_TipoInfo entity)
            : base(IsModal)
        {
            InitializeComponent();
            _tipo = tipo;
            _entity = entity;
            SetFormData();
            this.Text = Resources.Labels.TIPO_AUDITORIA_TITLE;
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_entity == null) return;

            Datos.DataSource = _tipo;
            Datos_Areas.DataSource = _tipo.Areas;

            eneroCheckBox.Checked = _entity.Enero;
            febreroCheckBox.Checked = _entity.Febrero;
            marzoCheckBox.Checked = _entity.Marzo;
            abrilCheckBox.Checked = _entity.Abril;
            mayoCheckBox.Checked = _entity.Mayo;
            junioCheckBox.Checked = _entity.Junio;
            julioCheckBox.Checked = _entity.Julio;
            agostoCheckBox.Checked = _entity.Agosto;
            septiembreCheckBox.Checked = _entity.Septiembre;
            octubreCheckBox.Checked = _entity.Octubre;
            noviembreCheckBox.Checked = _entity.Noviembre;
            diciembreCheckBox.Checked = _entity.Diciembre;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            _action_result = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Events

        #endregion

    }
}

