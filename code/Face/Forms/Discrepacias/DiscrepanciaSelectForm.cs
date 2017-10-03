using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class DiscrepanciaSelectForm : DiscrepanciaMngForm
    {

        #region Factory Methods

        public DiscrepanciaSelectForm()
            : this(null) {}

        public DiscrepanciaSelectForm(Form parent)
            : this(parent, null) {}
		
		public DiscrepanciaSelectForm(Form parent, DiscrepanciaList list)
            : base(true, parent, list)
        {
            InitializeComponent();
            _view_mode = molView.Select;
            DialogResult = DialogResult.Cancel;
        }
		
        #endregion

        #region Style & Source

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Accion por defecto. Se usa para el Double_Click del Grid
        /// <returns>void</returns>
        /// </summary>
        protected override void DefaultAction() { ExecuteAction(molAction.Select);}

        #endregion
    }
}
