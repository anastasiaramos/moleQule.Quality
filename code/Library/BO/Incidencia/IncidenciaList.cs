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
	/// ReadOnly Business Object Root Collection
	/// </summary>
    [Serializable()]
	public class IncidenciaList : ReadOnlyListBaseEx<IncidenciaList, IncidenciaInfo>
	{	
		#region Business Methods
			
		#endregion
		 
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private IncidenciaList() {}

        public static IncidenciaList NewList() { return new IncidenciaList(); }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private IncidenciaList(IList<Incidencia> list, bool retrieve_childs)
        {
			Childs = retrieve_childs;
            Fetch(list);
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private IncidenciaList(IDataReader reader, bool retrieve_childs)
        {
			Childs = retrieve_childs;
            Fetch(reader);
        }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private IncidenciaList(IList<IncidenciaInfo> list, bool retrieve_childs)
        {
			Childs = retrieve_childs;
            Fetch(list);
        }
		
		#endregion
		
		#region Root Factory Methods
		
		/// <summary>
		/// Default call for GetList(bool retrieve_childs)
		/// </summary>
		/// <returns></returns>
		public static IncidenciaList GetList()
		{
			return IncidenciaList.GetList(true);
		}
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="retrieve_childs">Retrieving the childs</param>
		/// <returns></returns>
		public static IncidenciaList GetList(bool retrieve_childs)
		{
			CriteriaEx criteria = Incidencia.GetCriteria(Incidencia.OpenSession());
			criteria.Childs = retrieve_childs;
			
			//No criteria. Retrieve all de List
			
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = IncidenciaList.SELECT();
            
			IncidenciaList list = DataPortal.Fetch<IncidenciaList>(criteria);
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static IncidenciaList GetList(CriteriaEx criteria)
		{
			return IncidenciaList.RetrieveList(typeof(Incidencia), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		/// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static IncidenciaList GetList(IList<Incidencia> list) { return new IncidenciaList(list,false); }
		
		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		/// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static IncidenciaList GetList(IList<IncidenciaInfo> list) { return new IncidenciaList(list, false); }
		
		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<IncidenciaInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<IncidenciaInfo> sortedList = new SortedBindingList<IncidenciaInfo>(GetList());
			
			sortedList.ApplySort(sortProperty, sortDirection);
			return sortedList;
		}
		
		/// <summary>
        /// Devuelve una lista ordenada de todos los elementos y sus hijos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <param name="childs">Traer hijos</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<IncidenciaInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<IncidenciaInfo> sortedList = new SortedBindingList<IncidenciaInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
			
		#endregion
		
		#region Common Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
		private void Fetch(IList<Incidencia> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;
			
			foreach (Incidencia item in lista)
				this.AddItem(item.GetInfo(Childs));

			IsReadOnly = true;

			this.RaiseListChangedEvents = true;
		}

        /// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="reader">IDataReader origen</param>
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(IncidenciaInfo.GetChild(reader, Childs));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
		
        #endregion
		#region Root Data Access
		 
		/// <summary>
		/// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
		protected override void Fetch(CriteriaEx criteria)
		{
			this.RaiseListChangedEvents = false;
			
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;
			
			try
			{
				if (nHMng.UseDirectSQL)
				{					
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session()); 
					
					IsReadOnly = false;
					
					while (reader.Read())
						this.AddItem(IncidenciaInfo.GetChild(reader, Childs));

					IsReadOnly = true;
				}
				else 
				{
					IList list = criteria.List();
					
					if (list.Count > 0)
					{
						IsReadOnly = false;
						foreach(Incidencia item in list)
							this.Add(item.GetInfo(false));
							
						IsReadOnly = true;
					}
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			this.RaiseListChangedEvents = true;
		}
				
		#endregion

        #region SQL

        public static string SELECT() { return IncidenciaInfo.SELECT(0); }

        #endregion
    }
}

