using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Quality
{

    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class AuditoriaInfo : ReadOnlyBaseEx<AuditoriaInfo>, IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return Referencia; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(Auditoria); } }

        #endregion

        #region Attributes

        protected AuditoriaBase _base = new AuditoriaBase();

        protected CuestionAuditoriaList _cuestiones = null;
        protected InformeDiscrepanciaList _informes = null;
        protected HistoriaAuditoriaList _historial = null;
        protected NotificacionInternaList _notificaciones = null;


        #endregion

        #region Properties

        public AuditoriaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAuditor { get { return _base.Record.OidAuditor; } }
        public long OidTipoAuditoria { get { return _base.Record.OidTipoAuditoria; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public DateTime FechaInicio { get { return _base.Record.FechaInicio; } }
        public DateTime FechaFin { get { return _base.Record.FechaFin; } }
        public string Referencia { get { return _base.Record.Referencia; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long OidPlan { get { return _base.Record.OidPlan; } }
        public long Estado { get { return _base.Record.Estado; } }
        public long OidResponsable { get { return _base.Record.OidResponsable; } }
        public long OidUsuarioAuditor { get { return _base.Record.OidUsuarioAuditor; } }
        public long OidUsuarioResponsable { get { return _base.Record.OidUsuarioResponsable; } }
        public long OidDepartamentoAuditor { get { return _base.Record.OidDepartamentoAuditor; } }
        public long OidDepartamentoResponsable { get { return _base.Record.OidDepartamentoResponsable; } }
        public long OidPlanTipo { get { return _base.Record.OidPlanTipo; } }
        public DateTime FechaComunicacion { get { return _base.Record.FechaComunicacion; } }
        
        public virtual CuestionAuditoriaList Cuestiones { get { return _cuestiones; } }
        public virtual InformeDiscrepanciaList Informes { get { return _informes; } }
        public virtual HistoriaAuditoriaList Historial { get { return _historial; } }
        public virtual NotificacionInternaList Notificaciones { get { return _notificaciones; } }

        public EstadoAuditoria EstadoAuditoria { get { return (EstadoAuditoria)_base.EstadoAuditoria; } }
        public string EstadoAuditoriaLabel { get { return EnumText<EstadoAuditoria>.GetLabel((EstadoAuditoria)_base.EstadoAuditoria); } }
        public string Auditor { get { return _base.Auditor; } }
        public string Responsable { get { return _base.Responsable; } }
        public string PlanAnual { get { return _base.PlanAnual; } }
        public string TipoAuditoria { get { return _base.TipoAuditoria; } }


        #endregion

        #region Business Methods

        public void CopyFrom(Auditoria source) { _base.CopyValues(source); }

        public AuditoriaPrint GetPrintObject(ClaseAuditoriaInfo clase, TipoAuditoriaInfo tipo, CompanyInfo empresa)
        {
            return AuditoriaPrint.New(this, clase, tipo, empresa);
        }


        #endregion		

        #region Factory Methods

        protected AuditoriaInfo() { /* require use of factory methods */ }

        private AuditoriaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal AuditoriaInfo(Auditoria item, bool copy_childs)
        {
            _base.CopyValues(item);

        	if (copy_childs)
			{
                _cuestiones = (item.Cuestiones != null) ? CuestionAuditoriaList.GetChildList(item.Cuestiones) : null;
                _informes = (item.Informes != null) ? InformeDiscrepanciaList.GetChildList(item.Informes) : null;
                _historial = (item.Historial != null) ? HistoriaAuditoriaList.GetChildList(item.Historial) : null;
                _notificaciones = (item.Notificaciones != null) ? NotificacionInternaList.GetChildList(item.Notificaciones) : null;
			}
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static AuditoriaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static AuditoriaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = childs;

            criteria.Query = AuditoriaInfo.SELECT(oid);

            AuditoriaInfo obj = DataPortal.Fetch<AuditoriaInfo>(criteria);
            Auditoria.CloseSession(criteria.SessionCode);
            return obj;
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static AuditoriaInfo Get(IDataReader reader, bool childs)
        {
            return new AuditoriaInfo(reader, childs);
        }

        public static AuditoriaInfo New(long oid = 0) { return new AuditoriaInfo() { Oid = oid }; }

        #endregion

        #region Data Access

        // called to retrieve data from db
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;
                        
                        query = CuestionesAuditoria.SELECT_BY_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cuestiones = CuestionAuditoriaList.GetChildList(reader);

                        query = InformesDiscrepancias.SELECT_BY_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _informes = InformeDiscrepanciaList.GetChildList(reader);

                        query = HistoriaAuditoriaList.SELECT_BY_AUDITORIA(Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _historial = HistoriaAuditoriaList.GetChildList(reader);

                        query = NotificacionesInternas.SELECT_BY_AUDITORIA(this.Oid, TipoNotificacionAsociado.COMUNICADO_AUDITORIA);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _notificaciones = NotificacionInternaList.GetChildList(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        //called to copy data from IDataReader
        private void Fetch(IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

                if (Childs)
                {
                    string query = string.Empty;
                    IDataReader reader;

                    query = CuestionesAuditoria.SELECT_BY_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _cuestiones = CuestionAuditoriaList.GetChildList(reader);

                    query = InformesDiscrepancias.SELECT_BY_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _informes = InformeDiscrepanciaList.GetChildList(reader);

                    query = HistoriaAuditoriaList.SELECT_BY_AUDITORIA(Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _historial = HistoriaAuditoriaList.GetChildList(reader);

                    query = NotificacionesInternas.SELECT_BY_AUDITORIA(this.Oid, TipoNotificacionAsociado.COMUNICADO_AUDITORIA);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _notificaciones = NotificacionInternaList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        public static string SELECT(long oid) { return Auditoria.SELECT(oid, false); }

        #endregion
 
   }

   /// <summary>
   /// ReadOnly Root Object
   /// </summary>
   [Serializable()]
    public class SerialAuditoriaInfo : SerialInfo
   {
       #region Attributes

       #endregion

       #region Properties

       #endregion

       #region Business Methods

       #endregion

       #region Common Factory Methods

       /// <summary>
       /// Constructor
       /// </summary>
       /// <remarks>
       ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
       /// </remarks>
       protected SerialAuditoriaInfo() { /* require use of factory methods */ }

       #endregion

       #region Root Factory Methods

       /// <summary>
       /// Obtiene el último serial de la entidad desde la base de datos
       /// </summary>
       /// <param name="oid">Oid del objeto</param>
       /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static SerialAuditoriaInfo Get(long year)
       {
           CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
           criteria.Childs = false;

           if (nHManager.Instance.UseDirectSQL)
               criteria.Query = SELECT(year);

           SerialAuditoriaInfo obj = DataPortal.Fetch<SerialAuditoriaInfo>(criteria);
           Auditoria.CloseSession(criteria.SessionCode);
           return obj;
       }

       /// <summary>
       /// Obtiene el siguiente serial para una entidad desde la base de datos
       /// </summary>
       /// <param name="entity">Tipo de Entidad</param>
       /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
       public static long GetNext(long year)
       {
           return Get(year).Value + 1;
       }

       #endregion

       #region Root Data Access

       #endregion

       #region SQL

       public static string SELECT(long year)
       {
           string a = nHManager.Instance.GetSQLTable(typeof(AuditoriaRecord));
           string query;

           query = "SELECT MAX(\"SERIAL\") AS \"SERIAL\"" +
                   " FROM " + a + " AS A" +
                   " WHERE to_char(A.\"FECHA_INICIO\", 'YYYY') = '" + year.ToString() + "'";

           return query;
       }

       #endregion

   }
}

