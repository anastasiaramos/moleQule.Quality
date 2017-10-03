using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class AreaEditForm : AreaUIForm
    {

        #region Factory Methods

        public AreaEditForm(long oid)
            : this(oid, true) { }

        public AreaEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.AREA_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }

            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Area.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

    }
}

