using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class ActaComiteAddForm : ActaComiteUIForm
    {

        #region Factory Methods

        public ActaComiteAddForm() : this(true) { }

        public ActaComiteAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.ACTA_COMITE_ADD_TITLE;
        }

        public ActaComiteAddForm(ActaComite source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.ACTA_COMITE_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = ActaComite.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}