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
    public partial class DepartamentoForm : ItemMngSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps; } }

        public virtual Departamento Entity { get { return null; } set { } }
        public virtual DepartamentoInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public DepartamentoForm() : this(-1, true) { }

        public DepartamentoForm(bool isModal) : this(-1, isModal) { }

        public DepartamentoForm(long oid) : this(oid, true) { }

        public DepartamentoForm(long oid, bool ismodal)
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

        #endregion

        #region Buttons

        #endregion

        #region Events

        #endregion

    }
}


