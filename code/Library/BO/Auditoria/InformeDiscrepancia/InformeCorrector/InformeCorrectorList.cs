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
	public class InformeCorrectorList : ReadOnlyListBaseEx<InformeCorrectorList, InformeCorrectorInfo>
	{
	
	     #region Child Factory Methods

			private InformeCorrectorList() { }



			private InformeCorrectorList(IList<InformeCorrector> lista)
			{
				Fetch(lista);
			}

			private InformeCorrectorList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a InformeCorrectorList from a IList<!--<InformeCorrectorInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeCorrectorList</returns>
			public static InformeCorrectorList GetChildList(IList<InformeCorrectorInfo> list)
			{
				InformeCorrectorList flist = new InformeCorrectorList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (InformeCorrectorInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}


			/// <summary>
			/// Builds a InformeCorrectorList from IList<!--<InformeCorrector>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeCorrectorList</returns>
			public static InformeCorrectorList GetChildList(IList<InformeCorrector> list) { return new InformeCorrectorList(list); }

			public static InformeCorrectorList GetChildList(IDataReader reader) { return new InformeCorrectorList(reader); }

		#endregion

		#region Root Factory Methods

		  //  private InformeCorrectorList() { }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <returns>InformeCorrectorList</returns>
			public static InformeCorrectorList GetList()
			{
				CriteriaEx criteria = InformeCorrector.GetCriteria(InformeCorrector.OpenSession());

				//No criteria. Retrieve all de List
				InformeCorrectorList list = DataPortal.Fetch<InformeCorrectorList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
			}

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static InformeCorrectorList GetList(CriteriaEx criteria)
			{
				return InformeCorrectorList.RetrieveList(typeof(InformeCorrector), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a InformeCorrectorList from a IList<!--<InformeCorrectorInfo>-->
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeCorrectorList</returns>
			public static InformeCorrectorList GetList(IList<InformeCorrectorInfo> list)
			{
				InformeCorrectorList flist = new InformeCorrectorList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (InformeCorrectorInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a InformeCorrectorList from a IList<!--<InformeCorrector>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeCorrector</returns>
			public static InformeCorrectorList GetList(IList<InformeCorrector> list)
			{
				InformeCorrectorList flist = new InformeCorrectorList();

				if (list != null)
				{
					flist.IsReadOnly = false;

					foreach (InformeCorrector item in list)
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
			public static SortedBindingList<InformeCorrectorInfo> GetSortedList(	string sortProperty,
																		ListSortDirection sortDirection)
			{
				SortedBindingList<InformeCorrectorInfo> sortedList =
					new SortedBindingList<InformeCorrectorInfo>(GetList());
				sortedList.ApplySort(sortProperty, sortDirection);
				return sortedList;
			}

		#endregion

		#region Child Data Access

			// called to copy objects data from list
			private void Fetch(IList<InformeCorrector> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (InformeCorrector item in lista)
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
					this.AddItem(InformeCorrectorInfo.Get(reader, true));

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

						InformeCorrector.LOCK(AppContext.ActiveSchema.Code);

                        IDataReader reader = nHManager.Instance.SQLNativeSelect(InformeCorrectorList.SELECT(), Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(InformeCorrectorInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<InformeCorrector> list = criteria.List<InformeCorrector>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (InformeCorrector item in list)
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

						foreach (InformeCorrector item in list)
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

        public static string SELECT() { return InformeCorrector.SELECT(new QueryConditions(), false); }

        #endregion
	
	}
}

