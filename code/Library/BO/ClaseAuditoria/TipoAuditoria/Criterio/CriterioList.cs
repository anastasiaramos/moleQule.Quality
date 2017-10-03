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
	public class CriterioList : ReadOnlyListBaseEx<CriterioList, CriterioInfo>
	{
		 
		 
		#region Factory Methods

		private CriterioList() { }
		
		private CriterioList(IList<Criterio> lista)
		{
            Fetch(lista);
        }

        private CriterioList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a CriterioList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>CriterioList</returns>
		public static CriterioList GetList(bool childs)
		{
			CriteriaEx criteria = Criterio.GetCriteria(Criterio.OpenSession());
            criteria.Childs = childs;
			
			
			criteria.Query = CriterioList.SELECT();
			

			CriterioList list = DataPortal.Fetch<CriterioList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a CriterioList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>CriterioList</returns>
		public static CriterioList GetList()
		{ 
			return CriterioList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static CriterioList GetList(CriteriaEx criteria)
        {
            return CriterioList.RetrieveList(typeof(Criterio), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a CriterioList from a IList<!--<CriterioInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CriterioList</returns>
        public static CriterioList GetChildList(IList<CriterioInfo> list)
        {
            CriterioList flist = new CriterioList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (CriterioInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a CriterioList from IList<!--<Criterio>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CriterioList</returns>
        public static CriterioList GetChildList(IList<Criterio> list) { return new CriterioList(list); }

        public static CriterioList GetChildList(IDataReader reader) { return new CriterioList(reader); }

		
		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<Criterio> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Criterio item in lista)
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
                this.AddItem(Criterio.GetChild(reader).GetInfo());

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
						this.AddItem(CriterioInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Criterio item in list)
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

        public static string SELECT() { return Criterio.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

