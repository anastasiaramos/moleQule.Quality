using System;
using System.Windows.Forms;

using moleQule.Library.Quality; 

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class DepartamentoAddForm : DepartamentoUIForm
    {

        #region Factory Methods

        public DepartamentoAddForm() : this(true) {}

        public DepartamentoAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.DEPARTAMENTO_ADD_TITLE;
        }

        public DepartamentoAddForm(Departamento source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.DEPARTAMENTO_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Departamento.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}