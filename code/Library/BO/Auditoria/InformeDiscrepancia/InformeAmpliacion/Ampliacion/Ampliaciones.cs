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
    public class Ampliaciones : BusinessListBaseEx<Ampliaciones, Ampliacion>
    {

        #region Business Methods
		
        public Ampliacion NewItem(Discrepancia parent)
        {
            this.AddItem(Ampliacion.NewChild(parent));
            return this[Count - 1];
        }
		
        public Ampliacion NewItem(InformeAmpliacion parent)
        {
            this.AddItem(Ampliacion.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private Ampliaciones()
        {
            MarkAsChild();
        }

        private Ampliaciones(IList<Ampliacion> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Ampliaciones(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static Ampliaciones NewChildList() { return new Ampliaciones(); }

        public static Ampliaciones GetChildList(IList<Ampliacion> lista) { return new Ampliaciones(lista); }

        public static Ampliaciones GetChildList(IDataReader reader, bool childs) { return new Ampliaciones(reader, childs); }

        public static Ampliaciones GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Ampliacion> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Ampliacion item in lista)
                this.AddItem(Ampliacion.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Ampliacion.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(Discrepancia parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Ampliacion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Ampliacion obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }
			
            this.RaiseListChangedEvents = true;
        }
		
        internal void Update(InformeAmpliacion parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Ampliacion obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Ampliacion obj in this)
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

        public static string SELECT_BY_DISCREPANCIA(long oid_discrepancia)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Discrepancia = DiscrepanciaInfo.New()
            };

            conditions.Discrepancia.Oid = oid_discrepancia;

            return Ampliacion.SELECT(conditions, true);
        }

        public static string SELECT_BY_INFORME_AMPLIACION(long oid_informe_ampliacion)
        {
            QueryConditions conditions = new QueryConditions()
            {
                InformeAmpliacion = InformeAmpliacionInfo.New()
            };

            conditions.InformeAmpliacion.Oid = oid_informe_ampliacion;

            return Ampliacion.SELECT(conditions, true);
        }

        #endregion

    }
}
