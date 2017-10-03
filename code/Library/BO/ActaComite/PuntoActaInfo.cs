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
	public class PuntoActaInfo : ReadOnlyBaseEx<PuntoActaInfo>
    {
        #region Attributes

        protected PuntoActaBase _base = new PuntoActaBase();


        #endregion

        #region Properties

        public PuntoActaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidActa { get { return _base.Record.OidActa; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Texto { get { return _base.Record.Texto; } }
        public long Numero { get { return _base.Record.Numero; } }



        #endregion

        #region Business Methods

        public void CopyFrom(PuntoActa source) { _base.CopyValues(source); }

        #endregion		
		 

		#region Factory Methods
		 
		protected PuntoActaInfo() { /* require use of factory methods */ }

		private PuntoActaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal PuntoActaInfo(PuntoActa source)
		{
            CopyFrom(source);
			
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static PuntoActaInfo Get(IDataReader reader, bool childs)
		{
			return new PuntoActaInfo(reader, childs);
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

