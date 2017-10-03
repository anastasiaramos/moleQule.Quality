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
	public class Plan_TipoInfo : ReadOnlyBaseEx<Plan_TipoInfo>
    {
        #region Attributes

        protected Plan_TipoBase _base = new Plan_TipoBase();


        #endregion

        #region Properties

        public Plan_TipoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPlan { get { return _base.Record.OidPlan; } }
        public long OidTipo { get { return _base.Record.OidTipo; } }
        public long Orden { get { return _base.Record.Orden; } }
        public bool Enero { get { return _base.Record.Enero; } }
        public bool Febrero { get { return _base.Record.Febrero; } }
        public bool Marzo { get { return _base.Record.Marzo; } }
        public bool Abril { get { return _base.Record.Abril; } }
        public bool Mayo { get { return _base.Record.Mayo; } }
        public bool Junio { get { return _base.Record.Junio; } }
        public bool Julio { get { return _base.Record.Julio; } }
        public bool Agosto { get { return _base.Record.Agosto; } }
        public bool Septiembre { get { return _base.Record.Septiembre; } }
        public bool Octubre { get { return _base.Record.Octubre; } }
        public bool Noviembre { get { return _base.Record.Noviembre; } }
        public bool Diciembre { get { return _base.Record.Diciembre; } }

        public long OidClase { get { return _base.OidClase; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Plan_Tipo source) { _base.CopyValues(source); }

        #endregion		

		#region Factory Methods
		 
		protected Plan_TipoInfo() { /* require use of factory methods */ }

		private Plan_TipoInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

        internal Plan_TipoInfo(Plan_Tipo source)
        {
            CopyFrom(source);
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static Plan_TipoInfo Get(IDataReader reader, bool childs)
		{
            return new Plan_TipoInfo(reader, childs);
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

