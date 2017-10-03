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

	/// <summary>
	/// ReadOnly Child Business Object
    /// </summary>
	[Serializable()]
	public class Auditoria_AreaInfo : ReadOnlyBaseEx<Auditoria_AreaInfo>
    {
        #region Attributes

        protected Auditoria_AreaBase _base = new Auditoria_AreaBase();


        #endregion

        #region Properties

        public Auditoria_AreaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAuditoria { get { return _base.Record.OidAuditoria; } }
        public long OidArea { get { return _base.Record.OidArea; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Auditoria_Area source) { _base.CopyValues(source); }

        #endregion		
		 

		#region Factory Methods
		 
		protected Auditoria_AreaInfo() { /* require use of factory methods */ }

		private Auditoria_AreaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal Auditoria_AreaInfo(Auditoria_Area source)
		{
            CopyFrom(source);			
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static Auditoria_AreaInfo Get(IDataReader reader, bool childs)
		{
			return new Auditoria_AreaInfo(reader, childs);
		}
		
		#endregion
		 
		 
		#region Data Access
		 
		//called to copy data from IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
			_base.CopyValues(source);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
					
		#endregion
		
	}
}

