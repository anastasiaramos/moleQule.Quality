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
	public class PuntoActaList : ReadOnlyListBaseEx<PuntoActaList, PuntoActaInfo>
	{
		 
		 
		#region Factory Methods

		private PuntoActaList() { }
		
		private PuntoActaList(IList<PuntoActa> lista)
		{
            Fetch(lista);
        }

        private PuntoActaList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a PuntoActaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>PuntoActaList</returns>
		public static PuntoActaList GetList(bool childs)
		{
			CriteriaEx criteria = PuntoActa.GetCriteria(PuntoActa.OpenSession());
            criteria.Childs = childs;
			
			
			criteria.Query = PuntoActaList.SELECT();
			

			PuntoActaList list = DataPortal.Fetch<PuntoActaList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a PuntoActaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>PuntoActaList</returns>
		public static PuntoActaList GetList()
		{ 
			return PuntoActaList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static PuntoActaList GetList(CriteriaEx criteria)
        {
            return PuntoActaList.RetrieveList(typeof(PuntoActa), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a PuntoActaList from a IList<!--<PuntoActaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PuntoActaList</returns>
        public static PuntoActaList GetChildList(IList<PuntoActaInfo> list)
        {
            PuntoActaList flist = new PuntoActaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (PuntoActaInfo item in list)
                    flist.Add(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PuntoActaList from IList<!--<PuntoActa>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PuntoActaList</returns>
        public static PuntoActaList GetChildList(IList<PuntoActa> list) { return new PuntoActaList(list); }

        public static PuntoActaList GetChildList(IDataReader reader) { return new PuntoActaList(reader); }


        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<PuntoActaInfo> GetSortedList(string sortProperty, ListSortDirection sortDirection)
        {
            SortedBindingList<PuntoActaInfo> sortedList = new SortedBindingList<PuntoActaInfo>(GetList());

            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
        }
		
		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<PuntoActa> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (PuntoActa item in lista)
                this.Add(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.Add(PuntoActa.GetChild(reader).GetInfo());

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
						this.AddItem(PuntoActaInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (PuntoActa item in list)
							this.Add(item.GetInfo());

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

        public static string SELECT() { return PuntoActa.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

