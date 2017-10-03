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

    public partial class PlanAnualAddForm : PlanAnualUIForm
    {

        #region Factory Methods

        public PlanAnualAddForm() : this(true) { }

        public PlanAnualAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLAN_ANUAL_ADD_TITLE;
        }

        public PlanAnualAddForm(PlanAnual source)
            : base()
        {
            InitializeComponent();
            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLAN_ANUAL_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = PlanAnual.New();
            _entity.BeginEdit();
        }

        #endregion

        #region Buttons

        #endregion
    }
}

