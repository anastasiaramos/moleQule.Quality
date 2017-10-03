using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Quality
{
	/// <summary>
	/// Read Only Child Collection of Business Objects
	/// </summary>
    [Serializable()]
	public class AuditoriaList : ReadOnlyListBaseEx<AuditoriaList, AuditoriaInfo>
	{

        #region Child Factory Methods

        private AuditoriaList() { }

        public static AuditoriaList NewList() { return new AuditoriaList(); }



        private AuditoriaList(IList<Auditoria> lista)
        {
            Fetch(lista);
        }

        private AuditoriaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a AuditoriaList from a IList<!--<AuditoriaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetChildList(IList<AuditoriaInfo> list)
        {
            AuditoriaList flist = new AuditoriaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (AuditoriaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a AuditoriaList from IList<!--<Auditoria>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetChildList(IList<Auditoria> list) { return new AuditoriaList(list); }

        public static AuditoriaList GetChildList(IDataReader reader) { return new AuditoriaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private AuditoriaList() { }

        public static AuditoriaList GetList()
        {
            return GetList(true);
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetList(bool get_childs)
        {
            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = get_childs;

            criteria.Query = AuditoriaList.SELECT();

            AuditoriaList list = DataPortal.Fetch<AuditoriaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetAbiertasList(long oid_auditoria, long oid_plan, 
            long estado, DateTime fecha_ini, DateTime fecha_fin, DateTime fecha_comunicacion,
            bool f_ini, bool f_fin, bool f_comunicacion)
        {
            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = true;

            criteria.Query = AuditoriaList.SELECT_ABIERTAS(oid_auditoria, oid_plan, estado, fecha_ini, fecha_fin, fecha_comunicacion, f_ini, f_fin, f_comunicacion);

            AuditoriaList list = DataPortal.Fetch<AuditoriaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetAvisoDiscrepanciasAbiertasList(DateTime f_fin)
        {
            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = false;

            criteria.Query = AuditoriaList.SELECT_AVISO_DISCREPANCIAS_ABIERTAS(f_fin);

            AuditoriaList list = DataPortal.Fetch<AuditoriaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetAvisoInformesNoGenerados(DateTime f_fin)
        {
            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = false;

            criteria.Query = AuditoriaList.SELECT_AVISO_INFORMES_NO_GENERADOS(f_fin);

            AuditoriaList list = DataPortal.Fetch<AuditoriaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static AuditoriaList GetList(CriteriaEx criteria)
        {
            return AuditoriaList.RetrieveList(typeof(Auditoria), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a AuditoriaList from a IList<!--<AuditoriaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AuditoriaList</returns>
        public static AuditoriaList GetList(IList<AuditoriaInfo> list)
        {
            AuditoriaList flist = new AuditoriaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (AuditoriaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a AuditoriaList from a IList<!--<Auditoria>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Auditoria</returns>
        public static AuditoriaList GetList(IList<Auditoria> list)
        {
            AuditoriaList flist = new AuditoriaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Auditoria item in list)
                    flist.AddItem(item.GetInfo());

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<AuditoriaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<AuditoriaInfo> sortedList =
                new SortedBindingList<AuditoriaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }


        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>AuditoriaList</returns>
        public static long GetSiguienteTipoAuditoria(long oid_plan)
        {
            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = false;

            criteria.Query = Auditorias.SELECT_BY_PLAN(oid_plan);

            SerialAuditoriaInfo orden = DataPortal.Fetch<SerialAuditoriaInfo>(criteria);

            CloseSession(criteria.SessionCode);

            return orden.Value;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Auditoria> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Auditoria item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(AuditoriaInfo.Get(reader, true));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            Childs = criteria.Childs;
            SessionCode = criteria.SessionCode;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(AuditoriaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region Root Data Access

        // called to retrieve data from db
        protected override void Fetch(string hql)
        {
            this.RaiseListChangedEvents = false;

            try
            {
                IList list = nHMng.HQLSelect(hql);

                if (list.Count > 0)
                {
                    IsReadOnly = false;

                    foreach (Auditoria item in list)
                        this.AddItem(item.GetInfo());

                    IsReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region SQL

        public static string SELECT() { return AuditoriaInfo.SELECT(0); }

        public static string SELECT_ABIERTAS(long oid_auditoria, long oid_plan, long estado,
            DateTime fecha_ini, DateTime fecha_fin, DateTime fecha_comunicacion, bool f_ini, 
            bool f_fin, bool f_comunicacion)
        {
            string query = AuditoriaInfo.SELECT(0);

            query += " WHERE 1=1";
            if (oid_auditoria != -1)
                query += " AND A.\"OID\" = " + oid_auditoria.ToString();
            if (oid_plan != -1)
                query += " AND A.\"OID_PLAN\" = " + oid_plan.ToString();
            if (estado != -1)
                query += " AND A.\"ESTADO\" = " + estado.ToString();
            if (f_ini)
                query += " AND A.\"FECHA_INICIO\" >= '" + fecha_ini.Year.ToString("0000") + "-" +
                fecha_ini.Month.ToString("00") + "-" + fecha_ini.Day.ToString("00") + "'";
            if (f_fin)
                query += " AND A.\"FECHA_FIN\" <= '" + fecha_fin.Year.ToString("0000") + "-" +
                fecha_fin.Month.ToString("00") + "-" + fecha_fin.Day.ToString("00") + "'";
            if (f_comunicacion)
                query += " AND A.\"FECHA_COMUNICACION\" >= '" + fecha_comunicacion.Year.ToString("0000") 
                    + "-" + fecha_comunicacion.Month.ToString("00") + "-" 
                    + fecha_comunicacion.Day.ToString("00") + "'";

            return query;
        }

        public static string SELECT_AVISO_DISCREPANCIAS_ABIERTAS(DateTime f_fin)
        {
            string informe_discrepancia = nHManager.Instance.GetSQLTable(typeof(InformeDiscrepanciaRecord));
            string discrepancia = nHManager.Instance.GetSQLTable(typeof(DiscrepanciaRecord));

            string query = AuditoriaInfo.SELECT(0);

            query += " INNER JOIN " + informe_discrepancia + " AS ID ON (ID.\"OID_AUDITORIA\" = A.\"OID\")";
            query += " INNER JOIN " + discrepancia + " AS D ON (D.\"OID_INFORME\" = ID.\"OID\")";
            query += " WHERE D.\"FECHA_CIERRE\"  = '9999-12-31'";
            query += " AND D.\"FECHA_DEBIDA\" <= '" + f_fin.Year.ToString("0000") + "-" +
                f_fin.Month.ToString("00") + "-" + f_fin.Day.ToString("00") + "'";

            return query;
        }

        public static string SELECT_AVISO_INFORMES_NO_GENERADOS(DateTime f_fin)
        {
            string historia = nHManager.Instance.GetSQLTable(typeof(HistoriaAuditoriaRecord));
            string discrepancia = nHManager.Instance.GetSQLTable(typeof(DiscrepanciaRecord));

            string query = AuditoriaInfo.SELECT(0);

            query += " INNER JOIN " + historia + " AS H ON (H.\"OID_AUDITORIA\" = A.\"OID\")";
            query += " WHERE (H.\"ESTADO\" = '" + Quality.EstadoAuditoria.EN_PROCESO.ToString() + "' AND A.\"ESTADO\" = '" + Quality.EstadoAuditoria.EN_PROCESO.ToString() + "')";
            query += " OR (H.\"ESTADO\" = '" + Quality.EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS.ToString() + "' AND A.\"ESTADO\" = '" + Quality.EstadoAuditoria.ACCIONES_CORRECTORAS_NOTIFICADAS.ToString() + "')";
            query += " AND H.\"FECHA\" <= '" + f_fin.Year.ToString("0000") + "-" +
                f_fin.Month.ToString("00") + "-" + f_fin.Day.ToString("00") + "'";

            return query;
        }

        #endregion
    }
}

