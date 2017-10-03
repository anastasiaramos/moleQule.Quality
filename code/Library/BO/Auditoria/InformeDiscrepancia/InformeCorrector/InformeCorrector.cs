using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;
using System.Reflection;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class InformeCorrectorRecord : RecordBase
	{
		#region Attributes

		private long _oid_informe_discrepancia;
		private DateTime _fecha;
		private string _observaciones = string.Empty;
		private string _codigo = string.Empty;
		private long _serial;
		private bool _notificado = false;
		private string _titulo = string.Empty;
		private DateTime _fecha_creacion;
		private DateTime _fecha_comunicacion;
		private string _numero = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInformeDiscrepancia { get { return _oid_informe_discrepancia; } set { _oid_informe_discrepancia = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual bool Notificado { get { return _notificado; } set { _notificado = value; } }
		public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
		public virtual DateTime FechaCreacion { get { return _fecha_creacion; } set { _fecha_creacion = value; } }
		public virtual DateTime FechaComunicacion { get { return _fecha_comunicacion; } set { _fecha_comunicacion = value; } }
		public virtual string Numero { get { return _numero; } set { _numero = value; } }

		#endregion
		
		#region Business Methods
		
		public InformeCorrectorRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_informe_discrepancia = Format.DataReader.GetInt64(source, "OID_INFORME_DISCREPANCIA");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_notificado = Format.DataReader.GetBool(source, "NOTIFICADO");
			_titulo = Format.DataReader.GetString(source, "TITULO");
			_fecha_creacion = Format.DataReader.GetDateTime(source, "FECHA_CREACION");
			_fecha_comunicacion = Format.DataReader.GetDateTime(source, "FECHA_COMUNICACION");
			_numero = Format.DataReader.GetString(source, "NUMERO");

		}		
		public virtual void CopyValues(InformeCorrectorRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_informe_discrepancia = source.OidInformeDiscrepancia;
			_fecha = source.Fecha;
			_observaciones = source.Observaciones;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_notificado = source.Notificado;
			_titulo = source.Titulo;
			_fecha_creacion = source.FechaCreacion;
			_fecha_comunicacion = source.FechaComunicacion;
			_numero = source.Numero;
		}
		
		#endregion	
	}

    [Serializable()]
	public class InformeCorrectorBase 
	{	 
		#region Attributes
		
		private InformeCorrectorRecord _record = new InformeCorrectorRecord();
		
		#endregion
		
		#region Properties
		
		public InformeCorrectorRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(InformeCorrector source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(InformeCorrectorInfo source)
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
	public class InformeCorrector : BusinessBaseEx<InformeCorrector>
	{	 
		#region Attributes
		
		protected InformeCorrectorBase _base = new InformeCorrectorBase();

        private AccionesCorrectoras _acciones = AccionesCorrectoras.NewChildList();
        private NotificacionesInternas _notificaciones = NotificacionesInternas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public InformeCorrectorBase Base { get { return _base; } }
		
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
		public virtual long OidInformeDiscrepancia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInformeDiscrepancia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInformeDiscrepancia.Equals(value))
				{
					_base.Record.OidInformeDiscrepancia = value;
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
		public virtual bool Notificado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Notificado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Notificado.Equals(value))
				{
					_base.Record.Notificado = value;
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
		public virtual DateTime FechaCreacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaCreacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaCreacion.Equals(value))
				{
					_base.Record.FechaCreacion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaComunicacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaComunicacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaComunicacion.Equals(value))
				{
					_base.Record.FechaComunicacion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Numero
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
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Numero.Equals(value))
				{
					_base.Record.Numero = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual AccionesCorrectoras Acciones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _acciones;
            }

            set
            {
                _acciones = value;
            }
        }
        public virtual NotificacionesInternas Notificaciones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _notificaciones;
            }

            set
            {
                _notificaciones = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _acciones.IsValid && _notificaciones.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _acciones.IsDirty || _notificaciones.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual InformeCorrector CloneAsNew()
		{
			InformeCorrector clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = InformeCorrector.OpenSession();
			InformeCorrector.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(InformeCorrectorInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInformeDiscrepancia = source.OidInformeDiscrepancia;
			Fecha = source.Fecha;
			Observaciones = source.Observaciones;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Notificado = source.Notificado;
			Titulo = source.Titulo;
			FechaCreacion = source.FechaCreacion;
			FechaComunicacion = source.FechaComunicacion;
			Numero = source.Numero;
		}
		
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(InformeCorrector));
            Codigo = Serial.ToString(Resources.Defaults.INFORME_CORRECTOR_CODE_FORMAT);
        }				

        /// <summary>
        /// Devuelve el siguiente código de PlanAnual.
        /// </summary>
        /// <returns></returns>
        public virtual void GetNewCode(long oid)
        {
            Serial = SerialInformeCorrectorInfo.GetNext(oid);
            Codigo = Serial.ToString(Resources.Defaults.INFORME_CORRECTOR_CODE_FORMAT);
        }
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInformeDiscrepancia", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");
            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Numero");
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ACCION_CORRECTORA);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ACCION_CORRECTORA);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ACCION_CORRECTORA);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ACCION_CORRECTORA);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected InformeCorrector()
        {
            Codigo = (0).ToString(Resources.Defaults.INFORME_CORRECTOR_CODE_FORMAT);
            Fecha = DateTime.Today;
            FechaCreacion = DateTime.Now;
            FechaComunicacion = DateTime.MaxValue;
        }

        public virtual InformeCorrectorInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new InformeCorrectorInfo(this, get_childs);
            /*if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            if (get_childs)
            {

                if (nHMng.UseDirectSQL)
                {
                    string query = AccionesCorrectoras.SELECT_BY_FIELD( "OidInformeCorrector", this.Oid);
                    IDataReader r_acciones = nHManager.Instance.SQLNativeSelect(query, Session());

                    return new InformeCorrectorInfo(
                    _oid, _oid_informe_discrepancia, _codigo, _serial, _fecha, _numero, _observaciones, AccionCorrectoraList.GetChildList(r_acciones));
                }
                else
                    return new InformeCorrectorInfo(_oid, _oid_informe_discrepancia, _codigo, _serial, _fecha, _numero, _observaciones, AccionCorrectoraList.GetChildList(_acciones));
            }
            else
                return new InformeCorrectorInfo(_oid, _oid_informe_discrepancia, _codigo, _serial, _fecha, _numero, _observaciones, null);*/
        }

        public virtual InformeCorrectorInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static InformeCorrector New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<InformeCorrector>(new CriteriaCs(-1));
        }

        public static InformeCorrector Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = InformeCorrector.GetCriteria(InformeCorrector.OpenSession());
            criteria.AddOidSearch(oid);
            InformeCorrector.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<InformeCorrector>(criteria);
        }

        public static InformeCorrector Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            InformeCorrector.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<InformeCorrector>(criteria);
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
        /// Elimina todas los InformeCorrectors
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = InformeCorrector.OpenSession();
            ISession sess = InformeCorrector.Session(sessCode);
            ITransaction trans = InformeCorrector.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from InformeCorrector");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                InformeCorrector.CloseSession(sessCode);
            }
        }

        public override InformeCorrector Save()
        {
            // Por interfaz Root/Child
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

                _acciones.Update(this);
                _notificaciones.Update(this);

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

        #region Child Factory Methods

        private InformeCorrector(InformeCorrector source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private InformeCorrector(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static InformeCorrector NewChild(InformeDiscrepancia parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            InformeCorrector obj = new InformeCorrector();
            obj.MarkAsChild();
            obj.GetNewCode(parent.Oid);
            obj.OidInformeDiscrepancia = parent.Oid;
            obj.Numero = parent.Numero;
            return obj;
        }

        internal static InformeCorrector GetChild(InformeCorrector source)
        {
            return new InformeCorrector(source);
        }

        internal static InformeCorrector GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new InformeCorrector(session_code, reader, childs);
        }


        internal static InformeCorrector GetChild(int session_code, IDataReader reader)
        {
            return GetChild(session_code, reader, true);
        }


        /// <summary>
        /// Borrado aplazado, es posible el undo 
        /// (La función debe ser "no estática")
        /// </summary>
        public override void Delete()
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MarkDeleted();
        }


        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random r = new Random();
            Oid = (long)r.Next();
            GetNewCode(OidInformeDiscrepancia);
        }

        #endregion

        #region Child Data Access

        private void Fetch(InformeCorrector source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = AccionCorrectora.GetCriteria(Session());
                criteria.AddEq("OidInformeCorrector", this.Oid);
                _acciones = AccionesCorrectoras.GetChildList(criteria.List<AccionCorrectora>());

                criteria = NotificacionInterna.GetCriteria(Session());
                criteria.AddEq("OidAsociado", this.Oid);
                criteria.AddEq("TipoAsociado", (long)TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS);
                _notificaciones = NotificacionesInternas.GetChildList(criteria.List<NotificacionInterna>());


            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        private void Fetch(int session_code, IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

                if (Childs)
                {
                    AccionCorrectora.LOCK(AppContext.ActiveSchema.Code);

                    string query = AccionesCorrectoras.SELECT_BY_INFORME_CORRECTOR(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _acciones = AccionesCorrectoras.GetChildList(reader);

                    NotificacionInterna.LOCK(AppContext.ActiveSchema.Code);

                    query = NotificacionesInternas.SELECT_BY_INFORME_CORRECTOR(this.Oid, TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _notificaciones = NotificacionesInternas.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void Insert(InformeDiscrepancia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidInformeDiscrepancia = parent.Oid;
            GetNewCode(parent.Oid);

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
					
                _acciones.Update(this);
                _notificaciones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(InformeDiscrepancia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidInformeDiscrepancia = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                InformeCorrectorRecord obj = parent.Session().Get<InformeCorrectorRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
					
                _acciones.Update(this);
                _notificaciones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(InformeDiscrepancia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<InformeCorrectorRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        #endregion

        #region Root Data Access

        // called to retrieve data from the database
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;

                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {

                    InformeCorrector.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = InformeCorrector.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        AccionCorrectora.LOCK(AppContext.ActiveSchema.Code);

                        string query = AccionesCorrectoras.SELECT_BY_INFORME_CORRECTOR(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _acciones = AccionesCorrectoras.GetChildList(reader);

                        NotificacionInterna.LOCK(AppContext.ActiveSchema.Code);

                        query = NotificacionesInternas.SELECT_BY_INFORME_CORRECTOR(this.Oid, TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _notificaciones = NotificacionesInternas.GetChildList(reader);
                    }
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
                GetNewCode(OidInformeDiscrepancia);
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
                    InformeCorrectorRecord obj = Session().Get<InformeCorrectorRecord>(Oid);
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        // deferred deletion
        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        // inmediate deletion
        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criterio)
        {
            try
            {
                //Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();

                CriteriaEx criteria = GetCriteria();
                criteria.AddOidSearch(criterio.Oid);

                // Obtenemos el objeto
                InformeCorrectorRecord obj = (InformeCorrectorRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<InformeCorrectorRecord>(obj.Oid));

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

            query = "SELECT IC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ic = nHManager.Instance.GetSQLTable(typeof(InformeCorrectorRecord));

            query = "   FROM   " + ic + "   AS IC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.InformeDiscrepancia != null && conditions.InformeDiscrepancia.Oid > 0)
                query += " AND IC.\"OID_INFORME_DISCREPANCIA\" = " + conditions.InformeDiscrepancia.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY \"FECHA_CREACION\"";

            if (lockTable) query += " FOR UPDATE OF IC NOWAIT";

            return query;
        }


        #endregion

    }
}

