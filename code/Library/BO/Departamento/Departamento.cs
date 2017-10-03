using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class DepartamentoRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _serial;
		private string _nombre = string.Empty;
		private string _telefonos = string.Empty;
		private string _fax = string.Empty;
		private string _email = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Telefonos { get { return _telefonos; } set { _telefonos = value; } }
		public virtual string Fax { get { return _fax; } set { _fax = value; } }
		public virtual string Email { get { return _email; } set { _email = value; } }

		#endregion
		
		#region Business Methods
		
		public DepartamentoRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_telefonos = Format.DataReader.GetString(source, "TELEFONOS");
			_fax = Format.DataReader.GetString(source, "FAX");
			_email = Format.DataReader.GetString(source, "EMAIL");

		}		
		public virtual void CopyValues(DepartamentoRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_nombre = source.Nombre;
			_telefonos = source.Telefonos;
			_fax = source.Fax;
			_email = source.Email;
		}
		
		#endregion	
	}

    [Serializable()]
	public class DepartamentoBase 
	{	 
		#region Attributes
		
		private DepartamentoRecord _record = new DepartamentoRecord();
		
		#endregion
		
		#region Properties
		
		public DepartamentoRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Departamento source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(DepartamentoInfo source)
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
	public class Departamento : BusinessBaseEx<Departamento>
	{	 
		#region Attributes
		
		protected DepartamentoBase _base = new DepartamentoBase();
		

		#endregion
		
		#region Properties
		
		public DepartamentoBase Base { get { return _base; } }
		
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
		public virtual string Telefonos
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Telefonos;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Telefonos.Equals(value))
				{
					_base.Record.Telefonos = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Fax
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Fax;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Fax.Equals(value))
				{
					_base.Record.Fax = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Email
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Email;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Email.Equals(value))
				{
					_base.Record.Email = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Departamento CloneAsNew()
		{
			Departamento clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = Departamento.OpenSession();
			Departamento.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(DepartamentoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Nombre = source.Nombre;
			Telefonos = source.Telefonos;
			Fax = source.Fax;
			Email = source.Email;
		}
				
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(Departamento));
            Codigo = Serial.ToString(Resources.Defaults.DEPARTAMENTO_CODE_FORMAT);
        }
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");
        }
		 
		#endregion
		 
		#region Autorization Rules
		 
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.AREA);
		}
		
		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.AREA);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.AREA);
		}
		
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.AREA);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero es protected por exigencia de NHibernate.
		/// </summary>
		protected Departamento () 
        {
            GetNewCode();
        }
			
		private Departamento (IDataReader reader)
		{
			Fetch(reader);
		}
			
		public static Departamento New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<Departamento>(new CriteriaCs(-1));
		}
			
		public static Departamento Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = Departamento.GetCriteria(Departamento.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = Departamento.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			Departamento.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<Departamento>(criteria);
		}
		
		internal static Departamento Get(IDataReader reader)
		{
			return new Departamento(reader);
		}
			
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">True si se quiere que traiga los hijos</param>
		/// <returns></returns>
		public virtual DepartamentoInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			if (get_childs)
				return new DepartamentoInfo(this, true);
			else
				return new DepartamentoInfo(this);
		}
		
		public virtual DepartamentoInfo GetInfo()
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
		/// Elimina todos los Departamento. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Departamento.OpenSession();
			ISession sess = Departamento.Session(sessCode);
			ITransaction trans = Departamento.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from Departamento");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Departamento.CloseSession(sessCode);
			}
		}
		
		public override Departamento Save()
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
            Codigo = (0).ToString(Resources.Defaults.DEPARTAMENTO_CODE_FORMAT);
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
					Departamento.DoLOCK(Session());
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
						_base.CopyValues(reader);
				}
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		//Fetch independiente de DataPortal para generar un Departamento a partir de un IDataReader
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
					DepartamentoRecord obj = Session().Get<DepartamentoRecord>(Oid);
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
				Session().Delete((DepartamentoRecord)(criterio.UniqueResult()));
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

            query = "SELECT D.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string d = nHManager.Instance.GetSQLTable(typeof(DepartamentoRecord));

            query = "   FROM   " + d + "   AS D";

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

            if (lockTable) query += " FOR UPDATE OF D NOWAIT";

            return query;
        }


        #endregion
	}
}

