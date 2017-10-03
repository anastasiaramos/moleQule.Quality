using System;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeDiscrepanciaEditForm : InformeDiscrepanciaUIForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeDiscrepanciaEditForm";
		public new static Type Type { get { return typeof(InformeDiscrepanciaEditForm); } }

		#endregion
		
        #region Factory Methods

        public InformeDiscrepanciaEditForm(Auditoria auditoria, InformeDiscrepancia entity, Form parent)
            : base (entity.Oid, true, parent, null)
        {
            InitializeComponent();
            _entity = entity;
            _auditoria = auditoria;
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.INFORME_DISCREPANCIA_TITLE + " " + Entity.Codigo.ToUpper();
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
