using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class ClaseAuditoriaAddForm : ClaseAuditoriaUIForm
    {

        #region Factory Methods

        public ClaseAuditoriaAddForm() : this(true) { }

        public ClaseAuditoriaAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CLASE_AUDITORIA_ADD_TITLE;
        }

        public ClaseAuditoriaAddForm(ClaseAuditoria source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.CLASE_AUDITORIA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = ClaseAuditoria.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}