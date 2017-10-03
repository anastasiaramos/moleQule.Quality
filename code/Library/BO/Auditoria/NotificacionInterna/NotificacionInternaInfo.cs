using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;

using NHibernate;

using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{

	/// <summary>
	/// ReadOnly Child Business Object
    /// </summary>
	[Serializable()]
	public class NotificacionInternaInfo : ReadOnlyBaseEx<NotificacionInternaInfo>
    {
        #region Attributes

        protected NotificacionInternaBase _base = new NotificacionInternaBase();


        #endregion

        #region Properties

        public NotificacionInternaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAsociado { get { return _base.Record.OidAsociado; } }
        public long TipoAsociado { get { return _base.Record.TipoAsociado; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public long Numero { get { return _base.Record.Numero; } }
        public string Comentarios { get { return _base.Record.Comentarios; } }
        public string Asunto { get { return _base.Record.Asunto; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Atencion { get { return _base.Record.Atencion; } }
        public string Copia { get { return _base.Record.Copia; } }



        #endregion

        #region Business Methods

        public void CopyFrom(NotificacionInterna source) { _base.CopyValues(source); }

        #endregion		

		#region Factory Methods
		 
		protected NotificacionInternaInfo() { /* require use of factory methods */ }

		private NotificacionInternaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

        internal NotificacionInternaInfo(NotificacionInterna source)
		{
            CopyFrom(source);	
		}


        public NotificacionInternaPrint GetPrintObject(CompanyInfo empresa, AuditoriaInfo auditoria)
        {
            InstructorList instructores = InstructorList.GetList(false);
            return NotificacionInternaPrint.New(this, auditoria, instructores, empresa);
        }

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static NotificacionInternaInfo Get(IDataReader reader, bool childs)
		{
			return new NotificacionInternaInfo(reader, childs);
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

