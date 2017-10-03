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
	public class AmpliacionList : ReadOnlyListBaseEx<AmpliacionList, AmpliacionInfo>
	{
		 
		 
		#region Factory Methods

		private AmpliacionList() { }
		
		private AmpliacionList(IList<Ampliacion> lista)
		{
            Fetch(lista);
        }

        private AmpliacionList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a AmpliacionList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AmpliacionList</returns>
		public static AmpliacionList GetList(bool childs)
		{
			CriteriaEx criteria = Ampliacion.GetCriteria(Ampliacion.OpenSession());
            criteria.Childs = childs;
			
			
			criteria.Query = AmpliacionList.SELECT();
			

			AmpliacionList list = DataPortal.Fetch<AmpliacionList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a AmpliacionList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AmpliacionList</returns>
		public static AmpliacionList GetList()
		{ 
			return AmpliacionList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static AmpliacionList GetList(CriteriaEx criteria)
        {
            return AmpliacionList.RetrieveList(typeof(Ampliacion), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a AmpliacionList from a IList<!--<AmpliacionInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AmpliacionList</returns>
        public static AmpliacionList GetChildList(IList<AmpliacionInfo> list)
        {
            AmpliacionList flist = new AmpliacionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (AmpliacionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a AmpliacionList from IList<!--<Ampliacion>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AmpliacionList</returns>
        public static AmpliacionList GetChildList(IList<Ampliacion> list) { return new AmpliacionList(list); }

        public static AmpliacionList GetChildList(IDataReader reader) { return new AmpliacionList(reader); }


        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<AmpliacionInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<AmpliacionInfo> sortedList =
                new SortedBindingList<AmpliacionInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }

		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<Ampliacion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Ampliacion item in lista)
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
                this.AddItem(Ampliacion.GetChild(reader).GetInfo());

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
						this.AddItem(AmpliacionInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Ampliacion item in list)
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

        public static string SELECT() { return Ampliacion.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

