using System;
using System.Collections.Generic;

using moleQule.Library;
using moleQule.Library.Common;

namespace moleQule.Library.Quality
{
    #region Querys

    public class QueryConditions : moleQule.Library.QueryConditions
    {
        public long Oid = 0;
        public ETipoEntidad EntityType = ETipoEntidad.Todos;
        public EEstado[] Status = null;

        public BankAccountInfo CuentaBancaria = null;
        public Modelo Modelo = null;
        public CreditCardInfo TarjetaCredito = null;
        public UserInfo Usuario = null;

        public EEstado Estado = EEstado.Todos;
        public Common.EMedioPago MedioPago = Common.EMedioPago.Todos;
        public EModelo EModelo = EModelo.Modelo111;

        public List<EMedioPago> MedioPagoList = null;

        public ActaComiteInfo ActaComite = null;
        public AuditoriaInfo Auditoria = null;
        public ClaseAuditoriaInfo ClaseAuditoria = null;
        public CuestionInfo Cuestion = null;
        public DiscrepanciaInfo Discrepancia = null;
        public InformeAmpliacionInfo InformeAmpliacion = null;
        public InformeCorrectorInfo InformeCorrector = null;
        public InformeDiscrepanciaInfo InformeDiscrepancia = null;
        public TipoAuditoriaInfo TipoAuditoria = null;
        public TipoNotificacionAsociado TipoNotificacionAsociado = TipoNotificacionAsociado.Todos;

        public static Common.QueryConditions ConvertToCommonQuery(Store.QueryConditions conditions)
        {
            Common.QueryConditions conds = new Common.QueryConditions
            {
                Oid = conditions.Oid,
                EntityType = conditions.EntityType,
                Status = conditions.Status,

                FechaIni = conditions.FechaIni,
                FechaFin = conditions.FechaFin,
                FechaAuxIni = conditions.FechaAuxIni,
                FechaAuxFin = conditions.FechaAuxFin,
                Estado = conditions.Estado
            };

            return conds;
        }
    }

    public delegate string SelectCaller(QueryConditions conditions);

    #endregion

    #region Enums

    /// <summary>
    /// Estados en los que puede estar una auditoría
    /// </summary>
    public enum EstadoAuditoria
    {
        CREADA = 1,
        COMUNICADA = 2,
        EN_PROCESO = 3,
        INFORME_GENERADO = 4,
        DISCREPANCIAS = 5,
        DISCREPANCIAS_NOTIFICADAS = 6,
        DISCREPANCIAS_RESUELTAS = 7,
        ACCIONES_CORRECTORAS_NOTIFICADAS = 8,
        SIN_DISCREPANCIAS = 9,
        FINALIZADA = 10,
        AMPLIACION_SOLICITADA = 11,
        AMPLIACION_DENEGADA = 12,
        AMPLIADA = 13,
        BLOQUEADA = 14,
    }

    /// <summary>
    /// Enum de las acciones que es posible realizar sobre una auditoría
    /// </summary>
    public enum AccionAuditoria
    {
        DAR_ALTA = 1,
        COMUNICAR = 2,
        INICIAR = 3,
        GENERAR_INFORME_AUDITORIA = 4,
        GENERAR_INFORME_DISCREPANCIAS = 5,
        NOTIFICAR_DISCREPANCIAS = 6,
        APROBAR_AUDITORIA = 7,
        NOTIFICAR_FIN_AUDITORIA = 8,
        GENERAR_INFORME_ACCIONES_CORRECTORAS = 9,
        GENERAR_INFORME_AMPLIACION = 10,
        NOTIFICAR_DENEGACION_AMPLIACION = 11,
        NOTIFICAR_CONCESION_AMPLIACION = 12,
        NOTIFICAR_INFORME_ACCIONES_CORRECTORAS = 13,
        DESBLOQUEAR = 14,
        EDITAR_INFORME_DISCREPANCIAS = 15,
        EDITAR_INFORME_ACCIONES_CORRECTORAS = 16,
        BORRAR_INFORME_DISCREPANCIAS = 17,
        BORRAR_INFORME_ACCIONES_CORRECTORAS = 18,
        BORRAR_INFORME_AMPLIACION = 19,
    }


    /// <summary>
    /// Enum de las acciones que es posible realizar sobre una auditoría
    /// </summary>
    public enum TipoNotificacionAsociado
    {
        Todos = 0,
        COMUNICADO_AUDITORIA = 1,
        INFORME_DISCREPANCIAS = 2,
        INFORME_ACCIONES_CORRECTORAS = 3,
        INFORME_FIN_AUDITORIA = 4,
        SOLICITUD_AMPLIACION = 5,
        CONCESION_AMPLIACION = 6,
        DENEGACION_AMPLIACION = 7,
    }

    public class EnumText<T> : EnumTextBase<T>
    {
        public static ComboBoxList<T> GetList()
        {
            return GetList(Resources.Enums.ResourceManager);
        }

        public static string GetLabel(object value)
        {
            return GetLabel(Resources.Enums.ResourceManager, value);
        }
    }
    #endregion
}
