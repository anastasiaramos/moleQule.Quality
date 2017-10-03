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
	public class AmpliacionInfo : ReadOnlyBaseEx<AmpliacionInfo>
    {
        #region Attributes

        protected AmpliacionBase _base = new AmpliacionBase();


        #endregion

        #region Properties

        public AmpliacionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInformeAmpliacion { get { return _base.Record.OidInformeAmpliacion; } }
        public long OidDiscrepancia { get { return _base.Record.OidDiscrepancia; } }
        public DateTime FechaDebida { get { return _base.Record.FechaDebida; } }
        public DateTime FechaCierre { get { return _base.Record.FechaCierre; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Ampliacion source) { _base.CopyValues(source); }

        #endregion				 

		#region Factory Methods
		 
		protected AmpliacionInfo() { /* require use of factory methods */ }

		private AmpliacionInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal AmpliacionInfo(Ampliacion source)
		{
            CopyFrom(source);
			
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static AmpliacionInfo Get(IDataReader reader, bool childs)
		{
			return new AmpliacionInfo(reader, childs);
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

