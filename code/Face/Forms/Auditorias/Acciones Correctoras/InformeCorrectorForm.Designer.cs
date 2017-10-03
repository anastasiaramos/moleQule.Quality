namespace moleQule.Face.Quality
{
    partial class InformeCorrectorForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Datos_AccionCorrectoras = new System.Windows.Forms.BindingSource(this.components);
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AccionesCorrectoras_Grid = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDebida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Edit_BT = new System.Windows.Forms.Button();
            observacionesLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_AccionCorrectoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccionesCorrectoras_Grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Edit_BT);
            this.PanelesV.Panel1.Controls.Add(this.AccionesCorrectoras_Grid);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(1155, 549);
            this.PanelesV.SplitterDistance = 509;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(252, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Size = new System.Drawing.Size(87, 23);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(348, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            this.Cancel_BT.Size = new System.Drawing.Size(87, 23);
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
            this.Paneles2.Size = new System.Drawing.Size(1153, 37);
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(156, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            this.Imprimir_Button.Size = new System.Drawing.Size(87, 23);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.InformeCorrector);
            this.Datos.DataSourceChanged += new System.EventHandler(this.Datos_DataSourceChanged);
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(488, 23);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(81, 13);
            observacionesLabel.TabIndex = 17;
            observacionesLabel.Text = "Observaciones:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(279, 23);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(47, 13);
            numeroLabel.TabIndex = 16;
            numeroLabel.Text = "Número:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(58, 23);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(43, 13);
            codigoLabel.TabIndex = 13;
            codigoLabel.Text = "Código:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(63, 70);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 12;
            fechaLabel.Text = "Fecha:";
            // 
            // Datos_AccionCorrectoras
            // 
            this.Datos_AccionCorrectoras.DataSource = typeof(moleQule.Library.Quality.AccionCorrectoraList);
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(587, 20);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(485, 67);
            this.observacionesTextBox.TabIndex = 19;
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(339, 20);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(100, 20);
            this.numeroTextBox.TabIndex = 18;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(112, 20);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(111, 20);
            this.codigoTextBox.TabIndex = 15;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(112, 66);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(111, 20);
            this.fechaDateTimePicker.TabIndex = 14;
            this.fechaDateTimePicker.Tag = "";
            // 
            // AccionesCorrectoras_Grid
            // 
            this.AccionesCorrectoras_Grid.AllowUserToAddRows = false;
            this.AccionesCorrectoras_Grid.AllowUserToDeleteRows = false;
            this.AccionesCorrectoras_Grid.AllowUserToOrderColumns = true;
            this.AccionesCorrectoras_Grid.AutoGenerateColumns = false;
            this.AccionesCorrectoras_Grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AccionesCorrectoras_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.Numero,
            this.Texto,
            this.FechaDebida,
            this.FechaCierre});
            this.AccionesCorrectoras_Grid.DataSource = this.Datos_AccionCorrectoras;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccionesCorrectoras_Grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.AccionesCorrectoras_Grid.Location = new System.Drawing.Point(11, 117);
            this.AccionesCorrectoras_Grid.Name = "AccionesCorrectoras_Grid";
            this.AccionesCorrectoras_Grid.ReadOnly = true;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccionesCorrectoras_Grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.AccionesCorrectoras_Grid.Size = new System.Drawing.Size(1131, 347);
            this.AccionesCorrectoras_Grid.TabIndex = 20;
            this.AccionesCorrectoras_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.AccionesCorrectoras_Grid_DataError);
            this.AccionesCorrectoras_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AccionesCorrectoras_Grid_DataBindingComplete);
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 80;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 80;
            // 
            // Texto
            // 
            this.Texto.DataPropertyName = "Texto";
            this.Texto.HeaderText = "Texto";
            this.Texto.Name = "Texto";
            this.Texto.ReadOnly = true;
            this.Texto.Width = 740;
            // 
            // FechaDebida
            // 
            this.FechaDebida.DataPropertyName = "FechaDebida";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.FechaDebida.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaDebida.HeaderText = "Fecha Debida";
            this.FechaDebida.Name = "FechaDebida";
            this.FechaDebida.ReadOnly = true;
            this.FechaDebida.Width = 80;
            // 
            // FechaCierre
            // 
            this.FechaCierre.DataPropertyName = "FechaCierre";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.FechaCierre.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaCierre.HeaderText = "Fecha Cierre";
            this.FechaCierre.Name = "FechaCierre";
            this.FechaCierre.ReadOnly = true;
            this.FechaCierre.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.observacionesTextBox);
            this.groupBox1.Controls.Add(observacionesLabel);
            this.groupBox1.Controls.Add(this.fechaDateTimePicker);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Controls.Add(numeroLabel);
            this.groupBox1.Controls.Add(this.codigoTextBox);
            this.groupBox1.Controls.Add(this.numeroTextBox);
            this.groupBox1.Controls.Add(codigoLabel);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 100);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // Edit_BT
            // 
            this.Edit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit_BT.Location = new System.Drawing.Point(440, 470);
            this.Edit_BT.Name = "Edit_BT";
            this.Edit_BT.Size = new System.Drawing.Size(273, 34);
            this.Edit_BT.TabIndex = 22;
            this.Edit_BT.Text = "Editar Acciones Correctoras";
            this.Edit_BT.UseVisualStyleBackColor = true;
            // 
            // InformeCorrectorForm
            // 
            this.ClientSize = new System.Drawing.Size(1155, 549);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "InformeCorrectorForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "InformeCorrectorForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_AccionCorrectoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccionesCorrectoras_Grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.BindingSource Datos_AccionCorrectoras;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.DataGridView AccionesCorrectoras_Grid;
        protected System.Windows.Forms.Button Edit_BT;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDebida;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCierre;
		

    }
}
