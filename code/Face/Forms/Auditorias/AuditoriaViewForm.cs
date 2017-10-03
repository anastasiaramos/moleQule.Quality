using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;

using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;
using moleQule.Library.Instruction;

namespace moleQule.Face.Quality
{
    public partial class AuditoriaViewForm : AuditoriaForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private AuditoriaInfo _entity;

        public override AuditoriaInfo EntityInfo { get { return _entity; } }

        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveOID
        {
            get
            {
                return Informes_Grid.CurrentRow != null ? ((InformeDiscrepanciaInfo)Datos_Informes.Current).Oid : 0;
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private AuditoriaViewForm() : this(-1) { }

        public AuditoriaViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();

            SetFormData();

            this.Text = Resources.Labels.AUDITORIA_EDIT_TITLE;
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = AuditoriaInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            Comunicado_Print_BT.Enabled = true;

            AddAmpliacion_TI.Enabled = false;
            AddCorreccion_TI.Enabled = false;
            AddDiscrepancia_TI.Enabled = false;
            EditAmpliacion_TI.Enabled = false;
            EditCorreccion_TI.Enabled = false;
            EditDiscrepancia_TI.Enabled = false;
            DeleteAmpliacion_TI.Enabled = false;
            DeleteCorreccion_TI.Enabled = false;
            DeleteDiscrepancia_TI.Enabled = false;
            NotifyAmpliacion_TI.Enabled = false;
            NotifyDiscrepancia_TI.Enabled = false;
            NotityCorreccion_TI.Enabled = false;
            ViewAmpliacion_TI.Enabled = true;
            ViewCorrecccion_TI.Enabled = true;
            ViewDiscrepancia_TI.Enabled = true;
            
            base.FormatControls();
        }

        public override void RefreshSecondaryData()
        {
            base.RefreshSecondaryData();
            Bar.Grow();

            if (EntityInfo != null)
            {
                Datos_Cuestiones.DataSource = _entity.Cuestiones;
                Bar.Grow(string.Empty, "Auditorias");

                Datos_Informes.DataSource = _entity.Informes;
                Bar.Grow();

                SetUnlinkedGridValues(Cuestiones_Grid.Name);
                Bar.Grow();

                if (Datos_Informes.Current != null && ActiveOID > 0)
                {
                    InformeAmpliacionList lista = _entity.Informes.GetItem(ActiveOID).Ampliaciones;
                    Datos_Ampliaciones.DataSource = lista;

                    InformeCorrectorList listac = _entity.Informes.GetItem(ActiveOID).Correctores;
                    Datos_AccionesCorrectoras.DataSource = listac;
                }
                Bar.Grow();

                Datos_Historia.DataSource = _entity.Historial;
                Bar.Grow();
            }

        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Bar.FillUp();

            Estado_TB.Text = ((EstadoAuditoria)_entity.Estado).ToString();
            Bar.Grow();
        }

        protected override void RefreshInformes()
        {
            if (Datos_Informes.Current != null && ActiveOID > 0)
            {
                InformeAmpliacionList lista = _entity.Informes.GetItem(ActiveOID).Ampliaciones;
                Datos_Ampliaciones.DataSource = lista;

                InformeCorrectorList listac = _entity.Informes.GetItem(ActiveOID).Correctores;
                Datos_AccionesCorrectoras.DataSource = listac;
            }
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Cuestiones_Grid":
                    {
                        foreach (DataGridViewRow row in Cuestiones_Grid.Rows)
                        {
                            if (_tipo_auditoria == null)
                                _tipo_auditoria = _tipos_auditorias.GetItem(EntityInfo.OidTipoAuditoria);
                            if (_tipo_auditoria != null)
                            {
                                CuestionAuditoriaInfo cuestion = (CuestionAuditoriaInfo)row.DataBoundItem;
                                if (cuestion != null)
                                {
                                    CuestionInfo info = _tipo_auditoria.Cuestiones.GetItem(cuestion.OidCuestion);
                                    if (info != null)
                                    {
                                        row.Cells["Cuestion"].Value = info.Texto;
                                        row.Cells["Numero"].Value = info.Numero;
                                    }
                                }
                            }
                        }
                    } break;
                case "Historia_Grid":
                    {
                        InstructorList instructores = InstructorList.GetList(false);
                        foreach (DataGridViewRow row in Historia_Grid.Rows)
                        {
                            HistoriaAuditoriaInfo item = (HistoriaAuditoriaInfo)row.DataBoundItem;
                            if (item.Empleado == string.Empty)
                            {
                                InstructorInfo instructor = instructores.GetItem(item.OidEmpleado);
                                if (instructor != null)
                                    row.Cells["Empleado"].Value = instructor.Nombre;
                            }
                        }
                    }
                    break;
            }
        }

        protected override void PrintComunicado()
        {
            if ((EstadoAuditoria)_entity.Estado > EstadoAuditoria.CREADA)
            {
                AuditoriaReportMng reportMng = new AuditoriaReportMng(AppContext.ActiveSchema);

                NotificacionInternaInfo notificacion = _entity.Notificaciones[0];

                NotificacionInternaRpt rpt = reportMng.GetDetailNotificacionAuditoriaReport(notificacion, _entity, CompanyInfo.Get(AppContext.ActiveSchema.Oid, false));

                ReportViewer.SetReport(rpt);
                ReportViewer.ShowDialog();
            }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion

    }
}
