using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Quality
{
	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class DepartamentoInfo : ReadOnlyBaseEx<DepartamentoInfo>, Hipatia.IAgenteHipatia
	{
        #region IAgenteHipatia

        public string NombreHipatia { get { return Nombre; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return string.Empty; } }
        public Type TipoEntidad { get { return typeof(Departamento); } }

        #endregion

        #region Attributes

        protected DepartamentoBase _base = new DepartamentoBase();


        #endregion

        #region Properties

        public DepartamentoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Telefonos { get { return _base.Record.Telefonos; } }
        public string Fax { get { return _base.Record.Fax; } }
        public string Email { get { return _base.Record.Email; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Departamento source) { _base.CopyValues(source); }

        #endregion		
		
		#region Factory Methods
		
		private DepartamentoInfo() { /* require use of factory methods */ }
		
		private DepartamentoInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de DepartamentoInfo a partir de un Departamento
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal DepartamentoInfo(Departamento item)
			: this(item, false)
		{
		}
		
		internal DepartamentoInfo(Departamento item, bool childs)
		{
            _base.CopyValues(item);
		}
		
		/// <summary>
		/// Devuelve un DepartamentoInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		
		public static DepartamentoInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un DepartamentoInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static DepartamentoInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Departamento.GetCriteria(Departamento.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = Departamento.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
			DepartamentoInfo obj = DataPortal.Fetch<DepartamentoInfo>(criteria);
			Departamento.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static DepartamentoInfo Get(IDataReader reader, bool childs)
        {
			return new DepartamentoInfo(reader, childs);
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
                    _base.Record.CopyValues((DepartamentoRecord)(criteria.UniqueResult()));
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



