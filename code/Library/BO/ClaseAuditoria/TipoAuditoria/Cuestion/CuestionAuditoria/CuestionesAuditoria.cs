using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Quality
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class CuestionesAuditoria : BusinessListBaseEx<CuestionesAuditoria, CuestionAuditoria>
    {

        #region Business Methods

		
        public CuestionAuditoria NewItem(Auditoria parent)
        {
            this.AddItem(CuestionAuditoria.NewChild(parent));
            return this[Count - 1];
        }
		
        public CuestionAuditoria NewItem(Cuestion parent)
        {
            this.AddItem(CuestionAuditoria.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private CuestionesAuditoria()
        {
            MarkAsChild();
        }

        private CuestionesAuditoria(IList<CuestionAuditoria> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private CuestionesAuditoria(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static CuestionesAuditoria NewChildList() { return new CuestionesAuditoria(); }

        public static CuestionesAuditoria GetChildList(IList<CuestionAuditoria> lista) { return new CuestionesAuditoria(lista); }

        public static CuestionesAuditoria GetChildList(IDataReader reader, bool childs) { return new CuestionesAuditoria(reader, childs); }

        public static CuestionesAuditoria GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<CuestionAuditoria> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (CuestionAuditoria item in lista)
                this.AddItem(CuestionAuditoria.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(CuestionAuditoria.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(Auditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (CuestionAuditoria obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (CuestionAuditoria obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }
			
            this.RaiseListChangedEvents = true;
        }
		
        internal void Update(Cuestion parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (CuestionAuditoria obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (CuestionAuditoria obj in this)
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

            return CuestionAuditoria.SELECT(conditions, true);
        }

        public static string SELECT_BY_CUESTION(long oid_cuestion)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Cuestion = CuestionInfo.New()
            };

            conditions.Cuestion.Oid = oid_cuestion;

            return CuestionAuditoria.SELECT(conditions, true);
        }

        #endregion

    }
}
