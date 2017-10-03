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
    public partial class AreaForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

        public virtual Area Entity { get { return null; } set { } }
        public virtual AreaInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public AreaForm() : this(-1, true) { }

        public AreaForm(bool isModal) : this(-1, isModal) { }

        public AreaForm(long oid) : this(oid, true) { }

        public AreaForm(long oid, bool ismodal)
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


    }
}


