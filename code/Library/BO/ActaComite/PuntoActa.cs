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
	public class PuntoActaRecord : RecordBase
	{
		#region Attributes

		private long _oid_acta;
		private string _codigo = string.Empty;
		private long _serial;
		private string _texto = string.Empty;
		private long _numero;
  
		#endregion
		
		#region Properties
		
				public virtual long OidActa { get { return _oid_acta; } set { _oid_acta = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }

		#endregion
		
		#region Business Methods
		
		public PuntoActaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_acta = Format.DataReader.GetInt64(source, "OID_ACTA");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");

		}		
		public virtual void CopyValues(PuntoActaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_acta = source.OidActa;
			_codigo = source.Codigo;
			_serial = source.Serial;
			_texto = source.Texto;
			_numero = source.Numero;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PuntoActaBase 
	{	 
		#region Attributes
		
		private PuntoActaRecord _record = new PuntoActaRecord();
		
		#endregion
		
		#region Properties
		
		public PuntoActaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(PuntoActa source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(PuntoActaInfo source)
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
	public class PuntoActa : BusinessBaseEx<PuntoActa>
	{	 
		#region Attributes
		
		protected PuntoActaBase _base = new PuntoActaBase();
		

		#endregion
		
		#region Properties
		
		public PuntoActaBase Base { get { return _base; } }
		
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
		public virtual long OidActa
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidActa;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidActa.Equals(value))
				{
					_base.Record.OidActa = value;
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
	
		
		
		#endregion
		
		#region Business Methods
		
		protected virtual void CopyFrom(PuntoActaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidActa = source.OidActa;
			Codigo = source.Codigo;
			Serial = source.Serial;
			Texto = source.Texto;
			Numero = source.Numero;
		}
		
		

        /// <summary>
        /// Devuelve el siguiente código de ActaComite.
        /// </summary>
        /// <returns></returns>
        public static string GetNewCode(ActaComite parent)
        {
            Int64 lastcode = PuntoActa.GetNewSerial(parent);

            // Devolvemos el siguiente codigo de ActaComite 
            return lastcode.ToString(Resources.Defaults.PUNTO_ACTA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de ActaComite
        /// </summary>
        /// <returns></returns>
        private static Int64 GetNewSerial(ActaComite parent)
        {
            // Obtenemos la lista de clientes ordenados por serial
            SortedBindingList<PuntoActaInfo> Puntos =
                PuntoActaList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último serial de servicio
            Int64 lastcode;

            if (Puntos.Count > 0)
                lastcode = Puntos[Puntos.Count - 1].Serial;
            else
                lastcode = Convert.ToInt64(Resources.Defaults.PUNTO_ACTA_CODE_FORMAT);

            foreach (PuntoActa item in parent.PuntosActas)
            {
                if (lastcode < item.Serial)
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
                                    new CommonRules.MinValueRuleArgs<long>("OidActa", 1));

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
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		
		public static bool CanGetObject()
		{
			return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		
		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ACTA_COMITE);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public PuntoActa() 
		{ 
			MarkAsChild();
			Random r = new Random();
			Oid = (long)r.Next();
            Codigo = (0).ToString(Resources.Defaults.PUNTO_ACTA_CODE_FORMAT);		
		}	
		
		private PuntoActa(PuntoActa source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private PuntoActa(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static PuntoActa NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new PuntoActa();
		}
		
		public static PuntoActa NewChild(ActaComite parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			PuntoActa obj = new PuntoActa();
			obj.OidActa = parent.Oid;
			
			return obj;
		}
		
		
		internal static PuntoActa GetChild(PuntoActa source)
		{
			return new PuntoActa(source);
		}
		
		internal static PuntoActa GetChild(IDataReader reader)
		{
			return new PuntoActa(reader);
		}
		
		public virtual PuntoActaInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new PuntoActaInfo(this);
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
		public override PuntoActa Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(PuntoActa source)
		{
			_base.CopyValues(source);
			MarkOld();
		}
		
		private void Fetch(IDataReader reader)
		{
			_base.CopyValues(reader);
			MarkOld();
		}
		
		internal void Insert(ActaComite parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

            OidActa = parent.Oid;
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

		internal void Update(ActaComite parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				PuntoActaRecord obj = Session().Get<PuntoActaRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void DeleteSelf(ActaComite parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;
			
			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<PuntoActaRecord>(Oid));
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

            query = "SELECT PA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pa = nHManager.Instance.GetSQLTable(typeof(PuntoActaRecord));

            query = "   FROM   " + pa + "   AS PA";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.ActaComite != null && conditions.ActaComite.Oid > 0)
                query += " AND PA.\"OID_ACTA\" = " + conditions.ActaComite.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF PA NOWAIT";

            return query;
        }


        #endregion
	
	}
}

