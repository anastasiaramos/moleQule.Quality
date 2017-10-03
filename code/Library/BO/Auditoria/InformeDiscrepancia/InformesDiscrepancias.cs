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
    public class InformesDiscrepancias : BusinessListBaseEx<InformesDiscrepancias, InformeDiscrepancia>
    {

        #region Business Methods

        public InformeDiscrepancia NewItem(Auditoria parent)
        {
           this.AddItem(InformeDiscrepancia.NewChild(parent));
           return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private InformesDiscrepancias()
        {
            MarkAsChild();
        }

        private InformesDiscrepancias(IList<InformeDiscrepancia> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private InformesDiscrepancias(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }


        public static InformesDiscrepancias NewChildList() { return new InformesDiscrepancias(); }

        public static InformesDiscrepancias GetChildList(IList<InformeDiscrepancia> lista) { return new InformesDiscrepancias(lista); }

        public static InformesDiscrepancias GetChildList(int session_code, IDataReader reader, bool childs) { return new InformesDiscrepancias(session_code, reader, childs); }

        public static InformesDiscrepancias GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<InformeDiscrepancia> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (InformeDiscrepancia item in lista)
                this.AddItem(InformeDiscrepancia.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(InformeDiscrepancia.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Auditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (InformeDiscrepancia obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (InformeDiscrepancia obj in this)
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

        public static string SELECT_BY_AUDITORIA(long oid_auditoria)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Auditoria = AuditoriaInfo.New()
            };

            conditions.Auditoria.Oid = oid_auditoria;

            return InformeDiscrepancia.SELECT(conditions, true);
        }

        #endregion

    }
}

