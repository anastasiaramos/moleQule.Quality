using System;
using System.Windows.Forms;

using moleQule.Face;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class IncidenciaAddForm : IncidenciaUIForm
    {

        #region Attributes & Properties
		
        public new const string ID = "IncidenciaAddForm";
		public new static Type Type { get { return typeof(IncidenciaAddForm); } }

		#endregion
		
        #region Factory Methods

        public IncidenciaAddForm() : this(true) {}

        public IncidenciaAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INCIDENCIA_ADD_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        public IncidenciaAddForm(Incidencia source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            this.Text = Resources.Labels.INCIDENCIA_ADD_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        protected override void GetFormSourceData()
        {
            _entity = Incidencia.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}
