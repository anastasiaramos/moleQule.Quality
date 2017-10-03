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
    public class TipoAuditoriaInfo : ReadOnlyBaseEx<TipoAuditoriaInfo>
    {
        #region Attributes

        protected TipoAuditoriaBase _base = new TipoAuditoriaBase();

        private CriterioList _criterios = null;
        private CuestionList _cuestiones = null;
        private Auditoria_AreaList _areas = null;
        private Plan_TipoList _planes_tipos = null;


        #endregion

        #region Properties

        public TipoAuditoriaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidClaseAuditoria { get { return _base.Record.OidClaseAuditoria; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Documentacion { get { return _base.Record.Documentacion; } }
        public string Apreciaciones { get { return _base.Record.Apreciaciones; } }
        public string Numero { get { return _base.Record.Numero; } }
        public bool Enero { get { return _base.Record.Enero; } }
        public bool Febrero { get { return _base.Record.Febrero; } }
        public bool Marzo { get { return _base.Record.Marzo; } }
        public bool Abril { get { return _base.Record.Abril; } }
        public bool Mayo { get { return _base.Record.Mayo; } }
        public bool Junio { get { return _base.Record.Junio; } }
        public bool Julio { get { return _base.Record.Julio; } }
        public bool Agosto { get { return _base.Record.Agosto; } }
        public bool Septiembre { get { return _base.Record.Septiembre; } }
        public bool Octubre { get { return _base.Record.Octubre; } }
        public bool Noviembre { get { return _base.Record.Noviembre; } }
        public bool Diciembre { get { return _base.Record.Diciembre; } }
        public string TextoInforme { get { return _base.Record.TextoInforme; } }


        public virtual CriterioList Criterios { get { return _criterios; } }
        public virtual CuestionList Cuestiones { get { return _cuestiones; } }
        public virtual Auditoria_AreaList Areas { get { return _areas; } }
        public virtual Plan_TipoList Planes_Tipos { get { return _planes_tipos; } }



        #endregion

        #region Business Methods

        public void CopyFrom(TipoAuditoria source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected TipoAuditoriaInfo() { /* require use of factory methods */ }

        private TipoAuditoriaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal TipoAuditoriaInfo(TipoAuditoria source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _criterios = source.Criterios != null ? CriterioList.GetChildList(source.Criterios) : null;
                _areas = source.Areas != null ? Auditoria_AreaList.GetChildList(source.Areas) : null;
                _cuestiones = source.Cuestiones != null ? CuestionList.GetChildList(source.Cuestiones) : null;
                _planes_tipos = source.PlanesTipos != null ? Plan_TipoList.GetChildList(source.PlanesTipos) : null;
            }
        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static TipoAuditoriaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static TipoAuditoriaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = TipoAuditoria.GetCriteria(TipoAuditoria.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            TipoAuditoriaInfo obj = DataPortal.Fetch<TipoAuditoriaInfo>(criteria);
            TipoAuditoria.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static TipoAuditoriaInfo Get(IDataReader reader, bool childs)
        {
            return new TipoAuditoriaInfo(reader, childs);
        }

        public static TipoAuditoriaInfo New(long oid = 0) { return new TipoAuditoriaInfo() { Oid = oid }; }

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

                    TipoAuditoria.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = TipoAuditoria.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;

                        //Criterio.LOCK( Session());

                        query = Quality.Criterios.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _criterios = CriterioList.GetChildList(reader);

                        //Auditoria_Area.LOCK( Session());

                        query = Auditorias_Areas.SELECT_BY_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _areas = Auditoria_AreaList.GetChildList(reader);
                        
                        //Cuestion.LOCK( Session());

                        query = Quality.Cuestiones.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cuestiones = CuestionList.GetChildList(reader);

                        query = Quality.Planes_Tipos.SELECT_BY_FIELD("OidTipo", this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _planes_tipos = Plan_TipoList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((TipoAuditoriaRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = Criterio.GetCriteria(criteria.Session);
                        criteria.AddEq("OidTipoAuditoria", this.Oid);
                        _criterios = CriterioList.GetChildList(criteria.List<Criterio>());

                        criteria = Auditoria_Area.GetCriteria(criteria.Session);
                        criteria.AddEq("OidAuditoria", this.Oid);
                        _areas = Auditoria_AreaList.GetChildList(criteria.List<Auditoria_Area>());

                        criteria = Cuestion.GetCriteria(criteria.Session);
                        criteria.AddEq("OidTipoAuditoria", this.Oid);
                        _cuestiones = CuestionList.GetChildList(criteria.List<Cuestion>());

                        criteria = Plan_Tipo.GetCriteria(criteria.Session);
                        criteria.AddEq("OidTipo", this.Oid);
                        _planes_tipos = Plan_TipoList.GetChildList(criteria.List<Plan_Tipo>());
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

                    query = Quality.Criterios.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _criterios = CriterioList.GetChildList(reader);

                    query = Auditorias_Areas.SELECT_BY_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _areas = Auditoria_AreaList.GetChildList(reader);

                    query = Quality.Cuestiones.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _cuestiones = CuestionList.GetChildList(reader);

                    query = Quality.Planes_Tipos.SELECT_BY_FIELD("OidTipo", this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _planes_tipos = Plan_TipoList.GetChildList(reader);
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

