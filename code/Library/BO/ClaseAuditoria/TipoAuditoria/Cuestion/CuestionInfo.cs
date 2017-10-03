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
    public class CuestionInfo : ReadOnlyBaseEx<CuestionInfo>
    {
        #region Attributes

        protected CuestionBase _base = new CuestionBase();

        private CuestionAuditoriaList _cuestiones = null;


        #endregion

        #region Properties

        public CuestionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidTipoAuditoria { get { return _base.Record.OidTipoAuditoria; } }
        public long Numero { get { return _base.Record.Numero; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string Nota { get { return _base.Record.Nota; } }
        public string Referencias { get { return _base.Record.Referencias; } }

        public virtual CuestionAuditoriaList Cuestiones { get { return _cuestiones; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Cuestion source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected CuestionInfo() { /* require use of factory methods */ }

        private CuestionInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal CuestionInfo(Cuestion source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
                _cuestiones = source.Cuestiones != null ? CuestionAuditoriaList.GetChildList(source.Cuestiones) : null;
        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static CuestionInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static CuestionInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Cuestion.GetCriteria(Cuestion.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            CuestionInfo obj = DataPortal.Fetch<CuestionInfo>(criteria);
            Cuestion.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static CuestionInfo Get(IDataReader reader, bool childs)
        {
            return new CuestionInfo(reader, childs);
        }

        public static CuestionInfo New(long oid = 0) { return new CuestionInfo() { Oid = oid }; }

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

                    //Cuestion.LOCK( Session());

                    IDataReader reader = Cuestion.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;
                        //CuestionAuditoria.LOCK( Session());

                        query = CuestionesAuditoria.SELECT_BY_CUESTION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cuestiones = CuestionAuditoriaList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((CuestionRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = CuestionAuditoria.GetCriteria(criteria.Session);
                        criteria.AddEq("OidCuestion", this.Oid);
                        _cuestiones = CuestionAuditoriaList.GetChildList(criteria.List<CuestionAuditoria>());
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

                    query = CuestionesAuditoria.SELECT_BY_CUESTION(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _cuestiones = CuestionAuditoriaList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}

