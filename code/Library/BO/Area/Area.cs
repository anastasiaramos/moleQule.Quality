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
	public class AreaRecord : RecordBase
	{
		#region Attributes

		private string _nombre = string.Empty;
		private string _codigo = string.Empty;
		private long _serial;
		private string _observaciones = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

		#endregion
		
		#region Business Methods
		
		public AreaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");

		}		
		public virtual void CopyValues(AreaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_nombre = source.Nombre;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_observaciones = source.Observaciones;
		}
		
		#endregion	
	}

    [Serializable()]
	public class AreaBase 
	{	 
		#region Attributes
		
		private AreaRecord _record = new AreaRecord();
		
		#endregion
		
		#region Properties
		
		public AreaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Area source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(AreaInfo source)
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
	public class Area : BusinessBaseEx<Area>
	{	 
		#region Attributes
		
		protected AreaBase _base = new AreaBase();
		

		#endregion
		
		#region Properties
		
		public AreaBase Base { get { return _base; } }
		
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Area CloneAsNew()
		{
			Area clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = Area.OpenSession();
			Area.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(AreaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Nombre = source.Nombre;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Observaciones = source.Observaciones;
		}
				
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(Area));
            Codigo = Serial.ToString(Resources.Defaults.AREA_CODE_FORMAT);
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
		 
		#region Root Factory Methods
		 
		public static Area New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<Area>(new CriteriaCs(-1));
		}
			
		public static Area Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = Area.GetCriteria(Area.OpenSession());
		
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = Area.SELECT( oid);
			else
				criteria.AddOidSearch(oid);
			
			Area.BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<Area>(criteria);
		}
		
		internal static Area Get(IDataReader reader)
		{
			return new Area(reader, true);
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
		/// Elimina todos los Area. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Area.OpenSession();
			ISession sess = Area.Session(sessCode);
			ITransaction trans = Area.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from Area");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Area.CloseSession(sessCode);
			}
		}
		
		public override Area Save()
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
		
        #region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// </summary>
		protected Area () 
        {
            GetNewCode();
        }		
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
		private Area(Area source, bool retrieve_childs)
        {
			MarkAsChild();
			Childs = retrieve_childs;
            Fetch(source);
        }
		
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
        private Area(IDataReader source, bool retrieve_childs)
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
		public static Area NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<Area>(new CriteriaCs(-1));
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(Area source, bool retrieve_childs)
		/// <remarks/>
		internal static Area GetChild(Area source)
		{
			return new Area(source, false);
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Area con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
		internal static Area GetChild(Area source, bool retrieve_childs)
		{
			return new Area(source, retrieve_childs);
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
        internal static Area GetChild(IDataReader source)
        {
            return new Area(source, false);
        }
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">IDataReader con los datos para el objeto</param>
		/// <param name="retrieve_childs">Flag para obtener también los hijos</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static Area GetChild(IDataReader source, bool retrieve_childs)
        {
            return new Area(source, retrieve_childs);
        }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// También copia los datos de los hijos del objeto.
		/// </summary>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual AreaInfo GetInfo()
		{
			return GetInfo(true);
		}
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual AreaInfo GetInfo (bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new AreaInfo(this, get_childs);
		}
		
		#endregion

		#region Common Data Access
		 
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			Random r = new Random();
            Oid = (long)r.Next();
		}
		 
        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="source">Objeto fuente</param>
        private void Fetch(Area source)
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
					Area.DoLOCK(Session());
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
					AreaRecord obj = Session().Get<AreaRecord>(Oid);
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
				Session().Delete((AreaRecord)(criterio.UniqueResult()));
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

            query = "SELECT A.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string a = nHManager.Instance.GetSQLTable(typeof(AreaRecord));

            query = "   FROM   " + a + "   AS A";

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

            if (lockTable) query += " FOR UPDATE OF A NOWAIT";

            return query;
        }


        #endregion

	}
}

