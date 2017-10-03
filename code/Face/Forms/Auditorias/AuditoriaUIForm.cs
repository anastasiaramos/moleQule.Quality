using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;
using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;
using moleQule.Face.Quality.Tools;
using moleQule.Library.Application.Tools;
using moleQule.Library.Instruction;

namespace moleQule.Face.Quality
{
    public partial class AuditoriaUIForm : AuditoriaForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 5; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Auditoria _entity;

        public override Auditoria Entity { get { return _entity; } set { _entity = value; } }
        public override AuditoriaInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveOID
        {
            get
            {
                return Informes_Grid.CurrentRow != null ? ((InformeDiscrepancia)Datos_Informes.Current).Oid : 0;
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected AuditoriaUIForm() : this(-1, true) { }

        public AuditoriaUIForm(bool isModal) : this(-1, isModal) { }

        public AuditoriaUIForm(long oid) : this(oid, true) { }

        public AuditoriaUIForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                Auditoria temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }

        }
        
        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        public override void RefreshSecondaryData()
        {
            base.RefreshSecondaryData();
            Bar.Grow();

            if (Entity != null)
            {
                Datos_Cuestiones.DataSource = _entity.Cuestiones;
                Bar.Grow(string.Empty, "Auditorias");

                Datos_Informes.DataSource = _entity.Informes;
                Bar.Grow();

                SetUnlinkedGridValues(Cuestiones_Grid.Name);
                Bar.Grow();

                if (Datos_Informes.Current != null && ActiveOID > 0)
                {
                    InformesAmpliaciones lista = _entity.Informes.GetItem(ActiveOID).Ampliaciones;
                    Datos_Ampliaciones.DataSource = lista;

                    InformesCorrectores listac = _entity.Informes.GetItem(ActiveOID).Correctores;
                    Datos_AccionesCorrectoras.DataSource = listac;
                }
                Bar.Grow();

                Datos_Historia.DataSource = _entity.Historial;
                Bar.Grow();
            }
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
        }

        protected override void RefreshInformes()
        {
            if (Datos_Informes.Current != null && ActiveOID > 0)
            {
                InformesAmpliaciones lista = _entity.Informes.GetItem(ActiveOID).Ampliaciones;
                Datos_Ampliaciones.DataSource = lista;

                InformesCorrectores listac = _entity.Informes.GetItem(ActiveOID).Correctores;
                Datos_AccionesCorrectoras.DataSource = listac;
            }
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Cuestiones_Grid":
                    {
                        foreach (DataGridViewRow row in Cuestiones_Grid.Rows)
                        {
                            if (_tipo_auditoria == null)
                                _tipo_auditoria = _tipos_auditorias.GetItem(Entity.OidTipoAuditoria);
                            if (_tipo_auditoria != null)
                            {
                                CuestionAuditoria cuestion = (CuestionAuditoria)row.DataBoundItem;
                                if (cuestion != null)
                                {
                                    CuestionInfo info = _tipo_auditoria.Cuestiones.GetItem(cuestion.OidCuestion);
                                    if (info != null)
                                    {
                                        row.Cells["Cuestion"].Value = info.Texto;
                                        row.Cells["Numero"].Value = info.Numero;
                                    }
                                }
                            }
                        }
                    } break;
                case "Historia_Grid":
                    {
                        InstructorList instructores = InstructorList.GetList(false);
                        foreach (DataGridViewRow row in Historia_Grid.Rows)
                        {
                            HistoriaAuditoria item = (HistoriaAuditoria)row.DataBoundItem;
                            if (item.Empleado == string.Empty)
                            {
                                InstructorInfo instructor = instructores.GetItem(item.OidEmpleado);
                                if (instructor != null)
                                    row.Cells["Empleado"].Value = instructor.Nombre;
                            }
                        }
                    }
                    break;
            }
        }

        protected override void PrintComunicado()
        {
            if ((EstadoAuditoria)_entity.Estado >= EstadoAuditoria.COMUNICADA)
            {
                AuditoriaReportMng reportMng = new AuditoriaReportMng(AppContext.ActiveSchema);

                if (_entity.Notificaciones.Count > 0)
                {
                    NotificacionInternaInfo comunicado = _entity.Notificaciones[0].GetInfo();

                    NotificacionInternaRpt rpt = reportMng.GetDetailNotificacionAuditoriaReport(comunicado, EntityInfo, CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                    ReportViewer.SetReport(rpt);
                    ReportViewer.ShowDialog();
                }

                /*if (_entity.Informes.Count > 0)
                {
                    InformeDiscrepanciaRpt Dreport = reportMng.GetDetailReport(_entity.GetInfo(true).Informes[0].Discrepancias);

                    ReportViewer.SetReport(Dreport);
                    ReportViewer.ShowDialog();

                    InformeAccionesCorrectorasRpt Creport = reportMng.GetDetailReport(_entity.GetInfo(true).Informes[0].Correctores[0]);

                    ReportViewer.SetReport(Creport);
                    ReportViewer.ShowDialog();

                    ControlNoConformidadRpt Nreport = reportMng.GetNoConformidadDetailReport(_entity.GetInfo(true).Informes[0].Discrepancias);

                    ReportViewer.SetReport(Nreport);
                    ReportViewer.ShowDialog();
                }*/
            }
        }


        protected override void PrintInforme()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.GENERAR_INFORME_AUDITORIA)) return;
            AuditoriaController.DoAction(_entity, AccionAuditoria.GENERAR_INFORME_AUDITORIA);

            moleQule.Library.Application.Tools.WordExporter word = new moleQule.Library.Application.Tools.WordExporter();

            ClaseAuditoriaInfo clase = ClaseAuditoriaInfo.Get(_tipo_auditoria.OidClaseAuditoria, true);

            AuditoriaInfo info = _entity.GetInfo(true);   

            word.ExportInformeAuditoria(info.GetPrintObject(clase, _tipo_auditoria, CompanyInfo.GetByCode(AppContext.ActiveSchema.Code)));

            Estado_TB.Text = _entity.EstadoAuditoriaLabel;

        }

        #endregion

        #region Validation & Format

        #endregion

        #region Actions

        protected override void SaveAction()
        {
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void NotificarFinAuditoria()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.NOTIFICAR_FIN_AUDITORIA))
                return;

                ComunicadoAuditoriaActionForm form = new ComunicadoAuditoriaActionForm(Entity, TipoNotificacionAsociado.INFORME_FIN_AUDITORIA);
                form.ShowDialog();
                Datos.ResetBindings(false);

            AuditoriaFormController.DoAction(_entity, AccionAuditoria.NOTIFICAR_FIN_AUDITORIA);
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
        }

        protected override void NuevaDiscrepanciaAction()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS))
                return;
            InformeDiscrepanciaAddForm form = new InformeDiscrepanciaAddForm(_entity, this);
            form.ShowDialog();
            Datos_Informes.ResetBindings(false);
        }

        protected override void PrintDiscrepancias()
        {
            if (Datos_Informes.Current == null) return;

            moleQule.Library.Application.Tools.WordExporter word = new moleQule.Library.Application.Tools.WordExporter();

            ClaseAuditoriaInfo clase = ClaseAuditoriaInfo.Get(_tipo_auditoria.OidClaseAuditoria, true);

            AuditoriaInfo info = _entity.GetInfo(true);

            word.ExportInformeDiscrepancias(info.GetPrintObject(clase, _tipo_auditoria, CompanyInfo.GetByCode(AppContext.ActiveSchema.Code)), Datos_Informes.Current as InformeDiscrepancia);
        }

        protected override void PrintCorreccionAction()
        {
            if (Datos_AccionesCorrectoras.Current == null) return;

            moleQule.Library.Application.Tools.WordExporter word = new moleQule.Library.Application.Tools.WordExporter();

            ClaseAuditoriaInfo clase = ClaseAuditoriaInfo.Get(_tipo_auditoria.OidClaseAuditoria, true);

            AuditoriaInfo info = _entity.GetInfo(true);

            word.ExportInformeCorrector(info.GetPrintObject(clase, _tipo_auditoria, CompanyInfo.GetByCode(AppContext.ActiveSchema.Code)), Datos_AccionesCorrectoras.Current as InformeCorrector);
        }

        protected override void EditarDiscrepanciaAction()
        {
            if (Datos_Informes.Current == null) return;

            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.EDITAR_INFORME_DISCREPANCIAS) || (Datos_Informes.Current as InformeDiscrepancia).Notificado)
                return;
            
            InformeDiscrepanciaEditForm form = new InformeDiscrepanciaEditForm(_entity, Datos_Informes.Current as InformeDiscrepancia, this);
            form.ShowDialog();

            Datos_Informes.ResetBindings(false);
        }

        protected override void VerDiscrepanciaAction()
        {
            if (Datos_Informes.Current == null) return;

            InformeDiscrepanciaViewForm form = new InformeDiscrepanciaViewForm(Datos_Informes.Current as InformeDiscrepancia, _entity, this);
            form.ShowDialog();
        }

        protected override void BorrarDiscrepanciaAction()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.BORRAR_INFORME_DISCREPANCIAS, ActiveOID) || (Datos_Informes.Current as InformeDiscrepancia).Notificado)
                return;

            AuditoriaFormController.DoAction(_entity, AccionAuditoria.BORRAR_INFORME_DISCREPANCIAS, ActiveOID);

            Datos.ResetBindings(false);
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;

        }

        protected override void NotificarDiscrepanciaAction()
        {
            Datos_Informes.MoveLast();
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.NOTIFICAR_DISCREPANCIAS)
                || (Datos_Informes.Current as InformeDiscrepancia).Notificado)
                return;

            /*AuditoriaFormController.DoAction(_entity, AccionAuditoria.NOTIFICAR_DISCREPANCIAS);
            AuditoriaController.CalculaFechasDebidas(_entity);*/


            ComunicadoAuditoriaActionForm form = new ComunicadoAuditoriaActionForm(Entity, TipoNotificacionAsociado.INFORME_DISCREPANCIAS, ActiveOID);
            form.ShowDialog();
            Datos.ResetBindings(false);
            //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
            //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
            //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
            //así que habrá una auditoría duplicada
            //_entity = form.Auditoria;

            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
            //MessageBox.Show(Resources.Messages.INFORME_DISCREPANCIAS_NOTIFICADO);

        }

        protected override void NuevaAmpliacionAction()
        {
            //No se cambia el estado de la auditoría al de "ampliación solicitada" hasta que no se 
            //notifique la solicitud de ampliación
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.GENERAR_INFORME_AMPLIACION))
                return;

            foreach (InformeAmpliacion informe in _entity.Informes[_entity.Informes.Count-1].Ampliaciones)
            {
                if (!informe.Notificado)
                    return;
            }

            InformeAmpliacionAddForm form = new InformeAmpliacionAddForm(_entity, this);
            form.ShowDialog();
            Datos_Ampliaciones.ResetBindings(false);
        }

        protected override void EditarAmpliacionAction()
        {
            if (Datos_AccionesCorrectoras.Current == null) return;

            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.GENERAR_INFORME_AMPLIACION)
                || (Datos_Ampliaciones.Current as InformeAmpliacion).Notificado)
                return;

            InformeAmpliacionEditForm form = new InformeAmpliacionEditForm(_entity, Datos_Ampliaciones.Current as InformeAmpliacion, this);
            form.ShowDialog();

            Datos_Ampliaciones.ResetBindings(false);
        }

        protected override void VerAmpliacionAction()
        {
            if (Datos_AccionesCorrectoras.Current == null) return;

            InformeAmpliacionViewForm form = new InformeAmpliacionViewForm(_entity, Datos_Ampliaciones.Current as InformeAmpliacion, this);
            form.ShowDialog();
        }

        protected override void BorrarAmpliacionAction()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.BORRAR_INFORME_AMPLIACION, ActiveOIDAmpliacion) || (Datos_Ampliaciones.Current as InformeAmpliacion).Notificado)
                return;

            AuditoriaFormController.DoAction(_entity, AccionAuditoria.BORRAR_INFORME_AMPLIACION, ActiveOIDAmpliacion);

            Datos.ResetBindings(false);
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
        }

        protected override void NotificarAmpliacionAction()
        {
            if(!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.GENERAR_INFORME_AMPLIACION)
                || (Datos_Ampliaciones.Current as InformeAmpliacion).Notificado)
            return;
            //AuditoriaFormController.DoAction(_entity, AccionAuditoria.GENERAR_INFORME_AMPLIACION);

        ComunicadoAuditoriaActionForm form = new ComunicadoAuditoriaActionForm(Entity, TipoNotificacionAsociado.SOLICITUD_AMPLIACION, ActiveOIDAmpliacion);
        form.ShowDialog();
        Datos.ResetBindings(false);
        //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
        //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
        //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
        //así que habrá una auditoría duplicada
        //_entity = form.Auditoria;
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
            //MessageBox.Show(Resources.Messages.SOLICITUD_AMPLIACION_NOTIFICADA);
        }

        protected override void ConcederAmpliacionAction()
        {
            if (Datos_Ampliaciones.Current == null) return;

            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.NOTIFICAR_CONCESION_AMPLIACION) || (Datos_Ampliaciones.Current as InformeAmpliacion).Valorado) return;

            ConcesionAmpliacionActionForm form = new ConcesionAmpliacionActionForm(true, Datos_Ampliaciones.Current as InformeAmpliacion, _entity, this);
            form.ShowDialog();

            Datos.ResetBindings(false);
            //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
            //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
            //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
            //así que habrá una auditoría duplicada

            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
            //MessageBox.Show(Resources.Messages.CONCESION_AUDITORIA_NOTIFICADA);
        }

        protected override void DenegarAmpliacionAction()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.NOTIFICAR_DENEGACION_AMPLIACION) || (Datos_Ampliaciones.Current as InformeAmpliacion).Valorado) return;
            //AuditoriaFormController.DoAction(_entity, AccionAuditoria.NOTIFICAR_DENEGACION_AMPLIACION);

            (Datos_Ampliaciones.Current as InformeAmpliacion).Valorado = true;
            ComunicadoAuditoriaActionForm form = new ComunicadoAuditoriaActionForm(Entity, TipoNotificacionAsociado.DENEGACION_AMPLIACION);
            form.ShowDialog();
            Datos.ResetBindings(false);
            //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
            //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
            //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
            //así que habrá una auditoría duplicada
            //_entity = form.Auditoria;
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;

            //MessageBox.Show(Resources.Messages.DENEGACION_AUDITORIA_NOTIFICADA);
        }

        protected override void NuevaCorreccionAction()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS))
                return;
            InformeCorrectorAddForm form = new InformeCorrectorAddForm(_entity, this);
            form.ShowDialog();
            Datos_AccionesCorrectoras.ResetBindings(false);
        }

        protected override void EditarCorreccionAction()
        {
            if (Datos_AccionesCorrectoras.Current == null) return;

            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.EDITAR_INFORME_ACCIONES_CORRECTORAS) || (Datos_AccionesCorrectoras.Current as InformeCorrector).Notificado)
                return;

            InformeCorrectorEditForm form = new InformeCorrectorEditForm(_entity, Datos_AccionesCorrectoras.Current as InformeCorrector, this);
            form.ShowDialog();

            Datos_AccionesCorrectoras.ResetBindings(false);
        }

        protected override void VerCorreccionAction()
        {
            if (Datos_AccionesCorrectoras.Current == null) return;

            InformeCorrectorViewForm form = new InformeCorrectorViewForm(_entity, Datos_AccionesCorrectoras.Current as InformeCorrector, this);
            form.ShowDialog();

            Datos_AccionesCorrectoras.ResetBindings(false);
        }

        protected override void BorrarCorreccionAction()
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.BORRAR_INFORME_ACCIONES_CORRECTORAS, ActiveOIDCorrector) || (Datos_AccionesCorrectoras.Current as InformeCorrector).Notificado)
                return;

            AuditoriaFormController.DoAction(_entity, AccionAuditoria.BORRAR_INFORME_ACCIONES_CORRECTORAS, ActiveOIDCorrector);

            Datos.ResetBindings(false);
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
        }

        protected override void NotificarCorreccionAction()
        {
            Datos_AccionesCorrectoras.MoveLast();
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.NOTIFICAR_INFORME_ACCIONES_CORRECTORAS) || (Datos_AccionesCorrectoras.Current as InformeCorrector).Notificado)
                return;

            /*AuditoriaFormController.DoAction(_entity, AccionAuditoria.NOTIFICAR_INFORME_ACCIONES_CORRECTORAS);
            Estado_TB.Text = _entity.EstadoAuditoriaLabel;*/

            ComunicadoAuditoriaActionForm form = new ComunicadoAuditoriaActionForm(Entity, TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS, ActiveOIDCorrector);
            form.ShowDialog();
            Datos.ResetBindings(false);
            //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
            //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
            //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
            //así que habrá una auditoría duplicada
            //_entity = form.Auditoria;

            Estado_TB.Text = _entity.EstadoAuditoriaLabel;

            //MessageBox.Show(Resources.Messages.INFORME_CORRECTOR_NOTIFICADO);
        }

        #endregion

        #region Buttons

        private void Comunicar_BT_Click(object sender, EventArgs e)
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.COMUNICAR))
                return;

            ComunicadoAuditoriaActionForm form = new ComunicadoAuditoriaActionForm(Entity, TipoNotificacionAsociado.COMUNICADO_AUDITORIA);
            form.ShowDialog();
            Datos.ResetBindings(false);
            //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
            //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
            //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
            //así que habrá una auditoría duplicada
            //_entity = form.Auditoria;
        }

        private void Iniciar_BT_Click(object sender, EventArgs e)
        {
            try
            {
                AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.INICIAR);
                AuditoriaFormController.DoAction(_entity, AccionAuditoria.INICIAR);
                Estado_TB.Text = _entity.EstadoAuditoriaLabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Aprobar_BT_Click(object sender, EventArgs e)
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.APROBAR_AUDITORIA))
                return;
            AuditoriaFormController.DoAction(_entity, AccionAuditoria.APROBAR_AUDITORIA);

            //Se hace esta asignación porque, si todo va bien, las modificaciones realizadas a la auditoría
            //se guardarán en la base de datos al cerrar el formulario del comunicado de auditorías
            //Si se trata de una auditoría nueva, al cerrar el formulario de la auditoría también la grabará
            //así que habrá una auditoría duplicada
            //_entity = form.Auditoria;

            Estado_TB.Text = _entity.EstadoAuditoriaLabel;
            //MessageBox.Show(Resources.Messages.AUDITORIA_APROBADA);
        }

        private void Desbloquear_BT_Click(object sender, EventArgs e)
        {
            if (!AuditoriaFormController.IsActionEnabled(_entity, AccionAuditoria.DESBLOQUEAR))
                return;
            AuditoriaController.RevertAuditoria(_entity, _entity.OidAuditor, false);
        }

        #endregion

        #region Events
        
        private void AuditoriaUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Entity.CloseSession();
        }

        private void PlanAnual_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is AuditoriaEditForm) return;
            if (PlanAnual_CB.SelectedItem != null && ((ComboBoxSource)PlanAnual_CB.SelectedItem).Oid != 0)
            {
                PlanAnualInfo plan = _planes.GetItem(((ComboBoxSource)PlanAnual_CB.SelectedItem).Oid);
                if (plan != null)
                {
                    
                    //Hay que buscar todas las auditorías asociadas al plan anual seleccionado
                    long oid_tipo_siguiente = AuditoriaList.GetSiguienteTipoAuditoria(((ComboBoxSource)PlanAnual_CB.SelectedItem).Oid);

                    foreach (Plan_TipoInfo info in plan.PlanesTipos)
                    {
                        if (info.Orden == oid_tipo_siguiente + 1)
                        {
                            TipoAuditoriaInfo tipo = _tipos_auditorias.GetItem(info.OidTipo);
                            _entity.OidPlan = info.OidPlan;
                            _entity.OidTipoAuditoria = info.OidTipo;
                            _entity.OidPlanTipo = info.Oid;
                            _entity.TipoAuditoria = tipo.Numero + " " + tipo.Nombre;
                            TipoAuditoria_TB.Text = _entity.TipoAuditoria;
                            break;
                        }
                    }
                }

                _tipo_auditoria = _tipos_auditorias.GetItem(_entity.OidTipoAuditoria);
                
                if (_tipo_auditoria != null)
                {
                    CuestionesAuditoria cuestiones = CuestionesAuditoria.NewChildList();
                    foreach (CuestionInfo info in _tipo_auditoria.Cuestiones)
                    {
                        CuestionAuditoria cuestion = CuestionAuditoria.NewChild(_entity);
                        cuestion.Numero = info.Numero;
                        cuestion.OidCuestion = info.Oid;
                        cuestion.OidAuditoria = Entity.Oid;
                        cuestiones.AddItem(cuestion);
                    }
                    _entity.Cuestiones = cuestiones;
                    Datos_Cuestiones.DataSource = _entity.Cuestiones;
                }
             }
        }
        
        #endregion

    }
}
