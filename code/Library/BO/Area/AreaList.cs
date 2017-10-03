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
	public class AreaList : ReadOnlyListBaseEx<AreaList, AreaInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private AreaList() { }

        public static AreaList NewList() { return new AreaList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static AreaList GetList(bool childs)
		{
			CriteriaEx criteria = Area.GetCriteria(Area.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = AreaList.SELECT();
			AreaList list = DataPortal.Fetch<AreaList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static AreaList GetList()
		{
			return AreaList.GetList(true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static AreaList GetList(CriteriaEx criteria)
		{
			return AreaList.RetrieveList(typeof(Area), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a AreaList from a IList<!--<AreaInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static AreaList GetList(IList<AreaInfo> list)
		{
			AreaList flist = new AreaList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (AreaInfo item in list)
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
		public static SortedBindingList<AreaInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<AreaInfo> sortedList = new SortedBindingList<AreaInfo>(GetList());
			
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
        public static SortedBindingList<AreaInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<AreaInfo> sortedList = new SortedBindingList<AreaInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a AreaList from a IList<!--<Area>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AreaList</returns>
        public static AreaList GetList(IList<Area> list)
        {
            AreaList flist = new AreaList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Area item in list)
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
							this.AddItem(AreaInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(Area item in list)
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

        public static string SELECT() { return Area.SELECT(new QueryConditions(), false); }

        #endregion
	}
}

