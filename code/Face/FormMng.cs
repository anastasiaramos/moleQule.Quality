using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality
{
    /// <summary>
    /// Clase base para manejo (apertura y cierre) de formularios
    /// Es único en el sistema (singleton)
    /// </summary>
    /// <remarks>
    /// Para utilizar el FormMng es necesario indicar cual será el MainForm padre de los formularios
    /// Este MainForm deberá ser un formulario heredado de MainFormBase
    /// </remarks>
    public class FormMng : IFormMng
    {

        #region Factory Methods

        /// <summary>
        /// Única instancia de la clase (Singleton)
        /// </summary>
        protected static FormMng _main;

        /// <summary>
        /// Unique FormMng Class Instance
        /// </summary>
        /// <remarks>
        /// Para utilizar el FormMng es necesario inicializar
        /// </remarks>
        public static FormMng Instance { get { return (_main != null) ? _main : new FormMng(); } }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMng()
		{
			// Singleton
			_main = this;
		}

        #endregion

        #region Business Methods

        /// <summary>
        /// Abre un nuevo manager para la entidad. Si no está abierto, lo crea, y si 
        /// lo está, lo muestra 
        /// </summary>
        /// <param name="formID">Identificador del formulario que queremos abrir</param>
        public void OpenForm(string formID) { OpenForm(formID, null, null); }
        public void OpenForm(string formID, object param) { OpenForm(formID, new object[1] { param }); }
        public void OpenForm(string formID, object[] param) { OpenForm(formID, param, null); }

        /// <summary>
        /// Abre un nuevo manager para la entidad. Si no está abierto, lo crea, y si 
        /// lo está, lo muestra 
        /// </summary>
        /// <param name="formID">Identificador del formulario que queremos abrir</param>
        /// <param name="parameters">Parámetro para el formulario</param>
        public void OpenForm(string formID, object[] parameters, Form parent)
        {
            try
            {
                switch (formID)
                {
                    case AreaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(AreaMngForm.Type))
                            {
                                AreaMngForm em = new AreaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case ActaComiteMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(ActaComiteMngForm.Type))
                            {
                                ActaComiteMngForm em = new ActaComiteMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case AuditoriaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(AuditoriaMngForm.Type))
                            {
                                AuditoriaMngForm em = new AuditoriaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case ClaseAuditoriaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(ClaseAuditoriaMngForm.Type))
                            {
                                ClaseAuditoriaMngForm em = new ClaseAuditoriaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case DepartamentoMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(DepartamentoMngForm.Type))
                            {
                                DepartamentoMngForm em = new DepartamentoMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case DiscrepanciaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(DiscrepanciaMngForm.Type))
                            {
                                DiscrepanciaMngForm em = new DiscrepanciaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                     case IncidenciaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(IncidenciaMngForm.Type))
                            {
                                IncidenciaMngForm em = new IncidenciaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case PlanAnualMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(PlanAnualMngForm.Type))
                            {
                                PlanAnualMngForm em = new PlanAnualMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;
                    case SeguimientoAuditoriasActionForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(SeguimientoAuditoriasActionForm.Type))
                            {
                                SeguimientoAuditoriasActionForm em = new SeguimientoAuditoriasActionForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    default:
                        {
                            throw new iQImplementationException(string.Format(moleQule.Face.Resources.Messages.FORM_NOT_FOUND, formID), string.Empty);
                        } 
                }
            }
            catch (iQImplementationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(iQExceptionHandler.GetAllMessages(ex), Application.ProductName);
            }
        }

        /// <summary>
        /// Devuelve un formulario hijo del tipo pasado como parámetro
        /// </summary>
        /// <param name="childType">Tipo de formulario</param>
        public object GetFormulario(Type childType) { return FormMngBase.Instance.GetFormulario(childType); }

        #endregion

    }
}
