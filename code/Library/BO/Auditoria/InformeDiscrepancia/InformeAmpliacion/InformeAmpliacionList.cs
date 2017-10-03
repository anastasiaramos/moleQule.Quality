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
	public class InformeAmpliacionList : ReadOnlyListBaseEx<InformeAmpliacionList, InformeAmpliacionInfo>
	{
	
	     #region Child Factory Methods

			private InformeAmpliacionList() { }



			private InformeAmpliacionList(IList<InformeAmpliacion> lista)
			{
				Fetch(lista);
			}

			private InformeAmpliacionList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a InformeAmpliacionList from a IList<!--<InformeAmpliacionInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeAmpliacionList</returns>
			public static InformeAmpliacionList GetChildList(IList<InformeAmpliacionInfo> list)
			{
				InformeAmpliacionList flist = new InformeAmpliacionList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (InformeAmpliacionInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}


			/// <summary>
			/// Builds a InformeAmpliacionList from IList<!--<InformeAmpliacion>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeAmpliacionList</returns>
			public static InformeAmpliacionList GetChildList(IList<InformeAmpliacion> list) { return new InformeAmpliacionList(list); }

			public static InformeAmpliacionList GetChildList(IDataReader reader) { return new InformeAmpliacionList(reader); }

		#endregion

		#region Root Factory Methods

		  //  private InformeAmpliacionList() { }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <returns>InformeAmpliacionList</returns>
			public static InformeAmpliacionList GetList()
			{
				CriteriaEx criteria = InformeAmpliacion.GetCriteria(InformeAmpliacion.OpenSession());

				//No criteria. Retrieve all de List
				InformeAmpliacionList list = DataPortal.Fetch<InformeAmpliacionList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
			}

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static InformeAmpliacionList GetList(CriteriaEx criteria)
			{
				return InformeAmpliacionList.RetrieveList(typeof(InformeAmpliacion), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a InformeAmpliacionList from a IList<!--<InformeAmpliacionInfo>-->
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeAmpliacionList</returns>
			public static InformeAmpliacionList GetList(IList<InformeAmpliacionInfo> list)
			{
				InformeAmpliacionList flist = new InformeAmpliacionList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (InformeAmpliacionInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a InformeAmpliacionList from a IList<!--<InformeAmpliacion>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>InformeAmpliacion</returns>
			public static InformeAmpliacionList GetList(IList<InformeAmpliacion> list)
			{
				InformeAmpliacionList flist = new InformeAmpliacionList();

				if (list != null)
				{
					flist.IsReadOnly = false;

					foreach (InformeAmpliacion item in list)
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
			public static SortedBindingList<InformeAmpliacionInfo> GetSortedList(	string sortProperty,
																		ListSortDirection sortDirection)
			{
				SortedBindingList<InformeAmpliacionInfo> sortedList =
					new SortedBindingList<InformeAmpliacionInfo>(GetList());
				sortedList.ApplySort(sortProperty, sortDirection);
				return sortedList;
			}

		#endregion

		#region Child Data Access

			// called to copy objects data from list
			private void Fetch(IList<InformeAmpliacion> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (InformeAmpliacion item in lista)
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
					this.AddItem(InformeAmpliacionInfo.Get(reader, true));

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

						InformeAmpliacion.LOCK(AppContext.ActiveSchema.Code);

                        IDataReader reader = nHManager.Instance.SQLNativeSelect(InformeAmpliacionList.SELECT(), Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(InformeAmpliacionInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<InformeAmpliacion> list = criteria.List<InformeAmpliacion>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (InformeAmpliacion item in list)
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

						foreach (InformeAmpliacion item in list)
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

        public static string SELECT() { return InformeAmpliacion.SELECT(new QueryConditions(), false); }

        #endregion
	
	}
}

