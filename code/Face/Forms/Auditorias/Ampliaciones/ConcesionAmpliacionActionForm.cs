using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Quality;
using moleQule.Face.Skin01;
using moleQule.Face.Quality.Tools;
using moleQule.Library;

namespace moleQule.Face.Quality
{
    public partial class ConcesionAmpliacionActionForm : ActionSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "ConcesionAmpliacionActionForm";
        public static Type Type { get { return typeof(DiscrepanciaActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private InformeDiscrepancia _entity;
        private List<Discrepancia> _list;
        private Auditoria _auditoria;
        private SchemaSettingList _variables;

        public InformeDiscrepancia Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public List<Discrepancia> List
        {
            get { return _list; }
            set { _list = value; }
        }

        #endregion

        #region Factory Methods


        public ConcesionAmpliacionActionForm(bool IsModal, InformeAmpliacion ampliacion, Auditoria auditoria, Form parent)
            : base(IsModal)
        {
            
            InitializeComponent();
            _variables = SchemaSettingList.GetList();
            _parent = parent as AuditoriaUIForm;
            _auditoria = auditoria;
            _entity = _auditoria.Informes.GetItem(ampliacion.OidInformeDiscrepancia);
            _list = new List<Discrepancia>();

            foreach (Ampliacion info in ampliacion.Ampliaciones)
            {
                Discrepancia obj = _entity.Discrepancias.GetItem(info.OidDiscrepancia);
                if (obj != null)
                    _list.Add(obj);
            }

            SetFormData();
            this.Text = Resources.Labels.CONCESION_AMPLIACION_TITLE;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            FechaDebida_DTP.ShowCheckBox = false;
            FechaCierre_DTP.ShowCheckBox = false;
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _list;
            Bar.FillUp();
        }


        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            _auditoria.Informes.GetItem(_entity.Oid).Ampliaciones[_entity.Ampliaciones.Count - 1].Valorado = true;

            //AuditoriaFormController.DoAction(_auditoria, AccionAuditoria.NOTIFICAR_CONCESION_AMPLIACION, _entity.Oid);

            ComunicadoAuditoriaActionForm Cform = new ComunicadoAuditoriaActionForm(_auditoria, TipoNotificacionAsociado.CONCESION_AMPLIACION, _entity.Oid);
            Cform.ShowDialog();

            _auditoria = Cform.Auditoria;

            _action_result = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            if (!IsModal)
                _entity.CancelEdit();
            _action_result = DialogResult.Cancel;

            Cerrar();
        }

        #endregion

        #region Events

        private void ConcesionAmpliacionActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
                Entity.CancelEdit();
            }

            Cerrar();

        }

        private void FechaDebida_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (Datos.Current == null) return;
            Discrepancia discrepancia = ((Discrepancia)Datos.Current);
            DateTime fecha_debida;
            SchemaSettingInfo variable = null;

            switch (discrepancia.Nivel)
            {
                case 1:
                    {
                        variable = _variables.GetItem("PLAZO_MAXIMO_DISCREPANCIAS_N1");
                    }
                    break;
                case 2:
                    {
                        variable = _variables.GetItem("PLAZO_MAXIMO_DISCREPANCIAS_N2");
                    }
                    break;
                case 3:
                    {
                        variable = _variables.GetItem("PLAZO_MAXIMO_DISCREPANCIAS_N3");
                    }
                    break;
                default: break;
            }

            if (variable != null)
            {
                int porc_ampliacion = Convert.ToInt32(_variables.GetItem("PLAZO_MAXIMO_AMPLIACION").Value);
                int dias_ampliacion = (Convert.ToInt32(variable.Value) * porc_ampliacion) / 100;
                fecha_debida = discrepancia.FechaDebida.AddDays(dias_ampliacion);
                if (fecha_debida.Date < FechaDebida_DTP.Value.Date)
                {
                    FechaDebida_DTP.Value = fecha_debida;
                }
            }
        }

        #endregion

        


    }
}

