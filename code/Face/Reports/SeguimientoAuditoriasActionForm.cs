using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Application.Tools;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class SeguimientoAuditoriasActionForm : Skin01.ActionSkinForm
    {

        #region Properties

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public const string ID = "SeguimientoAuditoriasActionForm";
        public static Type Type { get { return typeof(SeguimientoAuditoriasActionForm); } }

        EstadoAuditoria _estado;
        AuditoriaInfo _auditoria = null;
        PlanAnualInfo _plan;
        
        #endregion

        #region Business Methods

        private string GetFilterValues()
        {
            string filtro = string.Empty;

            if (!TodosPlanes_CkB.Checked)
                filtro += "Plan Anual " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.Equal) + " " + _plan.Nombre + "; ";

            if (!TodosEstados_CkB.Checked)
                filtro +=  moleQule.Library.Quality.EnumText<EstadoAuditoria>.GetLabel((EstadoAuditoria)_estado) + "; ";            

            if (!TodosAuditorias_CkB.Checked)
                filtro += "Auditoría " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.Equal) + " " + _auditoria.Referencia + "; ";

            if (FInicial_DTP.Checked)
                filtro += "Fecha " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.GreaterOrEqual) + " " + FInicial_DTP.Value.ToShortDateString() + "; ";

            if (FFinal_DTP.Checked)
                filtro += "Fecha " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.LessOrEqual) + " " + FFinal_DTP.Value.ToShortDateString() + "; ";

            if (FComunicacion_DTP.Checked)
                filtro += "Fecha Comunicación " + moleQule.Library.CslaEx.EnumText.GetOperator(moleQule.Library.CslaEx.Operation.GreaterOrEqual) + " " + FFinal_DTP.Value.ToShortDateString() + "; ";

            return filtro;
        }
        
        #endregion

        #region Factory Methods

        public SeguimientoAuditoriasActionForm()
            : this(true) { }

        public SeguimientoAuditoriasActionForm(bool isModal)
            : this(isModal, null) { }

        public SeguimientoAuditoriasActionForm(Form parent)
            : this(true, parent) { }

        public SeguimientoAuditoriasActionForm(bool IsModal, Form parent)
            : base(IsModal, parent)
        {
            InitializeComponent();
            SetFormData();
        }

        #endregion

        #region Style & Source

        public override void RefreshSecondaryData()
        {
            Datos_Estados.DataSource = Enum.GetNames(typeof(EstadoAuditoria));
            Estado_CB.SelectedItem = string.Empty;
            PgMng.Grow();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void BkSubmitAction()
        {
            PgMng.Reset(4, 1, Face.Resources.Messages.RETRIEVING_DATA); 

            long oid_auditoria = TodosAuditorias_CkB.Checked ? -1 : _auditoria.Oid;
            long oid_plan = TodosPlanes_CkB.Checked ? -1 : _plan.Oid;
            _estado = !TodosEstados_CkB.Checked ? EstadoAuditoria.CREADA : (EstadoAuditoria)Enum.Parse(typeof(EstadoAuditoria), Estado_CB.Text);
            long estado = TodosEstados_CkB.Checked ? -1 : (long)_estado;
            DateTime f_ini = FInicial_DTP.Checked ? FInicial_DTP.Value : DateTime.MinValue;
            DateTime f_fin = FFinal_DTP.Checked ? FFinal_DTP.Value : DateTime.MaxValue;
            DateTime f_comunicacion = FComunicacion_DTP.Checked ? FComunicacion_DTP.Value : DateTime.MinValue;

            string filtro = GetFilterValues();
            PgMng.Grow();

            moleQule.Library.Application.Tools.WordExporter word = new moleQule.Library.Application.Tools.WordExporter();

            AuditoriaList lista = AuditoriaList.GetAbiertasList(oid_auditoria, oid_plan, estado, f_ini, f_fin, f_comunicacion, FInicial_DTP.Checked, FFinal_DTP.Checked, FComunicacion_DTP.Checked);

            word.ExportSeguimientoAuditorias(lista);
            PgMng.FillUp();

            _action_result = DialogResult.Ignore;
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

        private void SanidadAnimalActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
            }

            Cerrar();
        }

        private void Cliente_BT_Click(object sender, EventArgs e)
        {
            AuditoriaSelectForm form = new AuditoriaSelectForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _auditoria = form.Selected as AuditoriaInfo;
                Auditoria_TB.Text = _auditoria.Referencia;
            }
        }

        private void Producto_BT_Click(object sender, EventArgs e)
        {
            PlanAnualSelectForm form = new PlanAnualSelectForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _plan = form.Selected as PlanAnualInfo;
                Plan_TB.Text = _plan.Nombre;
            }
        }

        private void TodosCliente_CkB_CheckedChanged(object sender, EventArgs e)
        {
            Auditoria_BT.Enabled = !TodosAuditorias_CkB.Checked;
        }

        private void TodosProducto_CkB_CheckedChanged(object sender, EventArgs e)
        {
            Plan_BT.Enabled = !TodosPlanes_CkB.Checked;
        }

        private void TodosExpediente_CkB_CheckedChanged(object sender, EventArgs e)
        {
            Estado_CB.Enabled = !TodosEstados_CkB.Checked;
        }

        #endregion

    }
}

