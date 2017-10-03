using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Quality;


namespace moleQule.Face.Quality
{
    public partial class PuntoActaActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public const string ID = "PuntoActaActionForm";
        public static Type Type { get { return typeof(PuntoActaActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private ActaComite _entity;

        public ActaComite Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        #endregion

        #region Factory Methods

        public PuntoActaActionForm(ActaComite item)
            : this(true, item) { }

        public PuntoActaActionForm(bool IsModal, ActaComite item)
            : base(IsModal)
        {
            InitializeComponent();
            _entity = item;
            SetFormData();
            this.Text = Resources.Labels.PUNTOS_ACTAS_TITLE;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity.PuntosActas;
            Bar.FillUp();
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            _action_result  = DialogResult.OK;
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

        private void PuntoActaActionForm_FormClosing(object sender, FormClosingEventArgs e)
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

        #endregion


    }
}

