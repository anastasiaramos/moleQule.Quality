using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class ClaseAuditoriaInfo : ReadOnlyBaseEx<ClaseAuditoriaInfo>
    {
        #region Attributes

        protected ClaseAuditoriaBase _base = new ClaseAuditoriaBase();

        private TipoAuditoriaList _tipoauditorias = null;


        #endregion

        #region Properties

        public ClaseAuditoriaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public long Numero { get { return _base.Record.Numero; } }
        public string Tipo { get { return _base.Record.Tipo; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }

        public virtual TipoAuditoriaList TipoAuditorias { get { return _tipoauditorias; } }	



        #endregion

        #region Business Methods

        public void CopyFrom(ClaseAuditoria source) { _base.CopyValues(source); }

        #endregion		
		
		#region Factory Methods
		
		private ClaseAuditoriaInfo() { /* require use of factory methods */ }
		
		private ClaseAuditoriaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de ClaseAuditoriaInfo a partir de un ClaseAuditoria
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal ClaseAuditoriaInfo(ClaseAuditoria item)
			: this(item, false)
		{
		}
		
		internal ClaseAuditoriaInfo(ClaseAuditoria item, bool childs)
		{
			Oid = item.Oid;
			_base.Record.Codigo = item.Codigo;
			_base.Record.Serial = item.Serial;
			_base.Record.Numero = item.Numero;
			_base.Record.Tipo = item.Tipo;
			_base.Record.Nombre = item.Nombre;
			_base.Record.Observaciones = item.Observaciones;
			
			
			if (childs)
			{
				if (item.TipoAuditorias != null)
					_tipoauditorias = TipoAuditoriaList.GetChildList(item.TipoAuditorias);
				
			}
		}

        public static ClaseAuditoriaInfo New(long oid = 0) { return new ClaseAuditoriaInfo() { Oid = oid }; }
		
		/// <summary>
		/// Devuelve un ClaseAuditoriaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		
		public static ClaseAuditoriaInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un ClaseAuditoriaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static ClaseAuditoriaInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = ClaseAuditoria.GetCriteria(ClaseAuditoria.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ClaseAuditoria.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
			ClaseAuditoriaInfo obj = DataPortal.Fetch<ClaseAuditoriaInfo>(criteria);
			ClaseAuditoria.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ClaseAuditoriaInfo Get(IDataReader reader, bool childs)
        {
			return new ClaseAuditoriaInfo(reader, childs);
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
												
						query = Quality.TipoAuditorias.SELECT_BY_CLASE_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _tipoauditorias = TipoAuditoriaList.GetChildList(reader);
						
						
                    }
				}
				else
				{
					_base.Record.CopyValues((ClaseAuditoriaRecord)(criteria.UniqueResult()));
					if (Childs)
					{						
						criteria = TipoAuditoria.GetCriteria(criteria.Session);
                        criteria.AddEq("OidClaseAuditoria", this.Oid);
                        _tipoauditorias = TipoAuditoriaList.GetChildList(criteria.List<TipoAuditoria>());
						
						
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

                    query = Quality.TipoAuditorias.SELECT_BY_CLASE_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _tipoauditorias = TipoAuditoriaList.GetChildList(reader);
					
					
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



