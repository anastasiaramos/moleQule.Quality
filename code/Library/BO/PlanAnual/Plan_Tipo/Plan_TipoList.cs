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
	public class Plan_TipoList : ReadOnlyListBaseEx<Plan_TipoList, Plan_TipoInfo>
	{		 
		 
		#region Factory Methods

		private Plan_TipoList() { }
		
		private Plan_TipoList(IList<Plan_Tipo> lista)
		{
            Fetch(lista);
        }

        private Plan_TipoList(IDataReader reader)
		{
			Fetch(reader);
		}
		
		/// <summary>
		/// Builds a PlanClaseList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>PlanClaseList</returns>
        public static Plan_TipoList GetList(bool childs)
		{
			CriteriaEx criteria = Plan_Tipo.GetCriteria(Plan_Tipo.OpenSession());
            criteria.Childs = childs;


            criteria.Query = Plan_TipoList.SELECT();


            Plan_TipoList list = DataPortal.Fetch<Plan_TipoList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
        }

        /// <summary>
        /// Builds a PlanClaseList
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlanClaseList</returns>
        public static Plan_TipoList GetPlanAnualList(long oid_plan)
        {
            CriteriaEx criteria = Plan_Tipo.GetCriteria(Plan_Tipo.OpenSession());
            criteria.Childs = false;


            criteria.Query = Plan_TipoList.SELECT_PLAN_ANUAL(oid_plan);


            Plan_TipoList list = DataPortal.Fetch<Plan_TipoList>(criteria);

            CloseSession(criteria.SessionCode);
            return list;
        }

		/// <summary>
		/// Builds a PlanClaseList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>PlanClaseList</returns>
        public static Plan_TipoList GetList()
		{
            return Plan_TipoList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static Plan_TipoList GetList(CriteriaEx criteria)
        {
            return Plan_TipoList.RetrieveList(typeof(Plan_Tipo), AppContext.ActiveSchema.Code, criteria);
        }
		
		/// <summary>
        /// Builds a PlanClaseList from a IList<!--<PlanClaseInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlanClaseList</returns>
        public static Plan_TipoList GetChildList(IList<Plan_TipoInfo> list)
        {
            Plan_TipoList flist = new Plan_TipoList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Plan_TipoInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a PlanClaseList from IList<!--<PlanClase>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>PlanClaseList</returns>
        public static Plan_TipoList GetChildList(IList<Plan_Tipo> list) { return new Plan_TipoList(list); }

        public static Plan_TipoList GetChildList(IDataReader reader) { return new Plan_TipoList(reader); }

		
		#endregion

		#region Data Access
		
		// called to copy objects data from list
        private void Fetch(IList<Plan_Tipo> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Plan_Tipo item in lista)
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
                this.AddItem(Plan_Tipo.GetChild(reader).GetInfo());

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
						this.AddItem(Plan_TipoInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (Plan_Tipo item in list)
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

        private static string SELECT_PLAN_ANUAL(long oid_plan)
        {
            string tabla_plan_tipo = nHManager.Instance.GetSQLTable(typeof(Plan_TipoRecord));
            string tabla_tipo_auditoria = nHManager.Instance.GetSQLTable(typeof(TipoAuditoriaRecord));
            string columna_numero = nHManager.Instance.GetTableField(typeof(TipoAuditoriaRecord), "Numero");
            string columna_oid_tipo = nHManager.Instance.GetTableField(typeof(Plan_TipoRecord), "OidTipo");
            string columna_oid_plan = nHManager.Instance.GetTableField(typeof(Plan_TipoRecord), "OidPlan");            

            string query = "SELECT T.\"" + columna_numero + "\" AS NUMERO, PT.*"
            + " FROM " + tabla_plan_tipo + " AS PT "
            + " INNER JOIN " + tabla_tipo_auditoria + " AS T ON (T.\"OID\" = PT.\"" + columna_oid_tipo + "\")"
            + " WHERE PT.\"" + columna_oid_plan + "\" = " + oid_plan.ToString()
            + " ORDER BY NUMERO;";

            return query;

           /*SELECT T."NUMERO" AS NUMERO, PT.*
FROM "0001"."Plan_Tipo" as PT
INNER JOIN "0001"."TipoAuditoria" AS T ON (T."OID" = PT."OID_TIPO")
WHERE PT."OID_PLAN" = 6
ORDER BY NUMERO;*/
        }
        
        public static string SELECT() { return Plan_Tipo.SELECT(new QueryConditions(), false); }
        
        #endregion

    }
}

