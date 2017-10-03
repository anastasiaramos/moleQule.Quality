using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Quality;
using moleQule.Library.Application.Tools;

namespace moleQule.Face.Quality
{
    public partial class PlanAnualUIForm : PlanAnualForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected PlanAnual _entity;

        public override PlanAnual Entity { get { return _entity; } set { _entity = value; } }
        public override PlanAnualInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(true) : null; } }

        /// <summary>
        /// Devuelve el OID de la clase activa seleccionada en la fila actual del lunes
        /// </summary>
        /// <returns></returns>
        public long ActiveOID
        {
            get
            {
                return Clases_Grid.CurrentRow != null ? ((Plan_Tipo)Datos_Planes_Tipos.Current).OidTipo : 0;
            }
        }

        protected override void OpenClaseAuditoriaForm()
        {
            if (ActiveOID == 0)
                return;
            TipoAuditoriaInfo tipo = _tipos.GetItem(ActiveOID);
            ClaseAuditoriaInfo clase = _clases.GetItem(tipo.OidClaseAuditoria);
            Plan_TipoAuditoriaEditForm form = new Plan_TipoAuditoriaEditForm(clase, tipo,
                Datos_Planes_Tipos.Current as Plan_Tipo);
            if (form.Entity != null)
                form.ShowDialog();
        }


        /// <summary>
        /// Añade una lista de valores de combobox a la lista de combos
        /// </summary>
        protected override void AddComboList()
        {
            if (_source_list.CombosListCount < Clases_Grid.Rows.Count - 1)
            {
                for (long i = _source_list.CombosListCount; i < Clases_Grid.Rows.Count - 1; i++)
                {
                    _source_list.AddCombosList(((Plan_Tipo)Clases_Grid.Rows[(int)i].DataBoundItem).OidClase);
                    ((DataGridViewComboBoxCell)(Clases_Grid["TipoAuditoria_CBC", (int)i])).DataSource = _source_list.GetCombosList((int)i);

                }
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected PlanAnualUIForm() : this(-1, true) { }

        public PlanAnualUIForm(bool isModal) : this(-1, isModal) { }

        public PlanAnualUIForm(long oid) : this(oid, true) { }

        public PlanAnualUIForm(long oid, bool ismodal)
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

                PlanAnual temp = _entity.Clone();
                temp.ApplyEdit();

                foreach (Plan_Tipo item in _entity.PlanesTipos)
                {
                    if (item.OidTipo == 0)
                    {
                        MessageBox.Show(Resources.Messages.PLAN_TIPO_NO_VALIDO,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

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
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
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

            Csla.SortedBindingList<Plan_Tipo> lista = new Csla.SortedBindingList<Plan_Tipo>(_entity.PlanesTipos);
            lista.ApplySort("Orden", ListSortDirection.Ascending);

            Datos_Planes_Tipos.DataSource = lista;
            Bar.Grow();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            foreach (DataGridViewRow row in Clases_Grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    //_source_list_t.AddCombosList(((ClaseTeorica)row.DataBoundItem).OidModulo);
                    ((DataGridViewComboBoxCell)(row.Cells["TipoAuditoria_CBC"])).DataSource = _source_list.GetCombosList(row.Index);

                    TipoAuditoriaInfo tipo = _tipos.GetItem(((Plan_Tipo)row.DataBoundItem).OidTipo);
                    if (tipo != null)
                    {
                        ClaseAuditoriaInfo clase = _clases.GetItem(tipo.OidClaseAuditoria);
                        row.Cells[0].Value = clase.Tipo;
                        row.Cells[1].Value = clase.Numero;
                    }
                }
            }                   
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

        private void PlanAnualUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Entity.CloseSession();
        }

        #endregion        
    }
}

