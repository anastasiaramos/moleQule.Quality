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
    public class InformeAmpliacionInfo : ReadOnlyBaseEx<InformeAmpliacionInfo>, IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return Titulo; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(InformeAmpliacion); } }

        #endregion

        #region Attributes

        protected InformeAmpliacionBase _base = new InformeAmpliacionBase();

        private AmpliacionList _ampliaciones = null;
        private NotificacionInternaList _notificaciones = null;


        #endregion

        #region Properties

        public InformeAmpliacionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInformeDiscrepancia { get { return _base.Record.OidInformeDiscrepancia; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public bool Notificado { get { return _base.Record.Notificado; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public DateTime FechaCreacion { get { return _base.Record.FechaCreacion; } }
        public bool Valorado { get { return _base.Record.Valorado; } }
        public DateTime FechaComunicacion { get { return _base.Record.FechaComunicacion; } }
        public string Numero { get { return _base.Record.Numero; } }

        public AmpliacionList Ampliaciones { get { return _ampliaciones; } }
        public NotificacionInternaList Notificaciones { get { return _notificaciones; } }



        #endregion

        #region Business Methods

        public void CopyFrom(InformeAmpliacion source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected InformeAmpliacionInfo() { /* require use of factory methods */ }

        private InformeAmpliacionInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal InformeAmpliacionInfo(InformeAmpliacion source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _ampliaciones = source.Ampliaciones != null ? AmpliacionList.GetChildList(source.Ampliaciones) : null;
                _notificaciones = source.Notificaciones != null ? NotificacionInternaList.GetChildList(source.Notificaciones) : null;
            }
        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static InformeAmpliacionInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static InformeAmpliacionInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = InformeAmpliacion.GetCriteria(InformeAmpliacion.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            InformeAmpliacionInfo obj = DataPortal.Fetch<InformeAmpliacionInfo>(criteria);
            InformeAmpliacion.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static InformeAmpliacionInfo Get(IDataReader reader, bool childs)
        {
            return new InformeAmpliacionInfo(reader, childs);
        }

        public static InformeAmpliacionInfo New(long oid = 0) { return new InformeAmpliacionInfo() { Oid = oid }; }

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

                    InformeAmpliacion.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = InformeAmpliacion.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;
                        //Ampliacion.LOCK( Session());

                        query = Quality.Ampliaciones.SELECT_BY_INFORME_AMPLIACION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _ampliaciones = AmpliacionList.GetChildList(reader);

                        query = NotificacionesInternas.SELECT_BY_INFORME_AMPLIACION(this.Oid, TipoNotificacionAsociado.SOLICITUD_AMPLIACION);

                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _notificaciones = NotificacionInternaList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((InformeAmpliacionRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = Ampliacion.GetCriteria(criteria.Session);
                        criteria.AddEq("OidInformeAmpliacion", this.Oid);
                        _ampliaciones = AmpliacionList.GetChildList(criteria.List<Ampliacion>());

                        criteria = NotificacionInterna.GetCriteria(criteria.Session);
                        criteria.AddEq("OidAsociado", this.Oid);
                        criteria.AddEq("TipoAsociado", (long)TipoNotificacionAsociado.SOLICITUD_AMPLIACION);
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

                    query = Quality.Ampliaciones.SELECT_BY_INFORME_AMPLIACION(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _ampliaciones = AmpliacionList.GetChildList(reader);

                    query = NotificacionesInternas.SELECT_BY_INFORME_AMPLIACION(this.Oid, TipoNotificacionAsociado.SOLICITUD_AMPLIACION);

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
    public class SerialInformeAmpliacionInfo : SerialInfo
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
        protected SerialInformeAmpliacionInfo() { /* require use of factory methods */ }

        #endregion

        #region Root Factory Methods

        /// <summary>
        /// Obtiene el último serial de la entidad desde la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static SerialInformeAmpliacionInfo Get(long oid_informe_discrepancia)
        {
            CriteriaEx criteria = InformeAmpliacion.GetCriteria(InformeAmpliacion.OpenSession());
            criteria.Childs = false;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = SELECT(oid_informe_discrepancia);

            SerialInformeAmpliacionInfo obj = DataPortal.Fetch<SerialInformeAmpliacionInfo>(criteria);
            InformeAmpliacion.CloseSession(criteria.SessionCode);
            return obj;
        }

        /// <summary>
        /// Obtiene el siguiente serial para una entidad desde la base de datos
        /// </summary>
        /// <param name="entity">Tipo de Entidad</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static long GetNext(long oid_informe_discrepancia)
        {
            return Get(oid_informe_discrepancia).Value + 1;
        }

        #endregion

        #region Root Data Access

        #endregion

        #region SQL

        public static string SELECT(long oid_informe_discrepancia)
        {
            string i = nHManager.Instance.GetSQLTable(typeof(InformeAmpliacionRecord));
            string query;

            query = "SELECT MAX(\"SERIAL\") AS \"SERIAL\"" +
                    " FROM " + i + " AS I" +
                    " WHERE I.\"OID_INFORME_DISCREPANCIA\" = " + oid_informe_discrepancia.ToString();

            return query;
        }

        #endregion

    }
}

