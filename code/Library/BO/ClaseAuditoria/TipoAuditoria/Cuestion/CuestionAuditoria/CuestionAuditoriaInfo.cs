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
	public class CuestionAuditoriaInfo : ReadOnlyBaseEx<CuestionAuditoriaInfo>
    {
        #region Attributes

        protected CuestionAuditoriaBase _base = new CuestionAuditoriaBase();


        #endregion

        #region Properties

        public CuestionAuditoriaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAuditoria { get { return _base.Record.OidAuditoria; } }
        public long OidCuestion { get { return _base.Record.OidCuestion; } }
        public long Numero { get { return _base.Record.Numero; } }
        public bool Aceptado { get { return _base.Record.Aceptado; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }



        #endregion

        #region Business Methods

        public void CopyFrom(CuestionAuditoria source) { _base.CopyValues(source); }

        public CuestionAuditoriaPrint GetPrintObject(CuestionInfo cuestion)
        {
            return CuestionAuditoriaPrint.New(this, cuestion);
        }

        #endregion		

		#region Factory Methods
		 
		protected CuestionAuditoriaInfo() { /* require use of factory methods */ }

		private CuestionAuditoriaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal CuestionAuditoriaInfo(CuestionAuditoria source)
        {
            CopyFrom(source);			
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static CuestionAuditoriaInfo Get(IDataReader reader, bool childs)
		{
			return new CuestionAuditoriaInfo(reader, childs);
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

