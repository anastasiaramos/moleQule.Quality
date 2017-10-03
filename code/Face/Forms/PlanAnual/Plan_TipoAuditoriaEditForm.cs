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
    public partial class Plan_TipoAuditoriaEditForm : Plan_TipoAuditoriaActionForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public new const string ID = "TipoAuditoriaEditForm";
        public new static Type Type { get { return typeof(TipoAuditoriaEditForm); } }

        protected ClaseAuditoriaInfo _clase;
        protected TipoAuditoriaInfo _tipo;
        protected Plan_Tipo _entity;

        public Plan_Tipo Entity { get { return _entity; } set { _entity = value; } }

        #endregion

        #region Factory Methods

        public Plan_TipoAuditoriaEditForm(ClaseAuditoriaInfo item, TipoAuditoriaInfo tipo, Plan_Tipo entity)
            : this(true, item, tipo, entity) { }

        public Plan_TipoAuditoriaEditForm(bool IsModal, ClaseAuditoriaInfo item, TipoAuditoriaInfo tipo, Plan_Tipo entity)
            : base(IsModal)
        {
            InitializeComponent();
            _clase = item;
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
            _entity.Enero = eneroCheckBox.Checked;
            _entity.Febrero = febreroCheckBox.Checked;
            _entity.Marzo = marzoCheckBox.Checked;
            _entity.Abril = abrilCheckBox.Checked;
            _entity.Mayo = mayoCheckBox.Checked;
            _entity.Junio = junioCheckBox.Checked;
            _entity.Julio = julioCheckBox.Checked;
            _entity.Agosto = agostoCheckBox.Checked;
            _entity.Septiembre = septiembreCheckBox.Checked;
            _entity.Octubre = octubreCheckBox.Checked;
            _entity.Noviembre = noviembreCheckBox.Checked;
            _entity.Diciembre = diciembreCheckBox.Checked;

            _action_result = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            _entity.CancelEdit();
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Events

        #endregion

    }
}

