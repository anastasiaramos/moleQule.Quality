using System;
using System.ComponentModel;
using System.Collections.Generic;
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
	public class CuestionRecord : RecordBase
	{
		#region Attributes

		private long _oid_tipo_auditoria;
		private long _numero;
		private string _texto = string.Empty;
		private string _nota = string.Empty;
		private string _referencias = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual long OidTipoAuditoria { get { return _oid_tipo_auditoria; } set { _oid_tipo_auditoria = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string Nota { get { return _nota; } set { _nota = value; } }
		public virtual string Referencias { get { return _referencias; } set { _referencias = value; } }

		#endregion
		
		#region Business Methods
		
		public CuestionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_tipo_auditoria = Format.DataReader.GetInt64(source, "OID_TIPO_AUDITORIA");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_nota = Format.DataReader.GetString(source, "NOTA");
			_referencias = Format.DataReader.GetString(source, "REFERENCIAS");

		}		
		public virtual void CopyValues(CuestionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_tipo_auditoria = source.OidTipoAuditoria;
			_numero = source.Numero;
			_texto = source.Texto;
			_nota = source.Nota;
			_referencias = source.Referencias;
		}
		
		#endregion	
	}

    [Serializable()]
	public class CuestionBase 
	{	 
		#region Attributes
		
		private CuestionRecord _record = new CuestionRecord();
		
		#endregion
		
		#region Properties
		
		public CuestionRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Cuestion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(CuestionInfo source)
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
	public class Cuestion : BusinessBaseEx<Cuestion>
	{	 
		#region Attributes
		
		protected CuestionBase _base = new CuestionBase();

        private CuestionesAuditoria _cuestiones = CuestionesAuditoria.NewChildList();
		

		#endregion
		
		#region Properties
		
		public CuestionBase Base { get { return _base; } }
		
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
		public virtual string Nota
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nota;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Nota.Equals(value))
				{
					_base.Record.Nota = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Referencias
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Referencias;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Referencias.Equals(value))
				{
					_base.Record.Referencias = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual CuestionesAuditoria Cuestiones
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _cuestiones;
            }

            set
            {
                _cuestiones = value;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cuestiones.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cuestiones.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Cuestion CloneAsNew()
		{
			Cuestion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Cuestion.OpenSession();
			Cuestion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(CuestionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidTipoAuditoria = source.OidTipoAuditoria;
			Numero = source.Numero;
			Texto = source.Texto;
			Nota = source.Nota;
			Referencias = source.Referencias;
		}


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        public virtual void CopyValues(Cuestion source, bool oid)
        {
            if (source == null) return;
            if (oid)
            {
                Oid = source.Oid;
                OidTipoAuditoria = source.OidTipoAuditoria;
            }
            Numero = source.Numero;
            Texto = source.Texto;
            Nota = source.Nota;
            Referencias = source.Referencias;

        }
		
			
		#endregion

        #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidTipoAuditoria", 1));

            ValidationRules.AddRule(
                    Csla.Validation.CommonRules.StringRequired, "Texto");

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Numero", 1));
        }

        #endregion

        #region Autorization Rules

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

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Cuestion() 
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        public virtual CuestionInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new CuestionInfo(this, get_childs);
        }

        public virtual CuestionInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Cuestion New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Cuestion>(new CriteriaCs(-1));
        }

        public static Cuestion Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Cuestion.GetCriteria(Cuestion.OpenSession());
            criteria.AddOidSearch(oid);
            Cuestion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Cuestion>(criteria);
        }

        public static Cuestion Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Cuestion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Cuestion>(criteria);
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
        /// Elimina todas los Cuestions
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Cuestion.OpenSession();
            ISession sess = Cuestion.Session(sessCode);
            ITransaction trans = Cuestion.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Cuestion");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Cuestion.CloseSession(sessCode);
            }
        }

        public override Cuestion Save()
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

                _cuestiones.Update(this);

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

        private Cuestion(Cuestion source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Cuestion(int session_code, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static Cuestion NewChild(TipoAuditoria parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Cuestion obj = new Cuestion();
            obj.OidTipoAuditoria = parent.Oid;
            return obj;
        }

        internal static Cuestion GetChild(Cuestion source)
        {
            return new Cuestion(source);
        }

        internal static Cuestion GetChild(int session_code, IDataReader reader, bool childs)
        {
            return new Cuestion(session_code, reader, childs);
        }


        internal static Cuestion GetChild(int session_code, IDataReader reader)
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

        private void Fetch(Cuestion source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = CuestionAuditoria.GetCriteria(Session());
                criteria.AddEq("OidCuestion", this.Oid);
                _cuestiones = CuestionesAuditoria.GetChildList(criteria.List<CuestionAuditoria>());


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
                    CuestionAuditoria.LOCK(AppContext.ActiveSchema.Code);

                    string query = CuestionesAuditoria.SELECT_BY_CUESTION(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
                    _cuestiones = CuestionesAuditoria.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void Insert(TipoAuditoria parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidTipoAuditoria = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
					
                _cuestiones.Update(this);
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

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidTipoAuditoria = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                CuestionRecord obj = parent.Session().Get<CuestionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
					
                _cuestiones.Update(this);
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
                Session().Delete(Session().Get<CuestionRecord>(Oid));
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

                    Cuestion.LOCK(AppContext.ActiveSchema.Code);

                    IDataReader reader = Cuestion.DoSELECT(AppContext.ActiveSchema.Code, Session(),criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        CuestionAuditoria.LOCK(AppContext.ActiveSchema.Code);

                        string query = CuestionesAuditoria.SELECT_BY_CUESTION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _cuestiones = CuestionesAuditoria.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((CuestionRecord)(criteria.UniqueResult()));

                    Session().Lock(Session().Get<CuestionRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = CuestionAuditoria.GetCriteria(Session());
                        criteria.AddEq("OidCuestion", this.Oid);
                        _cuestiones = CuestionesAuditoria.GetChildList(criteria.List<CuestionAuditoria>());
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
                    CuestionRecord obj = Session().Get<CuestionRecord>(Oid);
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
                CuestionRecord obj = (CuestionRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<CuestionRecord>(obj.Oid));

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

        #region Commands

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

            string c = nHManager.Instance.GetSQLTable(typeof(CuestionRecord));

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

