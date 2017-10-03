using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;

using NHibernate;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class ActaComiteInfo : ReadOnlyBaseEx<ActaComiteInfo>, IAgenteHipatia
    {

        #region IAgenteHipatia

        public string NombreHipatia { get { return Titulo; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Motivo; } }
        public Type TipoEntidad { get { return typeof(ActaComite); } }

        #endregion

        #region Attributes

        protected ActaComiteBase _base = new ActaComiteBase();

        private PuntoActaList _puntoactas = null;


        #endregion

        #region Properties

        public ActaComiteBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public long Revision { get { return _base.Record.Revision; } }
        public string Motivo { get { return _base.Record.Motivo; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }


        public virtual PuntoActaList PuntosActas { get { return _puntoactas; } }



        #endregion

        #region Business Methods

        public void CopyFrom(ActaComite source) { _base.CopyValues(source); }
        
        #endregion		
		
		#region Factory Methods
		
		private ActaComiteInfo() { /* require use of factory methods */ }
		
		private ActaComiteInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de ActaComiteInfo a partir de un ActaComite
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal ActaComiteInfo(ActaComite item)
			: this(item, false)
		{
		}
		
		internal ActaComiteInfo(ActaComite item, bool childs)
		{
			Oid = item.Oid;
			_base.Record.Codigo = item.Codigo;
			_base.Record.Serial = item.Serial;
			_base.Record.Titulo = item.Titulo;
			_base.Record.Revision = item.Revision;
			_base.Record.Motivo = item.Motivo;
			_base.Record.Fecha = item.Fecha;
			
			
			if (childs)
			{
				if (item.PuntosActas != null)
					_puntoactas = PuntoActaList.GetChildList(item.PuntosActas);
				
			}
		}
		
		/// <summary>
		/// Devuelve un ActaComiteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		
		public static ActaComiteInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un ActaComiteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static ActaComiteInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = ActaComite.GetCriteria(ActaComite.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ActaComite.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
			ActaComiteInfo obj = DataPortal.Fetch<ActaComiteInfo>(criteria);
			ActaComite.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ActaComiteInfo Get(IDataReader reader, bool childs)
        {
			return new ActaComiteInfo(reader, childs);
		}

        public static ActaComiteInfo New(long oid = 0) { return new ActaComiteInfo() { Oid = oid }; }
		
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
						
                        query = Quality.PuntosActas.SELECT_BY_ACTA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _puntoactas = PuntoActaList.GetChildList(reader);
						
						
                    }
				}
				else
				{
					_base.Record.CopyValues((ActaComiteRecord)(criteria.UniqueResult()));
					if (Childs)
					{
                        criteria = PuntoActa.GetCriteria(criteria.Session);
                        criteria.AddEq("OidActa", this.Oid);
                        _puntoactas = PuntoActaList.GetChildList(criteria.List<PuntoActa>());
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
					
					query = Quality.PuntosActas.SELECT_BY_ACTA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _puntoactas = PuntoActaList.GetChildList(reader);
					
					
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



