using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class NotificacionInternaRecord : RecordBase
	{
		#region Attributes

		private long _oid_asociado;
		private long _tipo_asociado;
		private string _codigo = string.Empty;
		private long _serial;
		private long _numero;
		private string _comentarios = string.Empty;
		private string _asunto = string.Empty;
		private DateTime _fecha;
		private string _atencion = string.Empty;
		private string _copia = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAsociado { get { return _oid_asociado; } set { _oid_asociado = value; } }
		public virtual long TipoAsociado { get { return _tipo_asociado; } set { _tipo_asociado = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Comentarios { get { return _comentarios; } set { _comentarios = value; } }
		public virtual string Asunto { get { return _asunto; } set { _asunto = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual string Atencion { get { return _atencion; } set { _atencion = value; } }
		public virtual string Copia { get { return _copia; } set { _copia = value; } }

		#endregion
		
		#region Business Methods
		
		public NotificacionInternaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_asociado = Format.DataReader.GetInt64(source, "OID_ASOCIADO");
			_tipo_asociado = Format.DataReader.GetInt64(source, "TIPO_ASOCIADO");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_comentarios = Format.DataReader.GetString(source, "COMENTARIOS");
			_asunto = Format.DataReader.GetString(source, "ASUNTO");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_atencion = Format.DataReader.GetString(source, "ATENCION");
			_copia = Format.DataReader.GetString(source, "COPIA");

		}		
		public virtual void CopyValues(NotificacionInternaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_asociado = source.OidAsociado;
			_tipo_asociado = source.TipoAsociado;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_numero = source.Numero;
			_comentarios = source.Comentarios;
			_asunto = source.Asunto;
			_fecha = source.Fecha;
			_atencion = source.Atencion;
			_copia = source.Copia;
		}
		
		#endregion	
	}

    [Serializable()]
	public class NotificacionInternaBase 
	{	 
		#region Attributes
		
		private NotificacionInternaRecord _record = new NotificacionInternaRecord();
		
		#endregion
		
		#region Properties
		
		public NotificacionInternaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(NotificacionInterna source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(NotificacionInternaInfo source)
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
	public class NotificacionInterna : BusinessBaseEx<NotificacionInterna>
	{	 
		#region Attributes
		
		protected NotificacionInternaBase _base = new NotificacionInternaBase();
		

		#endregion
		
		#region Properties
		
		public NotificacionInternaBase Base { get { return _base; } }
		
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
		public virtual long OidAsociado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAsociado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidAsociado.Equals(value))
				{
					_base.Record.OidAsociado = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long TipoAsociado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.TipoAsociado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.TipoAsociado.Equals(value))
				{
					_base.Record.TipoAsociado = value;
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
		public virtual string Comentarios
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Comentarios;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Comentarios.Equals(value))
				{
					_base.Record.Comentarios = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Asunto
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Asunto;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Asunto.Equals(value))
				{
					_base.Record.Asunto = value;
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
		public virtual string Atencion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Atencion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Atencion.Equals(value))
				{
					_base.Record.Atencion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Copia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Copia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Copia.Equals(value))
				{
					_base.Record.Copia = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual NotificacionInterna CloneAsNew()
		{
			NotificacionInterna clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.GetNewCode();
			
			clon.SessionCode = NotificacionInterna.OpenSession();
			NotificacionInterna.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(NotificacionInternaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAsociado = source.OidAsociado;
			TipoAsociado = source.TipoAsociado;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Numero = source.Numero;
			Comentarios = source.Comentarios;
			Asunto = source.Asunto;
			Fecha = source.Fecha;
			Atencion = source.Atencion;
			Copia = source.Copia;
		}
		
		
        public virtual void GetNewCode()
        {
            Serial = SerialInfo.GetNext(typeof(NotificacionInterna));
            Codigo = Serial.ToString(Resources.Defaults.COMUNICADO_AUDITORIA_CODE_FORMAT);
        }
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAsociado", 1));


            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("TipoAsociado", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Numero", 1));
        }
		
		#endregion
		 
		#region Authorization Rules
		 
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
        public NotificacionInterna()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
            GetNewCode();
            Numero = Serial;
            Fecha = DateTime.Today;
        }

        private NotificacionInterna(NotificacionInterna source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private NotificacionInterna(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static NotificacionInterna NewChild(Auditoria parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            NotificacionInterna obj = new NotificacionInterna();
            obj.OidAsociado = parent.Oid;
            return obj;
        }

        public static NotificacionInterna NewChild(InformeDiscrepancia parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            NotificacionInterna obj = new NotificacionInterna();
            obj.OidAsociado = parent.Oid;
            return obj;
        }

        public static NotificacionInterna NewChild(InformeCorrector parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            NotificacionInterna obj = new NotificacionInterna();
            obj.OidAsociado = parent.Oid;
            return obj;
        }

        public static NotificacionInterna NewChild(InformeAmpliacion parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            NotificacionInterna obj = new NotificacionInterna();
            obj.OidAsociado = parent.Oid;
            return obj;
        }

        internal static NotificacionInterna GetChild(NotificacionInterna source)
        {
            return new NotificacionInterna(source);
        }

        internal static NotificacionInterna GetChild(IDataReader reader)
        {
            return new NotificacionInterna(reader);
        }

        public virtual NotificacionInternaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new NotificacionInternaInfo(this);
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
        public override NotificacionInterna Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }

        #endregion

        #region Child Data Access

        private void Fetch(NotificacionInterna source)
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

            OidAsociado = parent.Oid;
            GetNewCode();

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

            OidAsociado = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                NotificacionInternaRecord obj = parent.Session().Get<NotificacionInternaRecord>(Oid);
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
                parent.Session().Delete(parent.Session().Get<NotificacionInternaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }



        internal void Insert(InformeDiscrepancia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAsociado = parent.Oid;
            GetNewCode();

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

        internal void Update(InformeDiscrepancia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAsociado = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                NotificacionInternaRecord obj = parent.Session().Get<NotificacionInternaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
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
                parent.Session().Delete(parent.Session().Get<NotificacionInternaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }



        internal void Insert(InformeCorrector parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAsociado = parent.Oid;
            GetNewCode();

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

        internal void Update(InformeCorrector parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAsociado = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                NotificacionInternaRecord obj = parent.Session().Get<NotificacionInternaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(InformeCorrector parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<NotificacionInternaRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }



        internal void Insert(InformeAmpliacion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAsociado = parent.Oid;
            GetNewCode();

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

        internal void Update(InformeAmpliacion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAsociado = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                NotificacionInternaRecord obj = parent.Session().Get<NotificacionInternaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(InformeAmpliacion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<NotificacionInternaRecord>(Oid));
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

            query = "SELECT NI.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ni = nHManager.Instance.GetSQLTable(typeof(NotificacionInternaRecord));

            query = "   FROM   " + ni + "   AS NI";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Auditoria != null && conditions.Auditoria.Oid > 0)
                query += " AND NI.\"OID_ASOCIADO\" = " + conditions.Auditoria.Oid;
            if (conditions.InformeAmpliacion != null && conditions.InformeAmpliacion.Oid > 0)
                query += " AND NI.\"OID_ASOCIADO\" = " + conditions.InformeAmpliacion.Oid;
            if (conditions.InformeCorrector != null && conditions.InformeCorrector.Oid > 0)
                query += " AND NI.\"OID_ASOCIADO\" = " + conditions.InformeCorrector.Oid;
            if (conditions.InformeDiscrepancia != null && conditions.InformeDiscrepancia.Oid > 0)
                query += " AND NI.\"OID_ASOCIADO\" = " + conditions.InformeDiscrepancia.Oid;
            if (conditions.TipoNotificacionAsociado != TipoNotificacionAsociado.Todos)
                query += " AND NI.\"TIPO_ASOCIADO\" = " + (long)conditions.TipoNotificacionAsociado;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY NI.\"FECHA\"";

            if (lockTable) query += " FOR UPDATE OF NI NOWAIT";

            return query;
        }

        #endregion
	
	}
}

