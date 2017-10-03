using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face.Skin01;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class AmpliacionActionForm : ActionSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "AmpliacionActionForm";
        public static Type Type { get { return typeof(AmpliacionActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private InformeAmpliacion _entity;
        private InformeDiscrepancia _i_discrepancia;
        private Auditoria _auditoria;

        public InformeAmpliacion Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public InformeDiscrepancia IDiscrepancia
        {
            get { return _i_discrepancia; }
            set { _i_discrepancia = value; }
        }

        #endregion

        #region Factory Methods

        public AmpliacionActionForm(InformeAmpliacion item, InformeDiscrepancia informe, Auditoria auditoria)
            : this(true, item, informe, auditoria) { }

        public AmpliacionActionForm(bool IsModal, InformeAmpliacion item, InformeDiscrepancia informe, 
                Auditoria auditoria)
            : base(IsModal)
        {
            InitializeComponent();
            _entity = item;
            _i_discrepancia = informe;
            _auditoria = auditoria;
            SetFormData();
            this.Text = Resources.Labels.DISCREPANCIA_TITLE;
        }

        #endregion

        #region Style & Source

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity.Ampliaciones;
            Bar.FillUp();
        }

        public override void RefreshSecondaryData()
        {
            Library.Quality.HComboBoxSourceList combo_numeros = new Library.Quality.HComboBoxSourceList();
            combo_numeros.Add(new ComboBoxSource());
            if (IDiscrepancia != null)
            {
                foreach (Discrepancia item in IDiscrepancia.Discrepancias)
                {
                    if (item.EsDiscrepancia)
                    {
                        CuestionAuditoria cuestion = _auditoria.Cuestiones.GetItem(item.OidCuestion);
                        if (cuestion != null && !cuestion.Aceptado)
                            combo_numeros.Add(new ComboBoxSource(item.Oid, item.Numero.ToString()));
                    }
                }
            }
            Datos_Numeros.DataSource = combo_numeros;
            Bar.Grow();
        }


        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
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

        private void AmpliacionActionForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Numero_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDiscrepancia != null && Numero_CB.SelectedItem != null 
                && ((ComboBoxSource)Numero_CB.SelectedItem).Oid != 0)
            {
                Discrepancia disp = IDiscrepancia.Discrepancias.GetItem(((ComboBoxSource)Numero_CB.SelectedItem).Oid);
                Discrepancia_TB.Text = disp.Texto;
                Nivel_TB.Text = disp.Nivel.ToString();
            }
        }

        #endregion


    }
}

