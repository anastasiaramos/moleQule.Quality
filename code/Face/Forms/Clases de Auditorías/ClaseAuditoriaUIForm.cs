using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Application;
using moleQule.Library.Quality;


namespace moleQule.Face.Quality
{
    public partial class ClaseAuditoriaUIForm : ClaseAuditoriaForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected ClaseAuditoria _entity;

        public override ClaseAuditoria Entity { get { return _entity; } set { _entity = value; } }
        public override ClaseAuditoriaInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected ClaseAuditoriaUIForm() : this(-1, true) { }

        public ClaseAuditoriaUIForm(bool isModal) : this(-1, isModal) { }

        public ClaseAuditoriaUIForm(long oid) : this(oid, true) { }

        public ClaseAuditoriaUIForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                ClaseAuditoria temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }

        }
        
        #endregion

        #region Style & Source


        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            View_TI.Enabled = false;
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Bar.Grow(string.Empty, "Datos");

            Datos_Auditorias.DataSource = Entity.TipoAuditorias;
            Bar.Grow(string.Empty, "ClaseAuditorias");
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void NuevaAction()
        {
            TipoAuditoriaAddForm form = new TipoAuditoriaAddForm(true, Entity);
            form.Show();

            Datos_Auditorias.ResetBindings(false);
        }

        protected override void EditarAction()
        {
            if (Datos_Auditorias.Current == null) return;

            TipoAuditoriaEditForm form = new TipoAuditoriaEditForm(true, Entity, Datos_Auditorias.Current as TipoAuditoria);
            form.Show();

            Datos_Auditorias.ResetBindings(false);
        }

        protected override void BorrarAction()
        {
            if (Datos_Auditorias.Current == null) return;

            _entity.TipoAuditorias.Remove(Datos_Auditorias.Current as TipoAuditoria);

            Datos_Auditorias.ResetBindings(false);
        }

        #endregion

        #region Events

        private void ClaseAuditoriaUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Entity.CloseSession();
        }

        #endregion

    }
}
