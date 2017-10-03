using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using molApp.Library.Modules.Quality;


namespace molApp.Face.Modules.Quality
{
	public partial class PlanAnualMngForm : EntityMngSkinForm
	{

		#region Business Methods

		public const string ID = "PlanAnualMngForm";
		public static Type Type { get { return typeof(PlanAnualMngForm); } }

		protected override int BarSteps { get { return 3; } }

		/// <summary>
		///  Lista de objetos de sólo lectura
		/// </summary>
		private PlanAnualList _lista;

		/// <summary>
		///  Lista filtrada de sólo lectura
		/// </summary>
		private PlanAnualList _lista_filtrada = null;

		/// <summary>
		/// Devuelve el OID del objeto activo seleccionado de la tabla
		/// </summary>
		/// <returns></returns>
		public override long ActiveOID
		{
			get
			{
				return Datos.Current != null ? ((PlanAnualInfo)Datos.Current).Oid : -1;
			}
		}

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public PlanAnualInfo ActiveItem
        {
            get
            {
                if (Datos.Current != null)
                    return (PlanAnualInfo)Datos.Current;
                else
                    return null;
            }
        }

		#endregion

		#region Factory Methods

		public PlanAnualMngForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Autorizacion

		/// <summary>Aplica las reglas de validación de usuarios al formulario.
		/// <returns>void</returns>
		/// </summary>
		protected override void ApplyAuthorizationRules()
		{
			Tabla.Visible = PlanAnual.CanGetObject();
			Add_Button.Enabled = PlanAnual.CanAddObject();
			Edit_Button.Enabled = PlanAnual.CanEditObject();
			Delete_Button.Enabled = PlanAnual.CanDeleteObject();
			Copy_Button.Enabled = PlanAnual.CanAddObject();
			View_Button.Enabled = PlanAnual.CanGetObject();
		}

		#endregion

		#region Style & Source

		/// <summary>Formatea los controles del formulario
		/// <returns>void</returns>
		/// </summary>
		public override void FormatControls()
		{
			base.FormatControls();

			List<string> visibles = new List<string>();

			visibles.Add(Nombre.Name);
			visibles.Add(Codigo.Name);
            visibles.Add(Edicion.Name);
            visibles.Add(Revision.Name);
            visibles.Add(Fecha.Name);
			visibles.Add(Observaciones.Name);

			ControlTools.ShowDataGridColumns(Tabla, visibles);

			VScrollBar vs = new VScrollBar();

			int rowWidth = (int)(Tabla.Width - vs.Width
												- Tabla.RowHeadersWidth
												- Tabla.Columns[Codigo.Name].Width
                                                - Tabla.Columns[Edicion.Name].Width
                                                - Tabla.Columns[Revision.Name].Width
                                                - Tabla.Columns[Fecha.Name].Width);

            Tabla.Columns[Nombre.Name].Width = (int)(rowWidth * 0.495);
			Tabla.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.495);
		}

		/// <summary>
		/// Toma la lista de bancos de la base de datos y rellena la tabla.
		/// </summary>
		protected override void RefreshMainData()
		{
			_lista = PlanAnualList.GetList(false);
			Bar.Grow("PlanAnuales");

			Datos_Planes.DataSource = PlanAnualList.SortList(_lista,
														"Codigo",
														this.GetGridSortDirection(Tabla));
			Bar.FillUp("Ordenar Lista");
		}


		/// <summary>
		/// Selecciona un elemento de la tabla
		/// </summary>
		/// <param name="oid">Identificar del elemento</param>
		protected override void Select(long oid)
		{
			int foundIndex = Datos.IndexOf(PlanAnualList.GetList(false).GetItem(oid));
			Datos.Position = foundIndex;
		}

		/// <summary>
		/// Filtra la tabla
		/// </summary>
		/// <param name="oid">Identificar del elemento</param>
		protected override void Filter(object filtro)
		{
			_lista_filtrada = ((PlanAnualList)filtro).Clone();

			if (Filtros.SelectedTab != Filtros.TabPages["Advanced_TP"])
				Filtros.SelectedTab = Filtros.TabPages["Advanced_TP"];
			else
			{
				try
				{
					Datos.DataSource =
						PlanAnualList.SortList(_lista_filtrada, "Codigo", ListSortDirection.Ascending);
				}
				catch (Exception)
				{
					Datos.DataSource = _lista;
				}
			}
		}

		/// <summary>
		/// Aplica el filtro correspondiente según la pestaña
		/// </summary>
		protected override void ApplyFilter()
		{
			switch (Filtros.SelectedTab.Name)
			{
				case "Todos_TP":
					{
                        RefreshMainData();
					} break;

				case "Advanced_TP":
					{
						try
						{
							Datos_Planes.DataSource =
								PlanAnualList.SortList(_lista_filtrada, "Codigo", ListSortDirection.Ascending);
						}
						catch (Exception)
						{
							Datos_Planes.DataSource = _lista;
						}

                    } break;
                case "Nombre_TP":
                    {
                        try
                        {
                            CriteriaEx criteria = PlanAnual.GetCriteria(PlanAnual.OpenSession());
                            criteria.AddStartsWith("Nombre", ActiveItem.Nombre[0].ToString());
                            _lista = PlanAnualList.GetList(criteria);
                            Datos_Planes.DataSource = PlanAnualList.SortList(_lista,
                                                                    "Codigo",
                                                                    ListSortDirection.Ascending);
                        }
                        catch (Exception)
                        {
                            _lista = null;
                        }

                    } break;

			}
		}


		#endregion

		#region Buttons

		/// <summary>
		/// Abre el formulario para añadir item
		/// <returns>void</returns>
		/// </summary>
		public override void OpenAddForm()
		{

			try
			{
				AddForm(new PlanAnualAddForm());
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(ex.BusinessException.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
		}

		///// <summary>
		///// Abre el formulario para ver item
		///// <returns>void</returns>
		///// </summary>
		public override void OpenViewForm()
		{

			try
			{
				AddForm(new PlanAnualViewForm(ActiveOID));
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(ex.BusinessException.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
		}

		///// <summary>
		///// Abre el formulario para editar item
		///// <returns>void</returns>
		///// </summary>
		public override void OpenEditForm()
		{

			try
			{
                PlanAnualEditForm form = new PlanAnualEditForm(ActiveOID);
                if (form.EntityInfo != null)
                    AddForm(form);
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(ex.BusinessException.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
		}

		///// <summary>
		///// Abre el formulario para borrar item
		///// <returns>void</returns>
		///// </summary>
		public override void DeleteObject(long oid)
		{

			if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
								moleQule.Face.Resources.Labels.ADVISE_TITLE,
								MessageBoxButtons.YesNoCancel,
								MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
                    PlanAnualInfo instructor = PlanAnualInfo.Get(oid, true);
                    //if (instructor != null
                    //    && instructor.Sesiones.Count == 0
                    //    && instructor.Examenes.Count == 0)
                        PlanAnual.Delete(oid);
                    //else
                    //    MessageBox.Show("No es posible eliminar al instructor seleccionado.\n"
                    //                    + "Es posible que tenga sesiones asociados en algún horario o exámenes creados por este instructor.\n"
                    //                    + "Debe modificarlas antes de continuar.");

					//Se eliminan todos los formularios de ese objeto
					foreach (EntityDriverForm form in _list_active_form)
					{
						if (form is ItemMngBaseForm)
						{
							if (((ItemMngBaseForm)form).Oid == oid)
							{
								form.Dispose();
								break;
							}
						}
					}
				}
				catch (DataPortalException ex)
				{
					MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
				}
				finally
				{
					RefreshList();
				}
			}
		}

		///// <summary>Duplica un objeto y abre el formulario para editar item
		///// <returns>void</returns>
		///// </summary>
		public override void DuplicateObject(long oid)
		{
			try
			{
                PlanAnual old = PlanAnual.Get(oid);
                PlanAnual dup = old.CloneAsNew();
                old.CloseSession();

                AddForm(new PlanAnualAddForm(dup));
			}
			catch (iQException ex)
			{
				MessageBox.Show(ex.Message,
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (DataPortalException ex)
			{
				MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message,
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}

			RefreshList();
		}

		public override void OpenLocalizeForm()
		{

			try
			{
                PlanAnualLocalizeForm form = new PlanAnualLocalizeForm();
                form.Lista = _lista;
                form.SortProperty = this.GetGridSortProperty(Tabla);
                form.SortDirection = this.GetGridSortDirection(Tabla);
                AddForm(form);
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(ex.BusinessException.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
								moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
		}


		///// <summary>Imprime la lista del objetos
		///// <returns>void</returns>
		///// </summary>
		//public override void PrintList()
		//{
		//    ClienteReportMng reportMng = new ClienteReportMng(AppContext.ActiveSchema);

		//    PlanAnualListRpt report = reportMng.GetPlanAnualListReport(PlanAnualList.GetList((IList<PlanAnualInfo>)Datos.List));

		//    if (report != null)
		//    {
		//        ReportViewer.SetReport(report);
		//        ReportViewer.ShowDialog();
		//    }
		//    else
		//    {
		//        MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
		//                        Labels.EMPTY_REPORT,
		//                        MessageBoxButtons.OK,
		//                        MessageBoxIcon.Exclamation);
		//    }
		//}

		#endregion

		#region Events

		private void PlanAnualMngForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			DataGridViewColumn col;

			if (Tabla.CurrentCell == null)
			{
				if (Tabla.SortedColumn != null)
					col = Tabla.SortedColumn;
				else
					col = Tabla.Columns[0];
			}
			else
				col = Tabla.Columns[Tabla.CurrentCell.ColumnIndex];

			if (col.ValueType != null)
			{
				if (col.ValueType.Name == "Int32") return;
				if (col.ValueType.Name == "Int64") return;
				if (col.ValueType.Name == "Single") return;
				if (col.ValueType.Name == "Double") return;

				string car = e.KeyChar.ToString();
				CriteriaEx criteria = PlanAnual.GetCriteria(PlanAnual.OpenSession());

				criteria.AddStartsWith(col.DataPropertyName, car);

				// Buscamos las palabras que empiecen por el caracter
				PlanAnualList lista = PlanAnualList.GetList(criteria);
				SortedBindingList<PlanAnualInfo> list =
					PlanAnualList.GetSortedList(lista, col.DataPropertyName, ListSortDirection.Ascending);

				int foundIndex;

				// Nos situamos en la primera aparicion de esa lista en la 
				// que se muestra. Esto se hace pq se ha consultado la bd y no la lista actual
				// lo que puede dar lugar a inconsistencias si otro usuario a cambiado la bd
				foreach (PlanAnualInfo cli in list)
				{
					foundIndex = Datos.IndexOf(cli);
					if (foundIndex != -1)
					{
						Datos.Position = foundIndex;
						break;
					}
				}
			}
		}

		private void Tabla_DoubleClick(object sender, EventArgs e)
		{
			OpenViewForm();
		}

		#endregion
	}
}
