using System;
using System.Collections;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class InformeCorrectorPrint : InformeCorrectorInfo
    {

        #region Business Methods

        private string _auditor = string.Empty;
        private string _responsable = string.Empty;
        private string _fecha_informe_discrepancias = string.Empty;
        private string _auditoria = string.Empty;

        public string Auditor {get{return _auditor;}}
        public string Responsable{get{return _responsable;}}
        public string FechaInformeDiscrepancias{get{return _fecha_informe_discrepancias;}}
        public string Auditoria{get{return _auditoria;}}
        

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(InformeCorrectorInfo source, InformeDiscrepanciaInfo informe)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidInformeDiscrepancia = source.OidInformeDiscrepancia;
            _base.Record.Codigo = source.Codigo;
            _base.Record.Serial = source.Serial;
            _base.Record.Fecha = source.Fecha;
            _base.Record.Numero = source.Numero;
            _base.Record.Observaciones = source.Observaciones;

            if (informe != null)
            {
                _fecha_informe_discrepancias = informe.Fecha.Day.ToString("00") + "." +
                                                informe.Fecha.Month.ToString("00") + "." +
                                                informe.Fecha.Year.ToString();

                AuditoriaInfo auditoria = AuditoriaInfo.Get(informe.OidAuditoria,false);

                if (auditoria != null)
                {
                    InstructorInfo auditor = InstructorInfo.Get(auditoria.OidAuditor,false);
                    if (auditor != null)
                        _auditor = auditor.Nombre + " " + auditor.Apellidos;

                    InstructorInfo responsable = InstructorInfo.Get(auditoria.OidResponsable,false);
                    if (responsable != null)
                        _responsable = responsable.Nombre+ " " + responsable.Apellidos;

                    TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(auditoria.OidTipoAuditoria, false);
                    if (tipo != null)
                        _auditoria = tipo.Numero + " " + tipo.Nombre;
                }
            }
        }

        #endregion

        #region Factory Methods

        private InformeCorrectorPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static InformeCorrectorPrint New(InformeCorrectorInfo source, InformeDiscrepanciaInfo informe)
        {
            InformeCorrectorPrint item = new InformeCorrectorPrint();
            item.CopyValues(source, informe);

            return item;
        }

        #endregion

    }
}
