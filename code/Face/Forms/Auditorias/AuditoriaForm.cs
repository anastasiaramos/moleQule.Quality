using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;
using moleQule.Library.Hipatia;

using moleQule.Face;
using moleQule.Face.Skin01;
using moleQule.Face.Hipatia;
using moleQule.Face.Quality.Tools;

namespace moleQule.Face.Quality
{
    public partial class AuditoriaForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 6; } }

        public virtual Auditoria Entity { get { return null; } set { } }
        public virtual AuditoriaInfo EntityInfo { get { return null; } }

        protected TipoAuditoriaList _tipos_auditorias = null;
        protected PlanAnualList _planes = null;
        protected TipoAuditoriaInfo _tipo_auditoria = null;


        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveOIDAmpliacion
        {
            get
            {
                return Ampliaciones_Grid.CurrentRow != null ? ((InformeAmpliacion)Datos_Ampliaciones.Current).Oid : 0;
            }
        }

        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveOIDCorrector
        {
            get
            {
                return AccionesCorrectoras_Grid.CurrentRow != null ? ((InformeCorrector)Datos_AccionesCorrectoras.Current).Oid : 0;
            }
        }
        
        #endregion

        #region Factory Methods

        public AuditoriaForm() : this(-1, true) { }

        public AuditoriaForm(bool isModal) : this(-1, isModal) { }

        public AuditoriaForm(long oid) : this(oid, true) { }

        public AuditoriaForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Función que comprueba que se pueda modificar la propiedad especificada en función
        /// del estado actual de la auditoría
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private bool IsPropertyEnabled(string property)
        {
            if (!AuditoriaController.IsPropertyEnabled(Entity.Estado, property))
            {
                MessageBox.Show(string.Format(Resources.Messages.NOT_ENABLED_PROPERTY, property,
                    ((EstadoAuditoria)Entity.Estado).ToString()),
                    moleQule.Face.Resources.Labels.ADVISE_TITLE);
                return false;
            }
            return true;
        }

        #endregion

        #region Style & Source

        public override void FormatControls()
        {
            Docs_BT.Visible = true;

            Informes_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AccionesCorrectoras_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Ampliaciones_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Cuestiones_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            base.FormatControls();
        }

        public override void RefreshSecondaryData()
        {
            if (EntityInfo != null)
            {
                _planes = PlanAnualList.GetList();
                Library.Quality.HComboBoxSourceList _combo_planes = new Library.Quality.HComboBoxSourceList(_planes);
                Datos_Planes.DataSource = _combo_planes;
                Bar.Grow();

                Library.Instruction.InstructorList empleados = Library.Instruction.InstructorList.GetList(false);

                Library.Instruction.InstructorList responsables = empleados.GetResponsablesList();
                Library.Instruction.HComboBoxSourceList _combo_responsables = new Library.Instruction.HComboBoxSourceList(responsables);
                Datos_Responsables.DataSource = _combo_responsables;
                Bar.Grow();

                Library.Instruction.InstructorList auditores = empleados.GetAuditoresList();
                Library.Instruction.HComboBoxSourceList _combo_auditores = new Library.Instruction.HComboBoxSourceList(auditores);
                Datos_Auditores.DataSource = _combo_auditores;
                Bar.Grow();

                UserList usuarios = UserList.GetList();
                Library.Application.HComboBoxSourceList _combo_usuarios = new Library.Application.HComboBoxSourceList(usuarios);
                Datos_Usuarios_Auditores.DataSource = _combo_usuarios;
                Datos_Usuarios_Responsables.DataSource = _combo_usuarios;
                Bar.Grow();

                DepartamentoList departamentos = DepartamentoList.GetList();
                Library.Quality.HComboBoxSourceList _combo_departamentos = new Library.Quality.HComboBoxSourceList(departamentos);
                Datos_Departamentos_Auditores.DataSource = _combo_departamentos;
                Datos_Departamentos_Responsables.DataSource = _combo_departamentos;
                Bar.Grow();
                
                _tipos_auditorias = TipoAuditoriaList.GetList();
                Bar.Grow();
            }
        }

        protected virtual void RefreshInformes() { }
        
        protected virtual void PrintComunicado() { }

        protected virtual void PrintInforme() { }

        protected virtual void NotificarFinAuditoria() { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected virtual void NuevaDiscrepanciaAction() { }
        protected virtual void EditarDiscrepanciaAction() { }
        protected virtual void BorrarDiscrepanciaAction() { }
        protected virtual void NotificarDiscrepanciaAction() { }
        protected virtual void VerDiscrepanciaAction() { }
        protected virtual void PrintDiscrepancias() { }

        protected virtual void NuevaAmpliacionAction() { }
        protected virtual void EditarAmpliacionAction() { }
        protected virtual void BorrarAmpliacionAction() { }
        protected virtual void NotificarAmpliacionAction() { }
        protected virtual void VerAmpliacionAction() { }
        protected virtual void ConcederAmpliacionAction (){}
        protected virtual void DenegarAmpliacionAction() { }
        protected virtual void PrintAmpliacionAction() { }

        protected virtual void NuevaCorreccionAction() { }
        protected virtual void EditarCorreccionAction() { }
        protected virtual void BorrarCorreccionAction() { }
        protected virtual void NotificarCorreccionAction() { }
        protected virtual void VerCorreccionAction() { }
        protected virtual void PrintCorreccionAction() { }


        /// <summary>
        /// Implementa Docs_BT_Click
        /// </summary>
        protected override void DocumentsAction()
        {
            try
            {
                AgenteEditForm form = new AgenteEditForm(typeof(Auditoria), EntityInfo as IAgenteHipatia);
                form.ShowDialog();
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(typeof(Auditoria), EntityInfo as IAgenteHipatia);
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Buttons


        private void ImprimirDiscrepancia_TI_Click(object sender, EventArgs e)
        {
            PrintDiscrepancias();
        }

        private void PrintCorrector_TI_Click(object sender, EventArgs e)
        {
            PrintCorreccionAction();
        }

        private void PrintAmpliacion_TI_Click(object sender, EventArgs e)
        {
            PrintAmpliacionAction();
        }

        private void Comunicado_Print_BT_Click(object sender, EventArgs e)
        {
            PrintComunicado();
        }
        
        private void Informe_Print_BT_Click(object sender, EventArgs e)
        {
            PrintInforme();
        }

        private void FinAuditoria_BT_Click(object sender, EventArgs e)
        {
            NotificarFinAuditoria();
        }

        private void AddDiscrepancia_TI_Click(object sender, EventArgs e)
        {
            NuevaDiscrepanciaAction();
        }

        private void EditDiscrepancia_TI_Click(object sender, EventArgs e)
        {
            EditarDiscrepanciaAction();
        }

        private void ViewDiscrepancia_TI_Click(object sender, EventArgs e)
        {
            VerDiscrepanciaAction();
        }

        private void DeleteDiscrepancia_TI_Click(object sender, EventArgs e)
        {
            BorrarDiscrepanciaAction();
        }

        private void NotificarDiscrepancia_TI_Click(object sender, EventArgs e)
        {
            NotificarDiscrepanciaAction();
        }

        private void AddAmpliacion_TI_Click(object sender, EventArgs e)
        {
            NuevaAmpliacionAction();
        }

        private void EditAmpliacion_TI_Click(object sender, EventArgs e)
        {
            EditarAmpliacionAction();
        }

        private void ViewAmpliacion_TI_Click(object sender, EventArgs e)
        {
            VerAmpliacionAction();
        }

        private void DeleteAmpliacion_TI_Click(object sender, EventArgs e)
        {
            BorrarAmpliacionAction();
        }

        private void NotifyAmpliacion_TI_Click(object sender, EventArgs e)
        {
            NotificarAmpliacionAction();
        }

        private void AddCorreccion_TI_Click(object sender, EventArgs e)
        {
            NuevaCorreccionAction();
        }

        private void EditCorreccion_TI_Click(object sender, EventArgs e)
        {
            EditarCorreccionAction();
        }

        private void ViewCorrecccion_TI_Click(object sender, EventArgs e)
        {
            VerCorreccionAction();
        }

        private void DeleteCorreccion_TI_Click(object sender, EventArgs e)
        {
            BorrarCorreccionAction();
        }

        private void NotityCorreccion_TI_Click(object sender, EventArgs e)
        {
            NotificarCorreccionAction();
        }


        private void ConcederAmpliacion_TI_Click(object sender, EventArgs e)
        {
            ConcederAmpliacionAction();
        }

        private void DenegarAmpliacion_TI_Click(object sender, EventArgs e)
        {
            DenegarAmpliacionAction();
        }

        #endregion

        #region Events

        private void AuditoriaForm_Shown(object sender, EventArgs e)
        {
            SetUnlinkedGridValues(Cuestiones_Grid.Name);
        }

        private void Informes_Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            RefreshSecondaryData();
        }

        private void Referencia_TB_TextChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm) return;

            if (Entity.Referencia != Referencia_TB.Text && !IsPropertyEnabled("Referencia"))
                Referencia_TB.Text = Entity.Referencia;
        }

        private void FechaInicio_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm) return;

            if (Entity.FechaInicio != FechaInicio_DTP.Value && !IsPropertyEnabled("Fecha Inicio"))
                FechaInicio_DTP.Value = Entity.FechaInicio;
        }

        private void FechaFin_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm) return;

            if (Entity.FechaFin != FechaFin_DTP.Value && !IsPropertyEnabled("Fecha Fin"))
                FechaFin_DTP.Value = Entity.FechaFin;
        }

        private void Auditor_CB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm || Auditor_CB.SelectedValue == null) return;

            if (Entity.OidAuditor != (long)Auditor_CB.SelectedValue && !IsPropertyEnabled("Auditor"))
                Auditor_CB.SelectedValue = Entity.OidAuditor;
        }

        private void Responsable_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm || Responsable_CB.SelectedValue == null) return;

            if (Entity.OidResponsable != (long)Responsable_CB.SelectedValue && !IsPropertyEnabled("Responsable"))
                Responsable_CB.SelectedValue = Entity.OidResponsable;
        }

        private void Usuario_Auditor_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm || Usuario_Auditor_CB.SelectedValue == null) return;

            if (Entity.OidUsuarioAuditor != (long)Usuario_Auditor_CB.SelectedValue 
                && !IsPropertyEnabled("OidUsuarioAuditor"))
                Usuario_Auditor_CB.SelectedValue = Entity.OidUsuarioAuditor;

        }

        private void Usuario_Responsable_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm || Usuario_Responsable_CB.SelectedValue == null) return;

            if (Entity.OidUsuarioResponsable != (long)Usuario_Responsable_CB.SelectedValue 
                && !IsPropertyEnabled("OidUsuarioResponsable"))
                Usuario_Responsable_CB.SelectedValue = Entity.OidUsuarioResponsable;

        }

        private void PlanAnual_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm || PlanAnual_CB.SelectedValue == null) return;

            if (Entity.OidPlan != (long)PlanAnual_CB.SelectedValue && !IsPropertyEnabled("Plan Anual"))
                PlanAnual_CB.SelectedValue = Entity.OidPlan;
        }

        private void Obsersvaciones_TB_TextChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaViewForm) return;

            if (Entity.Observaciones != Observaciones_TB.Text && !IsPropertyEnabled("Observaciones"))
                Observaciones_TB.Text = Entity.Observaciones;
        }

        private void Cuestiones_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Cuestiones_Grid.Name);
        }

        private void Cuestiones_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AuditoriaFormController.IsActionEnabled(Entity, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
        }

        private void Cuestiones_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this is AuditoriaViewForm) return;

            if (!AuditoriaFormController.IsActionEnabled(Entity, AccionAuditoria.GENERAR_INFORME_AUDITORIA))
                e.Cancel = true;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "Historia_TP")
                SetUnlinkedGridValues(Historia_Grid.Name);
        }


        private void Datos_Informes_CurrentChanged(object sender, EventArgs e)
        {
            RefreshInformes();
        }

        #endregion     






    }
}


