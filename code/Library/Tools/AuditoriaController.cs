using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{
    /// <summary>
    /// Clase con funciones que controlan modificaciones en el proceso de una auditoría
    /// </summary>
    public class AuditoriaController
    {

        #region Acciones

        public static bool PuedoAprobarAuditoria(Auditoria auditoria)
        {
            try
            {
                CompruebaCuestionesAceptadas(auditoria);
                EsUsuarioAuditor(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void AprobarAuditoria(Auditoria auditoria)
        {
            if (PuedoAprobarAuditoria(auditoria))
            {
                if (auditoria.EstadoAuditoria == EstadoAuditoria.EN_PROCESO
                    || auditoria.EstadoAuditoria == EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS)
                    SetEstado(auditoria, EstadoAuditoria.INFORME_GENERADO, auditoria.OidAuditor);
                SetEstado(auditoria, EstadoAuditoria.SIN_DISCREPANCIAS, auditoria.OidAuditor);
            }
        }

        public static bool PuedoComunicarAuditoria(Auditoria auditoria)
        {
            try
            {
                EsUsuarioAuditor(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void ComunicarAuditoria(Auditoria auditoria)
        {
            if (PuedoComunicarAuditoria(auditoria))
                SetEstado(auditoria, EstadoAuditoria.COMUNICADA, auditoria.OidAuditor);
        }

        public static bool PuedoDesbloquearAuditoria(Auditoria auditoria)
        {
            //Hay que comprobar que la persona que intenta desbloquear la auditoría sea el responsable 
            //de calidad
            return false;
        }

        public static void DesbloquearAuditoria(Auditoria auditoria)
        {
            if (PuedoDesbloquearAuditoria(auditoria))
                RevertAuditoria(auditoria, auditoria.OidAuditor, false);
        }

        public static void BorrarInformeAmpliacion(Auditoria auditoria, long oid_informe_ampliacion)
        {
            if (PuedoBorrarInformeAmpliacion(auditoria, oid_informe_ampliacion))
            {
                foreach (InformeDiscrepancia informe_discrepancia in auditoria.Informes)
                {
                    if (informe_discrepancia.Ampliaciones.GetItem(oid_informe_ampliacion) != null)
                    {
                        informe_discrepancia.Ampliaciones.Remove(oid_informe_ampliacion);

                        AuditoriaController.RevertAuditoria(auditoria, auditoria.OidResponsable, true);
                        auditoria.Estado = auditoria.Historial[auditoria.Historial.Count - 1].Estado;
                        break;
                    }
                }
            }
        }

        public static bool PuedoBorrarInformeAmpliacion(Auditoria auditoria, long oid_informe_ampliacion)
        {
            try
            {
                EsUsuarioResponsable(auditoria);
                CompruebaPlazoFechaDebida(auditoria);
                CompruebaUltimoInformeAmpliacion(auditoria, oid_informe_ampliacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void BorrarInformeCorrector(Auditoria auditoria, long oid_informe_corrector)
        {
            if (PuedoBorrarInformeCorrector(auditoria, oid_informe_corrector))
            {
                foreach (InformeDiscrepancia informe_discrepancia in auditoria.Informes)
                {
                    if (informe_discrepancia.Correctores.GetItem(oid_informe_corrector) != null)
                    {
                        informe_discrepancia.Correctores.Remove(oid_informe_corrector);

                        AuditoriaController.RevertAuditoria(auditoria, auditoria.OidResponsable, true);
                        auditoria.Estado = auditoria.Historial[auditoria.Historial.Count - 1].Estado;
                        break;
                    }
                }
            }
        }

        public static bool PuedoBorrarInformeCorrector(Auditoria auditoria, long oid_informe_corrector)
        {
            try
            {
                EsUsuarioResponsable(auditoria);
                CompruebaPlazoFechaDebida(auditoria);
                CompruebaUltimoInformeCorrector(auditoria, oid_informe_corrector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void BorrarInformeDiscrepancias(Auditoria auditoria, long oid_informe_discrepancias)
        {
            if (PuedoBorrarInformeDiscrepancias(auditoria, oid_informe_discrepancias))
            {
                if (auditoria.Informes.GetItem(oid_informe_discrepancias) != null)
                {
                    auditoria.Informes.Remove(oid_informe_discrepancias);

                    AuditoriaController.RevertAuditoria(auditoria, auditoria.OidAuditor, true);
                    auditoria.Estado = auditoria.Historial[auditoria.Historial.Count - 1].Estado;
                }
            }
        }

        public static bool PuedoBorrarInformeDiscrepancias(Auditoria auditoria, long oid_informe_discrepancias)
        {
            try
            {
                EsUsuarioAuditor(auditoria);
                CompruebaPlazoNotificacionDiscrepancias(auditoria);
                CompruebaUltimoInformeDiscrepancias(auditoria, oid_informe_discrepancias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool PuedoEditarDiscrepancias(Auditoria auditoria)
        {
            try
            {
                EsUsuarioAuditor(auditoria);
                CompruebaPlazoNotificacionDiscrepancias(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool PuedoEditarInformeAccionesCorrectoras(Auditoria auditoria)
        {
            try
            {
                EsUsuarioResponsable(auditoria);
                CompruebaPlazoFechaDebida(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool PuedoGenerarInformeAccionesCorrectoras(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioResponsable(auditoria);
                    PuedoEditarInformeAccionesCorrectoras(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void GenerarInformeAccionesCorrectoras(Auditoria auditoria)
        {
            if (PuedoGenerarInformeAccionesCorrectoras(auditoria))
                SetEstado(auditoria, EstadoAuditoria.DISCREPANCIAS_RESUELTAS, auditoria.OidResponsable);
        }

        public static bool PuedoGenerarInformeAmpliacion(Auditoria auditoria)
        {
            try
            {
                EsUsuarioResponsable(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void GenerarInformeAmpliacion(Auditoria auditoria, long oid_informe_ampliacion)
        {
            if (PuedoGenerarInformeAmpliacion(auditoria))
            {
                foreach (InformeDiscrepancia informe_discrepancia in auditoria.Informes)
                {
                    InformeAmpliacion informe = informe_discrepancia.Ampliaciones.GetItem(oid_informe_ampliacion);
                    if (informe != null)
                    {
                        informe_discrepancia.Ampliaciones.GetItem(oid_informe_ampliacion).Notificado = true;
                        break;
                    }
                }
                SetEstado(auditoria, EstadoAuditoria.AMPLIACION_SOLICITADA, auditoria.OidResponsable);
            }
        }

        public static bool PuedoEditarInformeAmpliacion(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioResponsable(auditoria);
                    CompruebaPlazoFechaDebida(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static bool PuedoGenerarInformeAuditoria(Auditoria auditoria)
        {         
                try
                {
                    EsUsuarioAuditor(auditoria);
                    CompruebaPlazoGeneracion(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void GenerarInformeAuditoria(Auditoria auditoria)
        {
            if (PuedoGenerarInformeAuditoria(auditoria))
            {
                if (auditoria.EstadoAuditoria == EstadoAuditoria.EN_PROCESO || auditoria.EstadoAuditoria == EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS)
                    SetEstado(auditoria, EstadoAuditoria.INFORME_GENERADO, auditoria.OidAuditor);
            }
        }

        public static bool PuedoGenerarInformeDiscrepancias(Auditoria auditoria)
        {
            try
            {
                EsUsuarioAuditor(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void GenerarInformeDiscrepancias(Auditoria auditoria)
        {
            if (PuedoGenerarInformeDiscrepancias(auditoria))
            {
                if (auditoria.EstadoAuditoria == EstadoAuditoria.EN_PROCESO
                    || auditoria.EstadoAuditoria == EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS)
                    SetEstado(auditoria, EstadoAuditoria.INFORME_GENERADO, auditoria.OidAuditor);
                SetEstado(auditoria, EstadoAuditoria.DISCREPANCIAS, auditoria.OidAuditor);
            }
        }

        public static bool PuedoIniciarAuditoria(Auditoria auditoria)
        {
            try
            {
                EsUsuarioAuditor(auditoria);
                CompruebaFechasInicioFin(auditoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static void IniciarAuditoria(Auditoria auditoria)
        {
            if (PuedoIniciarAuditoria(auditoria))
                SetEstado(auditoria, EstadoAuditoria.EN_PROCESO, auditoria.OidAuditor);
        }

        public static bool PuedoNotificarConcesionAmpliacion(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioAuditor(auditoria);
                    CompruebaPlazoNotificacionConcesionAmpliacion(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void NotificarConcesionAmpliacion(Auditoria auditoria)
        {
            if (PuedoNotificarConcesionAmpliacion(auditoria))
            {
                EstadoAuditoria estado_anterior = auditoria.EstadoAuditoria;

                for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
                {
                    if (auditoria.Historial[i].EstadoAuditoria != EstadoAuditoria.AMPLIACION_SOLICITADA)
                    {
                        estado_anterior = auditoria.Historial[i].EstadoAuditoria;
                        break;
                    }
                }

                SetEstado(auditoria, EstadoAuditoria.AMPLIADA, auditoria.OidAuditor);
                SetEstado(auditoria, estado_anterior, auditoria.OidAuditor);
            }
        }

        public static bool PuedoNotificarDenegacionAmpliacion(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioAuditor(auditoria);
                    CompruebaPlazoNotificacionDenegacionAmpliacion(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void NotificarDenegacionAmpliacion(Auditoria auditoria)
        {
            if (PuedoNotificarDenegacionAmpliacion(auditoria))
            {
                EstadoAuditoria estado_anterior = auditoria.EstadoAuditoria;

                for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
                {
                    if (auditoria.Historial[i].EstadoAuditoria != EstadoAuditoria.AMPLIACION_SOLICITADA)
                    {
                        estado_anterior = auditoria.Historial[i].EstadoAuditoria;
                        break;
                    }
                }

                SetEstado(auditoria, EstadoAuditoria.AMPLIACION_DENEGADA, auditoria.OidAuditor);
                SetEstado(auditoria, estado_anterior, auditoria.OidAuditor);
            }
        }

        public static bool PuedoNotificarDiscrepancias(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioAuditor(auditoria);
                    CompruebaPlazoNotificacionDiscrepancias(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void NotificarDiscrepancias(Auditoria auditoria, long oid_informe_discrepancias)
        {
            if (PuedoNotificarDiscrepancias(auditoria))
            {
                auditoria.Informes.GetItem(oid_informe_discrepancias).Notificado = true;
                SetEstado(auditoria, EstadoAuditoria.DISCREPANCIAS_NOTIFICADAS, auditoria.OidAuditor);
            }
        }

        public static bool PuedoNotificarFinAuditoria(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioAuditor(auditoria);
                    CompruebaPlazoNotificacionFinAuditoria(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void NotificarFinAuditoria(Auditoria auditoria)
        {
            if (PuedoNotificarFinAuditoria(auditoria))
            {
                if (auditoria.EstadoAuditoria == EstadoAuditoria.EN_PROCESO ||
                    auditoria.EstadoAuditoria == EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS)
                    SetEstado(auditoria, EstadoAuditoria.INFORME_GENERADO, auditoria.OidAuditor);
                if (auditoria.EstadoAuditoria == EstadoAuditoria.INFORME_GENERADO)
                    SetEstado(auditoria, EstadoAuditoria.SIN_DISCREPANCIAS, auditoria.OidAuditor);
                SetEstado(auditoria, EstadoAuditoria.FINALIZADA, auditoria.OidAuditor);
            }
        }

        public static bool PuedoNotificarInformeAccionesCorrectoras(Auditoria auditoria)
        {
                try
                {
                    EsUsuarioResponsable(auditoria);
                    CompruebaPlazoFechaDebida(auditoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
        }

        public static void NotificarInformeAccionesCorrectoras(Auditoria auditoria, long oid_informe_corrector)
        {
            if (PuedoNotificarInformeAccionesCorrectoras(auditoria))
            {
                foreach (InformeDiscrepancia informe_discrepancias in auditoria.Informes)
                {
                    InformeCorrector informe = informe_discrepancias.Correctores.GetItem(oid_informe_corrector);
                    if (informe != null)
                    {
                        informe_discrepancias.Correctores.GetItem(oid_informe_corrector).Notificado = true;
                        InformeCorrector informe_corrector = informe_discrepancias.Correctores.GetItem(oid_informe_corrector);
                        foreach (AccionCorrectora accion in informe_corrector.Acciones)
                        {
                            informe_discrepancias.Discrepancias.GetItem(accion.OidDiscrepancia).FechaCierre = DateTime.Now;
                        }
                        break;
                    }
                }

                SetEstado(auditoria, EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS, auditoria.OidResponsable);
            }
        }

        #endregion

        #region Controlador
        
        public static void CompruebaCuestionesAceptadas(Auditoria auditoria)
        {
            foreach (CuestionAuditoria  cuestion in auditoria.Cuestiones)
            {
                if (!cuestion.Aceptado)
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.CUESTIONES_AUDITORIA_NO_ACEPTADAS);
            }
        }

        public static void CompruebaFechasInicioFin(Auditoria auditoria)
        {
            if (DateTime.Today.Date < auditoria.FechaInicio.Date
                || DateTime.Today.Date > auditoria.FechaFin.Date)
            {
                throw new Exception(moleQule.Library.Quality.Resources.Messages.INICIO_AUDITORIA_FUERA_FECHAS);
            }
        }

        public static void CompruebaPlazoFechaDebida(Auditoria auditoria)
        {
            foreach (InformeDiscrepancia informe in auditoria.Informes)
            {
                foreach (Discrepancia discrepancia in informe.Discrepancias)
                {
                    if (DateTime.Today.Date > discrepancia.FechaAmpliacion)
                    {
                        //si alguna discrepancia ha superado la fecha debida
                        //lanza el mensaje con el aviso y se continúa con el proceso
                        throw new Exception(moleQule.Library.Quality.Resources.Messages.FECHA_DEBIDA_DISCREPANCIA_EXCEDIDA);
                    }
                }
            }
        }

        public static void CompruebaPlazoGeneracion(Auditoria auditoria)
        {
            //El plazo de generación es de dos semanas
            //En caso de haberlo sobrepasado se lanzará un mensaje avisando del problema
            HistoriaAuditoria historia = null;
            for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
            {
                if (auditoria.Historial[i].EstadoAuditoria == EstadoAuditoria.EN_PROCESO
                    || auditoria.Historial[i].EstadoAuditoria == EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS)
                {
                    historia = auditoria.Historial[i];
                    break;
                }
            }

            SchemaSettingInfo plazo = SchemaSettingInfo.Get("PLAZO_MAXIMO_GENERACION_INFORME");            

            if (historia != null)
            {
                if (DateTime.Today.Date > historia.Fecha.AddDays(Convert.ToInt32(plazo.Value)).Date)
                {
                    //Lanza el mensajito con el aviso
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.PLAZO_GENERACION_INFORME_AUDITORIA_EXCEDIDO);
                }
            }
        }

        public static void CompruebaPlazoNotificacionConcesionAmpliacion(Auditoria auditoria)
        {
            //El plazo de notificación de concesión de ampliación es de dos semanas.
            //En caso de haberlo sobrepasado se lanzará un mensaje avisando del problema
            HistoriaAuditoria historia = null;
            for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
            {
                if (auditoria.Historial[i].EstadoAuditoria == EstadoAuditoria.AMPLIACION_SOLICITADA)
                {
                    historia = auditoria.Historial[i];
                    break;
                }
            }

            SchemaSettingInfo plazo = SchemaSettingInfo.Get("PLAZO_MAXIMO_RESPUESTA_AMPLIACION");   

            if (historia != null)
            {
                if (DateTime.Today.Date > historia.Fecha.AddDays(Convert.ToInt32(plazo.Value)).Date)
                {
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.PLAZO_NOTIFICACION_CONCESION_AMPLIACION_EXCEDIDO);
                }
            }
        }

        public static void CompruebaPlazoNotificacionDenegacionAmpliacion(Auditoria auditoria)
        {
            //El plazo de notificación de denegación de ampliación es de dos semanas.
            //En caso de haberlo sobrepasado se lanzará un mensaje avisando del problema
            HistoriaAuditoria historia = null;
            for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
            {
                if (auditoria.Historial[i].EstadoAuditoria == EstadoAuditoria.AMPLIACION_SOLICITADA)
                {
                    historia = auditoria.Historial[i];
                    break;
                }
            }

            SchemaSettingInfo plazo = SchemaSettingInfo.Get("PLAZO_MAXIMO_RESPUESTA_AMPLIACION");

            if (historia != null)
            {
                if (DateTime.Today.Date > historia.Fecha.AddDays(Convert.ToInt32(plazo.Value)).Date)
                {
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.PLAZO_NOTIFICACION_DENEGACION_AMPLIACION_EXCEDIDO);
                }
            }
        }

        public static void CompruebaPlazoNotificacionDiscrepancias(Auditoria auditoria)
        {
            //El plazo de notificación de las discrepancias es de una semana
            //En caso de haberlo sobrepasado se lanzará un mensaje avisando del problema
            HistoriaAuditoria historia = null;
            for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
            {
                if (auditoria.Historial[i].EstadoAuditoria == EstadoAuditoria.DISCREPANCIAS)
                {
                    historia = auditoria.Historial[i];
                    break;
                }
            }

            SchemaSettingInfo plazo = SchemaSettingInfo.Get("PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS");

            if (historia != null)
            {
                if (DateTime.Today.Date > historia.Fecha.AddDays(Convert.ToInt32(plazo.Value)).Date)
                {
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.PLAZO_NOTIFICACION_DISCREPANCIAS_EXCEDIDO);
                }
            }
        }

        public static void CompruebaPlazoNotificacionFinAuditoria(Auditoria auditoria)
        {
            //El plazo de notificación del fin de auditoría es de una semana.
            //En caso de haberlo sobrepasado se lanzará un mensaje avisando del problema
            HistoriaAuditoria historia = null;
            for (int i = auditoria.Historial.Count - 1; i >= 0; i--)
            {
                if (auditoria.Historial[i].EstadoAuditoria == EstadoAuditoria.SIN_DISCREPANCIAS)
                {
                    historia = auditoria.Historial[i];
                    break;
                }
            }

            SchemaSettingInfo plazo = SchemaSettingInfo.Get("PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA");
            
            if (historia != null)
            {
                if (DateTime.Today.Date > historia.Fecha.AddDays(Convert.ToInt32(plazo.Value)).Date)
                {
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.PLAZO_NOTIFICACION_FIN_AUDITORIA_EXCEDIDO);
                }
            }
        }

        public static void CompruebaUltimoInformeAmpliacion(Auditoria auditoria, long oid_informe_ampliacion)
        {
            foreach (InformeDiscrepancia informe_discrepancia in auditoria.Informes)
            {
                InformeAmpliacion informe = informe_discrepancia.Ampliaciones.GetItem(oid_informe_ampliacion);
                if (informe != null && informe.Notificado)
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.BORRANDO_INFORME_NOTIFICADO);
            }
        }

        public static void CompruebaUltimoInformeCorrector(Auditoria auditoria, long oid_informe_corrector)
        {
            foreach (InformeDiscrepancia informe_discrepancia in auditoria.Informes)
            {
                InformeCorrector informe = informe_discrepancia.Correctores.GetItem(oid_informe_corrector);
                if (informe != null && informe.Notificado)
                    throw new Exception(moleQule.Library.Quality.Resources.Messages.BORRANDO_INFORME_NOTIFICADO);
            }
        }

        public static void CompruebaUltimoInformeDiscrepancias(Auditoria auditoria, long oid_informe_discrepancias)
        {
            InformeDiscrepancia informe = auditoria.Informes.GetItem(oid_informe_discrepancias);
            if (informe.Notificado)
                throw new Exception(moleQule.Library.Quality.Resources.Messages.BORRANDO_INFORME_NOTIFICADO);
        }

        public static void EsUsuarioAuditor(Auditoria auditoria)
        {
            if (AppContext.User.Oid != auditoria.OidUsuarioAuditor)
            {
                throw new Exception(string.Format(moleQule.Library.Quality.Resources.Messages.NO_USUARIO_AUDITOR, auditoria.Auditor));
            }

        }

        public static void EsUsuarioResponsable(Auditoria auditoria)
        {
            if (AppContext.User.Oid != auditoria.OidUsuarioResponsable)
            {
                throw new Exception(string.Format(moleQule.Library.Quality.Resources.Messages.NO_USUARIO_RESPONSABLE, auditoria.Responsable));
            }
        }

        public static void DoAction(Auditoria auditoria, AccionAuditoria accion)
        {
            DoAction(auditoria, accion, -1);
        }

        /// <summary>
        /// Función que controla que sólo se puedan llevar a cabo determinadas acciones sobre una auditoría
        /// dependiendo del estado de la misma. 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static void DoAction(Auditoria auditoria, AccionAuditoria accion, long oid_auxiliar)
        {
            switch (auditoria.EstadoAuditoria)
            {
                case EstadoAuditoria.CREADA:
                    {
                        if (accion == AccionAuditoria.COMUNICAR)
                        {
                            ComunicarAuditoria(auditoria);
                        }
                    }
                    break;
                case EstadoAuditoria.COMUNICADA:
                    {
                        if (accion == AccionAuditoria.INICIAR)
                        {
                            try
                            {
                                IniciarAuditoria(auditoria);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    break;
                case EstadoAuditoria.EN_PROCESO:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    GenerarInformeAuditoria(auditoria);
                                }
                                break;
                            case AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS:
                                {
                                    GenerarInformeDiscrepancias(auditoria);
                                }
                                break;
                            case AccionAuditoria.APROBAR_AUDITORIA:
                                {
                                    AprobarAuditoria(auditoria);
                                }
                                break;
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                {
                                    NotificarFinAuditoria(auditoria);
                                }
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.INFORME_GENERADO:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                }
                                break;
                            case AccionAuditoria.APROBAR_AUDITORIA:
                                {
                                    AprobarAuditoria(auditoria);
                                }
                                break;
                            case AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS:
                                {
                                    GenerarInformeDiscrepancias(auditoria);
                                }
                                break;
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                {
                                    NotificarFinAuditoria(auditoria);
                                }
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.DISCREPANCIAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.NOTIFICAR_DISCREPANCIAS:
                                {
                                    NotificarDiscrepancias(auditoria, oid_auxiliar);
                                }
                                break;
                            case AccionAuditoria.BORRAR_INFORME_DISCREPANCIAS:
                                { 
                                    BorrarInformeDiscrepancias(auditoria, oid_auxiliar);
                                }
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.DISCREPANCIAS_NOTIFICADAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    GenerarInformeAccionesCorrectoras(auditoria);
                                }
                                break;
                            case AccionAuditoria.GENERAR_INFORME_AMPLIACION:
                                {
                                    GenerarInformeAmpliacion(auditoria, oid_auxiliar);
                                }
                                break;
                            case AccionAuditoria.BORRAR_INFORME_AMPLIACION:
                                {
                                    BorrarInformeAmpliacion(auditoria, oid_auxiliar);
                                }
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.DISCREPANCIAS_RESUELTAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.NOTIFICAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    NotificarInformeAccionesCorrectoras(auditoria, oid_auxiliar);
                                }
                                break;
                            case AccionAuditoria.GENERAR_INFORME_AMPLIACION:
                                {
                                    GenerarInformeAmpliacion(auditoria, oid_auxiliar);
                                }
                                break;
                            case AccionAuditoria.BORRAR_INFORME_AMPLIACION:
                                {
                                    BorrarInformeAmpliacion(auditoria, oid_auxiliar);
                                }
                                break;
                            case AccionAuditoria.BORRAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    BorrarInformeCorrector(auditoria, oid_auxiliar);
                                }
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                { GenerarInformeAuditoria(auditoria); } break;
                            case AccionAuditoria.APROBAR_AUDITORIA:
                                { AprobarAuditoria(auditoria); } break;
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                { NotificarFinAuditoria(auditoria); } break;
                            case AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS:
                                {GenerarInformeDiscrepancias(auditoria);}
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.SIN_DISCREPANCIAS:
                    {
                        if (accion == AccionAuditoria.NOTIFICAR_FIN_AUDITORIA)
                            NotificarFinAuditoria(auditoria);
                    }
                    break;
                case EstadoAuditoria.FINALIZADA:
                    {
                        //Una vez finalizada no es posible realizar ningún tipo de acción sobre ella
                    }
                    break;
                case EstadoAuditoria.AMPLIACION_SOLICITADA:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.NOTIFICAR_DENEGACION_AMPLIACION:
                                {
                                    NotificarDenegacionAmpliacion(auditoria);
                                }
                                break;
                            case AccionAuditoria.NOTIFICAR_CONCESION_AMPLIACION:
                                {
                                    NotificarConcesionAmpliacion(auditoria);
                                }
                                break;
                        }
                    }
                    break;
                case EstadoAuditoria.AMPLIACION_DENEGADA:
                    {
                        if (accion == AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS)
                            GenerarInformeAccionesCorrectoras(auditoria);

                    }
                    break;
                case EstadoAuditoria.AMPLIADA:
                    {
                        if (accion == AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS)
                            GenerarInformeAccionesCorrectoras(auditoria);
                    }
                    break;
                case EstadoAuditoria.BLOQUEADA:
                    {
                        if (accion == AccionAuditoria.DESBLOQUEAR)
                            DesbloquearAuditoria(auditoria);
                    }
                    break;
            }
        }

        public static bool IsActionEnabled(Auditoria auditoria, AccionAuditoria accion)
        {
            return IsActionEnabled(auditoria, accion, -1);
        }

        /// <summary>
        /// Función que controla que sólo se puedan llevar a cabo determinadas acciones sobre una auditoría
        /// dependiendo del estado de la misma. 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool IsActionEnabled(Auditoria auditoria, AccionAuditoria accion, long oid_auxiliar)
        {
            switch (auditoria.EstadoAuditoria)
            {
                case EstadoAuditoria.CREADA:
                    {
                        if (accion == AccionAuditoria.COMUNICAR)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                case EstadoAuditoria.COMUNICADA:
                    {
                        if (accion == AccionAuditoria.INICIAR)
                        {
                            try
                            {
                                return PuedoIniciarAuditoria(auditoria);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                            return false;
                    }
                case EstadoAuditoria.EN_PROCESO:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                            case AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeDiscrepancias(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.APROBAR_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoAprobarAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoNotificarFinAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.INFORME_GENERADO:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    //DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.APROBAR_AUDITORIA:
                                {
                                    try{ return PuedoAprobarAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS:
                                {
                                    try{ return PuedoGenerarInformeDiscrepancias(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.EDITAR_INFORME_DISCREPANCIAS:
                                {
                                    try
                                    {
                                        return PuedoEditarDiscrepancias(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoNotificarFinAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.DISCREPANCIAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.NOTIFICAR_DISCREPANCIAS:
                                {
                                    try
                                    {
                                        return PuedoNotificarDiscrepancias(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.EDITAR_INFORME_DISCREPANCIAS:
                                {
                                    try
                                    {
                                        return PuedoEditarDiscrepancias(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.BORRAR_INFORME_DISCREPANCIAS:
                                {
                                    try
                                    {
                                        return PuedoBorrarInformeDiscrepancias(auditoria, oid_auxiliar);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.DISCREPANCIAS_NOTIFICADAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeAccionesCorrectoras(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.GENERAR_INFORME_AMPLIACION:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeAmpliacion(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.BORRAR_INFORME_AMPLIACION:
                                {
                                    try
                                    {
                                        return PuedoBorrarInformeAmpliacion(auditoria, oid_auxiliar);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.DISCREPANCIAS_RESUELTAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.NOTIFICAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    try
                                    {
                                        return PuedoNotificarInformeAccionesCorrectoras(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.EDITAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    try
                                    {
                                        return PuedoEditarInformeAccionesCorrectoras(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.GENERAR_INFORME_AMPLIACION:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeAmpliacion(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }

                            case AccionAuditoria.BORRAR_INFORME_AMPLIACION:
                                {
                                    try
                                    {
                                        return PuedoBorrarInformeAmpliacion(auditoria, oid_auxiliar);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.BORRAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    try
                                    {
                                        return PuedoBorrarInformeCorrector(auditoria, oid_auxiliar);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:                                
                            {
                                try
                                {
                                    return PuedoGenerarInformeAuditoria(auditoria);
                                }
                                catch (Exception ex)
                                { throw ex; }
                            }
                            case AccionAuditoria.APROBAR_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoAprobarAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoNotificarFinAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeDiscrepancias(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.SIN_DISCREPANCIAS:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.NOTIFICAR_FIN_AUDITORIA:
                                {
                                    try
                                    {
                                        return PuedoNotificarFinAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.FINALIZADA:
                    {
                        //Una vez finalizada no es posible realizar ningún tipo de acción sobre ella
                        return false;
                    }
                case EstadoAuditoria.AMPLIACION_SOLICITADA:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.NOTIFICAR_DENEGACION_AMPLIACION:
                                {
                                    try
                                    {
                                        return PuedoNotificarDenegacionAmpliacion(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            case AccionAuditoria.NOTIFICAR_CONCESION_AMPLIACION:
                                {
                                    try
                                    {
                                        return PuedoNotificarConcesionAmpliacion(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.AMPLIACION_DENEGADA:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeAccionesCorrectoras(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.AMPLIADA:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS:
                                {
                                    try
                                    {
                                        return PuedoGenerarInformeAccionesCorrectoras(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                case EstadoAuditoria.BLOQUEADA:
                    {
                        switch (accion)
                        {
                            case AccionAuditoria.GENERAR_INFORME_AUDITORIA:
                                {
                                    DoAction(auditoria, AccionAuditoria.GENERAR_INFORME_AUDITORIA);
                                    return true;
                                }
                            case AccionAuditoria.DESBLOQUEAR:
                                {
                                    try
                                    {
                                        return PuedoDesbloquearAuditoria(auditoria);
                                    }
                                    catch (Exception ex)
                                    { throw ex; }
                                }
                            default:
                                return false;
                        }
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// Función que controla que sólo se puedan modificar los datos de una auditoría si
        /// está en estado CREADA. La única propiedad que se podrá modificar en cualquier otro
        /// estado será "Estado".
        /// </summary>
        /// <param name="estado">Estado de la auditoría</param>
        /// <param name="property">Propiedad de la auditoría que se está intentando modificar</param>
        /// <returns></returns>
        public static bool IsPropertyEnabled(long estado, string property)
        {
            if (estado > (long)EstadoAuditoria.CREADA && property != "Estado" && property != "TipoAuditoria")
                return false;
            return true;
        }

        #endregion

        #region Auxiliar

        public static void SetEstado(Auditoria auditoria, EstadoAuditoria estado, long oid_responsable)
        {
            auditoria.EstadoAuditoria = estado;
            UpdateHistorial(auditoria, oid_responsable);
        }

        public static void SetEstado(Auditoria auditoria, EstadoAuditoria estado, string observaciones, long oid_responsable)
        {
            auditoria.EstadoAuditoria = estado;
            UpdateHistorial(auditoria, observaciones, oid_responsable);
        }

        /// <summary>
        /// Función que irá actualizando el historial de la auditoría
        /// </summary>
        public static void UpdateHistorial(Auditoria auditoria, long oid_responsable)
        {
            string observaciones = string.Empty;
            observaciones = EnumText<EstadoAuditoria>.GetLabel(auditoria.EstadoAuditoria);

            HistoriaAuditoria historia = HistoriaAuditoria.NewChild(auditoria, oid_responsable,
                observaciones, auditoria.Estado);

            auditoria.Historial.AddItem(historia);
        }

        /// <summary>
        /// Función que irá actualizando el historial de la auditoría
        /// No se llama porque se haya cambiado el estado de la auditoría, sin embargo se han producido 
        /// cambios y hay que registrarlos.
        /// </summary>
        public static void UpdateHistorial(Auditoria auditoria, string observaciones, long oid_responsable)
        {
            HistoriaAuditoria historia = HistoriaAuditoria.NewChild(auditoria, oid_responsable,
                observaciones, auditoria.Estado);

            auditoria.Historial.AddItem(historia);
        }

        /// <summary>
        /// Devuelve la auditoría al estado anterior al actual en función de la información del historial
        /// </summary>
        /// <param name="auditoria"></param>
        public static void RevertAuditoria(Auditoria auditoria, long oid_responsable, bool borrado)
        {
            for (int i = auditoria.Historial.Count - 1; i > 0; i--)
            {
                if (auditoria.Historial[i].EstadoAuditoria != EstadoAuditoria.BLOQUEADA)
                {
                    if (borrado)
                        auditoria.Historial.RemoveAt(i);
                    else
                        SetEstado(auditoria, auditoria.Historial[i - 1].EstadoAuditoria, oid_responsable);
                    break;
                }
            }
        }

        public static void CalculaFechasDebidas(Auditoria auditoria)
        {
            if (auditoria.Informes.Count == 0) return;
            DateTime fecha_comunicacion = DateTime.Today;
            SchemaSettingList variables_esquema = SchemaSettingList.GetList();
            InformeDiscrepancia informe = auditoria.Informes[auditoria.Informes.Count - 1];

            for (int i = auditoria.Historial.Count-1; i>=0; i--) 
            {
                HistoriaAuditoria item = auditoria.Historial[i];
                if (item.EstadoAuditoria == EstadoAuditoria.DISCREPANCIAS_NOTIFICADAS)
                {
                    fecha_comunicacion = item.Fecha;
                    break;
                }
            }

            foreach (Discrepancia item in informe.Discrepancias)
            {
                SchemaSettingInfo variable = null;

                switch (item.Nivel)
                {
                    case 1:
                        {
                            variable = variables_esquema.GetItem("PLAZO_MAXIMO_DISCREPANCIAS_N1");
                        }
                        break;
                    case 2:
                        {
                            variable = variables_esquema.GetItem("PLAZO_MAXIMO_DISCREPANCIAS_N2");
                        }
                        break;
                    case 3:
                        {
                            variable = variables_esquema.GetItem("PLAZO_MAXIMO_DISCREPANCIAS_N3");
                        }
                        break;
                    default:
                        continue;
                }

                item.FechaDebida = fecha_comunicacion.AddDays(Convert.ToInt32(variable.Value));
 
            }
        }

        public static string DevuelveExtensionReferencia(AuditoriaPrint auditoria)
        {
            int informes = 0;

            foreach (HistoriaAuditoriaInfo historia in auditoria.Historial)
            {
                if (historia.EstadoAuditoria == EstadoAuditoria.INFORME_GENERADO)
                    informes++;
            }

            if (informes == 0) return string.Empty;

            char ext = (char)(informes + 64);
            
            return ext.ToString();
        }

        #endregion


    }
}
