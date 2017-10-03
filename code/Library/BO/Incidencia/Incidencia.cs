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
using moleQule.Library.Common;
using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class IncidenciaRecord : RecordBase
	{
		#region Attributes

		private long _oid_agente;
		private string _tipo_agente = string.Empty;
		private string _codigo = string.Empty;
		private long _serial;
		private DateTime _fecha;
		private string _texto = string.Empty;
		private string _observaciones = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAgente { get { return _oid_agente; } set { _oid_agente = value; } }
		public virtual string TipoAgente { get { return _tipo_agente; } set { _tipo_agente = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

		#endregion
		
		#region Business Methods
		
		public IncidenciaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_agente = Format.DataReader.GetInt64(source, "OID_AGENTE");
			_tipo_agente = Format.DataReader.GetString(source, "TIPO_AGENTE");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");

		}		
		public virtual void CopyValues(IncidenciaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_agente = source.OidAgente;
			_tipo_agente = source.TipoAgente;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_fecha = source.Fecha;
			_texto = source.Texto;
			_observaciones = source.Observaciones;
		}
		
		#endregion	
	}

    [Serializable()]
	public class IncidenciaBase 
	{	 
		#region Attributes
		
		private IncidenciaRecord _record = new IncidenciaRecord();

        private string _agente = string.Empty;
		
		#endregion
		
		#region Properties
		
		public IncidenciaRecord Record { get { return _record; } }
       
        public virtual string Agente{get{return _agente;}set{_agente=value;}}
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

                _agente = Format.DataReader.GetString(source, "AGENTE");
		}		
		public void CopyValues(Incidencia source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _agente = source.Agente;
		}
		public void CopyValues(IncidenciaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _agente = source.Agente;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Incidencia : BusinessBaseEx<Incidencia>
	{	 
		#region Attributes
		
		protected IncidenciaBase _base = new IncidenciaBase();
		

		#endregion
		
		#region Properties
		
		public IncidenciaBase Base { get { return _base; } }
		
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
		public virtual long OidAgente
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAgente;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidAgente.Equals(value))
				{
					_base.Record.OidAgente = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string TipoAgente
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.TipoAgente;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.TipoAgente.Equals(value))
				{
					_base.Record.TipoAgente = value;
					PropertyHasChanged();
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
		public virtual string Texto
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Texto;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Texto.Equals(value))
				{
					_base.Record.Texto = value;
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

       public virtual string Agente
		{
			get
			{
				//CanReadProperty(true);
				return _base.Agente;
			}
            
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Agente.Equals(value))
				{
					_base.Agente = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Incidencia CloneAsNew()
		{
			Incidencia clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = Incidencia.OpenSession();
			Incidencia.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(IncidenciaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAgente = source.OidAgente;
			TipoAgente = source.TipoAgente;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Fecha = source.Fecha;
			Texto = source.Texto;
			Observaciones = source.Observaciones;
		}
		
		
		/// <summary>
        /// Devuelve el siguiente código disponible
        /// </summary>
        /// <returns></returns>
        public virtual string GetNewCode()
        {
			Int64 lastcode = Incidencia.GetNewSerial();

            // Devolvemos el siguiente codigo
            return lastcode.ToString(Resources.Defaults.DEFAULT_CODE_FORMAT);
        }		
		
		/// <summary>
        /// Devuelve el siguiente Serial de Incidencia
        /// </summary>
        /// <returns></returns>
        private static Int64 GetNewSerial()
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<IncidenciaInfo> Incidencias =
                IncidenciaList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (Incidencias.Count > 0)
                lastcode = Incidencias[Incidencias.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.DEFAULT_CODE_FORMAT);

            lastcode++;
            return lastcode;
        }			
			
		#endregion
		 
	    #region Validation Rules

		/// <summary>
		/// Añade las reglas de validación necesarias para el objeto
		/// </summary>
		protected override void AddBusinessRules()
		{
			
			//Código para valores requeridos o que haya que validar
			
		}
		 
		#endregion
		 
		#region Autorization Rules
		
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.INCIDENCIA);
		}
		
		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.INCIDENCIA);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.INCIDENCIA);
		}
		
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.INCIDENCIA);
		}

		#endregion
		 
		#region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// </summary>
		protected Incidencia () 
        {          
            Fecha = DateTime.Today;
        }
		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
		private Incidencia(Incidencia source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private Incidencia(IDataReader source, bool retrieve_childs)
        {
            MarkAsChild();	
			Childs = retrieve_childs;
            Fetch(source);
        }

		/// <summary>
		/// Crea un nuevo objeto
		/// </summary>
		/// <returns>Nuevo objeto creado</returns>
		/// La utiliza la BusinessListBaseEx correspondiente para crear nuevos elementos
		public static Incidencia NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<Incidencia>(new CriteriaCs(-1));
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Incidencia con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(Incidencia source, bool retrieve_childs)
		/// <remarks/>
		internal static Incidencia GetChild(Incidencia source)
		{
			return new Incidencia(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Incidencia con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
		internal static Incidencia GetChild(Incidencia source, bool retrieve_childs)
		{
			return new Incidencia(source, retrieve_childs);
		}

		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="reader">DataReader con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(IDataReader source, bool retrieve_childs)
		/// <remarks/>
        internal static Incidencia GetChild(IDataReader source)
        {
            return new Incidencia(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static Incidencia GetChild(IDataReader source, bool retrieve_childs)
        {
            return new Incidencia(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual IncidenciaInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual IncidenciaInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new IncidenciaInfo(this, get_childs);
		}
		
		#endregion
		
		#region Root Factory Methods
		
		/// <summary>
		/// Crea un nuevo objeto
		/// </summary>
		/// <returns>Nuevo objeto creado</returns>
		public static Incidencia New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<Incidencia>(new CriteriaCs(-1));
		}
		
		/// <summary>
		/// Obtiene un registro de la base de datos y lo convierte en un objeto de este tipo
		/// </summary>
		/// <param name="oid"></param>
		/// <returns>Objeto con los valores del registro</returns>
		public static Incidencia Get(long oid)
		{
			return Get(oid, true);
		}
		
		/// <summary>
		/// Obtiene un registro de la base de datos y lo convierte en un objeto de este tipo
		/// </summary>
		/// <param name="oid"></param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto con los valores del registro</returns>
		public static Incidencia Get(long oid, bool retrieve_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = Incidencia.GetCriteria(Incidencia.OpenSession());
			criteria.Childs = retrieve_childs;
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = Incidencia.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
			
			Incidencia.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<Incidencia>(criteria);
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
		/// Elimina todos los Incidencia. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Incidencia.OpenSession();
			ISession sess = Incidencia.Session(sessCode);
			ITransaction trans = Incidencia.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from Incidencia");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Incidencia.CloseSession(sessCode);
			}
		}
		
		/// <summary>
		/// Guarda en la base de datos todos los cambios del objeto.
		/// También guarda los cambios de los hijos si los tiene
		/// </summary>
		/// <returns>Objeto actualizado y con los flags reseteados</returns>
		public override Incidencia Save()
		{
			// Por la posible doble interfaz Root/Child
			if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			else if (!CanEditObject())
			{
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			}
			try
			{
				ValidationRules.CheckRules();
				
				if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

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
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="criteria">Criterios de consulta</param>
		/// <remarks>La llama el DataPortal a partir del New o NewChild</remarks>		
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			
			// El código va al constructor porque los DataGrid no llamana al DataPortal sino directamente al constructor
			
		}
		
		/// <summary>
		/// Construye el objeto y se encarga de obtener los
		/// hijos si los tiene y se solicitan
		/// </summary>
		/// <param name="source">Objeto fuente</param>
		private void Fetch(Incidencia source)
		{
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);
				
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

			MarkOld();
		}

		/// <summary>
		/// Construye el objeto y se encarga de obtener los
		/// hijos si los tiene y se solicitan
		/// </summary>
		/// <param name="source">DataReader fuente</param>
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

            MarkOld();
        }

		/// <summary>
		/// Inserta el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para insertar elementos<remarks/>
		internal void Insert(Incidencias parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{	
				ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				parent.Session().Save(this.Base.Record);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}
	
		/// <summary>
		/// Actualiza el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para actualizar elementos<remarks/>
		internal void Update(Incidencias parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{
				ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				SessionCode = parent.SessionCode;
				IncidenciaRecord obj = Session().Get<IncidenciaRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}
		
		/// <summary>
		/// Borra el registro de la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para borrar elementos<remarks/>
		internal void DeleteSelf(Incidencias parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<IncidenciaRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		
			MarkNew(); 
		}

		#endregion
		
		#region Root Data Access
		
		/// <summary>
		/// Obtiene un registro de la base de datos
		/// </summary>
		/// <param name="criteria">Criterios de consulta</param>
		/// <remarks>Lo llama el DataPortal tras generar el objeto</remarks>
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;
				
				if (nHMng.UseDirectSQL)
				{
					Incidencia.DoLOCK( Session());
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
                    _base.CopyValues(reader);
					
					 
				}
				else
				{
					Session().Lock(Session().Get<IncidenciaRecord>(Oid), LockMode.UpgradeNoWait);
                    _base.Record.CopyValues((IncidenciaRecord)(criteria.UniqueResult()));
					
					 
				}
				MarkOld();
			}
			catch (NHibernate.ADOException ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.ThrowExceptionByCode(ex);
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		/// <summary>
		/// Inserta un elemento en la tabla
		/// </summary>
		/// <remarks>Lo llama el DataPortal cuando se llama al Save y el objeto isNew</remarks>
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_Insert()
		{
			try
			{
				SessionCode = OpenSession();
				BeginTransaction();
				//si hay codigo o serial, hay que obtenerlos aquí por si ha habido
				//inserciones de otros usuarios en la tabla
				
				Serial = GetNewSerial();
				Codigo = GetNewCode();
				
				Session().Save(this.Base.Record);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		/// <summary>
		/// Modifica un elemento en la tabla
		/// </summary>
		/// <remarks>Lo llama el DataPortal cuando se llama al Save y el objeto isDirty</remarks>
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_Update()
		{
			if (IsDirty)
			{
				try
				{
					IncidenciaRecord obj = Session().Get<IncidenciaRecord>(Oid);
					obj.CopyValues(this.Base.Record);
					Session().Update(obj);
					MarkOld();
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
			}
		}
		
		/// <summary>
		/// Borrado aplazado, no se ejecuta hasta que se llama al Save
		/// </summary>
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new CriteriaCs(Oid));
		}
		
		/// <summary>
		/// Elimina un elemento en la tabla
		/// </summary>
		/// <remarks>Lo llama el DataPortal</remarks>
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
				Session().Delete((IncidenciaRecord)(criterio.UniqueResult()));
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

        public static bool Exists(string codigo)
        {
            ExistsCmd result;
            result = DataPortal.Execute<ExistsCmd>(new ExistsCmd(codigo));
            return result.Exists;
        }

        [Serializable()]
        private class ExistsCmd : CommandBase
        {
            private string _codigo;
            private bool _exists = false;

            public bool Exists
            {
                get { return _exists; }
            }

            public ExistsCmd(string codigo)
            {
                _codigo = codigo;
            }

            protected override void DataPortal_Execute()
            {
                // Buscar por codigo
                CriteriaEx criteria = Incidencia.GetCriteria(Incidencia.OpenSession());
                criteria.AddCodeSearch(_codigo);
                IncidenciaList list = IncidenciaList.GetList(criteria);
                _exists = !(list.Count == 0);
            }
        }

        #endregion
      
        #region SQL

        public new static string SELECT(long oid)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(IncidenciaRecord));
            string inner1 = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string inner2 = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            //string inner3 = nHManager.Instance.GetSQLTable(typeof(Empleado));

            string query = string.Empty;

            query = "SELECT c.*, i1.\"NOMBRE\" ||' '|| i1.\"APELLIDOS\" AS \"AGENTE\"" +
            " FROM " + tabla + " AS c" +
            " INNER JOIN " + inner1 + " AS i1 ON c.\"OID_AGENTE\" = i1.\"OID\"" +
            " WHERE c.\"TIPO_AGENTE\" = '" + (ETipoAgente.Alumno).ToString() + "'";
            if (oid > 0)
                query += "AND c.\"OID\" = '" + oid.ToString() + "'";

            query +=" UNION" +
            " SELECT c.*, i2.\"NOMBRE\" || ' ' ||i2.\"APELLIDOS\" AS \"AGENTE\"" +
            " FROM " + tabla + " AS c" +
            " INNER JOIN " + inner2 + " AS i2 ON c.\"OID_AGENTE\" = i2.\"OID\"" +
            " WHERE c.\"TIPO_AGENTE\" = '" + (ETipoAgente.Instructor).ToString() + "'";
            if (oid > 0)
                query += "AND c.\"OID\" = '" + oid.ToString() + "'" ;

            return query;
        }

        #endregion
	}
}

