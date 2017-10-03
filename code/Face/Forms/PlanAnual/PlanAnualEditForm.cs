using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Quality; 

using moleQule.Face;

namespace moleQule.Face.Quality
{
    public partial class PlanAnualEditForm : PlanAnualUIForm
    {

        #region Factory Methods

        public PlanAnualEditForm(long oid)
            : this(oid, true) { }

        public PlanAnualEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.PLAN_ANUAL_EDIT_TITLE + " " + Entity.Nombre.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = PlanAnual.Get(oid, true);
            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        #endregion

        #region Buttons

        #endregion

    }
}

