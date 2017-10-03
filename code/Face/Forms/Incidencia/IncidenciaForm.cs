using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Instruction;
using moleQule.Library.Common;
using moleQule.Library.Application;
using moleQule.Library.Quality;
using moleQule.Library.Instruction;
using moleQule.Library.Quality.Reports;

namespace moleQule.Face.Quality
{
    public partial class IncidenciaForm : Skin01.ItemMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "IncidenciaForm";
		public static Type Type { get { return typeof(IncidenciaForm); } }

        protected override int BarSteps { get { return base.BarSteps + 0; } }
		
        public virtual Incidencia Entity { get { return null; } set { } }
        public virtual IncidenciaInfo EntityInfo { get { return null; } }

		
        #endregion

        #region Factory Methods

        public IncidenciaForm() : this(-1) {}

        public IncidenciaForm(long oid) : this(oid, false, null) {}

		public IncidenciaForm(bool isModal) : this(-1, isModal, null) {}
        
        public IncidenciaForm(long oid, bool isModal) : this(oid, isModal, null) {}

        public IncidenciaForm(long oid, bool isModal, Form parent)
            : base(oid, isModal, parent)
        {
            InitializeComponent();
        }
		
        #endregion

        #region Style & Source

        /// <summary>Da formato a los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos principal
		/// y las listas hijas a los origenes de datos correspondientes
        /// </summary>
        protected override void RefreshMainData()
        {
			
        }

        /// <summary>
        /// Asigna los datos a los origenes de datos secundarios
        /// </summary>
        public override void RefreshSecondaryData()
		{
            TipoAgente_CB.DataSource = moleQule.Library.Common.EnumText<ETipoAgente>.GetList(false); //Enum.GetNames(typeof(ETipoAgente));
        }
		
		#endregion

        #region Validation & Format

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //    IncidenciaReportMng reportMng = new IncidenciaReportMng(AppContext.ActiveSchema);
        //    ReportViewer.SetReport(reportMng.GetReport(EntityInfo);
        //    ReportViewer.ShowDialog();
        //}

        #endregion

        #region Buttons

        private void Selecionar_B_Click(object sender, EventArgs e)
        {
            if (TipoAgente_CB.Text == string.Empty) return;
            ETipoAgente tipo = (ETipoAgente)Enum.Parse(typeof(ETipoAgente), TipoAgente_CB.Text);
            switch (tipo)
            {
                case ETipoAgente.Alumno:
                    AlumnoSelectForm form = new AlumnoSelectForm(this);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        Entity.OidAgente  = ((AlumnoInfo)form.Selected).Oid;
                        Entity.Agente = ((AlumnoInfo)form.Selected).Nombre +" "+ ((AlumnoInfo)form.Selected).Apellidos ;
                    }
                    break;
               
                          
                case ETipoAgente.Instructor:
                    InstructorList instructores = InstructorList.GetList(false);
                    InstructorSelectForm form2 = new InstructorSelectForm(this, instructores);
                    form2.ShowDialog();
                    if (form2.DialogResult == DialogResult.OK)
                    {
                        Entity.OidAgente = ((InstructorInfo)form2.Selected).Oid;
                        Entity.Agente = ((InstructorInfo)form2.Selected).Nombre + " " + ((InstructorInfo)form2.Selected).Apellidos;
                    }
                    break;                  
            }
        }

        #endregion

        #region Events

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            //SetDependentControlSource(ID_GB.Name);
        }

        private void TipoAgente_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this is IncidenciaViewForm) return;
            if (TipoAgente_CB.SelectedItem != null && Entity.TipoAgente != TipoAgente_CB.Text)
                Entity.Agente = string.Empty;
        }

        #endregion       
      
    }
}
