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
	public class Auditoria_AreaList : ReadOnlyListBaseEx<Auditoria_AreaList, Auditoria_AreaInfo>
	{
		 
		 
		#region Factory Methods

		private Auditoria_AreaList() { }
		
		private Auditoria_AreaList(IList<Auditoria_Area> lista)
		{
            Fetch(lista);
        }

        private Auditoria_AreaList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a AuditoriaAreaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AuditoriaAreaList</returns>
		public static Auditoria_AreaList GetList(bool childs)
		{
			CriteriaEx criteria = Auditoria_Area.GetCriteria(Auditoria_Area.OpenSession());
            criteria.Childs = childs;


            criteria.Query = Auditoria_AreaList.SELECT();
			

			Auditoria_AreaList list = DataPortal.Fetch<Auditoria_AreaList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a AuditoriaAreaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>AuditoriaAreaList</returns>
		public static Auditoria_AreaList GetList()
		{ 
			return Auditoria_AreaList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static Auditoria_AreaList GetList(CriteriaEx criteria)
        {
            return Auditoria_AreaList.RetrieveList(typeof(Auditoria_Area), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a AuditoriaAreaList from a IList<!--<AuditoriaAreaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>AuditoriaAreaList</returns>
        public static Auditoria_AreaList GetChildList(IList<Auditoria_AreaInfo> list)
        {
            Auditoria_AreaList flist = new Auditoria_AreaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Auditoria_AreaInfo item in list)
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
        public static Auditoria_AreaList GetChildList(IList<Auditoria_Area> list) { return new Auditoria_AreaList(list); }

        public static Auditoria_AreaList GetChildList(IDataReader reader) { return new Auditoria_AreaList(reader); }

		
		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<Auditoria_Area> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Auditoria_Area item in lista)
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
                this.AddItem(Auditoria_Area.GetChild(reader).GetInfo());

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
						this.AddItem(Auditoria_AreaInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Auditoria_Area item in list)
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

        public static string SELECT() { return Auditoria_Area.SELECT(new QueryConditions(), false); }

        #endregion

	
	}
}

