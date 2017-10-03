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
	public class AmpliacionRecord : RecordBase
	{
		#region Attributes

		private long _oid_informe_ampliacion;
		private long _oid_discrepancia;
		private DateTime _fecha_debida;
		private DateTime _fecha_cierre;
		private string _observaciones = string.Empty;
		private string _codigo = string.Empty;
		private long _serial;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInformeAmpliacion { get { return _oid_informe_ampliacion; } set { _oid_informe_ampliacion = value; } }
		public virtual long OidDiscrepancia { get { return _oid_discrepancia; } set { _oid_discrepancia = value; } }
		public virtual DateTime FechaDebida { get { return _fecha_debida; } set { _fecha_debida = value; } }
		public virtual DateTime FechaCierre { get { return _fecha_cierre; } set { _fecha_cierre = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }

		#endregion
		
		#region Business Methods
		
		public AmpliacionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_informe_ampliacion = Format.DataReader.GetInt64(source, "OID_INFORME_AMPLIACION");
			_oid_discrepancia = Format.DataReader.GetInt64(source, "OID_DISCREPANCIA");
			_fecha_debida = Format.DataReader.GetDateTime(source, "FECHA_DEBIDA");
			_fecha_cierre = Format.DataReader.GetDateTime(source, "FECHA_CIERRE");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");

		}		
		public virtual void CopyValues(AmpliacionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_informe_ampliacion = source.OidInformeAmpliacion;
			_oid_discrepancia = source.OidDiscrepancia;
			_fecha_debida = source.FechaDebida;
			_fecha_cierre = source.FechaCierre;
			_observaciones = source.Observaciones;
			_codigo = source.Codigo;
			_serial = source.Serial;
		}
		
		#endregion	
	}

    [Serializable()]
	public class AmpliacionBase 
	{	 
		#region Attributes
		
		private AmpliacionRecord _record = new AmpliacionRecord();
		
		#endregion
		
		#region Properties
		
		public AmpliacionRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Ampliacion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(AmpliacionInfo source)
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
	public class Ampliacion : BusinessBaseEx<Ampliacion>
	{	 
		#region Attributes
		
		protected AmpliacionBase _base = new AmpliacionBase();
		

		#endregion
		
		#region Properties
		
		public AmpliacionBase Base { get { return _base; } }
		
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
		public virtual long OidInformeAmpliacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInformeAmpliacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInformeAmpliacion.Equals(value))
				{
					_base.Record.OidInformeAmpliacion = value;
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
	
		
		
		#endregion
		
		#region Business Methods
				
		protected virtual void CopyFrom(AmpliacionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInformeAmpliacion = source.OidInformeAmpliacion;
			OidDiscrepancia = source.OidDiscrepancia;
			FechaDebida = source.FechaDebida;
			FechaCierre = source.FechaCierre;
			Observaciones = source.Observaciones;
			Codigo = source.Codigo;
			Serial = source.Serial;
		}
		
		
        /// <summary>
        /// Devuelve el siguiente código de PlanAnual.
        /// </summary>
        /// <returns></returns>
        public virtual string GetNewCode(InformeAmpliacion parent)
        {
            Int64 lastcode = Ampliacion.GetNewSerial(parent);

            // Devolvemos el siguiente codigo de PlanAnual 
            return lastcode.ToString(Resources.Defaults.AMPLIACION_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de PlanAnual
        /// </summary>
        /// <returns></returns>
        private static Int64 GetNewSerial(InformeAmpliacion parent)
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<AmpliacionInfo> Ampliaciones =
                AmpliacionList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (Ampliaciones.Count > 0)
                lastcode = Ampliaciones[Ampliaciones.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.AMPLIACION_CODE_FORMAT);

            foreach (Ampliacion item in parent.Ampliaciones)
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
                                    new CommonRules.MinValueRuleArgs<long>("OidInformeAmpliacion", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidDiscrepancia", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Codigo");
        }
		
		#endregion
		 
		#region Authorization Rules
		 
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.AMPLIACION);
		}
		
		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.AMPLIACION);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.AMPLIACION);
		}
		
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.AMPLIACION);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public Ampliacion() 
		{ 
			MarkAsChild();
			Random r = new Random();
			Oid = (long)r.Next();
            Codigo = (0).ToString(Resources.Defaults.AMPLIACION_CODE_FORMAT);
		}	
		
		private Ampliacion(Ampliacion source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private Ampliacion(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static Ampliacion NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Ampliacion();
		}
		
		public static Ampliacion NewChild(Discrepancia parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Ampliacion obj = new Ampliacion();
			obj.OidDiscrepancia = parent.Oid;
			
			return obj;
		}
		
		public static Ampliacion NewChild(InformeAmpliacion parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Ampliacion obj = new Ampliacion();
			obj.OidInformeAmpliacion = parent.Oid;
			
			return obj;
		}
		
		
		internal static Ampliacion GetChild(Ampliacion source)
		{
			return new Ampliacion(source);
		}
		
		internal static Ampliacion GetChild(IDataReader reader)
		{
			return new Ampliacion(reader);
		}
		
		public virtual AmpliacionInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new AmpliacionInfo(this);
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
		public override Ampliacion Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(Ampliacion source)
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
				AmpliacionRecord obj = Session().Get<AmpliacionRecord>(Oid);
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
				Session().Delete(Session().Get<AmpliacionRecord>(Oid));
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

            OidInformeAmpliacion = parent.Oid;
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

		internal void Update(InformeAmpliacion parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				AmpliacionRecord obj = Session().Get<AmpliacionRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
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
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<AmpliacionRecord>(Oid));
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

            query = "SELECT A.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string a = nHManager.Instance.GetSQLTable(typeof(AmpliacionRecord));

            query = "   FROM   " + a + "   AS A";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Discrepancia != null && conditions.Discrepancia.Oid > 0)
                query += " AND A.\"OID_DISCREPANCIA\" = " + conditions.Discrepancia.Oid;
            if (conditions.InformeAmpliacion != null && conditions.InformeAmpliacion.Oid > 0)
                query += " AND A.\"OID_INFORME_AMPLIACION\" = " + conditions.InformeAmpliacion.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY \"CODIGO\"";

            if (lockTable) query += " FOR UPDATE OF A NOWAIT";

            return query;
        }


        #endregion
	
	}
}

