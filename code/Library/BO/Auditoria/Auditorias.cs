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
	public class Auditorias : BusinessListBaseEx<Auditorias, Auditoria>
	{
	
	     #region Business Methods
		 
			public Auditoria NewItem(TipoAuditoria parent)
			{
				this.AddItem(Auditoria.NewChild(parent));
				return this[Count - 1];
			}
			
		 #endregion
		 
	     #region Factory Methods
		 
		 	private Auditorias()
			{
				MarkAsChild();
			}
			
			private Auditorias(IList<Auditoria> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private Auditorias(int session_code, IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(session_code, reader);
			}


			public static Auditorias NewChildList() { return new Auditorias(); }
			
			public static Auditorias GetChildList(IList<Auditoria> lista) { return new Auditorias(lista); }

			public static Auditorias GetChildList(int session_code, IDataReader reader, bool childs) { return new Auditorias(session_code, reader, childs); }

			public static Auditorias GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<Auditoria> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (Auditoria item in lista)
					this.AddItem(Auditoria.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(int session_code, IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(Auditoria.GetChild(session_code, reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(TipoAuditoria parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (Auditoria obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (Auditoria obj in this)
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

        public static string SELECT_BY_PLAN(long oid_plan)
        {
            string a = nHManager.Instance.GetSQLTable(typeof(AuditoriaRecord));
            string t = nHManager.Instance.GetSQLTable(typeof(TipoAuditoriaRecord));
            string p = nHManager.Instance.GetSQLTable(typeof(PlanAnualRecord));
            string pt = nHManager.Instance.GetSQLTable(typeof(Plan_TipoRecord));
            string query;

            query = "SELECT 0 AS \"OID\", MAX(PT.\"ORDEN\") AS \"SERIAL\"" +
                    " FROM " + a + " AS A" +
                    " INNER JOIN " + p + " AS P ON (A.\"OID_PLAN\" = P.\"OID\")" +
                    " INNER JOIN " + pt + " AS PT ON (A.\"OID_PLAN_TIPO\" = PT.\"OID\")" +
                    " WHERE P.\"OID\" = '" + oid_plan.ToString() + "'";

            return query;
        }

        #endregion
	
	}
}

