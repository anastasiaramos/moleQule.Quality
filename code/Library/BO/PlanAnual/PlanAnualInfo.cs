using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class PlanAnualInfo : ReadOnlyBaseEx<PlanAnualInfo>
    {
        #region Attributes

        protected PlanAnualBase _base = new PlanAnualBase();

        private Plan_TipoList _planes_tipos = null;


        #endregion

        #region Properties

        public PlanAnualBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Edicion { get { return _base.Record.Edicion; } }
        public string Revision { get { return _base.Record.Revision; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public long Ano { get { return _base.Record.Ano; } }

        public virtual Plan_TipoList PlanesTipos { get { return _planes_tipos; } }



        #endregion

        #region Business Methods

        public void CopyFrom(PlanAnual source) { _base.CopyValues(source); }

        #endregion		
		
		#region Factory Methods
		
		private PlanAnualInfo() { /* require use of factory methods */ }
		
		private PlanAnualInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de PlanAnualInfo a partir de un PlanAnual
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal PlanAnualInfo(PlanAnual item)
			: this(item, false)
		{
		}
		
		internal PlanAnualInfo(PlanAnual item, bool childs)
        {
            _base.CopyValues(item);
			
			
			if (childs)
			{
				if (item.PlanesTipos != null)
                    _planes_tipos = Plan_TipoList.GetChildList(item.PlanesTipos);
				
			}
		}
		
		/// <summary>
		/// Devuelve un PlanAnualInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		
		public static PlanAnualInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un PlanAnualInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static PlanAnualInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = PlanAnual.GetCriteria(PlanAnual.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = PlanAnual.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
			PlanAnualInfo obj = DataPortal.Fetch<PlanAnualInfo>(criteria);
			PlanAnual.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static PlanAnualInfo Get(IDataReader reader, bool childs)
        {
			return new PlanAnualInfo(reader, childs);
		}
		
 		#endregion
		 
		#region Data Access
		 
		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;
			try
			{
				if (nHMng.UseDirectSQL)
				{
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					if (reader.Read())
						_base.CopyValues(reader);
					
                    if (Childs)
					{
						string query = string.Empty;
						
                        query = Planes_Tipos.SELECT_BY_FIELD( "OidPlan", this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _planes_tipos = Plan_TipoList.GetChildList(reader);
						
						
                    }
				}
				else
				{
                    _base.Record.CopyValues((PlanAnualRecord)(criteria.UniqueResult()));
					if (Childs)
					{
                        criteria = Plan_Tipo.GetCriteria(criteria.Session);
                        criteria.AddEq("OidPlan", this.Oid);
                        _planes_tipos = Plan_TipoList.GetChildList(criteria.List<Plan_Tipo>());
						
						
					}
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		//called to copy data from IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
				_base.CopyValues(source);
				
				if (Childs)
				{
					string query = string.Empty;
					IDataReader reader;
					
					query = Planes_Tipos.SELECT_BY_FIELD( "OidPlan", this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _planes_tipos = Plan_TipoList.GetChildList(reader);
					
					
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		#endregion
	}
}



