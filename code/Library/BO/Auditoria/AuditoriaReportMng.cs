using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Reports;

using moleQule.Library.Instruction;
using moleQule.Library.Quality.Reports;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class AuditoriaReportMng : BaseReportMng
    {

        #region Business Methods Examen

        public NotificacionInternaRpt GetDetailNotificacionAuditoriaReport(NotificacionInternaInfo comunicado, AuditoriaInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;
            NotificacionInternaRpt doc = new NotificacionInternaRpt();
            
            List<NotificacionInternaPrint> pList = new List<NotificacionInternaPrint>();

            NotificacionInternaPrint print = comunicado.GetPrintObject(empresa, item);
            pList.Add(comunicado.GetPrintObject(empresa, item));

            doc.SetDataSource(pList);

            doc.SetParameterValue("ReferenciaTitulo", item.Referencia);
            doc.SetParameterValue("ReferenciaInforme", item.Referencia + 
                " (" + print.NumeroAuditoria + ") " + print.NombreAuditoria);
            doc.SetParameterValue("PieInforme",Resources.Messages.PIE_COMUNICADO_AUDITORIA);

            //FormatReport(doc);

            return doc;
        }

        public NotificacionInternaRpt GetDetailNotificacionDiscrepanciasReport(NotificacionInternaInfo comunicado, AuditoriaInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;
            NotificacionInternaRpt doc = new NotificacionInternaRpt();

            List<NotificacionInternaPrint> pList = new List<NotificacionInternaPrint>();

            NotificacionInternaPrint print = comunicado.GetPrintObject(empresa, item);
            pList.Add(comunicado.GetPrintObject(empresa, item));

            doc.SetDataSource(pList);

            doc.SetParameterValue("ReferenciaTitulo", item.Referencia);
            doc.SetParameterValue("ReferenciaInforme", item.Referencia +
                " (" + print.NumeroAuditoria + ") " + print.NombreAuditoria);
            doc.SetParameterValue("PieInforme", string.Empty);

            //FormatReport(doc);

            return doc;
        }

        public NotificacionInternaRpt GetDetailNotificacionCierreDiscrepanciasReport(NotificacionInternaInfo comunicado, AuditoriaInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;
            NotificacionInternaRpt doc = new NotificacionInternaRpt();

            List<NotificacionInternaPrint> pList = new List<NotificacionInternaPrint>();

            NotificacionInternaPrint print = comunicado.GetPrintObject(empresa, item);
            pList.Add(comunicado.GetPrintObject(empresa, item));

            doc.SetDataSource(pList);

            doc.SetParameterValue("ReferenciaTitulo", item.Referencia);
            doc.SetParameterValue("ReferenciaInforme", item.Referencia +
                " (" + print.NumeroAuditoria + ") " + print.NombreAuditoria);
            doc.SetParameterValue("PieInforme", string.Format(Resources.Messages.PIE_COMUNICADO_CIERRE_DISCREPANCIAS, print.DeptoAuditor.ToUpper(), print.Auditor.ToUpper()));

            //FormatReport(doc);

            return doc;
        }


        public InformeAuditoriaRpt GetDetailReport(AuditoriaInfo item, CompanyInfo empresa)
        {
            if (item == null) return null;
            InformeAuditoriaRpt doc = new InformeAuditoriaRpt();

            List<AuditoriaPrint> pList = new List<AuditoriaPrint>();
            List<CuestionAuditoriaPrint> cuestiones = new List<CuestionAuditoriaPrint>();
            List<CriterioInfo> criterios = new List<CriterioInfo>();

            TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(item.OidTipoAuditoria,true);

            foreach (CriterioInfo criterio in tipo.Criterios)
                criterios.Add(criterio);

            foreach (CuestionAuditoriaInfo info in item.Cuestiones)
            {
                CuestionInfo cuestion = tipo.Cuestiones.GetItem(info.OidCuestion);
                cuestiones.Add(info.GetPrintObject(cuestion));
            }

            ClaseAuditoriaInfo clase = ClaseAuditoriaInfo.Get(tipo.OidClaseAuditoria, false);

            pList.Add(item.GetPrintObject(clase, tipo, empresa));

            doc.SetDataSource(pList);

            doc.Subreports["CriteriosAuditoriaListSubRpt"].SetDataSource(criterios);
            //doc.Subreports["CuestionesAuditoriaListSubRpt"].SetDataSource(cuestiones);

            //FormatReport(doc);

            return doc;
        }
        
        public InformeDiscrepanciaRpt GetDetailReport(DiscrepanciaList list)
        {
            if (list == null) return null;
            InformeDiscrepanciaRpt doc = new InformeDiscrepanciaRpt();

            List<DiscrepanciaPrint> pList = new List<DiscrepanciaPrint>();

            InformeDiscrepanciaList informes = InformeDiscrepanciaList.GetList(false);

            foreach (DiscrepanciaInfo info in list)
                pList.Add(info.GetPrintObject(informes.GetItem(info.OidInforme)));

            doc.Subreports["DiscrepanciaListSubRpt"].SetDataSource(pList);

            //FormatReport(doc);

            return doc;
        }
        
        public InformeAccionesCorrectorasRpt GetDetailReport(InformeCorrectorInfo item)
        {
            if (item == null) return null;
            InformeAccionesCorrectorasRpt doc = new InformeAccionesCorrectorasRpt();

            List<InformeCorrectorPrint> pList = new List<InformeCorrectorPrint>();

            List<AccionCorrectoraInfo> list = new List<AccionCorrectoraInfo>();

            foreach (AccionCorrectoraInfo info in item.Acciones)
                list.Add(info);

            InformeDiscrepanciaInfo informe = InformeDiscrepanciaInfo.Get(item.OidInformeDiscrepancia,false);

            pList.Add(item.GetPrintObject(informe));

            doc.Subreports["AccionCorrectoraListSubRpt"].SetDataSource(list);

            //FormatReport(doc);

            return doc;
        }

        public ControlNoConformidadRpt GetNoConformidadDetailReport(DiscrepanciaList list)
        {
            if (list == null) return null;
            ControlNoConformidadRpt doc = new ControlNoConformidadRpt();

            List<DiscrepanciaPrint> pList = new List<DiscrepanciaPrint>();

            InformeDiscrepanciaList informes = InformeDiscrepanciaList.GetList(false);

            foreach (DiscrepanciaInfo info in list)
                pList.Add(info.GetPrintObject(informes.GetItem(info.OidInforme)));

            doc.Subreports["NoConformidadListSubRpt"].SetDataSource(pList);

            //FormatReport(doc);

            return doc;
        }
        
        public ActaReunionComiteCalidadRpt GetDetailReport(ActaComiteInfo item)
        {
            if (item == null) return null;
            ActaReunionComiteCalidadRpt doc = new ActaReunionComiteCalidadRpt();

            List<ActaComiteInfo> pList = new List<ActaComiteInfo>();

            List<PuntoActaInfo> list = new List<PuntoActaInfo>();

            foreach (PuntoActaInfo info in item.PuntosActas)
                list.Add(info);

            pList.Add(item);

            doc.Subreports["PuntosActaComiteListSubRpt"].SetDataSource(list);

            //FormatReport(doc);

            return doc;
        }

        #endregion

        #region Factory Methods

        public AuditoriaReportMng()
        {

        }

        public AuditoriaReportMng(ISchemaInfo empresa)
            : base(empresa)
        { }

        #endregion

        #region Style


        #endregion

    }
}
