using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Quality
{
    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Planes_Tipos : BusinessListBaseEx<Planes_Tipos, Plan_Tipo>
    {

        #region Business Methods

        public void Clone(PlanAnual plan)
        {
            foreach (Plan_Tipo item in this)
            {
                item.OidPlan = plan.Oid;
            }
        }

        public Plan_Tipo NewItem(TipoAuditoria parent)
        {
            this.AddItem(Plan_Tipo.NewChild(parent));
            return this[Count - 1];
        }
		
        public Plan_Tipo NewItem(PlanAnual parent)
        {
            this.AddItem(Plan_Tipo.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private Planes_Tipos()
        {
            MarkAsChild();
        }

        private Planes_Tipos(IList<Plan_Tipo> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Planes_Tipos(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
        
        public static Planes_Tipos NewChildList() { return new Planes_Tipos(); }

        public static Planes_Tipos GetChildList(IList<Plan_Tipo> lista) { return new Planes_Tipos(lista); }

        public static Planes_Tipos GetChildList(IDataReader reader, bool childs) { return new Planes_Tipos(reader, childs); }

        public static Planes_Tipos GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Plan_Tipo> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Plan_Tipo item in lista)
                this.AddItem(Plan_Tipo.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Plan_Tipo.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(TipoAuditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Plan_Tipo obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Plan_Tipo obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }
			
            this.RaiseListChangedEvents = true;
        }
		
        internal void Update(PlanAnual parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Plan_Tipo obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Plan_Tipo obj in this)
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


        public new static string SELECT_BY_FIELD(string field, object value)
        {
            string query;
            string bd_field = nHManager.Instance.GetTableField(typeof(Plan_TipoRecord), field);

            query = "SELECT P.*, TA.\"OID_CLASE_AUDITORIA\" AS \"OID_CLASE\" " + 
                "FROM \"0001\".\"Plan_Tipo\" AS P " +
                "INNER JOIN \"0001\".\"TipoAuditoria\" AS TA ON (P.\"OID_TIPO\" = TA.\"OID\") " +
                "WHERE \"" + bd_field + "\" = " +  value.ToString() + ";";

            return query;
        }


        #endregion

    }
}
