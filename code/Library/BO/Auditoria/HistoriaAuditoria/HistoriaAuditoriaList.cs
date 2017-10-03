using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Quality
{
	/// <summary>
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
	public class HistoriaAuditoriaList : ReadOnlyListBaseEx<HistoriaAuditoriaList, HistoriaAuditoriaInfo>
	{

        #region Factory Methods

        private HistoriaAuditoriaList() { }

        private HistoriaAuditoriaList(IList<HistoriaAuditoria> lista)
        {
            Fetch(lista);
        }

        private HistoriaAuditoriaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a HistoriaAuditoriaList from a IList<!--<HistoriaAuditoriaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>HistoriaAuditoriaList</returns>
        public static HistoriaAuditoriaList GetChildList(IList<HistoriaAuditoriaInfo> list)
        {
            HistoriaAuditoriaList flist = new HistoriaAuditoriaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (HistoriaAuditoriaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a HistoriaAuditoriaList from IList<!--<HistoriaAuditoria>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>HistoriaAuditoriaList</returns>
        public static HistoriaAuditoriaList GetChildList(IList<HistoriaAuditoria> list) { return new HistoriaAuditoriaList(list); }

        public static HistoriaAuditoriaList GetChildList(IDataReader reader) { return new HistoriaAuditoriaList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<HistoriaAuditoria> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (HistoriaAuditoria item in lista)
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
                this.AddItem(HistoriaAuditoria.GetChild(reader).GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    //HistoriaAuditoria.DoLOCK( Session());

                    IDataReader reader = nHManager.Instance.SQLNativeSelect(HistoriaAuditoriaList.SELECT(), Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(HistoriaAuditoriaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<HistoriaAuditoria> list = criteria.List<HistoriaAuditoria>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (HistoriaAuditoria item in list)
                            this.AddItem(item.GetInfo());

                        IsReadOnly = true;
                    }
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

        public static string SELECT() { return HistoriaAuditoriaInfo.SELECT(0); }

        public static string SELECT_BY_AUDITORIA(long oid_auditoria) 
        { 
            string query = HistoriaAuditoriaInfo.SELECT(0);

            query += "WHERE H.\"OID_AUDITORIA\" = " + oid_auditoria.ToString();

            return query;
        }

        #endregion
	}
}

