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
	public class Auditoria_AreaRecord : RecordBase
	{
		#region Attributes

		private long _oid_auditoria;
		private long _oid_area;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAuditoria { get { return _oid_auditoria; } set { _oid_auditoria = value; } }
		public virtual long OidArea { get { return _oid_area; } set { _oid_area = value; } }

		#endregion
		
		#region Business Methods
		
		public Auditoria_AreaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_auditoria = Format.DataReader.GetInt64(source, "OID_AUDITORIA");
			_oid_area = Format.DataReader.GetInt64(source, "OID_AREA");

		}		
		public virtual void CopyValues(Auditoria_AreaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_auditoria = source.OidAuditoria;
			_oid_area = source.OidArea;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Auditoria_AreaBase 
	{	 
		#region Attributes
		
		private Auditoria_AreaRecord _record = new Auditoria_AreaRecord();
		
		#endregion
		
		#region Properties
		
		public Auditoria_AreaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Auditoria_Area source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Auditoria_AreaInfo source)
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
	public class Auditoria_Area : BusinessBaseEx<Auditoria_Area>
	{	 
		#region Attributes
		
		protected Auditoria_AreaBase _base = new Auditoria_AreaBase();
		

		#endregion
		
		#region Properties
		
		public Auditoria_AreaBase Base { get { return _base; } }
		
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
		public virtual long OidArea
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidArea;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidArea.Equals(value))
				{
					_base.Record.OidArea = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Auditoria_Area CloneAsNew()
		{
			Auditoria_Area clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Auditoria_Area.OpenSession();
			Auditoria_Area.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Auditoria_AreaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAuditoria = source.OidAuditoria;
			OidArea = source.OidArea;
		}
		
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAuditoria", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidArea", 1));
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
		public Auditoria_Area() 
		{ 
			MarkAsChild();
			Random r = new Random();
			Oid = (long)r.Next();
			//Rellenar si hay más campos que deban ser inicializados aquí
		}	
		
		private Auditoria_Area(Auditoria_Area source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private Auditoria_Area(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static Auditoria_Area NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Auditoria_Area();
		}
		
		public static Auditoria_Area NewChild(TipoAuditoria parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Auditoria_Area obj = new Auditoria_Area();
			obj.OidAuditoria = parent.Oid;
			
			return obj;
		}
		
		
		internal static Auditoria_Area GetChild(Auditoria_Area source)
		{
			return new Auditoria_Area(source);
		}
		
		internal static Auditoria_Area GetChild(IDataReader reader)
		{
			return new Auditoria_Area(reader);
		}
		
		public virtual Auditoria_AreaInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Auditoria_AreaInfo(this);
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
		public override Auditoria_Area Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(Auditoria_Area source)
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
            OidAuditoria = parent.Oid;

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
            OidAuditoria = parent.Oid;
			
			try
			{
				SessionCode = parent.SessionCode;
				Auditoria_AreaRecord obj = Session().Get<Auditoria_AreaRecord>(Oid);
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
				Session().Delete(Session().Get<Auditoria_AreaRecord>(Oid));
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

            query = "SELECT AA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string aa = nHManager.Instance.GetSQLTable(typeof(Auditoria_AreaRecord));

            query = "   FROM   " + aa + "   AS AA";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Auditoria != null && conditions.Auditoria.Oid > 0)
                query += " AND AA.\"OID_AUDITORIA\" = " + conditions.Auditoria.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF AA NOWAIT";

            return query;
        }


        #endregion
	
	}
}

