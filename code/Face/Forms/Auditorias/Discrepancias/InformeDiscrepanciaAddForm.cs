using System;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    public partial class InformeDiscrepanciaAddForm : InformeDiscrepanciaUIForm
    {

        #region Attributes & Properties
		
        public new const string ID = "InformeDiscrepanciaAddForm";
		public new static Type Type { get { return typeof(InformeDiscrepanciaAddForm); } }

		#endregion
		
        #region Factory Methods

        public InformeDiscrepanciaAddForm() : this(true) {}

        public InformeDiscrepanciaAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.INFORME_DISCREPANCIA_TITLE;
            _mf_type = ManagerFormType.MFAdd;
        }

        public InformeDiscrepanciaAddForm(Auditoria auditoria, Form parent)
            : base(-1, true, parent, auditoria)
        {
            InitializeComponent();
            _entity = _auditoria.Informes.NewItem(_auditoria);
            SetFormData(); 
            this.Text = Resources.Labels.INFORME_DISCREPANCIA_TITLE;
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
            AuditoriaController.DoAction(_auditoria, AccionAuditoria.GENERAR_INFORME_DISCREPANCIAS);
            _action_result = DialogResult.OK;
            Close();
        }

        protected override void CancelAction()
        {
            _auditoria.Informes.Remove(_entity);
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
