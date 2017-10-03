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
	public class AccionCorrectoraList : ReadOnlyListBaseEx<AccionCorrectoraList, AccionCorrectoraInfo>
	{
		 
		 
		#region Factory Methods

		private AccionCorrectoraList() { }
		
		private AccionCorrectoraList(IList<AccionCorrectora> lista)
		{
            Fetch(lista);
        }

        private AccionCorrectoraList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a AccioncorrectoraList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AccioncorrectoraList</returns>
		public static AccionCorrectoraList GetList(bool childs)
		{
			CriteriaEx criteria = AccionCorrectora.GetCriteria(AccionCorrectora.OpenSession());
            criteria.Childs = childs;


            criteria.Query = AccionCorrectoraList.SELECT();
			

			AccionCorrectoraList list = DataPortal.Fetch<AccionCorrectoraList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a AccioncorrectoraList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AccioncorrectoraList</returns>
		public static AccionCorrectoraList GetList()
		{ 
			return AccionCorrectoraList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static AccionCorrectoraList GetList(CriteriaEx criteria)
        {
            return AccionCorrectoraList.RetrieveList(typeof(AccionCorrectora), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a AccioncorrectoraList from a IList<!--<AccioncorrectoraInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AccioncorrectoraList</returns>
        public static AccionCorrectoraList GetChildList(IList<AccionCorrectoraInfo> list)
        {
            AccionCorrectoraList flist = new AccionCorrectoraList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (AccionCorrectoraInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a AccioncorrectoraList from IList<!--<Accioncorrectora>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AccioncorrectoraList</returns>
        public static AccionCorrectoraList GetChildList(IList<AccionCorrectora> list) { return new AccionCorrectoraList(list); }

        public static AccionCorrectoraList GetChildList(IDataReader reader) { return new AccionCorrectoraList(reader); }


        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<AccionCorrectoraInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<AccionCorrectoraInfo> sortedList =
                new SortedBindingList<AccionCorrectoraInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<AccionCorrectora> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (AccionCorrectora item in lista)
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
                this.AddItem(AccionCorrectora.GetChild(reader).GetInfo());

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
						this.AddItem(AccionCorrectoraInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (AccionCorrectora item in list)
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

        public static string SELECT() { return AccionCorrectora.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

