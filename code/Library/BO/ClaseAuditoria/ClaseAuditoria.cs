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
using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class ClaseAuditoriaRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _serial;
		private long _numero;
		private string _tipo = string.Empty;
		private string _nombre = string.Empty;
		private string _observaciones = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Tipo { get { return _tipo; } set { _tipo = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

		#endregion
		
		#region Business Methods
		
		public ClaseAuditoriaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_tipo = Format.DataReader.GetString(source, "TIPO");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");

		}		
		public virtual void CopyValues(ClaseAuditoriaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_numero = source.Numero;
			_tipo = source.Tipo;
			_nombre = source.Nombre;
			_observaciones = source.Observaciones;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ClaseAuditoriaBase 
	{	 
		#region Attributes
		
		private ClaseAuditoriaRecord _record = new ClaseAuditoriaRecord();
		
		#endregion
		
		#region Properties
		
		public ClaseAuditoriaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(ClaseAuditoria source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(ClaseAuditoriaInfo source)
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
	public class ClaseAuditoria : BusinessBaseEx<ClaseAuditoria>
	{	 
		#region Attributes
		
		protected ClaseAuditoriaBase _base = new ClaseAuditoriaBase();
		
		private TipoAuditorias _tipoauditorias = TipoAuditorias.NewChildList();
		

		#endregion
		
		#region Properties
		
		public ClaseAuditoriaBase Base { get { return _base; } }
		
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
		public virtual long Numero
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Numero;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Numero.Equals(value))
				{
					_base.Record.Numero = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Tipo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Tipo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Tipo.Equals(value))
				{
					_base.Record.Tipo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Nombre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nombre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Nombre.Equals(value))
				{
					_base.Record.Nombre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Observaciones
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Observaciones;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Observaciones.Equals(value))
				{
					_base.Record.Observaciones = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual TipoAuditorias TipoAuditorias
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _tipoauditorias;
			}
		}
		public override bool IsValid
		{
			get { return base.IsValid
						 && _tipoauditorias.IsValid ; }
		}
		
		//Para añadir una lista: || _lista.IsDirty
		public override bool IsDirty
		{
			get { return base.IsDirty
						 || _tipoauditorias.IsDirty ; }
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual ClaseAuditoria CloneAsNew()
		{
			ClaseAuditoria clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = ClaseAuditoria.OpenSession();
			ClaseAuditoria.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ClaseAuditoriaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Numero = source.Numero;
			Tipo = source.Tipo;
			Nombre = source.Nombre;
			Observaciones = source.Observaciones;
		}
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(ClaseAuditoria));
            Codigo = Serial.ToString(Resources.Defaults.CLASE_AUDITORIA_CODE_FORMAT);
            Numero = Serial;
        }					
			
		#endregion
		 
	    #region Validation Rules
		 
		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(
					Csla.Validation.CommonRules.StringRequired, "Codigo");

			ValidationRules.AddRule(CommonRules.MinValue<long>,
									new CommonRules.MinValueRuleArgs<long>("Numero", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Tipo");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");
		}
		 
		#endregion
		 
		#region Autorization Rules
		 
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.CLASE_AUDITORIA);
		}
		
		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.CLASE_AUDITORIA);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.CLASE_AUDITORIA);
		}
		
		public static bool CanEditObject()
		{
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.CLASE_AUDITORIA);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero es protected por exigencia de NHibernate.
		/// </summary>
		protected ClaseAuditoria () {}
			
		private ClaseAuditoria (IDataReader reader)
		{
			Fetch(reader);
		}
			
		public static ClaseAuditoria New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<ClaseAuditoria>(new CriteriaCs(-1));
		}
			
		public static ClaseAuditoria Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = ClaseAuditoria.GetCriteria(ClaseAuditoria.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = ClaseAuditoria.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			ClaseAuditoria.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<ClaseAuditoria>(criteria);
		}
		
		internal static ClaseAuditoria Get(IDataReader reader)
		{
			return new ClaseAuditoria(reader);
		}
			
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">True si se quiere que traiga los hijos</param>
		/// <returns></returns>
		public virtual ClaseAuditoriaInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			if (get_childs)
				return new ClaseAuditoriaInfo(this, true);
			else
				return new ClaseAuditoriaInfo(this);
		}
		
		public virtual ClaseAuditoriaInfo GetInfo()
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
		/// Elimina todos los ClaseAuditoria. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = ClaseAuditoria.OpenSession();
			ISession sess = ClaseAuditoria.Session(sessCode);
			ITransaction trans = ClaseAuditoria.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from ClaseAuditoria");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				ClaseAuditoria.CloseSession(sessCode);
			}
		}
		
		public override ClaseAuditoria Save()
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

                //_plan_clases.Update(this);
                _tipoauditorias.Update(this);

                if (!SharedTransaction) Transaction().Commit();
                return this;
            }
            catch (Exception ex)
            {
                if (!SharedTransaction) if (!SharedTransaction && Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
            finally
            {
                if (!SharedTransaction)
                {
                    if (CloseSessions && (this.IsNew || Transaction().WasCommitted)) CloseSession();
                    else BeginTransaction();
                }
            }
        }
				
		#endregion
		
		#region Common Data Access
		 
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			Random r = new Random();
			Oid = (long)r.Next();
            GetNewCode();

			//_plan_clases = Planes_Clases.NewChildList();			
			_tipoauditorias = TipoAuditorias.NewChildList();
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
                    ClaseAuditoria.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        TipoAuditoria.DoLOCK(Session());
                        query = TipoAuditorias.SELECT_BY_CLASE_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _tipoauditorias = TipoAuditorias.GetChildList(criteria.SessionCode, reader);


                    }
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
		}
		
		//Fetch independiente de DataPortal para generar un ClaseAuditoria a partir de un IDataReader
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
                GetNewCode();
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
					ClaseAuditoriaRecord obj = Session().Get<ClaseAuditoriaRecord>(Oid);
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
				Session().Delete((ClaseAuditoriaRecord)(criterio.UniqueResult()));
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

            query = "SELECT CA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ca = nHManager.Instance.GetSQLTable(typeof(ClaseAuditoriaRecord));

            query = "   FROM   " + ca + "   AS CA";

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

            if (lockTable) query += " FOR UPDATE OF CA NOWAIT";

            return query;
        }


        #endregion
	}
}

