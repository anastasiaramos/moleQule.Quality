using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Quality
{

    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class InformeDiscrepanciaInfo : ReadOnlyBaseEx<InformeDiscrepanciaInfo>, IAgenteHipatia
    {

        #region IAgenteHipatia

        public string NombreHipatia { get { return Titulo; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(InformeDiscrepancia); } }

        #endregion

        #region Attributes

        protected InformeDiscrepanciaBase _base = new InformeDiscrepanciaBase();

        private InformeAmpliacionList _ampliaciones = null;
        private InformeCorrectorList _correctores = null;
        private DiscrepanciaList _discrepancias = null;
        private NotificacionInternaList _notificaciones = null;


        #endregion

        #region Properties

        public InformeDiscrepanciaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAuditoria { get { return _base.Record.OidAuditoria; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public bool Notificado { get { return _base.Record.Notificado; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public DateTime FechaCreacion { get { return _base.Record.FechaCreacion; } }
        public DateTime FechaComunicacion { get { return _base.Record.FechaComunicacion; } }
        public string Numero { get { return _base.Record.Numero; } }

        public virtual InformeAmpliacionList Ampliaciones { get { return _ampliaciones; } }
        public virtual InformeCorrectorList Correctores { get { return _correctores; } }
        public virtual DiscrepanciaList Discrepancias { get { return _discrepancias; } }
        public virtual NotificacionInternaList Notificaciones { get { return _notificaciones; } }



        #endregion

        #region Business Methods

        public void CopyFrom(InformeDiscrepancia source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected InformeDiscrepanciaInfo() { /* require use of factory methods */ }

        private InformeDiscrepanciaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal InformeDiscrepanciaInfo(InformeDiscrepancia source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _ampliaciones = source.Ampliaciones != null ? InformeAmpliacionList.GetChildList(source.Ampliaciones) : null;
                _correctores = source.Correctores != null ? InformeCorrectorList.GetChildList(source.Correctores) : null;
                _discrepancias = source.Discrepancias != null ? DiscrepanciaList.GetChildList(source.Discrepancias) : null;
                _notificaciones = source.Notificaciones != null ? NotificacionInternaList.GetChildList(source.Notificaciones) : null;
            }
        }

        public static InformeDiscrepanciaInfo New(long oid = 0) { return new InformeDiscrepanciaInfo() { Oid = oid }; }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static InformeDiscrepanciaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static InformeDiscrepanciaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = InformeDiscrepancia.GetCriteria(InformeDiscrepancia.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            InformeDiscrepanciaInfo obj = DataPortal.Fetch<InformeDiscrepanciaInfo>(criteria);
            InformeDiscrepancia.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static InformeDiscrepanciaInfo Get(IDataReader reader, bool childs)
        {
            return new InformeDiscrepanciaInfo(reader, childs);
        }

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

                    InformeDiscrepancia.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = InformeDiscrepancia.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;

                        query = InformesAmpliaciones.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _ampliaciones = InformeAmpliacionList.GetChildList(reader);
                        
                        query = InformesCorrectores.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _correctores = InformeCorrectorList.GetChildList(reader);

                        query = Quality.Discrepancias.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _discrepancias = DiscrepanciaList.GetChildList(reader);

                        query = Quality.NotificacionesInternas.SELECT_BY_INFORME_DISCREPANCIA(this.Oid, TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _notificaciones = NotificacionInternaList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((InformeDiscrepanciaRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = InformeAmpliacion.GetCriteria(criteria.Session);
                        criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                        _ampliaciones = InformeAmpliacionList.GetChildList(criteria.List<InformeAmpliacion>());

                        criteria = InformeCorrector.GetCriteria(criteria.Session);
                        criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                        _correctores = InformeCorrectorList.GetChildList(criteria.List<InformeCorrector>());

                        criteria = Discrepancia.GetCriteria(criteria.Session);
                        criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                        _discrepancias = DiscrepanciaList.GetChildList(criteria.List<Discrepancia>());

                        criteria = NotificacionInterna.GetCriteria(criteria.Session);
                        criteria.AddEq("OidAsociado", this.Oid);
                        criteria.AddEq("TipoAsociado", (long)TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
                        _notificaciones = NotificacionInternaList.GetChildList(criteria.List<NotificacionInterna>());
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

                    query = InformesAmpliaciones.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _ampliaciones = InformeAmpliacionList.GetChildList(reader);

                    query = InformesCorrectores.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _correctores = InformeCorrectorList.GetChildList(reader);

                    query = Quality.Discrepancias.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _discrepancias = DiscrepanciaList.GetChildList(reader);

                    query = Quality.NotificacionesInternas.SELECT_BY_INFORME_DISCREPANCIA(this.Oid, TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
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

    }


    /// <summary>
    /// ReadOnly Root Object
    /// </summary>
    [Serializable()]
    public class SerialInformeDiscrepanciaInfo : SerialInfo
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
        protected SerialInformeDiscrepanciaInfo() { /* require use of factory methods */ }

        #endregion

        #region Root Factory Methods

        /// <summary>
        /// Obtiene el último serial de la entidad desde la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static SerialInformeDiscrepanciaInfo Get(long oid_auditoria)
        {
            CriteriaEx criteria = InformeDiscrepancia.GetCriteria(InformeDiscrepancia.OpenSession());
            criteria.Childs = false;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = SELECT(oid_auditoria);

            SerialInformeDiscrepanciaInfo obj = DataPortal.Fetch<SerialInformeDiscrepanciaInfo>(criteria);
            InformeDiscrepancia.CloseSession(criteria.SessionCode);
            return obj;
        }

        /// <summary>
        /// Obtiene el siguiente serial para una entidad desde la base de datos
        /// </summary>
        /// <param name="entity">Tipo de Entidad</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static long GetNext(long oid_auditoria)
        {
            return Get(oid_auditoria).Value + 1;
        }

        #endregion

        #region Root Data Access

        #endregion

        #region SQL

        public static string SELECT(long oid_auditoria)
        {
            string i = nHManager.Instance.GetSQLTable(typeof(InformeDiscrepanciaRecord));
            string query;

            query = "SELECT MAX(\"SERIAL\") AS \"SERIAL\"" +
                    " FROM " + i + " AS I" +
                    " WHERE I.\"OID_AUDITORIA\" = " + oid_auditoria.ToString();

            return query;
        }

        #endregion

    }
}

