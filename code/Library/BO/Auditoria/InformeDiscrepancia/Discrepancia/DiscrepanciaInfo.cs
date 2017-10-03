using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Quality
{
    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class DiscrepanciaInfo : ReadOnlyBaseEx<DiscrepanciaInfo>
    {
        #region Attributes

        protected DiscrepanciaBase _base = new DiscrepanciaBase();

        protected AmpliacionList _ampliaciones = null;
        protected AccionCorrectoraList _correctoras = null;


        #endregion

        #region Properties

        public DiscrepanciaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInforme { get { return _base.Record.OidInforme; } }
        public long Numero { get { return _base.Record.Numero; } }
        public string Texto { get { return _base.Record.Texto; } }
        public long Nivel { get { return _base.Record.Nivel; } }
        public DateTime FechaDebida { get { return _base.Record.FechaDebida; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public DateTime FechaCierre { get { return _base.Record.FechaCierre; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public long OidCuestion { get { return _base.Record.OidCuestion; } }
        public bool EsDiscrepancia { get { return _base.Record.Discrepancia; } }
        public DateTime FechaAmpliacion { get { return _base.Record.FechaAmpliacion; } }

        public AmpliacionList Ampliaciones { get { return _ampliaciones; } }
        public AccionCorrectoraList Correctoras { get { return _correctoras; } }

        public string Numeroinforme { get { return _base.NumeroInforme; } }
        public string NumeroAuditoria { get { return _base.NumeroAuditoria; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Discrepancia source) { _base.CopyValues(source); }

        public DiscrepanciaPrint GetPrintObject(InformeDiscrepanciaInfo informe)
        {
            return DiscrepanciaPrint.New(this, informe);
        }

        #endregion		

        #region Factory Methods

        protected DiscrepanciaInfo() { /* require use of factory methods */ }

        private DiscrepanciaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal DiscrepanciaInfo(Discrepancia item, bool copy_childs)
        {
            _base.CopyValues(item);

        	if (copy_childs)
			{
                _ampliaciones = (item.Ampliaciones != null) ? AmpliacionList.GetChildList(item.Ampliaciones) : null;
                _correctoras = (item.Correctoras != null) ? AccionCorrectoraList.GetChildList(item.Correctoras) : null;
			}
        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static DiscrepanciaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static DiscrepanciaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Discrepancia.GetCriteria(Discrepancia.OpenSession());
            criteria.Childs = childs;

            criteria.Query = DiscrepanciaInfo.SELECT(oid);

            DiscrepanciaInfo obj = DataPortal.Fetch<DiscrepanciaInfo>(criteria);
            Discrepancia.CloseSession(criteria.SessionCode);
            return obj;
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DiscrepanciaInfo Get(IDataReader reader, bool childs)
        {
            return new DiscrepanciaInfo(reader, childs);
        }

        public static DiscrepanciaInfo New(long oid = 0) { return new DiscrepanciaInfo() { Oid = oid }; }

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

                        query = Quality.Ampliaciones.SELECT_BY_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _ampliaciones = AmpliacionList.GetChildList(reader);

                        query = AccionesCorrectoras.SELECT_BY_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _correctoras = AccionCorrectoraList.GetChildList(reader);
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

                    query = Quality.Ampliaciones.SELECT_BY_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _ampliaciones = AmpliacionList.GetChildList(reader);

                    query = AccionesCorrectoras.SELECT_BY_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _correctoras = AccionCorrectoraList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        public static string SELECT(long oid) { return Discrepancia.SELECT(oid, false); }

        #endregion
    }
}


