using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Quality
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Discrepancias : BusinessListBaseEx<Discrepancias, Discrepancia>
    {

        #region Business Methods

        public Discrepancia NewItem(InformeDiscrepancia parent)
        {
           this.AddItem(Discrepancia.NewChild(parent));
           return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Discrepancias()
        {
            MarkAsChild();
        }

        private Discrepancias(IList<Discrepancia> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Discrepancias(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }


        public static Discrepancias NewChildList() { return new Discrepancias(); }

        public static Discrepancias GetChildList(IList<Discrepancia> lista) { return new Discrepancias(lista); }

        public static Discrepancias GetChildList(int session_code, IDataReader reader, bool childs) { return new Discrepancias(session_code, reader, childs); }

        public static Discrepancias GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Discrepancia> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Discrepancia item in lista)
                this.AddItem(Discrepancia.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Discrepancia.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(InformeDiscrepancia parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Discrepancia obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Discrepancia obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region SQL

        public static string SELECT_BY_INFORME_DISCREPANCIA(long oid_informe_discrepancia)
        {
            QueryConditions conditions = new QueryConditions()
            {
                InformeDiscrepancia = InformeDiscrepanciaInfo.New()
            };

            conditions.InformeDiscrepancia.Oid = oid_informe_discrepancia;

            return Discrepancia.SELECT(conditions, true);
        }

        #endregion

    }
}

