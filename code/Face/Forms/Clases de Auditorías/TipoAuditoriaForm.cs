using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Quality;
using moleQule.Face.Skin01;

namespace moleQule.Face.Quality
{
    public partial class TipoAuditoriaActionForm : ActionSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public const string ID = "TipoAuditoriaActionForm";
        public static Type Type { get { return typeof(TipoAuditoriaActionForm); } }

        #endregion

        #region Factory Methods

        public TipoAuditoriaActionForm()
            : this(true) { }

        public TipoAuditoriaActionForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.TIPO_AUDITORIA_TITLE;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
            this.Criterios_Grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Cuestiones_Grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Criterios_Grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            this.Cuestiones_Grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        public override void RefreshSecondaryData()
        {
            AreaList areas = AreaList.GetList(false);
            Library.Quality.HComboBoxSourceList combo_areas = new Library.Quality.HComboBoxSourceList(areas);
            Datos_ComboAreas.DataSource = combo_areas;
            Bar.Grow();
        }

        #endregion

        #region Buttons

        protected override void CancelAction()
        {
            _action_result = DialogResult.Cancel;
            Cerrar();
        }

        #endregion

        #region Events

        private void TipoAuditoriaActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Criterios_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

    }
}

