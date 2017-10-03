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
	public class DiscrepanciaList : ReadOnlyListBaseEx<DiscrepanciaList, DiscrepanciaInfo>
	{

        #region Child Factory Methods

        private DiscrepanciaList() { }

        public static DiscrepanciaList NewList() { return new DiscrepanciaList(); }



        private DiscrepanciaList(IList<Discrepancia> lista)
        {
            Fetch(lista);
        }

        private DiscrepanciaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a DiscrepanciaList from a IList<!--<DiscrepanciaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>DiscrepanciaList</returns>
        public static DiscrepanciaList GetChildList(IList<DiscrepanciaInfo> list)
        {
            DiscrepanciaList flist = new DiscrepanciaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (DiscrepanciaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a DiscrepanciaList from IList<!--<Discrepancia>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>DiscrepanciaList</returns>
        public static DiscrepanciaList GetChildList(IList<Discrepancia> list) { return new DiscrepanciaList(list); }

        public static DiscrepanciaList GetChildList(IDataReader reader) { return new DiscrepanciaList(reader); }

        #endregion

        #region Root Factory Methods

        //  private DiscrepanciaList() { }

        public static DiscrepanciaList GetList()
        {
            return GetList(true);
        }

        public static DiscrepanciaList GetList(bool get_childs)
        {
            CriteriaEx criteria = Discrepancia.GetCriteria(Discrepancia.OpenSession());
            criteria.Childs = get_childs;

            criteria.Query = DiscrepanciaList.SELECT();

            DiscrepanciaList list = DataPortal.Fetch<DiscrepanciaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }


        public static DiscrepanciaList GetDiscrepanciasAbiertasList()
        {
            CriteriaEx criteria = Discrepancia.GetCriteria(Discrepancia.OpenSession());
            criteria.Childs = false;

            criteria.Query = DiscrepanciaList.SELECT_DISCREPANCIAS_ABIERTAS();

            DiscrepanciaList list = DataPortal.Fetch<DiscrepanciaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static DiscrepanciaList GetList(CriteriaEx criteria)
        {
            return DiscrepanciaList.RetrieveList(typeof(Discrepancia), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a DiscrepanciaList from a IList<!--<DiscrepanciaInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>DiscrepanciaList</returns>
        public static DiscrepanciaList GetList(IList<DiscrepanciaInfo> list)
        {
            DiscrepanciaList flist = new DiscrepanciaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (DiscrepanciaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a DiscrepanciaList from a IList<!--<Discrepancia>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Discrepancia</returns>
        public static DiscrepanciaList GetList(IList<Discrepancia> list)
        {
            DiscrepanciaList flist = new DiscrepanciaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Discrepancia item in list)
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
        public static SortedBindingList<DiscrepanciaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<DiscrepanciaInfo> sortedList =
                new SortedBindingList<DiscrepanciaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Discrepancia> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Discrepancia item in lista)
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
                this.AddItem(DiscrepanciaInfo.Get(reader, true));

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
                        this.AddItem(DiscrepanciaInfo.Get(reader, Childs));
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

                    foreach (Discrepancia item in list)
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

        public static string SELECT()
        {
            string query = string.Empty;
            string tabla_discrepancia = nHManager.Instance.GetSQLTable(typeof(DiscrepanciaRecord));
            string tabla_informe = nHManager.Instance.GetSQLTable(typeof(InformeDiscrepanciaRecord));
            string tabla_auditoria = nHManager.Instance.GetSQLTable(typeof(AuditoriaRecord));
            string oid_informe = nHManager.Instance.GetTableField(typeof(DiscrepanciaRecord), "OidInforme");
            string oid_auditoria = nHManager.Instance.GetTableField(typeof(InformeDiscrepanciaRecord), "OidAuditoria");
            string referencia = nHManager.Instance.GetTableField(typeof(AuditoriaRecord), "Referencia");
            string numero = nHManager.Instance.GetTableField(typeof(InformeDiscrepanciaRecord), "Numero");
            string codigo = nHManager.Instance.GetTableField(typeof(DiscrepanciaRecord), "Codigo");

            query = "SELECT D.*, A.\"" + referencia + "\" AS \"NUMERO_AUDITORIA\", I.\"" + numero + "\" AS \"NUMERO_INFORME\" " +
                    "FROM " + tabla_discrepancia + " as D " +
                    "INNER JOIN " + tabla_informe + " as I ON (I.\"OID\" = D.\"" + oid_informe + "\") " +
                    "INNER JOIN " + tabla_auditoria + " as A ON (A.\"OID\" = I.\"" + oid_auditoria + "\") " +
                    "ORDER BY D.\"" + codigo + "\";";

            return query;
        }

        public static string SELECT_DISCREPANCIAS_ABIERTAS()
        {
            string query = string.Empty;
            long dias = 0;
            DateTime max = DateTime.MaxValue;
            SchemaSettingInfo variable = SchemaSettingInfo.Get("AVISO_DISCREPANCIAS_ABIERTAS");
            dias = Convert.ToInt32(variable.Value);
            string tabla_discrepancia = nHManager.Instance.GetSQLTable(typeof(DiscrepanciaRecord));
            string fecha_debida = nHManager.Instance.GetTableField(typeof(DiscrepanciaRecord), "FechaDebida");
            string fecha_cierre = nHManager.Instance.GetTableField(typeof(DiscrepanciaRecord), "FechaCierre");
            string es_discrepancia = nHManager.Instance.GetTableField(typeof(DiscrepanciaRecord), "EsDiscrepancia");

            query = "SELECT D.* " +
                    "FROM " + tabla_discrepancia + " AS D " +
                    "WHERE (D.\"" + fecha_debida + "\" - current_date <= " + dias.ToString() + " ) " +
                    "AND D.\"" + fecha_cierre + "\" = '" + max.Year.ToString() + "-" +
                    max.Month.ToString() + "-" + max.Day.ToString() + "' " +
                    "AND D.\"" + es_discrepancia + "\" = 'true';";

            return query;
        }

        #endregion

        #region Auxiliar

        public static List<string> GetAvisoDiscrepanciasAbiertas()
        {
            List<string> lista_avisos = new List<string>(); ;
            DiscrepanciaList lista = GetDiscrepanciasAbiertasList();
            InformeDiscrepanciaList informes = InformeDiscrepanciaList.GetList(false);

            foreach (DiscrepanciaInfo item in lista)
            {
                InformeDiscrepanciaInfo informe = informes.GetItem(item.OidInforme);
                lista_avisos.Add("Discrepancia " + item.Codigo + 
                    " del Informe de Discrepancias " +
                    informe.Titulo + " próxima a cerrar. Fecha de cierre: " +
                    item.FechaDebida.ToShortDateString());
            }

            return lista_avisos;
        }

        #endregion
    }
}

