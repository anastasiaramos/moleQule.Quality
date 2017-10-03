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
	public class AreaInfo : ReadOnlyBaseEx<AreaInfo>
    {
        #region Attributes

        protected AreaBase _base = new AreaBase();


        #endregion

        #region Properties

        public AreaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Area source) { _base.CopyValues(source); }

        #endregion		
		
		#region Factory Methods
		
		private AreaInfo() { /* require use of factory methods */ }
		
		private AreaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal AreaInfo(Area item)
			: this(item, false)
		{
		}
		
		internal AreaInfo(Area item, bool childs)
		{
			Oid = item.Oid;
			_base.Record.Nombre = item.Nombre;
            _base.Record.Codigo = item.Codigo;
            _base.Record.Serial = item.Serial;
            _base.Record.Observaciones = item.Observaciones;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		
		public static AreaInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static AreaInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Area.GetCriteria(Area.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = Area.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
			AreaInfo obj = DataPortal.Fetch<AreaInfo>(criteria);
			Area.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static AreaInfo Get(IDataReader reader, bool childs)
        {
			return new AreaInfo(reader, childs);
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
						
                        
                    }
				}
				else
				{
                    _base.Record.CopyValues((AreaRecord)(criteria.UniqueResult()));
					if (Childs)
					{
                        
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
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		#endregion
	}
}



