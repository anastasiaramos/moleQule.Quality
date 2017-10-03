using System;
using System.Collections.Generic;

using Csla;

using moleQule.Library;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Quality
{
    public partial class AgenteSelector : AgenteSelectorBase
    {
        #region Business Methods

        #endregion

        #region Style & Source

        public new static IAgenteHipatiaList GetAgentes(EntidadInfo entidad)
        {
            IAgenteHipatiaList lista = new IAgenteHipatiaList(new List<IAgenteHipatia>());

            if (entidad.Tipo == typeof(Auditoria).Name)
            {
                AuditoriaList list = AuditoriaList.GetList(false);

                foreach (AuditoriaInfo obj in list)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(InformeDiscrepancia).Name)
            {
                InformeDiscrepanciaList list = InformeDiscrepanciaList.GetList(false);

                foreach (InformeDiscrepanciaInfo obj in list)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(InformeCorrector).Name)
            {
                InformeCorrectorList list = InformeCorrectorList.GetList();

                foreach (InformeCorrectorInfo obj in list)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(InformeAmpliacion).Name)
            {
                InformeAmpliacionList list = InformeAmpliacionList.GetList();

                foreach (InformeAmpliacionInfo obj in list)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else
                throw new iQException("No se ha encontrado el tipo de entidad " + entidad.Tipo);

            return lista;
        }

        #endregion
    }
}