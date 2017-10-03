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
    public class InformeCorrectorInfo : ReadOnlyBaseEx<InformeCorrectorInfo>, IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return Titulo; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(InformeCorrector); } }

        #endregion

        #region Attributes

        protected InformeCorrectorBase _base = new InformeCorrectorBase();

        private AccionCorrectoraList _acciones = null;
        private NotificacionInternaList _notificaciones = null;


        #endregion

        #region Properties

        public InformeCorrectorBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInformeDiscrepancia { get { return _base.Record.OidInformeDiscrepancia; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public bool Notificado { get { return _base.Record.Notificado; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public DateTime FechaCreacion { get { return _base.Record.FechaCreacion; } }
        public DateTime FechaComunicacion { get { return _base.Record.FechaComunicacion; } }
        public string Numero { get { return _base.Record.Numero; } }

        public AccionCorrectoraList Acciones { get { return _acciones; } }
        public NotificacionInternaList Notificaciones { get { return _notificaciones; } }



        #endregion

        #region Business Methods

        public void CopyFrom(InformeCorrector source) { _base.CopyValues(source); }

        public InformeCorrectorPrint GetPrintObject(InformeDiscrepanciaInfo informe)
        {
            return InformeCorrectorPrint.New(this, informe);
        }

        #endregion		

        #region Factory Methods

        protected InformeCorrectorInfo() { /* require use of factory methods */ }

        private InformeCorrectorInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal InformeCorrectorInfo(InformeCorrector source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _acciones = source.Acciones != null ? AccionCorrectoraList.GetChildList(source.Acciones) : null;
                _notificaciones = source.Notificaciones != null ? NotificacionInternaList.GetChildList(source.Notificaciones) : null;
            }
        }
        

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static InformeCorrectorInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static InformeCorrectorInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = InformeCorrector.GetCriteria(InformeCorrector.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            InformeCorrectorInfo obj = DataPortal.Fetch<InformeCorrectorInfo>(criteria);
            InformeCorrector.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static InformeCorrectorInfo Get(IDataReader reader, bool childs)
        {
            return new InformeCorrectorInfo(reader, childs);
        }

        public static InformeCorrectorInfo New(long oid = 0) { return new InformeCorrectorInfo() { Oid = oid }; }

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

                    InformeCorrector.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = InformeCorrector.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;
                        //AccionCorrectora.LOCK( Session());

                        query = AccionesCorrectoras.SELECT_BY_INFORME_CORRECTOR(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _acciones = AccionCorrectoraList.GetChildList(reader);

                        query = NotificacionesInternas.SELECT_BY_INFORME_CORRECTOR(this.Oid, TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS);

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

                    query = AccionesCorrectoras.SELECT_BY_INFORME_CORRECTOR(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _acciones = AccionCorrectoraList.GetChildList(reader);

                    query = NotificacionesInternas.SELECT_BY_INFORME_CORRECTOR(this.Oid, TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS);
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
    public class SerialInformeCorrectorInfo : SerialInfo
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
        protected SerialInformeCorrectorInfo() { /* require use of factory methods */ }

        #endregion

        #region Root Factory Methods

        /// <summary>
        /// Obtiene el último serial de la entidad desde la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/>Construido a partir del registro</returns>
        public static SerialInformeCorrectorInfo Get(long oid_informe_discrepancia)
        {
            CriteriaEx criteria = InformeCorrector.GetCriteria(InformeCorrector.OpenSession());
            criteria.Childs = false;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = SELECT(oid_informe_discrepancia);

            SerialInformeCorrectorInfo obj = DataPortal.Fetch<SerialInformeCorrectorInfo>(criteria);
            InformeCorrector.CloseSession(criteria.SessionCode);
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
            string i = nHManager.Instance.GetSQLTable(typeof(InformeCorrectorRecord));
            string query;

            query = "SELECT MAX(\"SERIAL\") AS \"SERIAL\"" +
                    " FROM " + i + " AS I" +
                    " WHERE I.\"OID_INFORME_DISCREPANCIA\" = " + oid_informe_discrepancia.ToString();

            return query;
        }

        #endregion

    }
}

