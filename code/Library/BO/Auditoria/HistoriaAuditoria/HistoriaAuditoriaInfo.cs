using System;
using System.Collections.Generic;
using System.Data;

using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Quality
{

    /// <summary>
    /// ReadOnly Child Business Object
    /// </summary>
    [Serializable()]
    public class HistoriaAuditoriaInfo : ReadOnlyBaseEx<HistoriaAuditoriaInfo>
    {
        #region Attributes

        protected HistoriaAuditoriaBase _base = new HistoriaAuditoriaBase();


        #endregion

        #region Properties

        public HistoriaAuditoriaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAuditoria { get { return _base.Record.OidAuditoria; } }
        public long OidEmpleado { get { return _base.Record.OidEmpleado; } }
        public long Estado { get { return _base.Record.Estado; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public DateTime Hora { get { return _base.Record.Hora; } }


        //LINKED
        public EstadoAuditoria EstadoAuditoria { get { return (EstadoAuditoria)Estado; } }
        public string EstadoAuditoriaLabel { get { return EnumText<EstadoAuditoria>.GetLabel((EstadoAuditoria)Estado); } }
        public string Empleado { get { return _base.Empleado; } }


        #endregion

        #region Business Methods

        public void CopyFrom(HistoriaAuditoria source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected HistoriaAuditoriaInfo() { /* require use of factory methods */ }

        private HistoriaAuditoriaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal HistoriaAuditoriaInfo(HistoriaAuditoria item)
        {
            _base.CopyValues(item);
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static HistoriaAuditoriaInfo Get(IDataReader reader, bool childs)
        {
            return new HistoriaAuditoriaInfo(reader, childs);
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

        #region SQL

        public static string SELECT(long oid) { return HistoriaAuditoria.SELECT(oid, false); }

        #endregion
    }
}

