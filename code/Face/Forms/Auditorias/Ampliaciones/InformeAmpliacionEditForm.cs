using System;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeAmpliacionEditForm : InformeAmpliacionUIForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeAmpliacionEditForm";
		public new static Type Type { get { return typeof(InformeAmpliacionEditForm); } }

		#endregion
		
        #region Factory Methods
        
        public InformeAmpliacionEditForm(Auditoria auditoria, InformeAmpliacion entity, Form parent)
            : base (entity.Oid, true, parent, null)
        {
            InitializeComponent();
            _entity = entity;
            _auditoria = auditoria;
            _informe = _auditoria.Informes.GetItem(_entity.OidInformeDiscrepancia);
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.INFORME_AMPLIACION_TITLE + " " + Entity.Codigo.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {

        }

        #endregion

        #region Actions

        protected override void CancelAction()
        {
            _entity.CancelEdit();
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}
