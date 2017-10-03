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


namespace moleQule.Face.Quality
{
    public partial class ClaseAuditoriaForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

        public virtual ClaseAuditoria Entity { get { return null; } set { } }
        public virtual ClaseAuditoriaInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public ClaseAuditoriaForm() : this(-1, true) { }

        public ClaseAuditoriaForm(bool isModal) : this(-1, isModal) { }

        public ClaseAuditoriaForm(long oid) : this(oid, true) { }

        public ClaseAuditoriaForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            List<string> visibles = new List<string>();

            visibles.Add(Nombre.Name);
            visibles.Add(Codigo.Name);
            visibles.Add(Numero.Name);

            ControlTools.ShowDataGridColumns(Auditorias_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Auditorias_Grid.Width - vs.Width
                                                - Auditorias_Grid.RowHeadersWidth
                                                - Auditorias_Grid.Columns[Codigo.Name].Width
                                                - Auditorias_Grid.Columns[Numero.Name].Width);

            Auditorias_Grid.Columns[Nombre.Name].Width = (int)(rowWidth * 0.995);
            Auditorias_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions
        
        protected virtual void NuevaAction() { }
        protected virtual void EditarAction() { }
        protected virtual void BorrarAction() { }
        protected virtual void VerAction() { }

        #endregion

        #region Buttons

        private void Add_TI_Click(object sender, EventArgs e)
        {
            NuevaAction();
        }

        private void Edit_TI_Click(object sender, EventArgs e)
        {
            EditarAction();
        }

        private void View_TI_Click(object sender, EventArgs e)
        {
            VerAction();
        }

        private void Delete_TI_Click(object sender, EventArgs e)
        {
            BorrarAction();
        }

        #endregion

        #region Events

        private void Auditorias_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this is ClaseAuditoriaViewForm)
                VerAction();
            else
                EditarAction();
        }

        #endregion

    }
}


