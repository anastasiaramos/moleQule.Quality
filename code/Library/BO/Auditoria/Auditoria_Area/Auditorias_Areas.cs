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
    public class Auditorias_Areas : BusinessListBaseEx<Auditorias_Areas, Auditoria_Area>
    {

        #region Business Methods
		
        public Auditoria_Area NewItem(TipoAuditoria parent)
        {
            this.AddItem(Auditoria_Area.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Auditorias_Areas()
        {
            MarkAsChild();
        }

        private Auditorias_Areas(IList<Auditoria_Area> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Auditorias_Areas(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static Auditorias_Areas NewChildList() { return new Auditorias_Areas(); }

        public static Auditorias_Areas GetChildList(IList<Auditoria_Area> lista) { return new Auditorias_Areas(lista); }

        public static Auditorias_Areas GetChildList(IDataReader reader, bool childs) { return new Auditorias_Areas(reader, childs); }

        public static Auditorias_Areas GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Auditoria_Area> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Auditoria_Area item in lista)
                this.AddItem(Auditoria_Area.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Auditoria_Area.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(TipoAuditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Auditoria_Area obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Auditoria_Area obj in this)
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

            return Auditoria_Area.SELECT(conditions, true);
        }

        #endregion

    }
}
