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
    public class CuestionList : ReadOnlyListBaseEx<CuestionList, CuestionInfo>
    {

        #region Child Factory Methods

        private CuestionList() { }



        private CuestionList(IList<Cuestion> lista)
        {
            Fetch(lista);
        }

        private CuestionList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a CuestionList from a IList<!--<CuestionInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CuestionList</returns>
        public static CuestionList GetChildList(IList<CuestionInfo> list)
        {
            CuestionList flist = new CuestionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (CuestionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }


        /// <summary>
        /// Builds a CuestionList from IList<!--<Cuestion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CuestionList</returns>
        public static CuestionList GetChildList(IList<Cuestion> list) { return new CuestionList(list); }

        public static CuestionList GetChildList(IDataReader reader) { return new CuestionList(reader); }

        #endregion

        #region Root Factory Methods

        //  private CuestionList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>CuestionList</returns>
        public static CuestionList GetList()
        {
            CriteriaEx criteria = Cuestion.GetCriteria(Cuestion.OpenSession());

            //No criteria. Retrieve all de List
            CuestionList list = DataPortal.Fetch<CuestionList> (criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static CuestionList GetList(CriteriaEx criteria)
        {
            return CuestionList.RetrieveList(typeof(Cuestion), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a CuestionList from a IList<!--<CuestionInfo>-->
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CuestionList</returns>
        public static CuestionList GetList(IList<CuestionInfo> list)
        {
            CuestionList flist = new CuestionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (CuestionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a CuestionList from a IList<!--<Cuestion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Cuestion</returns>
        public static CuestionList GetList(IList<Cuestion> list)
        {
            CuestionList flist = new CuestionList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Cuestion item in list)
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
        public static SortedBindingList<CuestionInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<CuestionInfo> sortedList =
                new SortedBindingList<CuestionInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Cuestion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Cuestion item in lista)
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
                this.AddItem(CuestionInfo.Get(reader, true));

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

                    //Cuestion.LOCK( Session());

                    IDataReader reader = nHManager.Instance.SQLNativeSelect(CuestionList.SELECT(), Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(CuestionInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Cuestion> list = criteria.List<Cuestion>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Cuestion item in list)
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

                    foreach (Cuestion item in list)
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

        public static string SELECT() { return Cuestion.SELECT(new QueryConditions(), false); }

        #endregion

    }
}

