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
	public class DepartamentoList : ReadOnlyListBaseEx<DepartamentoList, DepartamentoInfo>
	{	

		#region Business Methods
			
		#endregion
		 
		#region Factory Methods

        private DepartamentoList() { }

        public static DepartamentoList NewList() { return new DepartamentoList(); }
		
		/// <summary>
		/// Retrieve the complete list from db
		/// </summary>
		/// <param name="get_childs">retrieving the childs</param>
		/// <returns></returns>
		public static DepartamentoList GetList(bool childs)
		{
			CriteriaEx criteria = Departamento.GetCriteria(Departamento.OpenSession());
			criteria.Childs = childs;
			
			//No criteria. Retrieve all de List
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = DepartamentoList.SELECT();
			DepartamentoList list = DataPortal.Fetch<DepartamentoList>(criteria);
			
			CloseSession(criteria.SessionCode);
			return list;
		}
		
		/// <summary>
		/// Default call for GetList(bool get_childs)
		/// </summary>
		/// <returns></returns>
		public static DepartamentoList GetList()
		{
			return DepartamentoList.GetList(true);
		}
		
		/// <summary>
		/// Devuelve una lista de todos los elementos
		/// </summary>
		/// <returns>Lista de elementos</returns>
		public static DepartamentoList GetList(CriteriaEx criteria)
		{
			return DepartamentoList.RetrieveList(typeof(Departamento), AppContext.ActiveSchema.Code, criteria);
		}
		
		/// <summary>
		/// Builds a DepartamentoList from a IList<!--<DepartamentoInfo>-->.
		/// Doesnt retrieve child data from DB.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public static DepartamentoList GetList(IList<DepartamentoInfo> list)
		{
			DepartamentoList flist = new DepartamentoList();
			
			if (list.Count > 0)
			{
				flist.IsReadOnly = false;
				
				foreach (DepartamentoInfo item in list)
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
		public static SortedBindingList<DepartamentoInfo> GetSortedList (string sortProperty, ListSortDirection sortDirection)
		{
			SortedBindingList<DepartamentoInfo> sortedList = new SortedBindingList<DepartamentoInfo>(GetList());
			
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
        public static SortedBindingList<DepartamentoInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection, bool childs)
        {
            SortedBindingList<DepartamentoInfo> sortedList = new SortedBindingList<DepartamentoInfo>(GetList(childs));

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		/// <summary>
        /// Builds a DepartamentoList from a IList<!--<Departamento>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>DepartamentoList</returns>
        public static DepartamentoList GetList(IList<Departamento> list)
        {
            DepartamentoList flist = new DepartamentoList();

            if (list != null)
            {
                flist.IsReadOnly = false;

                foreach (Departamento item in list)
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
							this.AddItem(DepartamentoInfo.Get(reader, Childs));
						}
						IsReadOnly = true;
					}
					else 
					{
						IList list = criteria.List();
						
						if (list.Count > 0)
						{
							IsReadOnly = false;
							foreach(Departamento item in list)
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

            public static string SELECT() { return Departamento.SELECT(new QueryConditions(), false); }

            #endregion
	}
}

