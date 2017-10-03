using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Hipatia;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class IncidenciaPrint : IncidenciaInfo
    {

        #region Attributes & Properties
		
		
		#endregion
		
		#region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(IncidenciaInfo source)
        {
            if (source == null) return;

			
			AgenteInfo agente = AgenteInfo.Get(OidAgente, false);
            if (agente != null)
                _base.Agente = agente.Nombre;
			
			
        }

        #endregion

        #region Factory Methods

        private IncidenciaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static IncidenciaPrint New(IncidenciaInfo source)
        {
            IncidenciaPrint item = new IncidenciaPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
