namespace moleQule.Face.Quality
{
    partial class ClaseAuditoriaForm
    {
        /// <summary>
        /// Variable del dise√±ador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se est√©n utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region C√≥digo generado por el Dise√±ador de Windows Forms

        /// <summary>
        /// M√©todo necesario para admitir el Dise√±ador. No se puede modificar
        /// el contenido del m√©todo con el editor de c√≥digo.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label tipoLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClaseAuditoriaForm));
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.tipoTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.Datos_Auditorias = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TipoAuditoria_SC = new System.Windows.Forms.SplitContainer();
            this.Tool_Strip = new System.Windows.Forms.ToolStrip();
            this.Add_TI = new System.Windows.Forms.ToolStripButton();
            this.Edit_TI = new System.Windows.Forms.ToolStripButton();
            this.View_TI = new System.Windows.Forms.ToolStripButton();
            this.Delete_TI = new System.Windows.Forms.ToolStripButton();
            this.Auditorias_Grid = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            codigoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            tipoLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Auditorias)).BeginInit();
            this.TipoAuditoria_SC.Panel1.SuspendLayout();
            this.TipoAuditoria_SC.Panel2.SuspendLayout();
            this.TipoAuditoria_SC.SuspendLayout();
            this.Tool_Strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Auditorias_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.TipoAuditoria_SC);
            this.PanelesV.Panel1.Controls.Add(this.label1);
            this.PanelesV.Panel1.Controls.Add(numeroLabel);
            this.PanelesV.Panel1.Controls.Add(this.numeroTextBox);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(this.codigoTextBox);
            this.PanelesV.Panel1.Controls.Add(tipoLabel);
            this.PanelesV.Panel1.Controls.Add(codigoLabel);
            this.PanelesV.Panel1.Controls.Add(this.tipoTextBox);
            this.PanelesV.Panel1.Controls.Add(this.nombreTextBox);
            this.PanelesV.Panel1.Controls.Add(nombreLabel);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(806, 661);
            this.PanelesV.SplitterDistance = 620;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(255, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(345, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Paneles2
            // 
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(804, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(165, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.ClaseAuditoria);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(194, 249);
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoLabel.Location = new System.Drawing.Point(63, 47);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "CÛdigo:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(222, 81);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(54, 13);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre*:";
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoLabel.Location = new System.Drawing.Point(239, 44);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(37, 13);
            tipoLabel.TabIndex = 4;
            tipoLabel.Text = "Tipo*:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            observacionesLabel.Location = new System.Drawing.Point(42, 513);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 6;
            observacionesLabel.Text = "Observaciones:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numeroLabel.Location = new System.Drawing.Point(53, 84);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(54, 13);
            numeroLabel.TabIndex = 8;
            numeroLabel.Text = "N˙mero*:";
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(113, 81);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(65, 21);
            this.numeroTextBox.TabIndex = 3;
            this.numeroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(130, 510);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(633, 66);
            this.observacionesTextBox.TabIndex = 5;
            // 
            // tipoTextBox
            // 
            this.tipoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Tipo", true));
            this.tipoTextBox.Location = new System.Drawing.Point(282, 41);
            this.tipoTextBox.Name = "tipoTextBox";
            this.tipoTextBox.Size = new System.Drawing.Size(127, 21);
            this.tipoTextBox.TabIndex = 2;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(282, 78);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(464, 21);
            this.nombreTextBox.TabIndex = 4;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(113, 44);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(65, 21);
            this.codigoTextBox.TabIndex = 1;
            this.codigoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Datos_Auditorias
            // 
            this.Datos_Auditorias.DataSource = typeof(moleQule.Library.Quality.TipoAuditoriaInfo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "TIPOS DE AUDITORÕAS";
            // 
            // TipoAuditoria_SC
            // 
            this.TipoAuditoria_SC.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.TipoAuditoria_SC.IsSplitterFixed = true;
            this.TipoAuditoria_SC.Location = new System.Drawing.Point(35, 147);
            this.TipoAuditoria_SC.Name = "TipoAuditoria_SC";
            this.TipoAuditoria_SC.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // TipoAuditoria_SC.Panel1
            // 
            this.TipoAuditoria_SC.Panel1.Controls.Add(this.Tool_Strip);
            // 
            // TipoAuditoria_SC.Panel2
            // 
            this.TipoAuditoria_SC.Panel2.Controls.Add(this.Auditorias_Grid);
            this.TipoAuditoria_SC.Size = new System.Drawing.Size(741, 321);
            this.TipoAuditoria_SC.SplitterDistance = 34;
            this.TipoAuditoria_SC.TabIndex = 12;
            // 
            // Tool_Strip
            // 
            this.Tool_Strip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Tool_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add_TI,
            this.Edit_TI,
            this.View_TI,
            this.Delete_TI});
            this.Tool_Strip.Location = new System.Drawing.Point(0, 0);
            this.Tool_Strip.Name = "Tool_Strip";
            this.Tool_Strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.HelpProvider.SetShowHelp(this.Tool_Strip, true);
            this.Tool_Strip.Size = new System.Drawing.Size(741, 39);
            this.Tool_Strip.TabIndex = 3;
            this.Tool_Strip.Text = "Imprimir";
            // 
            // Add_TI
            // 
            this.Add_TI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Add_TI.Image = global::moleQule.Face.Quality.Properties.Resources.add;
            this.Add_TI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Add_TI.Name = "Add_TI";
            this.Add_TI.Size = new System.Drawing.Size(36, 36);
            this.Add_TI.Text = "Nuevo";
            this.Add_TI.Click += new System.EventHandler(this.Add_TI_Click);
            // 
            // Edit_TI
            // 
            this.Edit_TI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Edit_TI.Image = global::moleQule.Face.Quality.Properties.Resources.edit;
            this.Edit_TI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Edit_TI.Name = "Edit_TI";
            this.Edit_TI.Size = new System.Drawing.Size(36, 36);
            this.Edit_TI.Text = "Editar";
            this.Edit_TI.Click += new System.EventHandler(this.Edit_TI_Click);
            // 
            // View_TI
            // 
            this.View_TI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.View_TI.Image = global::moleQule.Face.Quality.Properties.Resources.view;
            this.View_TI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.View_TI.Name = "View_TI";
            this.View_TI.Size = new System.Drawing.Size(36, 36);
            this.View_TI.Text = "Ver";
            this.View_TI.Click += new System.EventHandler(this.View_TI_Click);
            // 
            // Delete_TI
            // 
            this.Delete_TI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Delete_TI.Image = global::moleQule.Face.Quality.Properties.Resources.delete;
            this.Delete_TI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete_TI.Name = "Delete_TI";
            this.Delete_TI.Size = new System.Drawing.Size(36, 36);
            this.Delete_TI.Text = "Borrar";
            this.Delete_TI.Click += new System.EventHandler(this.Delete_TI_Click);
            // 
            // Auditorias_Grid
            // 
            this.Auditorias_Grid.AllowUserToAddRows = false;
            this.Auditorias_Grid.AllowUserToOrderColumns = true;
            this.Auditorias_Grid.AutoGenerateColumns = false;
            this.Auditorias_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Numero,
            this.Nombre});
            this.Auditorias_Grid.DataSource = this.Datos_Auditorias;
            this.Auditorias_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Auditorias_Grid.Location = new System.Drawing.Point(0, 0);
            this.Auditorias_Grid.MultiSelect = false;
            this.Auditorias_Grid.Name = "Auditorias_Grid";
            this.Auditorias_Grid.ReadOnly = true;
            this.Auditorias_Grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Auditorias_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Auditorias_Grid.Size = new System.Drawing.Size(741, 283);
            this.Auditorias_Grid.TabIndex = 10;
            this.Auditorias_Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Auditorias_Grid_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "CÛdigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "N˙mero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 500;
            // 
            // ClaseAuditoriaForm
            // 
            this.ClientSize = new System.Drawing.Size(806, 661);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClaseAuditoriaForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ClaseAuditoriaForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Auditorias)).EndInit();
            this.TipoAuditoria_SC.Panel1.ResumeLayout(false);
            this.TipoAuditoria_SC.Panel1.PerformLayout();
            this.TipoAuditoria_SC.Panel2.ResumeLayout(false);
            this.TipoAuditoria_SC.ResumeLayout(false);
            this.Tool_Strip.ResumeLayout(false);
            this.Tool_Strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Auditorias_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.TextBox tipoTextBox;
        protected System.Windows.Forms.BindingSource Datos_Auditorias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer TipoAuditoria_SC;
        protected System.Windows.Forms.DataGridView Auditorias_Grid;
        protected System.Windows.Forms.ToolStrip Tool_Strip;
        protected System.Windows.Forms.ToolStripButton Add_TI;
        protected System.Windows.Forms.ToolStripButton Edit_TI;
        protected System.Windows.Forms.ToolStripButton View_TI;
        protected System.Windows.Forms.ToolStripButton Delete_TI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}
