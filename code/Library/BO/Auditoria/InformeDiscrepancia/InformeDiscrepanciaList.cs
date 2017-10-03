using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// Read Only Child Collection of Business Objects
	/// </summary>
    [Serializable()]
	public class InformeDiscrepanciaList : ReadOnlyListBaseEx<InformeDiscrepanciaList, InformeDiscrepanciaInfo>
	{
	
	     #region Child Factory Methods

			private InformeDiscrepanciaList() { }



			private InformeDiscrepanciaList(IList<InformeDiscrepancia> lista)
			{
				Fetch(lista);
			}

			private InformeDiscrepanciaList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a InformeDiscrepanciaList from a IList<!--<InformeDiscrepanciaInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeDiscrepanciaList</returns>
			public static InformeDiscrepanciaList GetChildList(IList<InformeDiscrepanciaInfo> list)
			{
				InformeDiscrepanciaList flist = new InformeDiscrepanciaList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (InformeDiscrepanciaInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}


			/// <summary>
			/// Builds a InformeDiscrepanciaList from IList<!--<InformeDiscrepancia>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeDiscrepanciaList</returns>
			public static InformeDiscrepanciaList GetChildList(IList<InformeDiscrepancia> list) { return new InformeDiscrepanciaList(list); }

			public static InformeDiscrepanciaList GetChildList(IDataReader reader) { return new InformeDiscrepanciaList(reader); }

		#endregion

		#region Root Factory Methods

		  //  private InformeDiscrepanciaList() { }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <returns>InformeDiscrepanciaList</returns>
			public static InformeDiscrepanciaList GetList(bool childs)
			{
				CriteriaEx criteria = InformeDiscrepancia.GetCriteria(InformeDiscrepancia.OpenSession());
                criteria.Childs = childs;
				//No criteria. Retrieve all de List
				InformeDiscrepanciaList list = DataPortal.Fetch<InformeDiscrepanciaList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
            }

            /// <summary>
            /// Retrieve the complete list from db
            /// </summary>
            /// <returns>InformeDiscrepanciaList</returns>
            public static InformeDiscrepanciaList GetList()
            {
                return GetList(true);
            }

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static InformeDiscrepanciaList GetList(CriteriaEx criteria)
			{
				return InformeDiscrepanciaList.RetrieveList(typeof(InformeDiscrepancia), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a InformeDiscrepanciaList from a IList<!--<InformeDiscrepanciaInfo>-->
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeDiscrepanciaList</returns>
			public static InformeDiscrepanciaList GetList(IList<InformeDiscrepanciaInfo> list)
			{
				InformeDiscrepanciaList flist = new InformeDiscrepanciaList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (InformeDiscrepanciaInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a InformeDiscrepanciaList from a IList<!--<InformeDiscrepancia>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeDiscrepancia</returns>
			public static InformeDiscrepanciaList GetList(IList<InformeDiscrepancia> list)
			{
				InformeDiscrepanciaList flist = new InformeDiscrepanciaList();

				if (list != null)
				{
					flist.IsReadOnly = false;

					foreach (InformeDiscrepancia item in list)
						flist.AddItem(item.GetInfo());

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
			public static SortedBindingList<InformeDiscrepanciaInfo> GetSortedList(	string sortProperty,
																		ListSortDirection sortDirection)
			{
				SortedBindingList<InformeDiscrepanciaInfo> sortedList =
					new SortedBindingList<InformeDiscrepanciaInfo>(GetList());
				sortedList.ApplySort(sortProperty, sortDirection);
				return sortedList;
			}

		#endregion

		#region Child Data Access

			// called to copy objects data from list
			private void Fetch(IList<InformeDiscrepancia> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (InformeDiscrepancia item in lista)
					this.AddItem(item.GetInfo());

				IsReadOnly = true;

				this.RaiseListChangedEvents = true;
			}

			// called to copy objects data from list
			private void Fetch(IDataReader reader)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;

				while (reader.Read())
					this.AddItem(InformeDiscrepanciaInfo.Get(reader, true));

				IsReadOnly = true;

				this.RaiseListChangedEvents = true;
			}

			// called to retrieve data from db
			protected override void Fetch(CriteriaEx criteria)
			{
				this.RaiseListChangedEvents = false;

				Childs = criteria.Childs;
				SessionCode = criteria.SessionCode;

				try
				{
					if (nHMng.UseDirectSQL)
					{

						InformeDiscrepancia.LOCK(AppContext.ActiveSchema.Code);

						IDataReader reader = nHManager.Instance.SQLNativeSelect(InformeDiscrepanciaList.SELECT(), Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(InformeDiscrepanciaInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<InformeDiscrepancia> list = criteria.List<InformeDiscrepancia>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (InformeDiscrepancia item in list)
								this.AddItem(item.GetInfo());

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

		#region Root Data Access

			// called to retrieve data from db
			protected override void Fetch(string hql)
			{
				this.RaiseListChangedEvents = false;

				try
				{
					IList list = nHMng.HQLSelect(hql);

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (InformeDiscrepancia item in list)
							this.AddItem(item.GetInfo());

						IsReadOnly = true;
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

        public static string SELECT() { return InformeDiscrepancia.SELECT(new QueryConditions(), false); }

        #endregion
	
	}
}

