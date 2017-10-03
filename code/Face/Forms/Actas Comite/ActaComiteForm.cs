using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Quality;
using moleQule.Library.Quality.Reports;
using moleQule.Library.Application.Tools;
using moleQule.Library.Hipatia;

using moleQule.Face.Hipatia;

namespace moleQule.Face.Quality
{
    public partial class ActaComiteForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

        public virtual ActaComite Entity { get { return null; } set { } }
        public virtual ActaComiteInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public ActaComiteForm() : this(-1, true) { }

        public ActaComiteForm(bool isModal) : this(-1, isModal) { }

        public ActaComiteForm(long oid) : this(oid, true) { }

        public ActaComiteForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source


        #endregion

        #region Validation & Format

        #endregion

        #region Print

        protected override void PrintAction()
        {
            moleQule.Library.Application.Tools.WordExporter word = new moleQule.Library.Application.Tools.WordExporter();

            word.ExportActaComite(EntityInfo);
        }


        /// <summary>
        /// Implementa Docs_BT_Click
        /// </summary>
        protected override void DocumentsAction()
        {
            try
            {
                AgenteEditForm form = new AgenteEditForm(typeof(ActaComite), EntityInfo as IAgenteHipatia);
                form.ShowDialog();
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(typeof(ActaComite), EntityInfo as IAgenteHipatia);
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Buttons

        private void Edit_BT_Click(object sender, EventArgs e)
        {
            PuntoActaActionForm form = new PuntoActaActionForm(Entity);
            form.ShowDialog();
        }

        #endregion

        #region Events

        #endregion

    }
}


