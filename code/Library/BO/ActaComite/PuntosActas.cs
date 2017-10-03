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
    public class PuntosActas : BusinessListBaseEx<PuntosActas, PuntoActa>
    {

        #region Business Methods
		
        public PuntoActa NewItem(ActaComite parent)
        {
            this.AddItem(PuntoActa.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private PuntosActas()
        {
            MarkAsChild();
        }

        private PuntosActas(IList<PuntoActa> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private PuntosActas(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static PuntosActas NewChildList() { return new PuntosActas(); }

        public static PuntosActas GetChildList(IList<PuntoActa> lista) { return new PuntosActas(lista); }

        public static PuntosActas GetChildList(IDataReader reader, bool childs) { return new PuntosActas(reader, childs); }

        public static PuntosActas GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<PuntoActa> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (PuntoActa item in lista)
                this.AddItem(PuntoActa.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(PuntoActa.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(ActaComite parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (PuntoActa obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (PuntoActa obj in this)
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

        public static string SELECT_BY_ACTA(long oid_acta)
        {
            QueryConditions conditions = new QueryConditions()
            {
                ActaComite = ActaComiteInfo.New()
            };

            conditions.ActaComite.Oid = oid_acta;

            return PuntoActa.SELECT(conditions, true);
        }

        #endregion

    }
}
