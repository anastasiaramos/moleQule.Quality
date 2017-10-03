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
	public class CriterioRecord : RecordBase
	{
		#region Attributes

		private long _oid_tipo_auditoria;
		private string _nombre = string.Empty;
		private long _numero;
  
		#endregion
		
		#region Properties
		
				public virtual long OidTipoAuditoria { get { return _oid_tipo_auditoria; } set { _oid_tipo_auditoria = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }

		#endregion
		
		#region Business Methods
		
		public CriterioRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_tipo_auditoria = Format.DataReader.GetInt64(source, "OID_TIPO_AUDITORIA");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");

		}		
		public virtual void CopyValues(CriterioRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_tipo_auditoria = source.OidTipoAuditoria;
			_nombre = source.Nombre;
			_numero = source.Numero;
		}
		
		#endregion	
	}

    [Serializable()]
	public class CriterioBase 
	{	 
		#region Attributes
		
		private CriterioRecord _record = new CriterioRecord();
		
		#endregion
		
		#region Properties
		
		public CriterioRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Criterio source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(CriterioInfo source)
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
	public class Criterio : BusinessBaseEx<Criterio>
	{	 
		#region Attributes
		
		protected CriterioBase _base = new CriterioBase();
		

		#endregion
		
		#region Properties
		
		public CriterioBase Base { get { return _base; } }
		
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Criterio CloneAsNew()
		{
			Criterio clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Criterio.OpenSession();
			Criterio.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(CriterioInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidTipoAuditoria = source.OidTipoAuditoria;
			Nombre = source.Nombre;
			Numero = source.Numero;
		}
		
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        public virtual void CopyValues(Criterio source, bool oid)
        {
            if (source == null) return;
            if (oid)
            {
                Oid = source.Oid;
                OidTipoAuditoria = source.OidTipoAuditoria;
            }
            Nombre = source.Nombre;
            Numero = source.Numero;

        }
			
		#endregion
		 
	    #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidTipoAuditoria", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Nombre");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Numero", 1));
        }
		
		#endregion
		 
		#region Authorization Rules
		 
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
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public Criterio() 
		{ 
			MarkAsChild();
			Random r = new Random();
			Oid = (long)r.Next();
			//Rellenar si hay más campos que deban ser inicializados aquí
		}	
		
		private Criterio(Criterio source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private Criterio(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static Criterio NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Criterio();
		}
		
		public static Criterio NewChild(TipoAuditoria parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Criterio obj = new Criterio();
			obj.OidTipoAuditoria = parent.Oid;
			
			return obj;
		}
		
		
		internal static Criterio GetChild(Criterio source)
		{
			return new Criterio(source);
		}
		
		internal static Criterio GetChild(IDataReader reader)
		{
			return new Criterio(reader);
		}
		
		public virtual CriterioInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new CriterioInfo(this);
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
		public override Criterio Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(Criterio source)
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

            OidTipoAuditoria = parent.Oid;

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
				CriterioRecord obj = Session().Get<CriterioRecord>(Oid);
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
				Session().Delete(Session().Get<CriterioRecord>(Oid));
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

            query = "SELECT C.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string c = nHManager.Instance.GetSQLTable(typeof(CriterioRecord));

            query = "   FROM   " + c + "   AS C";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.TipoAuditoria != null && conditions.TipoAuditoria.Oid > 0)
                query += " AND C.\"OID_TIPO_AUDITORIA\" = " + conditions.TipoAuditoria.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF C NOWAIT";

            return query;
        }


        #endregion
	
	}
}

