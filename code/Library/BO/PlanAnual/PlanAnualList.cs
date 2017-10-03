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
	public class PlanAnualList : ReadOnlyListBaseEx<PlanAnualList, PlanAnualInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods
		 
		private PlanAnualList() {}

        public static PlanAnualList NewList() { return new PlanAnualList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static PlanAnualList GetList(bool childs)
		{
			CriteriaEx criteria = PlanAnual.GetCriteria(PlanAnual.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = PlanAnualList.SELECT();
			PlanAnualList list = DataPortal.Fetch<PlanAnualList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static PlanAnualList GetList()
		{
			return PlanAnualList.GetList(true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static PlanAnualList GetList(CriteriaEx criteria)
		{
			return PlanAnualList.RetrieveList(typeof(PlanAnual), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a PlanAnualList from a IList<!--<PlanAnualInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static PlanAnualList GetList(IList<PlanAnualInfo> list)
		{
			PlanAnualList flist = new PlanAnualList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (PlanAnualInfo item in list)
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
		public static SortedBindingList<PlanAnualInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<PlanAnualInfo> sortedList = new SortedBindingList<PlanAnualInfo>(GetList());
			
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
        public static SortedBindingList<PlanAnualInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<PlanAnualInfo> sortedList = new SortedBindingList<PlanAnualInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a PlanAnualList from a IList<!--<PlanAnual>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlanAnualList</returns>
        public static PlanAnualList GetList(IList<PlanAnual> list)
        {
            PlanAnualList flist = new PlanAnualList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (PlanAnual item in list)
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
							this.AddItem(PlanAnualInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(PlanAnual item in list)
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
        
        public static string SELECT() { return PlanAnual.SELECT(new QueryConditions(), false); }

        #endregion
	}
}

