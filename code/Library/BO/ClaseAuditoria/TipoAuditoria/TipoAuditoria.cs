using System;
using System.ComponentModel;
using System.Collections.Generic;
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
	public class TipoAuditoriaRecord : RecordBase
	{
		#region Attributes

		private long _oid_clase_auditoria;
		private string _codigo = string.Empty;
		private long _serial;
		private string _nombre = string.Empty;
		private string _documentacion = string.Empty;
		private string _apreciaciones = string.Empty;
		private string _numero = string.Empty;
		private bool _enero = false;
		private bool _febrero = false;
		private bool _marzo = false;
		private bool _abril = false;
		private bool _mayo = false;
		private bool _junio = false;
		private bool _julio = false;
		private bool _agosto = false;
		private bool _septiembre = false;
		private bool _octubre = false;
		private bool _noviembre = false;
		private bool _diciembre = false;
		private string _texto_informe = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidClaseAuditoria { get { return _oid_clase_auditoria; } set { _oid_clase_auditoria = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Documentacion { get { return _documentacion; } set { _documentacion = value; } }
		public virtual string Apreciaciones { get { return _apreciaciones; } set { _apreciaciones = value; } }
		public virtual string Numero { get { return _numero; } set { _numero = value; } }
		public virtual bool Enero { get { return _enero; } set { _enero = value; } }
		public virtual bool Febrero { get { return _febrero; } set { _febrero = value; } }
		public virtual bool Marzo { get { return _marzo; } set { _marzo = value; } }
		public virtual bool Abril { get { return _abril; } set { _abril = value; } }
		public virtual bool Mayo { get { return _mayo; } set { _mayo = value; } }
		public virtual bool Junio { get { return _junio; } set { _junio = value; } }
		public virtual bool Julio { get { return _julio; } set { _julio = value; } }
		public virtual bool Agosto { get { return _agosto; } set { _agosto = value; } }
		public virtual bool Septiembre { get { return _septiembre; } set { _septiembre = value; } }
		public virtual bool Octubre { get { return _octubre; } set { _octubre = value; } }
		public virtual bool Noviembre { get { return _noviembre; } set { _noviembre = value; } }
		public virtual bool Diciembre { get { return _diciembre; } set { _diciembre = value; } }
		public virtual string TextoInforme { get { return _texto_informe; } set { _texto_informe = value; } }

		#endregion
		
		#region Business Methods
		
		public TipoAuditoriaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_clase_auditoria = Format.DataReader.GetInt64(source, "OID_CLASE_AUDITORIA");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_documentacion = Format.DataReader.GetString(source, "DOCUMENTACION");
			_apreciaciones = Format.DataReader.GetString(source, "APRECIACIONES");
			_numero = Format.DataReader.GetString(source, "NUMERO");
			_enero = Format.DataReader.GetBool(source, "ENERO");
			_febrero = Format.DataReader.GetBool(source, "FEBRERO");
			_marzo = Format.DataReader.GetBool(source, "MARZO");
			_abril = Format.DataReader.GetBool(source, "ABRIL");
			_mayo = Format.DataReader.GetBool(source, "MAYO");
			_junio = Format.DataReader.GetBool(source, "JUNIO");
			_julio = Format.DataReader.GetBool(source, "JULIO");
			_agosto = Format.DataReader.GetBool(source, "AGOSTO");
			_septiembre = Format.DataReader.GetBool(source, "SEPTIEMBRE");
			_octubre = Format.DataReader.GetBool(source, "OCTUBRE");
			_noviembre = Format.DataReader.GetBool(source, "NOVIEMBRE");
			_diciembre = Format.DataReader.GetBool(source, "DICIEMBRE");
			_texto_informe = Format.DataReader.GetString(source, "TEXTO_INFORME");

		}		
		public virtual void CopyValues(TipoAuditoriaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_clase_auditoria = source.OidClaseAuditoria;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_nombre = source.Nombre;
			_documentacion = source.Documentacion;
			_apreciaciones = source.Apreciaciones;
			_numero = source.Numero;
			_enero = source.Enero;
			_febrero = source.Febrero;
			_marzo = source.Marzo;
			_abril = source.Abril;
			_mayo = source.Mayo;
			_junio = source.Junio;
			_julio = source.Julio;
			_agosto = source.Agosto;
			_septiembre = source.Septiembre;
			_octubre = source.Octubre;
			_noviembre = source.Noviembre;
			_diciembre = source.Diciembre;
			_texto_informe = source.TextoInforme;
		}
		
		#endregion	
	}

    [Serializable()]
	public class TipoAuditoriaBase 
	{	 
		#region Attributes
		
		private TipoAuditoriaRecord _record = new TipoAuditoriaRecord();
		
		#endregion
		
		#region Properties
		
		public TipoAuditoriaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(TipoAuditoria source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(TipoAuditoriaInfo source)
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
	public class TipoAuditoria : BusinessBaseEx<TipoAuditoria>
	{	 
		#region Attributes
		
		protected TipoAuditoriaBase _base = new TipoAuditoriaBase();

        private Criterios _criterios = Criterios.NewChildList();
        private Cuestiones _cuestiones = Cuestiones.NewChildList();
        private Auditorias_Areas _areas = Auditorias_Areas.NewChildList();
        private Planes_Tipos _planes_tipos = Planes_Tipos.NewChildList();
		

		#endregion
		
		#region Properties
		
		public TipoAuditoriaBase Base { get { return _base; } }
		
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
		public virtual long OidClaseAuditoria
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClaseAuditoria;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidClaseAuditoria.Equals(value))
				{
					_base.Record.OidClaseAuditoria = value;
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
		public virtual string Documentacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Documentacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Documentacion.Equals(value))
				{
					_base.Record.Documentacion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Apreciaciones
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Apreciaciones;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Apreciaciones.Equals(value))
				{
					_base.Record.Apreciaciones = value;
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
		public virtual bool Enero
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Enero;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Enero.Equals(value))
				{
					_base.Record.Enero = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Febrero
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Febrero;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Febrero.Equals(value))
				{
					_base.Record.Febrero = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Marzo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Marzo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Marzo.Equals(value))
				{
					_base.Record.Marzo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Abril
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Abril;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Abril.Equals(value))
				{
					_base.Record.Abril = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Mayo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Mayo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Mayo.Equals(value))
				{
					_base.Record.Mayo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Junio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Junio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Junio.Equals(value))
				{
					_base.Record.Junio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Julio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Julio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Julio.Equals(value))
				{
					_base.Record.Julio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Agosto
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Agosto;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Agosto.Equals(value))
				{
					_base.Record.Agosto = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Septiembre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Septiembre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Septiembre.Equals(value))
				{
					_base.Record.Septiembre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Octubre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Octubre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Octubre.Equals(value))
				{
					_base.Record.Octubre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Noviembre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Noviembre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Noviembre.Equals(value))
				{
					_base.Record.Noviembre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Diciembre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Diciembre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Diciembre.Equals(value))
				{
					_base.Record.Diciembre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string TextoInforme
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.TextoInforme;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.TextoInforme.Equals(value))
				{
					_base.Record.TextoInforme = value;
					PropertyHasChanged();
				}
			}
		}


        public virtual Criterios Criterios
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _criterios;
            }

            set
            {
                _criterios = value;
            }
        }
        public virtual Cuestiones Cuestiones
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
        public virtual Auditorias_Areas Areas
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _areas;
            }

            set
            {
                _areas = value;
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
       

        //En estas funciones habrá que añadir las preguntas de si las listas son válidas o están sucias
        //Para añadir una lista: && _lista.IsValid
        public override bool IsValid
        {
            get { return base.IsValid && _criterios.IsValid && _cuestiones.IsValid && _areas.IsValid 
                && _planes_tipos.IsValid; }
        }
        //Para añadir una lista: || _lista.IsDirty
        public override bool IsDirty
        {
            get { return base.IsDirty || _criterios.IsDirty || _cuestiones.IsDirty || _areas.IsDirty
                || _planes_tipos.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual TipoAuditoria CloneAsNew()
		{
			TipoAuditoria clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = TipoAuditoria.OpenSession();
			TipoAuditoria.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(TipoAuditoriaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidClaseAuditoria = source.OidClaseAuditoria;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Nombre = source.Nombre;
			Documentacion = source.Documentacion;
			Apreciaciones = source.Apreciaciones;
			Numero = source.Numero;
			Enero = source.Enero;
			Febrero = source.Febrero;
			Marzo = source.Marzo;
			Abril = source.Abril;
			Mayo = source.Mayo;
			Junio = source.Junio;
			Julio = source.Julio;
			Agosto = source.Agosto;
			Septiembre = source.Septiembre;
			Octubre = source.Octubre;
			Noviembre = source.Noviembre;
			Diciembre = source.Diciembre;
			TextoInforme = source.TextoInforme;
		}
		
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(TipoAuditoria));
            Codigo = Serial.ToString(Resources.Defaults.TIPO_AUDITORIA_CODE_FORMAT);
        }				

        public virtual void GetNewCode(long numero_clase)
        {
            Serial = SerialInfo.GetNext(typeof(TipoAuditoria));
            Codigo = Serial.ToString(Resources.Defaults.TIPO_AUDITORIA_CODE_FORMAT);
            Numero = numero_clase + "." + Serial.ToString();
        }

        public virtual void GetNewCode(ClaseAuditoria parent)
        {
            Serial = SerialInfo.GetNext(typeof(TipoAuditoria));

            foreach (TipoAuditoria item in parent.TipoAuditorias)
            {
                if (item.Serial >= Serial)
                    Serial = item.Serial + 1;
            }

            Codigo = Serial.ToString(Resources.Defaults.TIPO_AUDITORIA_CODE_FORMAT);
            Numero = parent.Numero + "." + Serial.ToString();
        }
			
		#endregion

        #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidClaseAuditoria", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Numero");
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

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public TipoAuditoria() 
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual TipoAuditoriaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new TipoAuditoriaInfo(this, get_childs);
        }

        public virtual TipoAuditoriaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static TipoAuditoria New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<TipoAuditoria>(new CriteriaCs(-1));
        }

        public static TipoAuditoria Get(long oid) { return Get(oid, true); }

        public static TipoAuditoria Get(long oid, bool childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = TipoAuditoria.GetCriteria(TipoAuditoria.OpenSession());
            criteria.Childs = childs;

            criteria.Query = TipoAuditoria.SELECT(oid);

            TipoAuditoria.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<TipoAuditoria>(criteria);
        }

        public static TipoAuditoria Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            TipoAuditoria.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<TipoAuditoria>(criteria);
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
        /// Elimina todas los TipoAuditorias
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = TipoAuditoria.OpenSession();
            ISession sess = TipoAuditoria.Session(sessCode);
            ITransaction trans = TipoAuditoria.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from TipoAuditoria");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                TipoAuditoria.CloseSession(sessCode);
            }
        }

        public override TipoAuditoria Save()
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

                _criterios.Update(this);
                _areas.Update(this);
                _cuestiones.Update(this);
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

        #region Child Factory Methods

        private TipoAuditoria(TipoAuditoria source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private TipoAuditoria(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static TipoAuditoria NewChild(ClaseAuditoria parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            TipoAuditoria obj = new TipoAuditoria();
            obj.OidClaseAuditoria = parent.Oid;
            obj.GetNewCode(parent);
            return obj;
        }

        internal static TipoAuditoria GetChild(TipoAuditoria source)
        {
            return new TipoAuditoria(source);
        }

        internal static TipoAuditoria GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new TipoAuditoria(session_code, reader, childs);
        }

        internal static TipoAuditoria GetChild(int session_code, IDataReader reader)
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
        }

        #endregion

        #region Child Data Access

        private void Fetch(TipoAuditoria source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = Criterio.GetCriteria(Session());
                criteria.AddEq("OidTipoAuditoria", this.Oid);
                _criterios = Criterios.GetChildList(criteria.List<Criterio>());

                criteria = Auditoria_Area.GetCriteria(Session());
                criteria.AddEq("OidAuditoria", this.Oid);
                _areas = Auditorias_Areas.GetChildList(criteria.List<Auditoria_Area>());

                criteria = Cuestion.GetCriteria(Session());
                criteria.AddEq("OidTipoAuditoria", this.Oid);
                _cuestiones = Cuestiones.GetChildList(criteria.List<Cuestion>());

                criteria = Plan_Tipo.GetCriteria(Session());
                criteria.AddEq("OidTipo", this.Oid);
                _planes_tipos = Planes_Tipos.GetChildList(criteria.List<Plan_Tipo>());


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
                    Criterio.LOCK(AppContext.ActiveSchema.Code);

                    string query = Criterios.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _criterios = Criterios.GetChildList(reader);

                    Auditoria_Area.LOCK(AppContext.ActiveSchema.Code);

                    query = Auditorias_Areas.SELECT_BY_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _areas = Auditorias_Areas.GetChildList(reader);
                    
                    Cuestion.LOCK(AppContext.ActiveSchema.Code);

                    query = Cuestiones.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _cuestiones = Cuestiones.GetChildList(session_code, reader);

                    Plan_Tipo.LOCK(AppContext.ActiveSchema.Code);

                    query = Planes_Tipos.SELECT_BY_FIELD("OidTipo", this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _planes_tipos = Planes_Tipos.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(ClaseAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseAuditoria = parent.Oid;
            //GetNewCode(parent);

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
					
                _criterios.Update(this);
                _areas.Update(this);
                _cuestiones.Update(this);
                _planes_tipos.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(ClaseAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidClaseAuditoria = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                TipoAuditoriaRecord obj = parent.Session().Get<TipoAuditoriaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
					
                _criterios.Update(this);
                _areas.Update(this);
                _cuestiones.Update(this);
                _planes_tipos.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(ClaseAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<TipoAuditoriaRecord>(Oid));
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
                    TipoAuditoria.LOCK();
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Criterio.LOCK(AppContext.ActiveSchema.Code);

                        string query = Criterios.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _criterios = Criterios.GetChildList(reader);

                        Auditoria_Area.LOCK(AppContext.ActiveSchema.Code);

                        query = Auditorias_Areas.SELECT_BY_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _areas = Auditorias_Areas.GetChildList(reader);

                        Cuestion.LOCK(AppContext.ActiveSchema.Code);

                        query = Cuestiones.SELECT_BY_TIPO_AUDITORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cuestiones = Cuestiones.GetChildList(criteria.SessionCode, reader);

                        Plan_Tipo.LOCK(AppContext.ActiveSchema.Code);

                        query = Planes_Tipos.SELECT_BY_FIELD("OidTipo", this.Oid);
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

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();

                GetNewCode(ClaseAuditoriaInfo.Get(OidClaseAuditoria).Numero);
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
                    TipoAuditoriaRecord obj = Session().Get<TipoAuditoriaRecord>(Oid);
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
                TipoAuditoriaRecord obj = (TipoAuditoriaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<TipoAuditoriaRecord>(obj.Oid));

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

            query = "SELECT TA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ta = nHManager.Instance.GetSQLTable(typeof(TipoAuditoriaRecord));

            query = "   FROM   " + ta + "   AS TA";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.ClaseAuditoria != null && conditions.ClaseAuditoria.Oid > 0)
                query += " AND TA.\"OID_CLASE_AUDITORIA\" = " + conditions.ClaseAuditoria.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY TA.\"NUMERO\"";

            if (lockTable) query += " FOR UPDATE OF TA NOWAIT";

            return query;
        }

        #endregion

    }
}

