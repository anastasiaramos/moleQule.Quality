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
	public class ActaComiteList : ReadOnlyListBaseEx<ActaComiteList, ActaComiteInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private ActaComiteList() { }

        public static ActaComiteList NewList() { return new ActaComiteList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static ActaComiteList GetList(bool childs)
		{
			CriteriaEx criteria = ActaComite.GetCriteria(ActaComite.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ActaComiteList.SELECT();
			ActaComiteList list = DataPortal.Fetch<ActaComiteList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static ActaComiteList GetList()
		{
			return ActaComiteList.GetList(true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static ActaComiteList GetList(CriteriaEx criteria)
		{
			return ActaComiteList.RetrieveList(typeof(ActaComite), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a ActaComiteList from a IList<!--<ActaComiteInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static ActaComiteList GetList(IList<ActaComiteInfo> list)
		{
			ActaComiteList flist = new ActaComiteList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (ActaComiteInfo item in list)
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
		public static SortedBindingList<ActaComiteInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<ActaComiteInfo> sortedList = new SortedBindingList<ActaComiteInfo>(GetList());
			
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
        public static SortedBindingList<ActaComiteInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<ActaComiteInfo> sortedList = new SortedBindingList<ActaComiteInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a ActaComiteList from a IList<!--<ActaComite>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ActaComiteList</returns>
        public static ActaComiteList GetList(IList<ActaComite> list)
        {
            ActaComiteList flist = new ActaComiteList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (ActaComite item in list)
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
							this.AddItem(ActaComiteInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(ActaComite item in list)
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

        public static string SELECT() { return ActaComite.SELECT(new QueryConditions(), false); }

        #endregion
	}
}

