using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class ActaComiteEditForm : ActaComiteUIForm
    {

        #region Factory Methods

        public ActaComiteEditForm(long oid)
            : this(oid, true) { }

        public ActaComiteEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.ACTA_COMITE_EDIT_TITLE + " " + Entity.Titulo.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ActaComite.Get(oid);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

    }
}

