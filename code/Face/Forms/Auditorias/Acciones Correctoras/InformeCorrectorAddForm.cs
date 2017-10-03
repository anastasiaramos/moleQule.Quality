using System;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeCorrectorAddForm : InformeCorrectorUIForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeCorrectorAddForm";
		public new static Type Type { get { return typeof(InformeCorrectorAddForm); } }

		#endregion
		
        #region Factory Methods

        public InformeCorrectorAddForm() : this(true) {}

        public InformeCorrectorAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INFORME_ACCION_CORRECTORA_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        public InformeCorrectorAddForm(Auditoria auditoria, Form parent)
            : base(-1, true, parent, auditoria)
        {
            InitializeComponent();
            _informe = _auditoria.Informes[_auditoria.Informes.Count - 1];
            _entity = _informe.Correctores.NewItem(_informe);
            SetFormData(); 
            this.Text = Resources.Labels.INFORME_ACCION_CORRECTORA_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        protected override void GetFormSourceData()
        {
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _entity.Titulo = _auditoria.TipoAuditoria + "/" + _entity.Numero;
            AuditoriaController.DoAction(_auditoria, AccionAuditoria.GENERAR_INFORME_ACCIONES_CORRECTORAS);
            _action_result = DialogResult.OK;
            Close();
        }

        protected override void CancelAction()
        {
            _informe.Correctores.Remove(_entity);
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
