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
    public class AccionesCorrectoras : BusinessListBaseEx<AccionesCorrectoras, AccionCorrectora>
    {

        #region Business Methods

		
        public AccionCorrectora NewItem(Discrepancia parent)
        {
            this.AddItem(AccionCorrectora.NewChild(parent));
            return this[Count - 1];
        }
		
        public AccionCorrectora NewItem(InformeCorrector parent)
        {
            this.AddItem(AccionCorrectora.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private AccionesCorrectoras()
        {
            MarkAsChild();
        }

        private AccionesCorrectoras(IList<AccionCorrectora> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private AccionesCorrectoras(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static AccionesCorrectoras NewChildList() { return new AccionesCorrectoras(); }

        public static AccionesCorrectoras GetChildList(IList<AccionCorrectora> lista) { return new AccionesCorrectoras(lista); }

        public static AccionesCorrectoras GetChildList(IDataReader reader, bool childs) { return new AccionesCorrectoras(reader, childs); }

        public static AccionesCorrectoras GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<AccionCorrectora> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (AccionCorrectora item in lista)
                this.AddItem(AccionCorrectora.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(AccionCorrectora.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(Discrepancia parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (AccionCorrectora obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (AccionCorrectora obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }
			
            this.RaiseListChangedEvents = true;
        }
		
        internal void Update(InformeCorrector parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (AccionCorrectora obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (AccionCorrectora obj in this)
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

            return AccionCorrectora.SELECT(conditions, true);
        }

        public static string SELECT_BY_INFORME_CORRECTOR(long oid_informe_corrector)
        {
            QueryConditions conditions = new QueryConditions()
            {
                InformeCorrector = InformeCorrectorInfo.New()
            };

            conditions.InformeCorrector.Oid = oid_informe_corrector;

            return AccionCorrectora.SELECT(conditions, true);
        }

        #endregion

    }
}
