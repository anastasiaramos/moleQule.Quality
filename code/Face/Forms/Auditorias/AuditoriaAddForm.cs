using System;
using System.Windows.Forms;

using moleQule.Library.Quality;

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class AuditoriaAddForm : AuditoriaUIForm
    {

        #region Factory Methods

        public AuditoriaAddForm() : this(true) { }

        public AuditoriaAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.AUDITORIA_ADD_TITLE;
        }

        public AuditoriaAddForm(Auditoria source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.AUDITORIA_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Auditoria.New();
            AuditoriaController.SetEstado(_entity, EstadoAuditoria.CREADA, _entity.OidAuditor);
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

         #endregion
    }
}