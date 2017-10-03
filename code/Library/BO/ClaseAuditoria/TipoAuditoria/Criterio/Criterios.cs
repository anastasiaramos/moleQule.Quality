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
    public class Criterios : BusinessListBaseEx<Criterios, Criterio>
    {

        #region Business Methods
		
        public Criterio NewItem(TipoAuditoria parent)
        {
            this.AddItem(Criterio.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private Criterios()
        {
            MarkAsChild();
        }

        private Criterios(IList<Criterio> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Criterios(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static Criterios NewChildList() { return new Criterios(); }

        public static Criterios GetChildList(IList<Criterio> lista) { return new Criterios(lista); }

        public static Criterios GetChildList(IDataReader reader, bool childs) { return new Criterios(reader, childs); }

        public static Criterios GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Criterio> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Criterio item in lista)
                this.AddItem(Criterio.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Criterio.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(TipoAuditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Criterio obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Criterio obj in this)
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

        public static string SELECT_BY_TIPO_AUDITORIA(long oid_tipo_auditoria)
        {
            QueryConditions conditions = new QueryConditions()
            {
                TipoAuditoria = TipoAuditoriaInfo.New()
            };

            conditions.TipoAuditoria.Oid = oid_tipo_auditoria;

            return Criterio.SELECT(conditions, true);
        }

        #endregion

    }
}
