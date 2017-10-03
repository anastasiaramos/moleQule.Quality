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
	/// ReadOnly Root Collection of Business Objects With Child Collection
	/// </summary>
    [Serializable()]
	public class ClaseAuditoriaList : ReadOnlyListBaseEx<ClaseAuditoriaList, ClaseAuditoriaInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private ClaseAuditoriaList() { }

        public static ClaseAuditoriaList NewList() { return new ClaseAuditoriaList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static ClaseAuditoriaList GetList(bool childs)
		{
			CriteriaEx criteria = ClaseAuditoria.GetCriteria(ClaseAuditoria.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ClaseAuditoriaList.SELECT();
			ClaseAuditoriaList list = DataPortal.Fetch<ClaseAuditoriaList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static ClaseAuditoriaList GetList()
		{
			return ClaseAuditoriaList.GetList(true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static ClaseAuditoriaList GetList(CriteriaEx criteria)
		{
			return ClaseAuditoriaList.RetrieveList(typeof(ClaseAuditoria), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a ClaseAuditoriaList from a IList<!--<ClaseAuditoriaInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static ClaseAuditoriaList GetList(IList<ClaseAuditoriaInfo> list)
		{
			ClaseAuditoriaList flist = new ClaseAuditoriaList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (ClaseAuditoriaInfo item in list)
					flist.AddItem(item);
				
				flist.IsReadOnly = true;
			}
			
			return flist;
		}
		
		/// <summary>
		/// Devuelve una lista ordenada de todos los elementos
		/// </summary>
		/// <param name="sortProperty">Campo de ordenación</param>
		/// <param name="sortDirection">Sentido de ordenación</param>
		/// <returns>Lista ordenada de elementos</returns>
		public static SortedBindingList<ClaseAuditoriaInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<ClaseAuditoriaInfo> sortedList = new SortedBindingList<ClaseAuditoriaInfo>(GetList());
			
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
        public static SortedBindingList<ClaseAuditoriaInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<ClaseAuditoriaInfo> sortedList = new SortedBindingList<ClaseAuditoriaInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a ClaseAuditoriaList from a IList<!--<ClaseAuditoria>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ClaseAuditoriaList</returns>
        public static ClaseAuditoriaList GetList(IList<ClaseAuditoria> list)
        {
            ClaseAuditoriaList flist = new ClaseAuditoriaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (ClaseAuditoria item in list)
                    flist.AddItem(item.GetInfo());

                flist.IsReadOnly = true;
            }

            return flist;
        }
			
		#endregion
		
		#region Data Access
		 
		 	// called to retrieve data from database
			protected override void Fetch(CriteriaEx criteria)
			{
				this.RaiseListChangedEvents = false;
				
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;
				
				try
				{
					if (nHMng.UseDirectSQL)
					{
					
						IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); 
						
						IsReadOnly = false;
						
						while (reader.Read())
						{
							this.AddItem(ClaseAuditoriaInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(ClaseAuditoria item in list)
								this.AddItem(item.GetInfo(false));
								
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

        public static string SELECT() { return ClaseAuditoria.SELECT(new QueryConditions(), false); }

        #endregion
	}
}

