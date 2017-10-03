using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Common;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class HistoriaAuditoriaRecord : RecordBase
	{
		#region Attributes

		private long _oid_auditoria;
		private long _oid_empleado;
		private long _estado;
		private string _observaciones = string.Empty;
		private DateTime _fecha;
		private DateTime _hora;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAuditoria { get { return _oid_auditoria; } set { _oid_auditoria = value; } }
		public virtual long OidEmpleado { get { return _oid_empleado; } set { _oid_empleado = value; } }
		public virtual long Estado { get { return _estado; } set { _estado = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual DateTime Hora { get { return _hora; } set { _hora = value; } }

		#endregion
		
		#region Business Methods
		
		public HistoriaAuditoriaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_auditoria = Format.DataReader.GetInt64(source, "OID_AUDITORIA");
			_oid_empleado = Format.DataReader.GetInt64(source, "OID_EMPLEADO");
			_estado = Format.DataReader.GetInt64(source, "ESTADO");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_hora = Format.DataReader.GetDateTime(source, "HORA");

		}		
		public virtual void CopyValues(HistoriaAuditoriaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_auditoria = source.OidAuditoria;
			_oid_empleado = source.OidEmpleado;
			_estado = source.Estado;
			_observaciones = source.Observaciones;
			_fecha = source.Fecha;
			_hora = source.Hora;
		}
		
		#endregion	
	}

    [Serializable()]
	public class HistoriaAuditoriaBase 
	{	 
		#region Attributes
		
		private HistoriaAuditoriaRecord _record = new HistoriaAuditoriaRecord();
        
        private string _empleado = string.Empty;
		
		#endregion
		
		#region Properties
		
		public HistoriaAuditoriaRecord Record { get { return _record; } }

		public EEstado EStatus { get { return (EEstado)_record.Estado; } }
		public string StatusLabel { get { return Library.Common.EnumText<EEstado>.GetLabel(EStatus); } }
        public virtual string Empleado { get { return _empleado; } set { _empleado = value;} }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _empleado = Format.DataReader.GetString(source, "EMPLEADO");
		}		
		public void CopyValues(HistoriaAuditoria source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _empleado = source.Empleado;
		}
		public void CopyValues(HistoriaAuditoriaInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _empleado = source.Empleado;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class HistoriaAuditoria : BusinessBaseEx<HistoriaAuditoria>
	{	 
		#region Attributes
		
		protected HistoriaAuditoriaBase _base = new HistoriaAuditoriaBase();
		

		#endregion
		
		#region Properties
		
		public HistoriaAuditoriaBase Base { get { return _base; } }
		
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
		public virtual long OidEmpleado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidEmpleado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidEmpleado.Equals(value))
				{
					_base.Record.OidEmpleado = value;
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
		public virtual DateTime Hora
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Hora;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Hora.Equals(value))
				{
					_base.Record.Hora = value;
					PropertyHasChanged();
				}
			}
		}
	
        public virtual EstadoAuditoria EstadoAuditoria { get { return (EstadoAuditoria)Estado; } set { Estado = (long)value; } }
        public virtual string EstadoAuditoriaLabel { get { return EnumText<EstadoAuditoria>.GetLabel(EstadoAuditoria); } }
        public virtual string Empleado { get { return _base.Empleado; } set { _base.Empleado = value;} }
		
		
		#endregion
		
		#region Business Methods
		
		public virtual HistoriaAuditoria CloneAsNew()
		{
			HistoriaAuditoria clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = HistoriaAuditoria.OpenSession();
			HistoriaAuditoria.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(HistoriaAuditoriaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAuditoria = source.OidAuditoria;
			OidEmpleado = source.OidEmpleado;
			Estado = source.Estado;
			Observaciones = source.Observaciones;
			Fecha = source.Fecha;
			Hora = source.Hora;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAuditoria", 1));
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidEmpleado", 1));
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Estado", 1));
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

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public HistoriaAuditoria()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private HistoriaAuditoria(HistoriaAuditoria source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private HistoriaAuditoria(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static HistoriaAuditoria NewChild(Auditoria parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            HistoriaAuditoria obj = new HistoriaAuditoria();
            obj.OidAuditoria = parent.Oid;
            return obj;
        }

        public static HistoriaAuditoria NewChild(Auditoria parent, long oid_empleado, string observaciones,
            long estado)
        {
            HistoriaAuditoria obj = NewChild(parent);

            obj.OidEmpleado = oid_empleado;
            obj.Fecha = DateTime.Now;
            obj.Hora = DateTime.Now;
            obj.Observaciones = observaciones;
            obj.Estado = estado;

            return obj;
        }

        internal static HistoriaAuditoria GetChild(HistoriaAuditoria source)
        {
            return new HistoriaAuditoria(source);
        }

        internal static HistoriaAuditoria GetChild(IDataReader reader)
        {
            return new HistoriaAuditoria(reader);
        }

        public virtual HistoriaAuditoriaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new HistoriaAuditoriaInfo(this);
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

        /// <summary>
        /// No se debe utilizar esta función para guardar. Hace falta el padre.
        /// Utilizar Insert o Update en sustitución de Save.
        /// </summary>
        /// <returns></returns>
        public override HistoriaAuditoria Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(HistoriaAuditoria source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Auditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAuditoria = parent.Oid;
            OidEmpleado = OidEmpleado != 0 ? OidEmpleado : parent.OidAuditor;

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

        internal void Update(Auditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAuditoria = parent.Oid;
            OidEmpleado = OidEmpleado != 0 ? OidEmpleado : parent.OidAuditor;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                HistoriaAuditoriaRecord obj = parent.Session().Get<HistoriaAuditoriaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
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
                parent.Session().Delete(parent.Session().Get<HistoriaAuditoriaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT H.*," +
                    "       E.\"NOMBRE\" AS \"EMPLEADO\"";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string h = nHManager.Instance.GetSQLTable(typeof(HistoriaAuditoriaRecord));
            string e = nHManager.Instance.GetSQLTable(typeof(moleQule.Library.Store.EmployeeRecord));

            string query;

            query = SELECT_FIELDS() +
                    " FROM " + h + " AS H" +
                    " LEFT JOIN " + e + " AS E ON H.\"OID_EMPLEADO\" = E.\"OID\"";

            if (oid > 0) query += " WHERE H.\"OID\" = " + oid.ToString();

            //if (lock_table) query += " FOR UPDATE OF H NOWAIT";

            return query;
        }

        public new static string SELECT(long oid) { return Auditoria.SELECT(oid, true); }

        #endregion

    }
}

