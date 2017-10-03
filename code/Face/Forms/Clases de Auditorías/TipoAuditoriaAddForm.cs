using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Application;
using moleQule.Library.Quality;
using moleQule.Face.Skin01;

namespace moleQule.Face.Quality
{
    public partial class TipoAuditoriaAddForm : TipoAuditoriaActionForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public new const string ID = "TipoAuditoriaAddForm";
        public new static Type Type { get { return typeof(TipoAuditoriaAddForm); } }

        protected ClaseAuditoria _clase;
        protected TipoAuditoria _entity;

        #endregion

        #region Factory Methods

        public TipoAuditoriaAddForm(ClaseAuditoria item)
            : this(true, item) { }

        public TipoAuditoriaAddForm(bool IsModal, ClaseAuditoria item)
            : base(IsModal)
        {
            InitializeComponent();
            _clase = item;
            _entity = _clase.TipoAuditorias.NewItem(_clase);
            SetFormData();
            this.Text = Resources.Labels.TIPO_AUDITORIA_TITLE;
        }

        #endregion

        #region Style & Source

        protected override void RefreshMainData()
        {
            if (_entity == null) return;

            Datos.DataSource = _entity;
            Datos_Areas.DataSource = _entity.Areas;
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
            _clase.TipoAuditorias.Remove(_entity);
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Events

        #endregion

    }
}

