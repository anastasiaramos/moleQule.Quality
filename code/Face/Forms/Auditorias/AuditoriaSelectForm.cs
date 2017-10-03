using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class AuditoriaSelectForm : AuditoriaMngForm
    {

        #region Factory Methods

        public AuditoriaSelectForm(Form parent)
            : this(parent, null) {}

        public AuditoriaSelectForm(Form parent, AuditoriaList lista)
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

