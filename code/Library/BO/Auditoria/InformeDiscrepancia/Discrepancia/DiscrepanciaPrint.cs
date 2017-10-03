using System;
using System.Collections;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class DiscrepanciaPrint : DiscrepanciaInfo
    {

        #region Business Methods

        private string _ref_informe = string.Empty;
        private string _num_auditoria = string.Empty;
        private DateTime _fecha_auditoria;
        private string _clase_auditoria = string.Empty;

        public string RefInforme { get {return _ref_informe;}}
        public string NumAuditoria { get { return _num_auditoria; } }
        public DateTime FechaAuditoria { get { return _fecha_auditoria; } }
        public string ClaseAuditoria { get { return _clase_auditoria; } }


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(DiscrepanciaInfo source, InformeDiscrepanciaInfo informe)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidInforme = source.OidInforme;
            _base.Record.Codigo = source.Codigo;
            _base.Record.Serial = source.Serial;
            _base.Record.Numero = source.Numero;
            _base.Record.Texto = source.Texto;
            _base.Record.Nivel = source.Nivel;
            _base.Record.FechaDebida = source.FechaDebida;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.FechaCierre = source.FechaCierre;

            if (informe != null)
            {
                _ref_informe = informe.Codigo;

                AuditoriaInfo auditoria = AuditoriaInfo.Get(informe.OidAuditoria, false);

                if (auditoria != null)
                {
                    _num_auditoria = auditoria.Codigo;
                    _fecha_auditoria = auditoria.FechaInicio;

                    TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(auditoria.OidTipoAuditoria, false);
                    if (tipo != null)
                    {
                        ClaseAuditoriaInfo clase = ClaseAuditoriaInfo.Get(tipo.OidClaseAuditoria, false);
                        if (clase != null)
                            _clase_auditoria = clase.Numero + " " + clase.Nombre;
                    }
                }
            }
        }

        #endregion

        #region Factory Methods

        private DiscrepanciaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static DiscrepanciaPrint New(DiscrepanciaInfo source, InformeDiscrepanciaInfo informe)
        {
            DiscrepanciaPrint item = new DiscrepanciaPrint();
            item.CopyValues(source, informe);

            return item;
        }

        #endregion

    }
}
