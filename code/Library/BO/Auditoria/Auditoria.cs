using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;

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
	public class AuditoriaRecord : RecordBase
	{
		#region Attributes

		private long _oid_auditor;
		private long _oid_tipo_auditoria;
		private string _codigo = string.Empty;
		private long _serial;
		private DateTime _fecha_inicio;
		private DateTime _fecha_fin;
		private string _referencia = string.Empty;
		private string _observaciones = string.Empty;
		private long _oid_plan;
		private long _estado;
		private long _oid_responsable;
		private long _oid_usuario_auditor;
		private long _oid_usuario_responsable;
		private long _oid_departamento_auditor;
		private long _oid_departamento_responsable;
		private long _oid_plan_tipo;
		private DateTime _fecha_comunicacion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAuditor { get { return _oid_auditor; } set { _oid_auditor = value; } }
		public virtual long OidTipoAuditoria { get { return _oid_tipo_auditoria; } set { _oid_tipo_auditoria = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual DateTime FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
		public virtual DateTime FechaFin { get { return _fecha_fin; } set { _fecha_fin = value; } }
		public virtual string Referencia { get { return _referencia; } set { _referencia = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
		public virtual long Estado { get { return _estado; } set { _estado = value; } }
		public virtual long OidResponsable { get { return _oid_responsable; } set { _oid_responsable = value; } }
		public virtual long OidUsuarioAuditor { get { return _oid_usuario_auditor; } set { _oid_usuario_auditor = value; } }
		public virtual long OidUsuarioResponsable { get { return _oid_usuario_responsable; } set { _oid_usuario_responsable = value; } }
		public virtual long OidDepartamentoAuditor { get { return _oid_departamento_auditor; } set { _oid_departamento_auditor = value; } }
		public virtual long OidDepartamentoResponsable { get { return _oid_departamento_responsable; } set { _oid_departamento_responsable = value; } }
		public virtual long OidPlanTipo { get { return _oid_plan_tipo; } set { _oid_plan_tipo = value; } }
		public virtual DateTime FechaComunicacion { get { return _fecha_comunicacion; } set { _fecha_comunicacion = value; } }

		#endregion
		
		#region Business Methods
		
		public AuditoriaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_auditor = Format.DataReader.GetInt64(source, "OID_AUDITOR");
			_oid_tipo_auditoria = Format.DataReader.GetInt64(source, "OID_TIPO_AUDITORIA");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_fecha_inicio = Format.DataReader.GetDateTime(source, "FECHA_INICIO");
			_fecha_fin = Format.DataReader.GetDateTime(source, "FECHA_FIN");
			_referencia = Format.DataReader.GetString(source, "REFERENCIA");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
			_estado = Format.DataReader.GetInt64(source, "ESTADO");
			_oid_responsable = Format.DataReader.GetInt64(source, "OID_RESPONSABLE");
			_oid_usuario_auditor = Format.DataReader.GetInt64(source, "OID_USUARIO_AUDITOR");
			_oid_usuario_responsable = Format.DataReader.GetInt64(source, "OID_USUARIO_RESPONSABLE");
			_oid_departamento_auditor = Format.DataReader.GetInt64(source, "OID_DEPARTAMENTO_AUDITOR");
			_oid_departamento_responsable = Format.DataReader.GetInt64(source, "OID_DEPARTAMENTO_RESPONSABLE");
			_oid_plan_tipo = Format.DataReader.GetInt64(source, "OID_PLAN_TIPO");
			_fecha_comunicacion = Format.DataReader.GetDateTime(source, "FECHA_COMUNICACION");

		}		
		public virtual void CopyValues(AuditoriaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_auditor = source.OidAuditor;
			_oid_tipo_auditoria = source.OidTipoAuditoria;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_fecha_inicio = source.FechaInicio;
			_fecha_fin = source.FechaFin;
			_referencia = source.Referencia;
			_observaciones = source.Observaciones;
			_oid_plan = source.OidPlan;
			_estado = source.Estado;
			_oid_responsable = source.OidResponsable;
			_oid_usuario_auditor = source.OidUsuarioAuditor;
			_oid_usuario_responsable = source.OidUsuarioResponsable;
			_oid_departamento_auditor = source.OidDepartamentoAuditor;
			_oid_departamento_responsable = source.OidDepartamentoResponsable;
			_oid_plan_tipo = source.OidPlanTipo;
			_fecha_comunicacion = source.FechaComunicacion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class AuditoriaBase 
	{	 
		#region Attributes
		
		private AuditoriaRecord _record = new AuditoriaRecord();

        protected string _auditor = string.Empty;
        protected string _responsable = string.Empty;
        protected string _tipo = string.Empty;
        protected string _plan = string.Empty;
		
		#endregion
		
		#region Properties
		
		public AuditoriaRecord Record { get { return _record; } }
        

        public virtual EstadoAuditoria EstadoAuditoria { get { return (EstadoAuditoria)_record.Estado; } set { _record.Estado = (long)value; } }
        public virtual string EstadoAuditoriaLabel { get { return EnumText<EstadoAuditoria>.GetLabel(EstadoAuditoria); } }
        public virtual string Auditor { get { return _auditor; } set { _auditor = value; } }
        public virtual string Responsable { get { return _responsable; } set { _responsable = value; } }
        public virtual string PlanAnual { get { return _plan; } }
        public virtual string TipoAuditoria { get { return _tipo; } set { _tipo = value; } }

		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _responsable = Format.DataReader.GetString(source, "RESPONSABLE");
            _auditor = Format.DataReader.GetString(source, "AUDITOR");
            _tipo = Format.DataReader.GetString(source, "TIPO_AUDITORIA");
            _plan = Format.DataReader.GetString(source, "PLAN");
		}		
		public void CopyValues(Auditoria source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _auditor = source.Auditor;
            _responsable = source.Responsable;
            _tipo = source.TipoAuditoria;
            _plan = source.PlanAnual;
		}
		public void CopyValues(AuditoriaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _auditor = source.Auditor;
            _responsable = source.Responsable;
            _tipo = source.TipoAuditoria;
            _plan = source.PlanAnual;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Auditoria : BusinessBaseEx<Auditoria>
	{	 
		#region Attributes
		
		protected AuditoriaBase _base = new AuditoriaBase();

        private CuestionesAuditoria _cuestiones = CuestionesAuditoria.NewChildList();
        private InformesDiscrepancias _informes = InformesDiscrepancias.NewChildList();
        private HistoriaAuditorias _historial = HistoriaAuditorias.NewChildList();
        private NotificacionesInternas _notificaciones = NotificacionesInternas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public AuditoriaBase Base { get { return _base; } }
		
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
		public virtual long OidAuditor
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAuditor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidAuditor.Equals(value))
				{
					_base.Record.OidAuditor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidTipoAuditoria
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidTipoAuditoria;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidTipoAuditoria.Equals(value))
				{
					_base.Record.OidTipoAuditoria = value;
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
		public virtual DateTime FechaInicio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaInicio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaInicio.Equals(value))
				{
					_base.Record.FechaInicio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaFin
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaFin;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaFin.Equals(value))
				{
					_base.Record.FechaFin = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Referencia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Referencia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Referencia.Equals(value))
				{
					_base.Record.Referencia = value;
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
		public virtual long OidPlan
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlan;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPlan.Equals(value))
				{
					_base.Record.OidPlan = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Estado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Estado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Estado.Equals(value))
				{
					_base.Record.Estado = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidResponsable
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidResponsable;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidResponsable.Equals(value))
				{
					_base.Record.OidResponsable = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidUsuarioAuditor
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidUsuarioAuditor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidUsuarioAuditor.Equals(value))
				{
					_base.Record.OidUsuarioAuditor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidUsuarioResponsable
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidUsuarioResponsable;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidUsuarioResponsable.Equals(value))
				{
					_base.Record.OidUsuarioResponsable = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidDepartamentoAuditor
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidDepartamentoAuditor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidDepartamentoAuditor.Equals(value))
				{
					_base.Record.OidDepartamentoAuditor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidDepartamentoResponsable
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidDepartamentoResponsable;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidDepartamentoResponsable.Equals(value))
				{
					_base.Record.OidDepartamentoResponsable = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidPlanTipo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlanTipo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPlanTipo.Equals(value))
				{
					_base.Record.OidPlanTipo = value;
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

        public virtual CuestionesAuditoria Cuestiones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _cuestiones;
            }

            set
            {
                _cuestiones = value;
            }
        }
        public virtual InformesDiscrepancias Informes
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _informes;
            }

            set
            {
                _informes = value;
            }
        }
        public virtual HistoriaAuditorias Historial
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _historial;
            }

            set
            {
                _historial = value;
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

        public virtual EstadoAuditoria EstadoAuditoria { get { return (EstadoAuditoria)_base.EstadoAuditoria; } set { _base.EstadoAuditoria = value; } }
        public virtual string EstadoAuditoriaLabel { get { return EnumText<EstadoAuditoria>.GetLabel(EstadoAuditoria); } }
        public virtual string Auditor { get { return _base.Auditor; } }
        public virtual string Responsable { get { return _base.Responsable; } }
        public virtual string PlanAnual { get { return _base.PlanAnual; } }
        public virtual string TipoAuditoria { get { return _base.TipoAuditoria; } set { _base.TipoAuditoria = value; } }

        public override bool IsValid
        {
            get { return base.IsValid && _cuestiones.IsValid && _informes.IsValid && _historial.IsValid && _notificaciones.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _cuestiones.IsDirty || _informes.IsDirty || _historial.IsDirty || _notificaciones.IsDirty; }
        }
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Auditoria CloneAsNew()
		{
			Auditoria clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = Auditoria.OpenSession();
			Auditoria.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(AuditoriaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAuditor = source.OidAuditor;
			OidTipoAuditoria = source.OidTipoAuditoria;
			Codigo = source.Codigo;
			Serial = source.Serial;
			FechaInicio = source.FechaInicio;
			FechaFin = source.FechaFin;
			Referencia = source.Referencia;
			Observaciones = source.Observaciones;
			OidPlan = source.OidPlan;
			Estado = source.Estado;
			OidResponsable = source.OidResponsable;
			OidUsuarioAuditor = source.OidUsuarioAuditor;
			OidUsuarioResponsable = source.OidUsuarioResponsable;
			OidDepartamentoAuditor = source.OidDepartamentoAuditor;
			OidDepartamentoResponsable = source.OidDepartamentoResponsable;
			OidPlanTipo = source.OidPlanTipo;
			FechaComunicacion = source.FechaComunicacion;
		}
		
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(Auditoria));
            Codigo = Serial.ToString(Resources.Defaults.AUDITORIA_CODE_FORMAT);
        }				
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAuditor", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidTipoAuditoria", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlanTipo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidResponsable", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Referencia");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Estado", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidUsuarioAuditor", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidUsuarioResponsable", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.AUDITORIA);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.AUDITORIA);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.AUDITORIA);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.AUDITORIA);
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected Auditoria() 
        {
            GetNewCode();
            Referencia = Codigo;
            //AuditoriaController.UpdateHistorial(this);
        }

        public virtual AuditoriaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new AuditoriaInfo(this, get_childs);
        }

        public virtual AuditoriaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Auditoria New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Auditoria>(new CriteriaCs(-1));
        }

        public static Auditoria Get(long oid, bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Auditoria.GetCriteria(Auditoria.OpenSession());
            criteria.Childs = get_childs;

            criteria.Query = Auditoria.SELECT(oid);

            Auditoria.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Auditoria>(criteria);
        }

        public static Auditoria Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Auditoria.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Auditoria>(criteria);
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
        /// Elimina todas los Auditorias
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Auditoria.OpenSession();
            ISession sess = Auditoria.Session(sessCode);
            ITransaction trans = Auditoria.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Auditoria");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Auditoria.CloseSession(sessCode);
            }
        }

        public override Auditoria Save()
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

                _cuestiones.Update(this);
                _informes.Update(this);
                _historial.Update(this);
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

        private Auditoria(Auditoria source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Auditoria(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code ,reader);
        }

        public static Auditoria NewChild(TipoAuditoria parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Auditoria obj = new Auditoria();
            obj.OidTipoAuditoria = parent.Oid;
            return obj;
        }

        internal static Auditoria GetChild(Auditoria source)
        {
            return new Auditoria(source);
        }

        internal static Auditoria GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Auditoria(session_code, reader, childs);
        }


        internal static Auditoria GetChild(int session_code, IDataReader reader)
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

            FechaInicio = DateTime.Today;
            FechaFin = DateTime.Today.AddMonths(1);
        }

        #endregion

        #region Child Data Access

        private void Fetch(Auditoria source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = CuestionAuditoria.GetCriteria(Session());
                criteria.AddEq("OidAuditoria", this.Oid);
                _cuestiones = CuestionesAuditoria.GetChildList(criteria.List<CuestionAuditoria>());

                criteria = InformeDiscrepancia.GetCriteria(Session());
                criteria.AddEq("OidAuditoria", this.Oid);
                _informes = InformesDiscrepancias.GetChildList(criteria.List<InformeDiscrepancia>());

                criteria = HistoriaAuditoria.GetCriteria(Session());
                criteria.AddEq("OidAuditoria", this.Oid);
                _historial = HistoriaAuditorias.GetChildList(criteria.List<HistoriaAuditoria>());

                criteria = NotificacionInterna.GetCriteria(Session());
                criteria.AddEq("OidAsociado", this.Oid);
                criteria.AddEq("TipoAsociado", (long)TipoNotificacionAsociado.COMUNICADO_AUDITORIA);
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
                    CuestionAuditoria.LOCK(AppContext.ActiveSchema.Code);

                    string query = CuestionesAuditoria.SELECT_BY_AUDITORIA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _cuestiones = CuestionesAuditoria.GetChildList(reader);

                    InformeDiscrepancia.LOCK(AppContext.ActiveSchema.Code);

                    query = InformesDiscrepancias.SELECT_BY_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _informes = InformesDiscrepancias.GetChildList(session_code, reader);

                    HistoriaAuditoria.LOCK(AppContext.ActiveSchema.Code);

                    query = HistoriaAuditorias.SELECT_BY_AUDITORIA(Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _historial = HistoriaAuditorias.GetChildList(reader);

                    NotificacionInterna.LOCK(AppContext.ActiveSchema.Code);

                    query = NotificacionesInternas.SELECT_BY_AUDITORIA(this.Oid, TipoNotificacionAsociado.COMUNICADO_AUDITORIA);
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
        
        internal void Insert(TipoAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidTipoAuditoria = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
					
                _cuestiones.Update(this);
                _informes.Update(this);
                _historial.Update(this);
                _notificaciones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(TipoAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidTipoAuditoria = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AuditoriaRecord obj = parent.Session().Get<AuditoriaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
					
                _cuestiones.Update(this);
                _informes.Update(this);
                _historial.Update(this);
                _notificaciones.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(TipoAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<AuditoriaRecord>(Oid));
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
                    Auditoria.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        CuestionAuditoria.LOCK(AppContext.ActiveSchema.Code);

                        string query = CuestionesAuditoria.SELECT_BY_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cuestiones = CuestionesAuditoria.GetChildList(reader);

                        InformeDiscrepancia.LOCK(AppContext.ActiveSchema.Code);

                        query = InformesDiscrepancias.SELECT_BY_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _informes = InformesDiscrepancias.GetChildList(criteria.SessionCode, reader);

                        HistoriaAuditoria.LOCK(AppContext.ActiveSchema.Code);

                        query = HistoriaAuditorias.SELECT_BY_AUDITORIA(Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _historial = HistoriaAuditorias.GetChildList(reader);

                        NotificacionInterna.LOCK(AppContext.ActiveSchema.Code);

                        query = NotificacionesInternas.SELECT_BY_AUDITORIA(this.Oid, TipoNotificacionAsociado.COMUNICADO_AUDITORIA);
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
                    AuditoriaRecord obj = Session().Get<AuditoriaRecord>(Oid);
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
                AuditoriaRecord obj = (AuditoriaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<AuditoriaRecord>(obj.Oid));

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
        
        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT A.*," +
                    "       (TA.\"NUMERO\" || ' ' || TA.\"NOMBRE\") AS \"TIPO_AUDITORIA\"," +
                    "       E.\"NOMBRE\" AS \"AUDITOR\"," +
                    "       I.\"NOMBRE\" AS \"RESPONSABLE\"," +
                    "       PA.\"NOMBRE\" AS \"PLAN\"";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string a = nHManager.Instance.GetSQLTable(typeof(AuditoriaRecord));
            string e = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));
            string pa = nHManager.Instance.GetSQLTable(typeof(PlanAnualRecord));
            string ta = nHManager.Instance.GetSQLTable(typeof(TipoAuditoriaRecord));

            string query;

            query = Auditoria.SELECT_FIELDS() +
                    " FROM " + a + " AS A" +
                    " LEFT JOIN " + e + " AS I ON A.\"OID_RESPONSABLE\" = I.\"OID\"" +
                    " LEFT JOIN " + e + " AS E ON A.\"OID_AUDITOR\" = E.\"OID\"" +
                    " LEFT JOIN " + pa + " AS PA ON A.\"OID_PLAN\" = PA.\"OID\"" +
                    " LEFT JOIN " + ta + " AS TA ON A.\"OID_TIPO_AUDITORIA\" = TA.\"OID\"";

            if (oid > 0) query += " WHERE A.\"OID\" = " + oid.ToString();

            //if (lock_table) query += " FOR UPDATE OF A NOWAIT";

            return query;
        }

        public new static string SELECT(long oid) { return Auditoria.SELECT(oid, true); }

        #endregion

    }
}

