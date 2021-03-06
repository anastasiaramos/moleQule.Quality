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
    public partial class ActaComiteUIForm : ActaComiteForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected ActaComite _entity;

        public override ActaComite Entity { get { return _entity; } set { _entity = value; } }
        public override ActaComiteInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(true) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected ActaComiteUIForm() : this(-1, true) { }

        public ActaComiteUIForm(bool isModal) : this(-1, isModal) { }

        public ActaComiteUIForm(long oid) : this(oid, true) { }

        public ActaComiteUIForm(long oid, bool ismodal)
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

                ActaComite temp = _entity.Clone();
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
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Bar.Grow();
        }

        public override void RefreshSecondaryData()
        {
            Datos_Puntos.DataSource = _entity.PuntosActas;
            Bar.Grow();
        }
        
        #endregion

        #region Validation & Format


        #endregion

        #region Actions

        protected override void SaveAction()
        {
            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

        #region Events

        private void ActaComiteUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
             Entity.CloseSession();
        }

        #endregion

    }
}
