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
	public class CuestionAuditoriaRecord : RecordBase
	{
		#region Attributes

		private long _oid_auditoria;
		private long _oid_cuestion;
		private long _numero;
		private bool _aceptado = false;
		private string _observaciones = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAuditoria { get { return _oid_auditoria; } set { _oid_auditoria = value; } }
		public virtual long OidCuestion { get { return _oid_cuestion; } set { _oid_cuestion = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual bool Aceptado { get { return _aceptado; } set { _aceptado = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

		#endregion
		
		#region Business Methods
		
		public CuestionAuditoriaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_auditoria = Format.DataReader.GetInt64(source, "OID_AUDITORIA");
			_oid_cuestion = Format.DataReader.GetInt64(source, "OID_CUESTION");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_aceptado = Format.DataReader.GetBool(source, "ACEPTADO");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");

		}		
		public virtual void CopyValues(CuestionAuditoriaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_auditoria = source.OidAuditoria;
			_oid_cuestion = source.OidCuestion;
			_numero = source.Numero;
			_aceptado = source.Aceptado;
			_observaciones = source.Observaciones;
		}
		
		#endregion	
	}

    [Serializable()]
	public class CuestionAuditoriaBase 
	{	 
		#region Attributes
		
		private CuestionAuditoriaRecord _record = new CuestionAuditoriaRecord();
		
		#endregion
		
		#region Properties
		
		public CuestionAuditoriaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(CuestionAuditoria source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(CuestionAuditoriaInfo source)
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
	public class CuestionAuditoria : BusinessBaseEx<CuestionAuditoria>
	{	 
		#region Attributes
		
		protected CuestionAuditoriaBase _base = new CuestionAuditoriaBase();
		

		#endregion
		
		#region Properties
		
		public CuestionAuditoriaBase Base { get { return _base; } }
		
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
		public virtual bool Aceptado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Aceptado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Aceptado.Equals(value))
				{
					_base.Record.Aceptado = value;
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual CuestionAuditoria CloneAsNew()
		{
			CuestionAuditoria clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = CuestionAuditoria.OpenSession();
			CuestionAuditoria.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(CuestionAuditoriaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAuditoria = source.OidAuditoria;
			OidCuestion = source.OidCuestion;
			Numero = source.Numero;
			Aceptado = source.Aceptado;
			Observaciones = source.Observaciones;
		}
		
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAuditoria", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidCuestion", 1));

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
		public CuestionAuditoria() 
		{ 
			MarkAsChild();
			Random r = new Random();
			Oid = (long)r.Next();
			//Rellenar si hay más campos que deban ser inicializados aquí
		}	
		
		private CuestionAuditoria(CuestionAuditoria source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private CuestionAuditoria(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static CuestionAuditoria NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new CuestionAuditoria();
		}
		
		public static CuestionAuditoria NewChild(Auditoria parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CuestionAuditoria obj = new CuestionAuditoria();
			obj.OidAuditoria = parent.Oid;
			
			return obj;
		}
		
		public static CuestionAuditoria NewChild(Cuestion parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CuestionAuditoria obj = new CuestionAuditoria();
			obj.OidCuestion = parent.Oid;
			
			return obj;
		}
		
		
		internal static CuestionAuditoria GetChild(CuestionAuditoria source)
		{
			return new CuestionAuditoria(source);
		}
		
		internal static CuestionAuditoria GetChild(IDataReader reader)
		{
			return new CuestionAuditoria(reader);
		}
		
		public virtual CuestionAuditoriaInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new CuestionAuditoriaInfo(this);
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
		public override CuestionAuditoria Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(CuestionAuditoria source)
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
			
			try
			{
                OidAuditoria = parent.Oid;
                long oid_old = this.Oid;
				parent.Session().Save(this.Base.Record);

                foreach (InformeDiscrepancia informe in parent.Informes)
                {
                    foreach (Discrepancia disc in informe.Discrepancias)
                    {
                        if (disc.OidCuestion == oid_old)
                            disc.OidCuestion = this.Oid;
                    }
                }
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
			
			
			try
			{
				SessionCode = parent.SessionCode;
				CuestionAuditoriaRecord obj = Session().Get<CuestionAuditoriaRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
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
				Session().Delete(Session().Get<CuestionAuditoriaRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		
			MarkNew(); 
		}
		
		internal void Insert(Cuestion parent)
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

		internal void Update(Cuestion parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				CuestionAuditoriaRecord obj = Session().Get<CuestionAuditoriaRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void DeleteSelf(Cuestion parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<CuestionAuditoriaRecord>(Oid));
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

            query = "SELECT CA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string ca = nHManager.Instance.GetSQLTable(typeof(CuestionAuditoriaRecord));

            query = "   FROM   " + ca + "   AS CA";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Auditoria != null && conditions.Auditoria.Oid > 0)
                query += " AND CA.\"OID_AUDITORIA\" = " + conditions.Auditoria.Oid;
            if (conditions.Cuestion != null && conditions.Cuestion.Oid > 0)
                query += " AND CA.\"OID_CUESTION\" = " + conditions.Cuestion.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY \"NUMERO\"";

            if (lockTable) query += " FOR UPDATE OF CA NOWAIT";

            return query;
        }


        #endregion
	
	}
}

