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
    public class AccionCorrectoraInfo : ReadOnlyBaseEx<AccionCorrectoraInfo>
    {
		#region Attributes

		protected AccionCorrectoraBase _base = new AccionCorrectoraBase();

		
		#endregion
		
		#region Properties
		
		public AccionCorrectoraBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
		public long OidInformeCorrector { get { return _base.Record.OidInformeCorrector; } }
		public long OidDiscrepancia { get { return _base.Record.OidDiscrepancia; } }
		public string Texto { get { return _base.Record.Texto; } }
		public long Numero { get { return _base.Record.Numero; } }
		public string Codigo { get { return _base.Record.Codigo; } }
		public long Serial { get { return _base.Record.Serial; } }
		
		
		
		#endregion
		
		#region Business Methods
						
		public void CopyFrom(AccionCorrectora source) { _base.CopyValues(source); }
			
		#endregion		
		 
		#region Factory Methods
		 
		protected AccionCorrectoraInfo() { /* require use of factory methods */ }

		private AccionCorrectoraInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal AccionCorrectoraInfo(AccionCorrectora source)
		{
			Oid = source.Oid;
			_base.Record.OidInformeCorrector = source.OidInformeCorrector;
			_base.Record.OidDiscrepancia = source.OidDiscrepancia;
            _base.Record.Codigo = source.Codigo;
            _base.Record.Serial = source.Serial;
			_base.Record.Texto = source.Texto;
			_base.Record.Numero = source.Numero;
			
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static AccionCorrectoraInfo Get(IDataReader reader, bool childs)
		{
			return new AccionCorrectoraInfo(reader, childs);
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

