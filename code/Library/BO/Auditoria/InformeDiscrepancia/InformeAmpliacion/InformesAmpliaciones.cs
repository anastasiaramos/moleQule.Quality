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
	public class InformesAmpliaciones : BusinessListBaseEx<InformesAmpliaciones, InformeAmpliacion>
	{
	
	     #region Business Methods
		 
			public InformeAmpliacion NewItem(InformeDiscrepancia parent)
			{
				this.AddItem(InformeAmpliacion.NewChild(parent));
				return this[Count - 1];
			}

		 #endregion
		 
	     #region Factory Methods
		 
		 	private InformesAmpliaciones()
			{
				MarkAsChild();
			}
			
			private InformesAmpliaciones(IList<InformeAmpliacion> lista)
			{
				MarkAsChild();
				Fetch(lista);
			}

			private InformesAmpliaciones(int session_code, IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(session_code, reader);
			}


			public static InformesAmpliaciones NewChildList() { return new InformesAmpliaciones(); }
			
			public static InformesAmpliaciones GetChildList(IList<InformeAmpliacion> lista) { return new InformesAmpliaciones(lista); }

			public static InformesAmpliaciones GetChildList(int session_code, IDataReader reader, bool childs) { return new InformesAmpliaciones(session_code, reader, childs); }

			public static InformesAmpliaciones GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }
			
		 #endregion
		 
		 #region Child Data Access
		 
		 	// called to copy objects data from list
			private void Fetch(IList<InformeAmpliacion> lista)
			{
				this.RaiseListChangedEvents = false;
				
				foreach (InformeAmpliacion item in lista)
					this.AddItem(InformeAmpliacion.GetChild(item));
				
				this.RaiseListChangedEvents = true;
			}

			private void Fetch(int session_code, IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				while (reader.Read())
					this.AddItem(InformeAmpliacion.GetChild(session_code, reader));

				this.RaiseListChangedEvents = true;
			}


			internal void Update(InformeDiscrepancia parent)
			{
				this.RaiseListChangedEvents = false;

				// update (thus deleting) any deleted child objects
				foreach (InformeAmpliacion obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// AddItem/update any current child objects
				foreach (InformeAmpliacion obj in this)
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

            public static string SELECT_BY_INFORME_DISCREPANCIA(long oid_informe_discrepancia)
            {
                QueryConditions conditions = new QueryConditions()
                {
                    InformeDiscrepancia = InformeDiscrepanciaInfo.New()
                };

                conditions.InformeDiscrepancia.Oid = oid_informe_discrepancia;

                return InformeAmpliacion.SELECT(conditions, true);
            }

            #endregion
	
	}
}

