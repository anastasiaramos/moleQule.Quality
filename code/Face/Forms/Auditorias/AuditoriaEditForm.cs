using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class AuditoriaEditForm : AuditoriaUIForm
    {

        #region Factory Methods

        public AuditoriaEditForm(long oid)
            : this(oid, true) { }

        public AuditoriaEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.AUDITORIA_EDIT_TITLE;
            }

            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Auditoria.Get(oid, true);
            //AuditoriaController.CompruebaPlazos(_entity);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

    }
}

