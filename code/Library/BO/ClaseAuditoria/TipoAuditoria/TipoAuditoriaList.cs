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
	public class TipoAuditoriaList : ReadOnlyListBaseEx<TipoAuditoriaList, TipoAuditoriaInfo>
	{
	
	     #region Child Factory Methods

			private TipoAuditoriaList() { }



			private TipoAuditoriaList(IList<TipoAuditoria> lista)
			{
				Fetch(lista);
			}

			private TipoAuditoriaList(IDataReader reader)
			{
				Fetch(reader);
			}

			/// <summary>
			/// Builds a TipoAuditoriaList from a IList<!--<TipoAuditoriaInfo>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>TipoAuditoriaList</returns>
			public static TipoAuditoriaList GetChildList(IList<TipoAuditoriaInfo> list)
			{
				TipoAuditoriaList flist = new TipoAuditoriaList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (TipoAuditoriaInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}


			/// <summary>
			/// Builds a TipoAuditoriaList from IList<!--<TipoAuditoria>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>TipoAuditoriaList</returns>
			public static TipoAuditoriaList GetChildList(IList<TipoAuditoria> list) { return new TipoAuditoriaList(list); }

			public static TipoAuditoriaList GetChildList(IDataReader reader) { return new TipoAuditoriaList(reader); }

		#endregion

		#region Root Factory Methods

		  //  private TipoAuditoriaList() { }

			/// <summary>
			/// Retrieve the complete list from db
			/// </summary>
			/// <returns>TipoAuditoriaList</returns>
			public static TipoAuditoriaList GetList()
			{
				CriteriaEx criteria = TipoAuditoria.GetCriteria(TipoAuditoria.OpenSession());

				//No criteria. Retrieve all de List
				TipoAuditoriaList list = DataPortal.Fetch<TipoAuditoriaList>(criteria);

				CloseSession(criteria.SessionCode);

				return list;
			}


            /// <summary>
            /// Retrieve the complete list from db
            /// </summary>
            /// <returns>TipoAuditoriaList</returns>
            public static TipoAuditoriaList GetClaseList(long oid_clase)
            {
                CriteriaEx criteria = TipoAuditoria.GetCriteria(TipoAuditoria.OpenSession());

                //No criteria. Retrieve all de List
                criteria.Query = TipoAuditorias.SELECT_BY_CLASE_AUDITORIA(oid_clase);
                TipoAuditoriaList list = DataPortal.Fetch<TipoAuditoriaList>(criteria);

                CloseSession(criteria.SessionCode);

                return list;
            }

			/// <summary>
			/// Devuelve una lista de todos los elementos
			/// </summary>
			/// <returns>Lista de elementos</returns>
			public static TipoAuditoriaList GetList(CriteriaEx criteria)
			{
				return TipoAuditoriaList.RetrieveList(typeof(TipoAuditoria), AppContext.ActiveSchema.Code, criteria);
			}

			/// <summary>
			/// Builds a TipoAuditoriaList from a IList<!--<TipoAuditoriaInfo>-->
			/// Doesn`t retrieve child data from DB.
			/// </summary>
			/// <param name="list"></param>
			/// <returns>TipoAuditoriaList</returns>
			public static TipoAuditoriaList GetList(IList<TipoAuditoriaInfo> list)
			{
				TipoAuditoriaList flist = new TipoAuditoriaList();

				if (list.Count > 0)
				{
					flist.IsReadOnly = false;

					foreach (TipoAuditoriaInfo item in list)
						flist.AddItem(item);

					flist.IsReadOnly = true;
				}

				return flist;
			}

			/// <summary>
			/// Builds a TipoAuditoriaList from a IList<!--<TipoAuditoria>-->
			/// </summary>
			/// <param name="list"></param>
			/// <returns>TipoAuditoria</returns>
			public static TipoAuditoriaList GetList(IList<TipoAuditoria> list)
			{
				TipoAuditoriaList flist = new TipoAuditoriaList();

				if (list != null)
				{
					flist.IsReadOnly = false;

					foreach (TipoAuditoria item in list)
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
			public static SortedBindingList<TipoAuditoriaInfo> GetSortedList(	string sortProperty,
																		ListSortDirection sortDirection)
			{
				SortedBindingList<TipoAuditoriaInfo> sortedList =
					new SortedBindingList<TipoAuditoriaInfo>(GetList());
				sortedList.ApplySort(sortProperty, sortDirection);
				return sortedList;
			}

		#endregion

		#region Child Data Access

			// called to copy objects data from list
			private void Fetch(IList<TipoAuditoria> lista)
			{
				this.RaiseListChangedEvents = false;

				IsReadOnly = false;
				
				foreach (TipoAuditoria item in lista)
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
					this.AddItem(TipoAuditoriaInfo.Get(reader, true));

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
                        IDataReader reader = null;

                        reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

						IsReadOnly = false;

						while (reader.Read())
						{
							this.AddItem(TipoAuditoriaInfo.Get(reader,Childs));
						}

						IsReadOnly = true;
					}
					else
					{
						IList<TipoAuditoria> list = criteria.List<TipoAuditoria>();

						if (list.Count > 0)
						{
							IsReadOnly = false;

							foreach (TipoAuditoria item in list)
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

						foreach (TipoAuditoria item in list)
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
	
	}
}

