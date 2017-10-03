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
	public class CriterioInfo : ReadOnlyBaseEx<CriterioInfo>
    {
        #region Attributes

        protected CriterioBase _base = new CriterioBase();


        #endregion

        #region Properties

        public CriterioBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidTipoAuditoria { get { return _base.Record.OidTipoAuditoria; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public long Numero { get { return _base.Record.Numero; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Criterio source) { _base.CopyValues(source); }

        #endregion		
		 
		#region Factory Methods
		 
		protected CriterioInfo() { /* require use of factory methods */ }

		private CriterioInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal CriterioInfo(Criterio source)
		{
            CopyFrom(source);			
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static CriterioInfo Get(IDataReader reader, bool childs)
		{
			return new CriterioInfo(reader, childs);
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

