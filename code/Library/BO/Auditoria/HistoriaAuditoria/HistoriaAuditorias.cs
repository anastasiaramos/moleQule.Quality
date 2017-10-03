using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx; 

namespace moleQule.Library.Quality
{
    /// <summary>
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class HistoriaAuditorias : BusinessListBaseEx<HistoriaAuditorias, HistoriaAuditoria>
    {

        #region Business Methods

        public HistoriaAuditoria NewItem(Auditoria parent)
        {
            this.AddItem(HistoriaAuditoria.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private HistoriaAuditorias()
        {
            MarkAsChild();
        }

        private HistoriaAuditorias(IList<HistoriaAuditoria> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private HistoriaAuditorias(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static HistoriaAuditorias NewChildList() { return new HistoriaAuditorias(); }

        public static HistoriaAuditorias GetChildList(IList<HistoriaAuditoria> lista) { return new HistoriaAuditorias(lista); }

        public static HistoriaAuditorias GetChildList(IDataReader reader) { return new HistoriaAuditorias(reader); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<HistoriaAuditoria> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (HistoriaAuditoria item in lista)
                this.AddItem(HistoriaAuditoria.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(HistoriaAuditoria.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Auditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (HistoriaAuditoria obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (HistoriaAuditoria obj in this)
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

        public new static string SELECT() { return HistoriaAuditoriaInfo.SELECT(0); }

        public static string SELECT_BY_AUDITORIA(long oid_auditoria)
        {
            string query = HistoriaAuditoria.SELECT(0, false);

            query += "WHERE H.\"OID_AUDITORIA\" = " + oid_auditoria.ToString();

            //query += " FOR UPDATE OF H NOWAIT";

            return query;
        }

        #endregion

    }
}

