using System;
using System.Collections;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class CuestionAuditoriaPrint : CuestionAuditoriaInfo
    {

        #region Business Methods

        private string _texto = string.Empty;
        private string _referencias = string.Empty;

        public string Texto { get { return _texto; } set { _texto = value; } }
        public string Referencias { get { return _referencias; } set { _referencias = value; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(CuestionAuditoriaInfo source, CuestionInfo cuestion)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidAuditoria = source.OidAuditoria;
            _base.Record.OidCuestion = source.OidCuestion;
            _base.Record.Numero = source.Numero;
            _base.Record.Aceptado = source.Aceptado;
            _base.Record.Observaciones = source.Observaciones;

            if (cuestion != null)
            {
                Texto = cuestion.Texto;
                Referencias = cuestion.Referencias;
            }
        }


        #endregion

        #region Factory Methods

        private CuestionAuditoriaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static CuestionAuditoriaPrint New(CuestionAuditoriaInfo source, CuestionInfo cuestion)
        {
            CuestionAuditoriaPrint item = new CuestionAuditoriaPrint();
            item.CopyValues(source, cuestion);

            return item;
        }

        #endregion

    }
}
