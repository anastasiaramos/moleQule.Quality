using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// Read Only Child Collection of Business Objects
	/// </summary>
    [Serializable()]
	public class NotificacionInternaList : ReadOnlyListBaseEx<NotificacionInternaList, NotificacionInternaInfo>
	{
		 
		 
		#region Factory Methods

		private NotificacionInternaList() { }

        private NotificacionInternaList(IList<NotificacionInterna> lista)
		{
            Fetch(lista);
        }

        private NotificacionInternaList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a AuditoriaAreaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AuditoriaAreaList</returns>
		public static NotificacionInternaList GetList(bool childs)
		{
            CriteriaEx criteria = NotificacionInterna.GetCriteria(NotificacionInterna.OpenSession());
            criteria.Childs = childs;


            criteria.Query = NotificacionInternaList.SELECT();
			

			NotificacionInternaList list = DataPortal.Fetch<NotificacionInternaList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a AuditoriaAreaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AuditoriaAreaList</returns>
		public static NotificacionInternaList GetList()
		{ 
			return NotificacionInternaList.GetList(true); 
		}

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<NotificacionInternaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<NotificacionInternaInfo> sortedList =
                new SortedBindingList<NotificacionInternaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static NotificacionInternaList GetList(CriteriaEx criteria)
        {
            return NotificacionInternaList.RetrieveList(typeof(NotificacionInterna), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a AuditoriaAreaList from a IList<!--<AuditoriaAreaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AuditoriaAreaList</returns>
        public static NotificacionInternaList GetChildList(IList<NotificacionInternaInfo> list)
        {
            NotificacionInternaList flist = new NotificacionInternaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (NotificacionInternaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a AuditoriaAreaList from IList<!--<AuditoriaArea>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AuditoriaAreaList</returns>
        public static NotificacionInternaList GetChildList(IList<NotificacionInterna> list) { return new NotificacionInternaList(list); }

        public static NotificacionInternaList GetChildList(IDataReader reader) { return new NotificacionInternaList(reader); }

		
		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<NotificacionInterna> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (NotificacionInterna item in lista)
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
                this.AddItem(NotificacionInterna.GetChild(reader).GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
		
		// called to retrieve data from db
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
						this.AddItem(NotificacionInternaInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

                        foreach (NotificacionInterna item in list)
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

        #region SQL

        public static string SELECT() { return NotificacionInterna.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

