using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class AccionCorrectoraRecord : RecordBase
	{
		#region Attributes

		private long _oid_informe_corrector;
		private long _oid_discrepancia;
		private string _texto = string.Empty;
		private long _numero;
		private string _codigo = string.Empty;
		private long _serial;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInformeCorrector { get { return _oid_informe_corrector; } set { _oid_informe_corrector = value; } }
		public virtual long OidDiscrepancia { get { return _oid_discrepancia; } set { _oid_discrepancia = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }

		#endregion
		
		#region Business Methods
		
		public AccionCorrectoraRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_informe_corrector = Format.DataReader.GetInt64(source, "OID_INFORME_CORRECTOR");
			_oid_discrepancia = Format.DataReader.GetInt64(source, "OID_DISCREPANCIA");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");

		}		
		public virtual void CopyValues(AccionCorrectoraRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_informe_corrector = source.OidInformeCorrector;
			_oid_discrepancia = source.OidDiscrepancia;
			_texto = source.Texto;
			_numero = source.Numero;
			_codigo = source.Codigo;
			_serial = source.Serial;
		}
		
		#endregion	
	}

    [Serializable()]
	public class AccionCorrectoraBase 
	{	 
		#region Attributes
		
		private AccionCorrectoraRecord _record = new AccionCorrectoraRecord();
		
		#endregion
		
		#region Properties
		
		public AccionCorrectoraRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(AccionCorrectora source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(AccionCorrectoraInfo source)
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
	public class AccionCorrectora : BusinessBaseEx<AccionCorrectora>
	{	 
		#region Attributes
		
		protected AccionCorrectoraBase _base = new AccionCorrectoraBase();
		

		#endregion
		
		#region Properties
		
		public AccionCorrectoraBase Base { get { return _base; } }
		
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
		public virtual long OidInformeCorrector
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInformeCorrector;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInformeCorrector.Equals(value))
				{
					_base.Record.OidInformeCorrector = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidDiscrepancia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidDiscrepancia;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidDiscrepancia.Equals(value))
				{
					_base.Record.OidDiscrepancia = value;
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
	
		
		
		#endregion
		
		#region Business Methods
				
		protected virtual void CopyFrom(AccionCorrectoraInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInformeCorrector = source.OidInformeCorrector;
			OidDiscrepancia = source.OidDiscrepancia;
			Texto = source.Texto;
			Numero = source.Numero;
			Codigo = source.Codigo;
			Serial = source.Serial;
		}
			
        /// <summary>
        /// Devuelve el siguiente código de PlanAnual.
        /// </summary>
        /// <returns></returns>
        public static string GetNewCode(InformeCorrector parent)
        {
            Int64 lastcode = AccionCorrectora.GetNewSerial(parent);

            // Devolvemos el siguiente codigo de PlanAnual 
            return lastcode.ToString(Resources.Defaults.ACCION_CORRECTORA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de PlanAnual
        /// </summary>
        /// <returns></returns>
        private static Int64 GetNewSerial(InformeCorrector parent)
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<AccionCorrectoraInfo> Acciones =
                AccionCorrectoraList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (Acciones.Count > 0)
                lastcode = Acciones[Acciones.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.ACCION_CORRECTORA_CODE_FORMAT);

            foreach (AccionCorrectora item in parent.Acciones)
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
                                    new CommonRules.MinValueRuleArgs<long>("OidInformeCorrector", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidDiscrepancia", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Texto");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Numero", 1));
        }
		
		#endregion
		 
		#region Authorization Rules
		 
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
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public AccionCorrectora() 
		{ 
			MarkAsChild();
			Random r = new Random();
            Oid = (long)r.Next();
            Codigo = (0).ToString(Resources.Defaults.ACCION_CORRECTORA_CODE_FORMAT);

		}	
		
		private AccionCorrectora(AccionCorrectora source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private AccionCorrectora(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static AccionCorrectora NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new AccionCorrectora();
		}
		
		public static AccionCorrectora NewChild(Discrepancia parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			AccionCorrectora obj = new AccionCorrectora();
			obj.OidDiscrepancia = parent.Oid;
			
			return obj;
		}
		
		public static AccionCorrectora NewChild(InformeCorrector parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			AccionCorrectora obj = new AccionCorrectora();
			obj.OidInformeCorrector = parent.Oid;
			
			return obj;
		}
		
		
		internal static AccionCorrectora GetChild(AccionCorrectora source)
		{
			return new AccionCorrectora(source);
		}
		
		internal static AccionCorrectora GetChild(IDataReader reader)
		{
			return new AccionCorrectora(reader);
		}
		
		public virtual AccionCorrectoraInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new AccionCorrectoraInfo(this);
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
		public override AccionCorrectora Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(AccionCorrectora source)
		{
			_base.CopyValues(source);
			MarkOld();
		}
		
		private void Fetch(IDataReader reader)
		{
			_base.CopyValues(reader);
			MarkOld();
		}
		
		internal void Insert(Discrepancia parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

            OidDiscrepancia = parent.Oid;

			try
			{	
				parent.Session().Save(this.Base.Record);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void Update(Discrepancia parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				AccionCorrectoraRecord obj = Session().Get<AccionCorrectoraRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void DeleteSelf(Discrepancia parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<AccionCorrectoraRecord>(Oid));
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

            OidInformeCorrector = parent.Oid;
            Codigo = GetNewCode(parent);
            Serial = GetNewSerial(parent);

			try
			{	
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
			
			
			try
			{
				SessionCode = parent.SessionCode;
				AccionCorrectoraRecord obj = Session().Get<AccionCorrectoraRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
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
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<AccionCorrectoraRecord>(Oid));
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

            query = "SELECT AC.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ac = nHManager.Instance.GetSQLTable(typeof(AccionCorrectoraRecord));

            query = "   FROM   " + ac + "   AS AC";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Discrepancia != null && conditions.Discrepancia.Oid > 0)
                query += " AND AC.\"OID_DISCREPANCIA\" = " + conditions.Discrepancia.Oid;
            if (conditions.InformeCorrector != null && conditions.InformeCorrector.Oid > 0)
                query += " AND AC.\"OID_INFORME_CORRECTOR\" = " + conditions.InformeCorrector.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY \"NUMERO\"";

            if (lockTable) query += " FOR UPDATE OF AC NOWAIT";

            return query;
        }


        #endregion
	
	}
}

