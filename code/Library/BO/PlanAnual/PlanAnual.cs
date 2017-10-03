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
	public class PlanAnualRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _serial;
		private string _nombre = string.Empty;
		private string _observaciones = string.Empty;
		private string _edicion = string.Empty;
		private string _revision = string.Empty;
		private DateTime _fecha;
		private long _ano;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual string Edicion { get { return _edicion; } set { _edicion = value; } }
		public virtual string Revision { get { return _revision; } set { _revision = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual long Ano { get { return _ano; } set { _ano = value; } }

		#endregion
		
		#region Business Methods
		
		public PlanAnualRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_edicion = Format.DataReader.GetString(source, "EDICION");
			_revision = Format.DataReader.GetString(source, "REVISION");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_ano = Format.DataReader.GetInt64(source, "ANO");

		}		
		public virtual void CopyValues(PlanAnualRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_nombre = source.Nombre;
			_observaciones = source.Observaciones;
			_edicion = source.Edicion;
			_revision = source.Revision;
			_fecha = source.Fecha;
			_ano = source.Ano;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PlanAnualBase 
	{	 
		#region Attributes
		
		private PlanAnualRecord _record = new PlanAnualRecord();
		
		#endregion
		
		#region Properties
		
		public PlanAnualRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(PlanAnual source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(PlanAnualInfo source)
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
	public class PlanAnual : BusinessBaseEx<PlanAnual>
	{	 
		#region Attributes
		
		protected PlanAnualBase _base = new PlanAnualBase();
		
		private Planes_Tipos _planes_tipos = Planes_Tipos.NewChildList();
		

		#endregion
		
		#region Properties
		
		public PlanAnualBase Base { get { return _base; } }
		
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
		public virtual string Edicion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Edicion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Edicion.Equals(value))
				{
					_base.Record.Edicion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Revision
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
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Revision.Equals(value))
				{
					_base.Record.Revision = value;
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
		public virtual long Ano
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Ano;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Ano.Equals(value))
				{
					_base.Record.Ano = value;
					PropertyHasChanged();
				}
			}
		}
		
		public virtual Planes_Tipos PlanesTipos
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _planes_tipos;
			}
		}
			 
		public override bool IsValid
		{
			get { return base.IsValid
						 && _planes_tipos.IsValid ; }
		}
		public override bool IsDirty
		{
			get { return base.IsDirty
						 || _planes_tipos.IsDirty ; }
                     }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual PlanAnual CloneAsNew()
		{
			PlanAnual clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = PlanAnual.OpenSession();
			PlanAnual.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(PlanAnualInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Nombre = source.Nombre;
			Observaciones = source.Observaciones;
			Edicion = source.Edicion;
			Revision = source.Revision;
			Fecha = source.Fecha;
			Ano = source.Ano;
		}
		
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(PlanAnual));
            Codigo = Serial.ToString(Resources.Defaults.PLAN_ANUAL_CODE_FORMAT);
        }
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Edicion");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Revision");

        }
		 
		#endregion
		 
		#region Autorization Rules
		 
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		
		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		
		public static bool CanEditObject()
		{
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero es protected por exigencia de NHibernate.
		/// </summary>
		protected PlanAnual () 
        {
            Fecha = DateTime.Today;
            Ano = DateTime.Today.Year;
        }
			
		private PlanAnual (IDataReader reader)
		{
			Fetch(reader);
		}
			
		public static PlanAnual New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<PlanAnual>(new CriteriaCs(-1));
		}
			
		public static PlanAnual Get(long oid, bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = PlanAnual.GetCriteria(PlanAnual.OpenSession());
            criteria.Childs = get_childs;
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = PlanAnual.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			PlanAnual.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<PlanAnual>(criteria);
		}
		
		internal static PlanAnual Get(IDataReader reader)
		{
			return new PlanAnual(reader);
		}
			
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">True si se quiere que traiga los hijos</param>
		/// <returns></returns>
		public virtual PlanAnualInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			if (get_childs)
				return new PlanAnualInfo(this, true);
			else
				return new PlanAnualInfo(this);
		}
		
		public virtual PlanAnualInfo GetInfo()
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
		/// Elimina todos los PlanAnual. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = PlanAnual.OpenSession();
			ISession sess = PlanAnual.Session(sessCode);
			ITransaction trans = PlanAnual.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from PlanAnual");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				PlanAnual.CloseSession(sessCode);
			}
		}
		
		public override PlanAnual Save()
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

                _planes_tipos.Update(this);

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
            Ano = DateTime.Now.Year;
			
			_planes_tipos = Planes_Tipos.NewChildList();
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
					PlanAnual.DoLOCK(Session());
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
						_base.CopyValues(reader);
					
					if (Childs)
					{
						string query = string.Empty;
						
						Plan_Tipo.DoLOCK(Session());
						query = Planes_Tipos.SELECT_BY_FIELD("OidPlan", this.Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_planes_tipos = Planes_Tipos.GetChildList(reader);					
 					}
				}
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		//Fetch independiente de DataPortal para generar un PlanAnual a partir de un IDataReader
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
					PlanAnualRecord obj = Session().Get<PlanAnualRecord>(Oid);
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
				Session().Delete((PlanAnualRecord)(criterio.UniqueResult()));
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

            query = "SELECT PA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pa = nHManager.Instance.GetSQLTable(typeof(PlanAnualRecord));

            query = "   FROM   " + pa + "   AS PA";

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

            if (lockTable) query += " FOR UPDATE OF PA NOWAIT";

            return query;
        }

        #endregion
	}
}

