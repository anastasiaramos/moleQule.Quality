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
	public class CuestionAuditoriaList : ReadOnlyListBaseEx<CuestionAuditoriaList, CuestionAuditoriaInfo>
	{
		 
		 
		#region Factory Methods

		private CuestionAuditoriaList() { }
		
		private CuestionAuditoriaList(IList<CuestionAuditoria> lista)
		{
            Fetch(lista);
        }

        private CuestionAuditoriaList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a CuestionauditoriaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>CuestionauditoriaList</returns>
		public static CuestionAuditoriaList GetList(bool childs)
		{
			CriteriaEx criteria = CuestionAuditoria.GetCriteria(CuestionAuditoria.OpenSession());
            criteria.Childs = childs;
			
			
			criteria.Query = CuestionAuditoriaList.SELECT();
			

			CuestionAuditoriaList list = DataPortal.Fetch<CuestionAuditoriaList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a CuestionauditoriaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>CuestionauditoriaList</returns>
		public static CuestionAuditoriaList GetList()
		{ 
			return CuestionAuditoriaList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static CuestionAuditoriaList GetList(CriteriaEx criteria)
        {
            return CuestionAuditoriaList.RetrieveList(typeof(CuestionAuditoria), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a CuestionauditoriaList from a IList<!--<CuestionauditoriaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CuestionauditoriaList</returns>
        public static CuestionAuditoriaList GetChildList(IList<CuestionAuditoriaInfo> list)
        {
            CuestionAuditoriaList flist = new CuestionAuditoriaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (CuestionAuditoriaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a CuestionauditoriaList from IList<!--<Cuestionauditoria>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>CuestionauditoriaList</returns>
        public static CuestionAuditoriaList GetChildList(IList<CuestionAuditoria> list) { return new CuestionAuditoriaList(list); }

        public static CuestionAuditoriaList GetChildList(IDataReader reader) { return new CuestionAuditoriaList(reader); }

		
		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<CuestionAuditoria> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (CuestionAuditoria item in lista)
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
                this.AddItem(CuestionAuditoria.GetChild(reader).GetInfo());

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
						this.AddItem(CuestionAuditoriaInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (CuestionAuditoria item in list)
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

        public static string SELECT() { return ClaseAuditoria.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

