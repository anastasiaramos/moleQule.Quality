using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using NHibernate;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// Editable Child Collection
	/// </summary>
    [Serializable()]
	public class Cuestiones : BusinessListBaseEx<Cuestiones, Cuestion>
	{
	
	     #region Business Methods
		 
		 
			public Cuestion NewItem(TipoAuditoria parent)
			{
				this.AddItem(Cuestion.NewChild(parent));
				return this[Count - 1];
			}


        #endregion
		 
	     #region Factory Methods
		 
		 	private Cuestiones()
			{
				MarkAsChild();
			}
			
			private Cuestiones(IList<Cuestion> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private Cuestiones(int session_code, IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(session_code, reader);
			}


			public static Cuestiones NewChildList() { return new Cuestiones(); }
			
			public static Cuestiones GetChildList(IList<Cuestion> lista) { return new Cuestiones(lista); }

			public static Cuestiones GetChildList(int session_code, IDataReader reader, bool childs) { return new Cuestiones(session_code, reader, childs); }

			public static Cuestiones GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<Cuestion> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (Cuestion item in lista)
					this.AddItem(Cuestion.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(int session_code, IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(Cuestion.GetChild(session_code, reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(TipoAuditoria parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (Cuestion obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (Cuestion obj in this)
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

                return Cuestion.SELECT(conditions, true);
            }

            #endregion
	
	}
}

