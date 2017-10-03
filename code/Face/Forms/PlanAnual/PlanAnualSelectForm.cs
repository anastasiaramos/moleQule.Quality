using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class PlanAnualSelectForm : PlanAnualMngForm
    {

        #region Factory Methods

        public PlanAnualSelectForm(Form parent)
            : this(parent, null) {}

        public PlanAnualSelectForm(Form parent, PlanAnualList lista)
            : base(true, parent,  lista)
        {
            InitializeComponent();
            _view_mode = molView.Select;
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Style & Source
        
        #endregion

        #region Actions

        /// <summary>
        /// Accion por defecto. Se usa para el Double_Click del Grid
        /// <returns>void</returns>
        /// </summary>
        protected override void DefaultAction() { ExecuteAction(molAction.Select); }

        #endregion
    }
}

