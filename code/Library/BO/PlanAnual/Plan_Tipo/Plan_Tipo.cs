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

using moleQule.Library.Quality;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class Plan_TipoRecord : RecordBase
	{
		#region Attributes

		private long _oid_plan;
		private long _oid_tipo;
		private long _orden;
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
  
		#endregion
		
		#region Properties
		
				public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
		public virtual long OidTipo { get { return _oid_tipo; } set { _oid_tipo = value; } }
		public virtual long Orden { get { return _orden; } set { _orden = value; } }
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

		#endregion
		
		#region Business Methods
		
		public Plan_TipoRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
			_oid_tipo = Format.DataReader.GetInt64(source, "OID_TIPO");
			_orden = Format.DataReader.GetInt64(source, "ORDEN");
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

		}		
		public virtual void CopyValues(Plan_TipoRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_plan = source.OidPlan;
			_oid_tipo = source.OidTipo;
			_orden = source.Orden;
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
		}
		
		#endregion	
	}

    [Serializable()]
	public class Plan_TipoBase 
	{	 
		#region Attributes
		
		private Plan_TipoRecord _record = new Plan_TipoRecord();

        protected long _oid_clase;
		
		#endregion
		
		#region Properties
		
		public Plan_TipoRecord Record { get { return _record; } }

        public virtual long OidClase { get { return _oid_clase; } set { _oid_clase = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _oid_clase = Format.DataReader.GetInt64(source, "OID_CLASE");
		}		
		public void CopyValues(Plan_Tipo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _oid_clase = source.OidClase;
		}
		public void CopyValues(Plan_TipoInfo source)
		{
			if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _oid_clase = source.OidClase;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Plan_Tipo : BusinessBaseEx<Plan_Tipo>
	{	 
		#region Attributes
		
		protected Plan_TipoBase _base = new Plan_TipoBase();
		

		#endregion
		
		#region Properties
		
		public Plan_TipoBase Base { get { return _base; } }
		
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
		public virtual long OidTipo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidTipo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidTipo.Equals(value))
				{
					_base.Record.OidTipo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Orden
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Orden;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Orden.Equals(value))
				{
					_base.Record.Orden = value;
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

        public virtual long OidClase { get { return _base.OidClase; } set { _base.OidClase = value; } }
		
		#endregion
		
		#region Business Methods
		
		public virtual Plan_Tipo CloneAsNew()
		{
			Plan_Tipo clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Plan_Tipo.OpenSession();
			Plan_Tipo.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Plan_TipoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPlan = source.OidPlan;
			OidTipo = source.OidTipo;
			Orden = source.Orden;
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
		}
		
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidTipo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidClase", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Orden", 1));
        }
		
		#endregion
		 
		#region Authorization Rules
		 
		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		
		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		
		public static bool CanEditObject()
		{
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PLAN_ANUAL);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public Plan_Tipo() 
		{ 
			MarkAsChild();
			Random r = new Random();
			Oid = (long)r.Next();
			//Rellenar si hay más campos que deban ser inicializados aquí
		}	
		
		private Plan_Tipo(Plan_Tipo source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private Plan_Tipo(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static Plan_Tipo NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Plan_Tipo();
		}
		
		public static Plan_Tipo NewChild(TipoAuditoria parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Plan_Tipo obj = new Plan_Tipo();
			obj.OidTipo = parent.Oid;
			
			return obj;
		}
		
		public static Plan_Tipo NewChild(PlanAnual parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Plan_Tipo obj = new Plan_Tipo();
			obj.OidPlan = parent.Oid;
			
			return obj;
		}
		
		
		internal static Plan_Tipo GetChild(Plan_Tipo source)
		{
			return new Plan_Tipo(source);
		}
		
		internal static Plan_Tipo GetChild(IDataReader reader)
		{
			return new Plan_Tipo(reader);
		}
		
		public virtual Plan_TipoInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Plan_TipoInfo(this);
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
		public override Plan_Tipo Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(Plan_Tipo source)
		{
			_base.CopyValues(source);
			MarkOld();
		}
		
		private void Fetch(IDataReader reader)
		{
			_base.CopyValues(reader);
			MarkOld();
		}
		
		internal void Insert(TipoAuditoria parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
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

		internal void Update(TipoAuditoria parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				Plan_TipoRecord obj = Session().Get<Plan_TipoRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
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
				Session().Delete(Session().Get<Plan_TipoRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		
			MarkNew(); 
		}
		
		internal void Insert(PlanAnual parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{
                OidPlan = parent.Oid;
				parent.Session().Save(this.Base.Record);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void Update(PlanAnual parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				Plan_TipoRecord obj = Session().Get<Plan_TipoRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void DeleteSelf(PlanAnual parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<Plan_TipoRecord>(Oid));
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

            query = "SELECT PT.*" + 
                    "   ,TA.\"OID_CLASE_AUDITORIA\" AS \"OID_CLASE\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pt = nHManager.Instance.GetSQLTable(typeof(Plan_TipoRecord));
            string ta = nHManager.Instance.GetSQLTable(typeof(TipoAuditoriaRecord));

            query = "   FROM   " + pt + "   AS PT" +
                    "   INNER JOIN " + ta + " AS TA ON TA.\"OID\" = PT.\"OID_TIPO\"";

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

            if (lockTable) query += " FOR UPDATE OF PT NOWAIT";

            return query;
        }

        #endregion
	
	}
}

