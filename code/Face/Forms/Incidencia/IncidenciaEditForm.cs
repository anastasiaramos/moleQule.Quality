using System;
using System.Windows.Forms;

using moleQule.Face;

using moleQule.Library.Quality;



namespace moleQule.Face.Quality
{
    public partial class IncidenciaEditForm : IncidenciaUIForm
    {

        #region Attributes & Properties
		
        public new const string ID = "IncidenciaEditForm";
		public new static Type Type { get { return typeof(IncidenciaEditForm); } }

		#endregion
		
        #region Factory Methods

        public IncidenciaEditForm(long oid)
            : this(oid, true) { }

        public IncidenciaEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.INCIDENCIA_EDIT_TITLE + " " + Entity.Texto.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Incidencia.Get(oid);
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion

    }
}
