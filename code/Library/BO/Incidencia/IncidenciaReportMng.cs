using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

using moleQule.Library;
using moleQule.Library.Reports;

using moleQule.Library.Quality.Reports;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class IncidenciaReportMng : BaseReportMng
    {

        #region Business Methods Incidencia
		
        public IncidenciaRpt GetDetailReport(IncidenciaInfo item)
        {
            if (item == null) return null;
			
            IncidenciaRpt doc = new IncidenciaRpt();
            
            List<IncidenciaPrint> pList = new List<IncidenciaPrint>();

            pList.Add(IncidenciaPrint.New(item));
            doc.SetDataSource(pList);
			doc.SetParameterValue("Empresa", Schema.Name);			

            //FormatReport(doc, empresa.Logo);

            return doc;
        }

		public IncidenciaListRpt GetListReport(IncidenciaList list)
		{
			if (list.Count == 0) return null;

			IncidenciaListRpt doc = new ClienteListRpt();

			List<IncidenciaPrint> pList = new List<IncidenciaPrint>();
			
			foreach (IncidenciaInfo item in list)
			{
				pList.Add(IncidenciaPrint.New(item));;
			}
			
			doc.SetDataSource(pList);
			doc.SetParameterValue("Empresa", Schema.Name);

			return doc;
		}
		
        #endregion

        #region Factory Methods

        public IncidenciaReportMng() {}

        public IncidenciaReportMng(ISchemaInfo empresa)
            : base(empresa) { }

        #endregion
        
        #region Style

        private static void FormatReport(IncidenciaRpt rpt, string logo)
        {
            /*string path = Images.GetRootPath() + "\\" + Resources.Paths.LOGO_EMPRESAS + logo;

            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                int width = rpt.Section1.ReportObjects["Logo"].Width;
                int height = rpt.Section1.ReportObjects["Logo"].Height;

                rpt.Section1.ReportObjects["Logo"].Width = 15 * image.Width;
                rpt.Section1.ReportObjects["Logo"].Height = 15 * image.Height;
                rpt.Section1.ReportObjects["Logo"].Left += (width - 15 * image.Width) / 2;
                rpt.Section1.ReportObjects["Logo"].Top += (height - 15 * image.Height) / 2;
            }*/
        }

        #endregion

    }
}
