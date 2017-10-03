using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class ActaComiteRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _serial;
		private string _titulo = string.Empty;
		private long _revision;
		private string _motivo = string.Empty;
		private DateTime _fecha;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
		public virtual long Revision { get { return _revision; } set { _revision = value; } }
		public virtual string Motivo { get { return _motivo; } set { _motivo = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

		#endregion
		
		#region Business Methods
		
		public ActaComiteRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_titulo = Format.DataReader.GetString(source, "TITULO");
			_revision = Format.DataReader.GetInt64(source, "REVISION");
			_motivo = Format.DataReader.GetString(source, "MOTIVO");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");

		}		
		public virtual void CopyValues(ActaComiteRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_titulo = source.Titulo;
			_revision = source.Revision;
			_motivo = source.Motivo;
			_fecha = source.Fecha;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ActaComiteBase 
	{	 
		#region Attributes
		
		private ActaComiteRecord _record = new ActaComiteRecord();
		
		#endregion
		
		#region Properties
		
		public ActaComiteRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(ActaComite source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(ActaComiteInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class ActaComite : BusinessBaseEx<ActaComite>
	{	 
		#region Attributes
		
		protected ActaComiteBase _base = new ActaComiteBase();
		
		private PuntosActas _puntoactas = PuntosActas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public ActaComiteBase Base { get { return _base; } }
		
		public override long Oid
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Oid;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				if (!_base.Record.Oid.Equals(value))
				{
					_base.Record.Oid = value;
					//PropertyHasChanged();
				}
			}
		}
		public virtual string Codigo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Codigo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Codigo.Equals(value))
				{
					_base.Record.Codigo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Serial
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Serial;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Serial.Equals(value))
				{
					_base.Record.Serial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Titulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Titulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Titulo.Equals(value))
				{
					_base.Record.Titulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Revision
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Revision;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Revision.Equals(value))
				{
					_base.Record.Revision = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Motivo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Motivo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Motivo.Equals(value))
				{
					_base.Record.Motivo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime Fecha
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Fecha;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Fecha.Equals(value))
				{
					_base.Record.Fecha = value;
					PropertyHasChanged();
				}
			}
		}
		
		public virtual PuntosActas PuntosActas
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _puntoactas;
			}
		}
		
			 
			 
		public override bool IsValid
		{
			get { return base.IsValid
						 && _puntoactas.IsValid ; }
		}
		
		//Para añadir una lista: || _lista.IsDirty
		public override bool IsDirty
		{
			get { return base.IsDirty
						 || _puntoactas.IsDirty ; }
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual ActaComite CloneAsNew()
		{
			ActaComite clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = ActaComite.OpenSession();
			ActaComite.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ActaComiteInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Titulo = source.Titulo;
			Revision = source.Revision;
			Motivo = source.Motivo;
			Fecha = source.Fecha;
		}			
		
		/// <summary>
        /// Devuelve el siguiente código de ActaComite.
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
			Int64 lastcode = ActaComite.GetNewSerial();

            // Devolvemos el siguiente codigo de ActaComite 
            return lastcode.ToString(Resources.Defaults.ACTA_COMITE_CODE_FORMAT);
        }				
		/// <summary>
        /// Devuelve el siguiente Serial de ActaComite
        /// </summary>
        /// <returns></returns>
        private static Int64 GetNewSerial()
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<ActaComiteInfo> ActaComites =
                ActaComiteList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (ActaComites.Count > 0)
                lastcode = ActaComites[ActaComites.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.ACTA_COMITE_CODE_FORMAT);

            lastcode++;
            return lastcode;
        }
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Revision", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Titulo");

        }
		 
		#endregion
		 
		#region Autorization Rules
		 
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		
		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero es protected por exigencia de NHibernate.
		/// </summary>
		protected ActaComite () 
        {
            Fecha = DateTime.Today;
        }
			
		private ActaComite (IDataReader reader)
		{
			Fetch(reader);
		}
			
		public static ActaComite New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<ActaComite>(new CriteriaCs(-1));
		}
			
		public static ActaComite Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = ActaComite.GetCriteria(ActaComite.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ActaComite.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			ActaComite.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<ActaComite>(criteria);
		}
		
		internal static ActaComite Get(IDataReader reader)
		{
			return new ActaComite(reader);
		}
			
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">True si se quiere que traiga los hijos</param>
		/// <returns></returns>
		public virtual ActaComiteInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			if (get_childs)
				return new ActaComiteInfo(this, true);
			else
				return new ActaComiteInfo(this);
		}
		
		public virtual ActaComiteInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Borrado inmediato, no cabe "undo"
		/// (La función debe ser "estática")
		/// </summary>
		/// <param name="oid"></param>
		public static void Delete(long oid)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			DataPortal.Delete(new CriteriaCs(oid));
		}
		
		/// <summary>
		/// Elimina todos los ActaComite. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = ActaComite.OpenSession();
			ISession sess = ActaComite.Session(sessCode);
			ITransaction trans = ActaComite.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from ActaComite");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				ActaComite.CloseSession(sessCode);
			}
		}
		
		public override ActaComite Save()
		{
			// Por la posible doble interfaz Root/Child
			if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			else if (!CanEditObject())
			{
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			}
			try
			{
				ValidationRules.CheckRules();
				
				base.Save();
				
				_puntoactas.Update(this);				
				
				Transaction().Commit();
                return this;
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
            finally
            {
                BeginTransaction();
            }
        }
				
		#endregion
		
		#region Common Data Access
		 
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			Random r = new Random();
			Oid = (long)r.Next();
			Codigo = (0).ToString(Resources.Defaults.ACTA_COMITE_CODE_FORMAT);		
			
			_puntoactas = PuntosActas.NewChildList();			
			
		}
		 
		#endregion
		 
		#region Root Data Access
		 
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;
				
				if (nHMng.UseDirectSQL)
				{
					ActaComite.DoLOCK( Session());
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
						_base.CopyValues(reader);
					
					if (Childs)
					{
						string query = string.Empty;
						
						PuntoActa.DoLOCK( Session());
						query = PuntosActas.SELECT_BY_ACTA(this.Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_puntoactas = PuntosActas.GetChildList(reader);
						
						
 					}
				}
				else
				{
					Session().Lock(Session().Get<ActaComiteRecord>(Oid), LockMode.UpgradeNoWait);
                    _base.Record.CopyValues((ActaComiteRecord)(criteria.UniqueResult()));
					
					if (Childs)
					{
						
						criteria = PuntoActa.GetCriteria(Session());
                        criteria.AddEq("OidActa", this.Oid);
                        _puntoactas = PuntosActas.GetChildList(criteria.List<PuntoActa>());
						
					}
				}
			}
			catch (NHibernate.ADOException)
			{
				if (Transaction() != null) Transaction().Rollback();
				throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		//Fetch independiente de DataPortal para generar un ActaComite a partir de un IDataReader
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
		 
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_Insert()
		{
			try
			{
				SessionCode = OpenSession();
				BeginTransaction();
				//si hay codigo o serial, hay que obtenerlos aquí
                Codigo = GetNewCode();
				Serial = GetNewSerial();
				Session().Save(this.Base.Record);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_Update()
		{
			if (IsDirty)
			{
				try
				{
					ActaComiteRecord obj = Session().Get<ActaComiteRecord>(Oid);
					obj.CopyValues(this.Base.Record);
					Session().Update(obj);
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
			}
		}
		
		//Deferred deletion
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new CriteriaCs(Oid));
		}
		
		[Transactional(TransactionalTypes.Manual)]
		private void DataPortal_Delete(CriteriaCs criteria)
		{
			try
			{
				// Iniciamos la conexion y la transaccion
				SessionCode = OpenSession();
				BeginTransaction();
					
				//Si no hay integridad referencial, aquí se deben borrar las listas hijo
				CriteriaEx criterio = GetCriteria();
				criterio.AddOidSearch(criteria.Oid);
				Session().Delete((ActaComiteRecord)(criterio.UniqueResult()));
				Transaction().Commit();
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				CloseSession();
			}
		}
		
		
		#endregion
		 
		#region Commands

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT AC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ac = nHManager.Instance.GetSQLTable(typeof(ActaComiteRecord));

            query = "   FROM   " + ac + "   AS AC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF AC NOWAIT";

            return query;
        }


        #endregion
	}
}

