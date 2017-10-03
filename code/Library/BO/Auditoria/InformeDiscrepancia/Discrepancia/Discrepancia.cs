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
	public class DiscrepanciaRecord : RecordBase
	{
		#region Attributes

		private long _oid_informe;
		private long _numero;
		private string _texto = string.Empty;
		private long _nivel;
		private DateTime _fecha_debida;
		private string _observaciones = string.Empty;
		private DateTime _fecha_cierre;
		private string _codigo = string.Empty;
		private long _serial;
		private long _oid_cuestion;
		private bool _discrepancia = false;
		private DateTime _fecha_ampliacion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInforme { get { return _oid_informe; } set { _oid_informe = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual long Nivel { get { return _nivel; } set { _nivel = value; } }
		public virtual DateTime FechaDebida { get { return _fecha_debida; } set { _fecha_debida = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual DateTime FechaCierre { get { return _fecha_cierre; } set { _fecha_cierre = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual long OidCuestion { get { return _oid_cuestion; } set { _oid_cuestion = value; } }
		public virtual bool Discrepancia { get { return _discrepancia; } set { _discrepancia = value; } }
		public virtual DateTime FechaAmpliacion { get { return _fecha_ampliacion; } set { _fecha_ampliacion = value; } }

		#endregion
		
		#region Business Methods
		
		public DiscrepanciaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_informe = Format.DataReader.GetInt64(source, "OID_INFORME");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_nivel = Format.DataReader.GetInt64(source, "NIVEL");
			_fecha_debida = Format.DataReader.GetDateTime(source, "FECHA_DEBIDA");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_fecha_cierre = Format.DataReader.GetDateTime(source, "FECHA_CIERRE");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_oid_cuestion = Format.DataReader.GetInt64(source, "OID_CUESTION");
			_discrepancia = Format.DataReader.GetBool(source, "DISCREPANCIA");
			_fecha_ampliacion = Format.DataReader.GetDateTime(source, "FECHA_AMPLIACION");

		}		
		public virtual void CopyValues(DiscrepanciaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_informe = source.OidInforme;
			_numero = source.Numero;
			_texto = source.Texto;
			_nivel = source.Nivel;
			_fecha_debida = source.FechaDebida;
			_observaciones = source.Observaciones;
			_fecha_cierre = source.FechaCierre;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_oid_cuestion = source.OidCuestion;
			_discrepancia = source.Discrepancia;
			_fecha_ampliacion = source.FechaAmpliacion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class DiscrepanciaBase 
	{	 
		#region Attributes
		
		private DiscrepanciaRecord _record = new DiscrepanciaRecord();

        private string _numero_informe = string.Empty;
        private string _numero_auditoria = string.Empty;
		
		#endregion
		
		#region Properties

        public DiscrepanciaRecord Record { get { return _record; } }

        public string NumeroInforme { get { return _numero_informe; } }
        public string NumeroAuditoria { get { return _numero_auditoria; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _numero_auditoria = Format.DataReader.GetString(source, "NUMERO_AUDITORIA");
            _numero_informe = Format.DataReader.GetString(source, "NUMERO_INFORME");
		}		
		public void CopyValues(Discrepancia source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(DiscrepanciaInfo source)
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
	public class Discrepancia : BusinessBaseEx<Discrepancia>
	{	 
		#region Attributes
		
		protected DiscrepanciaBase _base = new DiscrepanciaBase();

        private Ampliaciones _ampliaciones = Ampliaciones.NewChildList();
        private AccionesCorrectoras _correctoras = AccionesCorrectoras.NewChildList();
		

		#endregion
		
		#region Properties
		
		public DiscrepanciaBase Base { get { return _base; } }
		
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
		public virtual long OidInforme
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInforme;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInforme.Equals(value))
				{
					_base.Record.OidInforme = value;
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
		public virtual long Nivel
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nivel;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Nivel.Equals(value))
				{
					_base.Record.Nivel = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaDebida
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaDebida;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaDebida.Equals(value))
				{
					_base.Record.FechaDebida = value;
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
		public virtual DateTime FechaCierre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaCierre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaCierre.Equals(value))
				{
					_base.Record.FechaCierre = value;
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
		public virtual long OidCuestion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidCuestion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidCuestion.Equals(value))
				{
					_base.Record.OidCuestion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool EsDiscrepancia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Discrepancia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Discrepancia.Equals(value))
				{
					_base.Record.Discrepancia = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaAmpliacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaAmpliacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaAmpliacion.Equals(value))
				{
					_base.Record.FechaAmpliacion = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual Ampliaciones Ampliaciones
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
        public virtual AccionesCorrectoras Correctoras
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _correctoras;
            }

            set
            {
                _correctoras = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _ampliaciones.IsValid && _correctoras.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _ampliaciones.IsDirty || _correctoras.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
				
		protected virtual void CopyFrom(DiscrepanciaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInforme = source.OidInforme;
			Numero = source.Numero;
			Texto = source.Texto;
			Nivel = source.Nivel;
			FechaDebida = source.FechaDebida;
			Observaciones = source.Observaciones;
			FechaCierre = source.FechaCierre;
			Codigo = source.Codigo;
			Serial = source.Serial;
			OidCuestion = source.OidCuestion;
			EsDiscrepancia = source.EsDiscrepancia;
			FechaAmpliacion = source.FechaAmpliacion;
		}
				
        /// <summary>
        /// Devuelve el siguiente código de PlanAnual.
        /// </summary>
        /// <returns></returns>
        public static string GetNewCode(InformeDiscrepancia parent)
        {
            Int64 lastcode = Discrepancia.GetNewSerial(parent);

            // Devolvemos el siguiente codigo de PlanAnual 
            return lastcode.ToString(Resources.Defaults.DISCREPANCIA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de PlanAnual
        /// </summary>
        /// <returns></returns>
        private static Int64 GetNewSerial(InformeDiscrepancia parent)
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<DiscrepanciaInfo> Discrepancias =
                DiscrepanciaList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (Discrepancias.Count > 0)
                lastcode = Discrepancias[Discrepancias.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.DISCREPANCIA_CODE_FORMAT);

            foreach (Discrepancia item in parent.Discrepancias)
            {
                if (item.Serial > lastcode)
                    lastcode = item.Serial;
            }

            lastcode++;
            return lastcode;
        }
			
		#endregion

        #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInforme", 1));
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidCuestion", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Numero", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Nivel", 1));
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
        public Discrepancia()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next(); 
            Codigo = (0).ToString(Resources.Defaults.DISCREPANCIA_CODE_FORMAT);
            FechaCierre = DateTime.MaxValue;
            FechaAmpliacion = DateTime.MaxValue;
        }

        public virtual DiscrepanciaInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

           return new DiscrepanciaInfo(this, get_childs);
        }

        public virtual DiscrepanciaInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Discrepancia New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Discrepancia>(new CriteriaCs(-1));
        }

        public static Discrepancia Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Discrepancia.GetCriteria(Discrepancia.OpenSession());
            criteria.AddOidSearch(oid);
            Discrepancia.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Discrepancia>(criteria);
        }

        public static Discrepancia Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Discrepancia.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Discrepancia>(criteria);
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
        /// Elimina todas los Discrepancias
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Discrepancia.OpenSession();
            ISession sess = Discrepancia.Session(sessCode);
            ITransaction trans = Discrepancia.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Discrepancia");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Discrepancia.CloseSession(sessCode);
            }
        }

        public override Discrepancia Save()
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
                _correctoras.Update(this);

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

        private Discrepancia(Discrepancia source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Discrepancia(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Discrepancia NewChild(InformeDiscrepancia parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Discrepancia obj = new Discrepancia();
            obj.OidInforme = parent.Oid;
            return obj;
        }

        internal static Discrepancia GetChild(Discrepancia source)
        {
            return new Discrepancia(source);
        }

        internal static Discrepancia GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Discrepancia(session_code, reader, childs);
        }


        internal static Discrepancia GetChild(int session_code, IDataReader reader)
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

        private void Fetch(Discrepancia source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = Ampliacion.GetCriteria(Session());
                criteria.AddEq("OidDiscrepancia", this.Oid);
                _ampliaciones = Ampliaciones.GetChildList(criteria.List<Ampliacion>());

                criteria = AccionCorrectora.GetCriteria(Session());
                criteria.AddEq("OidDiscrepancia", this.Oid);
                _correctoras = AccionesCorrectoras.GetChildList(criteria.List<AccionCorrectora>());


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
                    Ampliacion.LOCK(AppContext.ActiveSchema.Code);

                    string query = Ampliaciones.SELECT_BY_DISCREPANCIA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _ampliaciones = Ampliaciones.GetChildList(reader);

                    AccionCorrectora.LOCK(AppContext.ActiveSchema.Code);

                    query = AccionesCorrectoras.SELECT_BY_DISCREPANCIA(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _correctoras = AccionesCorrectoras.GetChildList(reader);
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

            OidInforme = parent.Oid;
            Codigo = GetNewCode(parent);
            Serial = GetNewSerial(parent);

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
					
                _ampliaciones.Update(this);
                _correctoras.Update(this);
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

            OidInforme = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                DiscrepanciaRecord obj = parent.Session().Get<DiscrepanciaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
					
                _ampliaciones.Update(this);
                _correctoras.Update(this);
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
                Session().Delete(Session().Get<DiscrepanciaRecord>(Oid));
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

                    Discrepancia.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = Discrepancia.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Ampliacion.LOCK(AppContext.ActiveSchema.Code);

                        string query = Ampliaciones.SELECT_BY_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _ampliaciones = Ampliaciones.GetChildList(reader);

                        AccionCorrectora.LOCK(AppContext.ActiveSchema.Code);

                        query = AccionesCorrectoras.SELECT_BY_DISCREPANCIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _correctoras = AccionesCorrectoras.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((DiscrepanciaRecord)(criteria.UniqueResult()));

                    Session().Lock(Session().Get<DiscrepanciaRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Ampliacion.GetCriteria(Session());
                        criteria.AddEq("OidDiscrepancia", this.Oid);
                        _ampliaciones = Ampliaciones.GetChildList(criteria.List<Ampliacion>());
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
                    DiscrepanciaRecord obj = Session().Get<DiscrepanciaRecord>(Oid);
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
                DiscrepanciaRecord obj = (DiscrepanciaRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<DiscrepanciaRecord>(obj.Oid));

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

            query = "SELECT D.*," +
                    "       I.\"NUMERO\" AS \"N_INFORME\"," +
                    "       A.\"REFERENCIA\" AS \"N_AUDITORIA\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string d = nHManager.Instance.GetSQLTable(typeof(DiscrepanciaRecord));
            string id = nHManager.Instance.GetSQLTable(typeof(InformeDiscrepanciaRecord));
            string a = nHManager.Instance.GetSQLTable(typeof(AuditoriaRecord));

            query = "   FROM   " + d + "   AS D" +
                    "   INNER JOIN " + id + " AS ID ON ID.\"OID\" = D.\"OID_INFORME\"" +
                    "   INNER JOIN " + a + " AS A ON A.\"OID\" = ID.\"OID_AUDITORIA\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.InformeDiscrepancia != null && conditions.InformeDiscrepancia.Oid > 0)
                query += " AND D.\"OID_INFORME\" = " + conditions.InformeDiscrepancia.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY D.\"NUMERO\"";

            if (lockTable) query += " FOR UPDATE OF D NOWAIT";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string d = nHManager.Instance.GetSQLTable(typeof(DiscrepanciaRecord));
            string i = nHManager.Instance.GetSQLTable(typeof(InformeDiscrepanciaRecord));
            string a = nHManager.Instance.GetSQLTable(typeof(AuditoriaRecord));

            string query;

            query = SELECT_FIELDS() +
                    " FROM " + d + " AS D" +
                    " LEFT JOIN " + i + " AS I ON D.\"OID_INFORME\" = I.\"OID\"" +
                    " LEFT JOIN " + a + " AS A ON I.\"OID_AUDITORIA\" = A.\"OID\"";

            if (oid > 0) query += " WHERE D.\"OID\" = " + oid.ToString();

            //if (lock_table) query += " FOR UPDATE OF A NOWAIT";

            return query;
        }

        public new static string SELECT(long oid) { return SELECT(oid, true); }

        #endregion

    }
}

