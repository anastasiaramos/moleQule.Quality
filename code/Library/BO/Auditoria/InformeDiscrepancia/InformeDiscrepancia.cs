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
	public class InformeDiscrepanciaRecord : RecordBase
	{
		#region Attributes

		private long _oid_auditoria;
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
		
				public virtual long OidAuditoria { get { return _oid_auditoria; } set { _oid_auditoria = value; } }
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
		
		public InformeDiscrepanciaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_auditoria = Format.DataReader.GetInt64(source, "OID_AUDITORIA");
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
		public virtual void CopyValues(InformeDiscrepanciaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_auditoria = source.OidAuditoria;
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
	public class InformeDiscrepanciaBase 
	{	 
		#region Attributes
		
		private InformeDiscrepanciaRecord _record = new InformeDiscrepanciaRecord();
		
		#endregion
		
		#region Properties
		
		public InformeDiscrepanciaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(InformeDiscrepancia source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(InformeDiscrepanciaInfo source)
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
	public class InformeDiscrepancia : BusinessBaseEx<InformeDiscrepancia>
	{	 
		#region Attributes
		
		protected InformeDiscrepanciaBase _base = new InformeDiscrepanciaBase();

        private InformesAmpliaciones _ampliaciones = InformesAmpliaciones.NewChildList();
        private InformesCorrectores _correctores = InformesCorrectores.NewChildList();
        private Discrepancias _discrepancias = Discrepancias.NewChildList();
        private NotificacionesInternas _notificaciones = NotificacionesInternas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public InformeDiscrepanciaBase Base { get { return _base; } }
		
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
		public virtual long OidAuditoria
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAuditoria;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidAuditoria.Equals(value))
				{
					_base.Record.OidAuditoria = value;
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

        public virtual InformesAmpliaciones Ampliaciones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _ampliaciones;
            }

            set
            {
                _ampliaciones = value;
            }
        }
        public virtual InformesCorrectores Correctores
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _correctores;
            }

            set
            {
                _correctores = value;
            }
        }
        public virtual Discrepancias Discrepancias
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _discrepancias;
            }

            set
            {
                _discrepancias = value;
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
            get { return base.IsValid && _ampliaciones.IsValid && _correctores.IsValid && _discrepancias.IsValid && _notificaciones.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _ampliaciones.IsDirty || _correctores.IsDirty || _discrepancias.IsDirty || _notificaciones.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual InformeDiscrepancia CloneAsNew()
		{
			InformeDiscrepancia clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = InformeDiscrepancia.OpenSession();
			InformeDiscrepancia.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(InformeDiscrepanciaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAuditoria = source.OidAuditoria;
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
            Serial = SerialInfo.GetNext(typeof(InformeDiscrepancia));
            Codigo = Serial.ToString(Resources.Defaults.INFORME_DISCREPANCIA_CODE_FORMAT);
        }				

        /// <summary>
        /// Devuelve el siguiente código de PlanAnual.
        /// </summary>
        /// <returns></returns>
        public virtual void GetNewCode(long oid)
        {
            Serial = SerialInformeDiscrepanciaInfo.GetNext(oid);
            Codigo = Serial.ToString(Resources.Defaults.INFORME_DISCREPANCIA_CODE_FORMAT);
        }
			
		#endregion

        #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAuditoria", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Numero");
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.DISCREPANCIA);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.DISCREPANCIA);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.DISCREPANCIA);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.DISCREPANCIA);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected InformeDiscrepancia()
        {
           Fecha = DateTime.Today;
           FechaCreacion = DateTime.Now;
           FechaComunicacion = DateTime.MaxValue;
        }

        public virtual InformeDiscrepanciaInfo GetInfo(bool get_childs)
        {

            if (!CanGetObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new InformeDiscrepanciaInfo(this, get_childs);

            /*
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            if (get_childs)
            {
                if (nHMng.UseDirectSQL)
                {
                    string query = InformesAmpliaciones.SELECT_BY_FIELD( "OidInformeDiscrepancia", this.Oid);
                    IDataReader r_ampliaciones = nHManager.Instance.SQLNativeSelect(query, Session());
                    
                    query = InformesCorrectores.SELECT_BY_FIELD( "OidInformeDiscrepancia", this.Oid);
                    IDataReader r_correctores = nHManager.Instance.SQLNativeSelect(query, Session());

                    query = Discrepancias.SELECT_BY_FIELD( "OidInforme", this.Oid);
                    IDataReader r_discrepancias = nHManager.Instance.SQLNativeSelect(query, Session());

                    return new InformeDiscrepanciaInfo(
                    _oid, _oid_auditoria, _codigo, _serial, _fecha, _observaciones, _numero,
                    InformeAmpliacionList.GetChildList(r_ampliaciones),
                    InformeCorrectorList.GetChildList(r_correctores),
                    DiscrepanciaList.GetChildList(r_discrepancias));
                }
                else
                    return new InformeDiscrepanciaInfo(_oid, _oid_auditoria, _codigo, _serial, _fecha, _observaciones, _numero,
                    InformeAmpliacionList.GetChildList(_ampliaciones),
                    InformeCorrectorList.GetChildList(_correctores),
                    DiscrepanciaList.GetChildList(_discrepancias));
            }
            else
                return new InformeDiscrepanciaInfo(_oid, _oid_auditoria, _codigo, _serial, _fecha, _observaciones, _numero, null, null, null);*/
        }

        public virtual InformeDiscrepanciaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static InformeDiscrepancia New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<InformeDiscrepancia>(new CriteriaCs(-1));
        }

        public static InformeDiscrepancia Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = InformeDiscrepancia.GetCriteria(InformeDiscrepancia.OpenSession());
            criteria.AddOidSearch(oid);
            InformeDiscrepancia.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<InformeDiscrepancia>(criteria);
        }

        public static InformeDiscrepancia Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            InformeDiscrepancia.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<InformeDiscrepancia>(criteria);
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
        /// Elimina todas los InformeDiscrepancias
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = InformeDiscrepancia.OpenSession();
            ISession sess = InformeDiscrepancia.Session(sessCode);
            ITransaction trans = InformeDiscrepancia.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from InformeDiscrepancia");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                InformeDiscrepancia.CloseSession(sessCode);
            }
        }

        public override InformeDiscrepancia Save()
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

                _ampliaciones.Update(this);
                _correctores.Update(this);
                _discrepancias.Update(this);
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

        private InformeDiscrepancia(InformeDiscrepancia source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private InformeDiscrepancia(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static InformeDiscrepancia NewChild(Auditoria parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            InformeDiscrepancia obj = new InformeDiscrepancia();
            obj.MarkAsChild();
            obj.GetNewCode(parent.Oid);
            obj.OidAuditoria = parent.Oid;
            obj.Numero = parent.Referencia;
            return obj;
        }

        internal static InformeDiscrepancia GetChild(InformeDiscrepancia source)
        {
            return new InformeDiscrepancia(source);
        }

        internal static InformeDiscrepancia GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new InformeDiscrepancia(session_code, reader, childs);
        }


        internal static InformeDiscrepancia GetChild(int session_code, IDataReader reader)
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
            GetNewCode(OidAuditoria);
        }

        #endregion

        #region Child Data Access

        private void Fetch(InformeDiscrepancia source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = InformeAmpliacion.GetCriteria(Session());
                criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                _ampliaciones = InformesAmpliaciones.GetChildList(criteria.List<InformeAmpliacion>());

                criteria = InformeCorrector.GetCriteria(Session());
                criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                _correctores = InformesCorrectores.GetChildList(criteria.List<InformeCorrector>());

                criteria = Discrepancia.GetCriteria(Session());
                criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                _discrepancias = Discrepancias.GetChildList(criteria.List<Discrepancia>());

                criteria = NotificacionInterna.GetCriteria(Session());
                criteria.AddEq("OidAsociado", this.Oid);
                criteria.AddEq("TipoAsociado", (long)TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
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
                    InformeAmpliacion.LOCK(AppContext.ActiveSchema.Code);

                    string query = InformesAmpliaciones.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _ampliaciones = InformesAmpliaciones.GetChildList(session_code, reader);

                    query = InformesCorrectores.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _correctores = InformesCorrectores.GetChildList(session_code, reader);

                    query = Discrepancias.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _discrepancias = Discrepancias.GetChildList(session_code, reader);

                    query = NotificacionesInternas.SELECT_BY_INFORME_DISCREPANCIA(this.Oid, TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
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


        internal void Insert(Auditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidAuditoria = parent.Oid;
            GetNewCode(parent.Oid);

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
					
                _ampliaciones.Update(this);
                _correctores.Update(this);
                _discrepancias.Update(this);
                _notificaciones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Auditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidAuditoria = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                InformeDiscrepanciaRecord obj = parent.Session().Get<InformeDiscrepanciaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
					
                _ampliaciones.Update(this);
                _correctores.Update(this);
                _discrepancias.Update(this);
                _notificaciones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(Auditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<InformeDiscrepanciaRecord>(Oid));
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

                    InformeDiscrepancia.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = InformeDiscrepancia.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        InformeAmpliacion.LOCK(AppContext.ActiveSchema.Code);

                        string query = InformesAmpliaciones.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _ampliaciones = InformesAmpliaciones.GetChildList(criteria.SessionCode, reader);

                        InformeCorrector.LOCK(AppContext.ActiveSchema.Code);

                        query = InformesCorrectores.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _correctores = InformesCorrectores.GetChildList(criteria.SessionCode, reader);

                        Discrepancia.LOCK(AppContext.ActiveSchema.Code);

                        query = Discrepancias.SELECT_BY_INFORME_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _discrepancias = Discrepancias.GetChildList(criteria.SessionCode, reader);

                        NotificacionInterna.LOCK(AppContext.ActiveSchema.Code);

                        query = NotificacionesInternas.SELECT_BY_INFORME_DISCREPANCIA(this.Oid, TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _notificaciones = NotificacionesInternas.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((InformeDiscrepanciaRecord)(criteria.UniqueResult()));

                    Session().Lock(Session().Get<InformeDiscrepanciaRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = InformeAmpliacion.GetCriteria(Session());
                        criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                        _ampliaciones = InformesAmpliaciones.GetChildList(criteria.List<InformeAmpliacion>());

                        criteria = InformeCorrector.GetCriteria(Session());
                        criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                        _correctores = InformesCorrectores.GetChildList(criteria.List<InformeCorrector>());
                        
                        criteria = Discrepancia.GetCriteria(Session());
                        criteria.AddEq("OidInformeDiscrepancia", this.Oid);
                        _discrepancias = Discrepancias.GetChildList(criteria.List<Discrepancia>());

                        criteria = NotificacionInterna.GetCriteria(Session());
                        criteria.AddEq("OidAsociado", this.Oid);
                        criteria.AddEq("TipoAsociado", (long)TipoNotificacionAsociado.INFORME_DISCREPANCIAS);
                        _notificaciones = NotificacionesInternas.GetChildList(criteria.List<NotificacionInterna>());

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

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                GetNewCode(OidAuditoria);
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
                    InformeDiscrepanciaRecord obj = Session().Get<InformeDiscrepanciaRecord>(Oid);
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
                InformeDiscrepanciaRecord obj = (InformeDiscrepanciaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<InformeDiscrepanciaRecord>(obj.Oid));

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

            query = "SELECT ID.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string id = nHManager.Instance.GetSQLTable(typeof(InformeDiscrepanciaRecord));

            query = "   FROM   " + id + "   AS ID";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Auditoria != null && conditions.Auditoria.Oid > 0)
                query += " AND ID.\"OID_AUDITORIA\" = " + conditions.Auditoria.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY \"FECHA_CREACION\"";

            if (lockTable) query += " FOR UPDATE OF ID NOWAIT";

            return query;
        }


        #endregion

    }
}

