using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;

using moleQule.Library.Application;
using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;
using moleQule.Face.Quality.Tools;
using moleQule.Library.Instruction;

namespace moleQule.Face.Quality
{
    public partial class ComunicadoAuditoriaActionForm : moleQule.Face.Skin01.ActionSkinForm
    {
        
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        public const string ID = "ComunicadoAuditoriaActionForm";
        public static Type Type { get { return typeof(ComunicadoAuditoriaActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private NotificacionInterna _entity;
        private Auditoria _auditoria;
        private long _oid_auxiliar;

        public NotificacionInterna Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public NotificacionInternaInfo EntityInfo { get { return _entity.GetInfo(); } }

        public Auditoria Auditoria
        {
            get { return _auditoria; }
            set { _auditoria = value; }
        }

        #endregion

        #region Factory Methods

        public ComunicadoAuditoriaActionForm(Auditoria item, TipoNotificacionAsociado tipo)
            : this(true, item, tipo, -1) { }

        public ComunicadoAuditoriaActionForm(Auditoria item, TipoNotificacionAsociado tipo, long oid_auxiliar)
            : this(true, item, tipo, oid_auxiliar) { }

        public ComunicadoAuditoriaActionForm(bool IsModal, Auditoria item, TipoNotificacionAsociado tipo, long oid_auxiliar)
            : base(IsModal)
        {
            InitializeComponent();
            _auditoria = item;
            _entity = NotificacionInterna.NewChild(_auditoria);
            _entity.TipoAsociado = (long)tipo;
            _oid_auxiliar = oid_auxiliar;
            SetFormData();
            this.Text = Resources.Labels.COMUNICADO_AUDITORIA_TITLE;
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {
                this.Datos.RaiseListChangedEvents = false;

                Auditoria temp = _auditoria.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _auditoria = temp.Save();
                    _auditoria.ApplyEdit();

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    AppController.APP_TITLE,
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

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {

            switch (_entity.TipoAsociado)
            {
                case (long)TipoNotificacionAsociado.COMUNICADO_AUDITORIA:
                    {
                        string nombre_auditoria = string.Empty, areas = string.Empty, auditor = string.Empty;
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria ,true);
                        if (tipo != null)
                        {
                            nombre_auditoria = " _(" + tipo.Numero + ") " + tipo.Nombre;
                            auditor = _auditoria.Auditor == string.Empty ? InstructorInfo.Get(_auditoria.OidAuditor, false).Nombre : _auditoria.Auditor;
                            AreaList lista_areas = AreaList.GetList(false);

                            foreach (Auditoria_AreaInfo info in tipo.Areas)
                            {
                                AreaInfo area = lista_areas.GetItem(info.OidArea);
                                if (area != null)
                                {
                                    if (areas != string.Empty)
                                    areas += ", ";
                                    areas = area.Nombre;
                                }
                            }
                        }

                        _entity.Asunto = string.Format(Resources.Messages.ASUNTO_COMUNICADO_AUDITORIA, _auditoria.Codigo, nombre_auditoria, _auditoria.FechaInicio.ToShortDateString(), areas, auditor);
                        
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_DISCREPANCIAS:
                    { 
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria ,true);
                        if (tipo != null)
                        {
                            _entity.Asunto = "INFORME DE DISCREPANCIAS, (AUDITORÍA " + tipo.Numero + ") " +
                                tipo.Nombre;
                            _entity.Comentarios = string.Format(Resources.Messages.COMENTARIOS_COMUNICADO_NOTIFICACION_DISCREPANCIAS, _auditoria.Codigo, tipo.Numero, tipo.Nombre); 
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS:
                    {
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria, true);
                        if (tipo != null)
                        {
                            _entity.Asunto = "INFORME DE ACCIONES CORRECTORAS, (AUDITORÍA " 
                                + tipo.Numero + ") " + tipo.Nombre;
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_FIN_AUDITORIA:
                    {
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria, true);
                        if (tipo != null)
                        {
                            _entity.Asunto = "CIERRE DE DISCREPANCIAS AUDITORÍA " + _auditoria.Codigo + 
                                " " + tipo.Numero + " " + tipo.Nombre;
                            _entity.Comentarios = string.Format(Resources.Messages.COMENTARIOS_NOTIFICACION_CIERRE_DISCREPANCIAS, _auditoria.Codigo, tipo.Numero, tipo.Nombre);
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.SOLICITUD_AMPLIACION:
                    {
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria, true);
                        if (tipo != null)
                        {
                            _entity.Asunto = "INFORME DE SOLICITUD DE AMPLIACIÓN, (AUDITORÍA " +
                                tipo.Numero + ") " + tipo.Nombre;
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.CONCESION_AMPLIACION:
                    {
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria, true);
                        if (tipo != null)
                        {
                            _entity.Asunto = "INFORME DE CONCESIÓN DE AMPLIACIÓN, (AUDITORÍA " +
                                tipo.Numero + ") " + tipo.Nombre;
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.DENEGACION_AMPLIACION:
                    {
                        TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(_auditoria.OidTipoAuditoria, true);
                        if (tipo != null)
                        {
                            _entity.Asunto = "INFORME DE DENEGACIÓN DE AMPLIACIÓN, (AUDITORÍA " +
                                tipo.Numero + ") " + tipo.Nombre;
                        }
                    }
                    break;
                default:
                    break;
            }

            Datos.DataSource = _entity;
            Bar.FillUp();
        }


        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (!_entity.IsValid)
            {
                MessageBox.Show("Los campos introducidos no tienen los valores esperados.");
                return;
            }

            switch (_entity.TipoAsociado)
            {
                case (long)TipoNotificacionAsociado.COMUNICADO_AUDITORIA:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.COMUNICAR))
                            return;
                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.COMUNICAR);
                        _auditoria.Notificaciones.AddItem(_entity);
                        _auditoria.FechaComunicacion = DateTime.Now;
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_DISCREPANCIAS:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.NOTIFICAR_DISCREPANCIAS))
                            return;

                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.NOTIFICAR_DISCREPANCIAS, _oid_auxiliar);
                        AuditoriaController.CalculaFechasDebidas(_auditoria);
                        InformeDiscrepancia informe = _auditoria.Informes.GetItem(_oid_auxiliar);
                        informe.FechaComunicacion = DateTime.Now;
                        informe.Notificaciones.AddItem(_entity);
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.NOTIFICAR_INFORME_ACCIONES_CORRECTORAS))
                            return;

                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.NOTIFICAR_INFORME_ACCIONES_CORRECTORAS, _oid_auxiliar);
                        foreach (InformeDiscrepancia informe in _auditoria.Informes)
                        {
                            InformeCorrector corrector = informe.Correctores.GetItem(_oid_auxiliar);
                            if (corrector != null)
                            {
                                corrector.FechaComunicacion = DateTime.Now;
                                corrector.Notificaciones.AddItem(_entity);
                                break;
                            }
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_FIN_AUDITORIA:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.APROBAR_AUDITORIA))
                            return;
                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.APROBAR_AUDITORIA);
                        _auditoria.Notificaciones.AddItem(_entity);
                    }
                    break;
                case (long)TipoNotificacionAsociado.SOLICITUD_AMPLIACION:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.GENERAR_INFORME_AMPLIACION))
                            return;
                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.GENERAR_INFORME_AMPLIACION, _oid_auxiliar); 
                        foreach (InformeDiscrepancia informe in _auditoria.Informes)
                        {
                            InformeAmpliacion ampliacion = informe.Ampliaciones.GetItem(_oid_auxiliar);
                            if (ampliacion != null)
                            {
                                ampliacion.FechaComunicacion = DateTime.Now;
                                ampliacion.Notificaciones.AddItem(_entity);
                                break;
                            }
                        }
                    }
                    break;
                case (long)TipoNotificacionAsociado.CONCESION_AMPLIACION:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.NOTIFICAR_CONCESION_AMPLIACION))
                            return;
                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.NOTIFICAR_CONCESION_AMPLIACION, _oid_auxiliar);
                        _auditoria.Notificaciones.AddItem(_entity);
                    }
                    break;
                case (long)TipoNotificacionAsociado.DENEGACION_AMPLIACION:
                    {
                        if (!AuditoriaFormController.IsActionEnabled(_auditoria, AccionAuditoria.NOTIFICAR_DENEGACION_AMPLIACION))
                            return;
                        AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.NOTIFICAR_DENEGACION_AMPLIACION);
                        _auditoria.Notificaciones.AddItem(_entity);
                    }
                    break;
                default:
                    break;
            }


            //if (SaveObject())
            //{
                _action_result = DialogResult.OK;
                Close();
            //}
        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            if (!IsModal)
                _entity.CancelEdit();
            _action_result = DialogResult.Cancel;

            Cerrar();
        }

        private void Imprimir_BT_Click(object sender, EventArgs e)
        {
            AuditoriaReportMng reportMng = new AuditoriaReportMng(AppContext.ActiveSchema);

            switch (_entity.TipoAsociado)
            {
                case (long)TipoNotificacionAsociado.COMUNICADO_AUDITORIA:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionAuditoriaReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    } break;
                case (long)TipoNotificacionAsociado.INFORME_DISCREPANCIAS:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionDiscrepanciasReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionDiscrepanciasReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    }
                    break;
                case (long)TipoNotificacionAsociado.INFORME_FIN_AUDITORIA:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionCierreDiscrepanciasReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    }
                    break;
                case (long)TipoNotificacionAsociado.SOLICITUD_AMPLIACION:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionDiscrepanciasReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    }
                    break;
                case (long)TipoNotificacionAsociado.CONCESION_AMPLIACION:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionDiscrepanciasReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    }
                    break;
                case (long)TipoNotificacionAsociado.DENEGACION_AMPLIACION:
                    {
                        NotificacionInternaRpt comunicado = reportMng.GetDetailNotificacionDiscrepanciasReport(EntityInfo, Auditoria.GetInfo(false), CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                        ReportViewer.SetReport(comunicado);
                        ReportViewer.ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Events

        private void ComunicadoAuditoriaActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
                Entity.CancelEdit();
            }

            Cerrar();

        }

        #endregion

    }
}

