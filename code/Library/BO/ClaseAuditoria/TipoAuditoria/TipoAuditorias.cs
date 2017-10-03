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
	public class TipoAuditorias : BusinessListBaseEx<TipoAuditorias,TipoAuditoria>
	{
	
	     #region Business Methods
		 
		 
		 public TipoAuditoria NewItem(ClaseAuditoria parent)
			{
				this.AddItem(TipoAuditoria.NewChild(parent));
				return this[Count - 1];
			}
		
		 #endregion
		 
	     #region Factory Methods
		 
		 	private TipoAuditorias()
			{
				MarkAsChild();
			}
			
			private TipoAuditorias(IList<TipoAuditoria> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private TipoAuditorias(int session_code, IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(session_code, reader);
			}


			public static TipoAuditorias NewChildList() { return new TipoAuditorias(); }
			
			public static TipoAuditorias GetChildList(IList<TipoAuditoria> lista) { return new TipoAuditorias(lista); }

			public static TipoAuditorias GetChildList(int session_code, IDataReader reader, bool childs) { return new TipoAuditorias(session_code, reader, childs); }

			public static TipoAuditorias GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<TipoAuditoria> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (TipoAuditoria item in lista)
					this.AddItem(TipoAuditoria.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(int session_code, IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(TipoAuditoria.GetChild(session_code, reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(ClaseAuditoria parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (TipoAuditoria obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (TipoAuditoria obj in this)
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

        public static string SELECT_BY_CLASE_AUDITORIA(long oid_clase_auditoria)
        {
            QueryConditions conditions = new QueryConditions()
            {
                ClaseAuditoria = ClaseAuditoriaInfo.New()
            };

            conditions.ClaseAuditoria.Oid = oid_clase_auditoria;

            return TipoAuditoria.SELECT(conditions, true);
        }

        #endregion
	
	}
}

