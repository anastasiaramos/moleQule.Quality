using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class AreaAddForm : AreaUIForm
    {

        #region Factory Methods

        public AreaAddForm() : this(true) {}

        public AreaAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.AREA_ADD_TITLE;
        }

        public AreaAddForm(Area source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.AREA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Area.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}