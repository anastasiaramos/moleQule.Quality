using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Quality;
using moleQule.Face.Skin01;
using moleQule.Library;

namespace moleQule.Face.Quality
{
    public partial class DiscrepanciaActionForm : ActionSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "DiscrepanciaActionForm";
        public static Type Type { get { return typeof(DiscrepanciaActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private InformeDiscrepancia _entity;
        private SchemaSettingList _variables;
        private DateTime _fecha_comunicado;
        private Auditoria _auditoria;
        private CuestionList _cuestiones;

        public InformeDiscrepancia Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public DiscrepanciaActionForm(InformeDiscrepancia item)
            : this(true, item, null, DateTime.Today) { }

        public DiscrepanciaActionForm(bool IsModal, InformeDiscrepancia item, Auditoria auditoria, DateTime fecha_comunicacion)
            : base(IsModal)
        {
            InitializeComponent();
            _entity = item;
            _variables = SchemaSettingList.GetList();
            _cuestiones = CuestionList.GetList();
            _auditoria = auditoria;
            _fecha_comunicado = fecha_comunicacion;
            SetFormData();
            this.Text = Resources.Labels.DISCREPANCIA_TITLE;
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
            Library.Quality.HComboBoxSourceList combo_cuestiones = new Library.Quality.HComboBoxSourceList();
            combo_cuestiones.Add(new ComboBoxSource(0, string.Empty));

            foreach (CuestionAuditoria item in _auditoria.Cuestiones)
            {
                ComboBoxSource combo = new ComboBoxSource(item.Oid, item.Numero.ToString());
                combo_cuestiones.Add(combo);
            }

            Datos_Cuestiones.DataSource = combo_cuestiones;
            Bar.Grow();

            Datos.DataSource = _entity.Discrepancias;
            Bar.FillUp();
        }

        private void CalculaFechaDebida()
        {
            SchemaSettingInfo variable = null;
            int valor = Convert.ToInt32(Nivel_NUD.Value);

            switch (valor)
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
                default:
                    return;
            }

            ((Discrepancia)Datos.Current).FechaDebida = _fecha_comunicado.AddDays(Convert.ToInt32(variable.Value));
            ((Discrepancia)Datos.Current).FechaAmpliacion = ((Discrepancia)Datos.Current).FechaDebida;
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

        private void DiscrepanciaActionForm_FormClosing(object sender, FormClosingEventArgs e)
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


        private void Nivel_NUD_ValueChanged(object sender, EventArgs e)
        {
            if (Datos.Current == null) return;
            ((Discrepancia)Datos.Current).Nivel = Convert.ToInt32(Nivel_NUD.Value);
            CalculaFechaDebida();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            ((Discrepancia)Datos.Current).Nivel = 1;
            CalculaFechaDebida();
        }


        private void Cuestion_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cuestion_CB.SelectedItem == null) return;

            CuestionAuditoria cuestion_auditoria = _auditoria.Cuestiones.GetItem(((ComboBoxSource)Cuestion_CB.SelectedItem).Oid);

            if (cuestion_auditoria != null)
            {
                CuestionInfo cuestion = _cuestiones.GetItem(cuestion_auditoria.OidCuestion);

                if (cuestion != null)
                    Cuestion_TB.Text = cuestion.Texto;
            }

        }

        #endregion





    }
}

