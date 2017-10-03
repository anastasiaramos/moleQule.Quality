namespace moleQule.Face.Quality
{
    partial class InformeAmpliacionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Datos_Ampliaciones = new System.Windows.Forms.BindingSource(this.components);
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ampliaciones_Grid = new System.Windows.Forms.DataGridView();
            this.Edit_BT = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDebida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Ampliaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ampliaciones_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(this.Edit_BT);
            this.PanelesV.Panel1.Controls.Add(this.Ampliaciones_Grid);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(1142, 551);
            this.PanelesV.SplitterDistance = 511;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(252, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(348, 6);
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
            this.Paneles2.Size = new System.Drawing.Size(1140, 37);
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(156, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.InformeAmpliacion);
            this.Datos.DataSourceChanged += new System.EventHandler(this.Datos_DataSourceChanged);
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(442, 36);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(93, 13);
            observacionesLabel.TabIndex = 17;
            observacionesLabel.Text = "Observaciones:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(233, 36);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(54, 13);
            numeroLabel.TabIndex = 16;
            numeroLabel.Text = "Número:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(12, 36);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 13;
            codigoLabel.Text = "Código:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(17, 83);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(43, 13);
            fechaLabel.TabIndex = 12;
            fechaLabel.Text = "Fecha:";
            // 
            // Datos_Ampliaciones
            // 
            this.Datos_Ampliaciones.DataSource = typeof(moleQule.Library.Quality.AmpliacionList);
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(541, 33);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(571, 67);
            this.observacionesTextBox.TabIndex = 19;
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(293, 33);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(100, 21);
            this.numeroTextBox.TabIndex = 18;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(66, 33);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(111, 21);
            this.codigoTextBox.TabIndex = 15;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(66, 79);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(111, 21);
            this.fechaDateTimePicker.TabIndex = 14;
            this.fechaDateTimePicker.Tag = "";
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
            this.groupBox1.Size = new System.Drawing.Size(1118, 121);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // Ampliaciones_Grid
            // 
            this.Ampliaciones_Grid.AllowUserToAddRows = false;
            this.Ampliaciones_Grid.AllowUserToDeleteRows = false;
            this.Ampliaciones_Grid.AllowUserToOrderColumns = true;
            this.Ampliaciones_Grid.AutoGenerateColumns = false;
            this.Ampliaciones_Grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Ampliaciones_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.Numero,
            this.FechaDebida,
            this.FechaCierre,
            this.dataGridViewTextBoxColumn2});
            this.Ampliaciones_Grid.DataSource = this.Datos_Ampliaciones;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Ampliaciones_Grid.DefaultCellStyle = dataGridViewCellStyle5;
            this.Ampliaciones_Grid.Location = new System.Drawing.Point(11, 138);
            this.Ampliaciones_Grid.Name = "Ampliaciones_Grid";
            this.Ampliaciones_Grid.ReadOnly = true;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Ampliaciones_Grid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Ampliaciones_Grid.Size = new System.Drawing.Size(1119, 328);
            this.Ampliaciones_Grid.TabIndex = 21;
            this.Ampliaciones_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Ampliaciones_Grid_DataError);
            this.Ampliaciones_Grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Ampliaciones_Grid_DataBindingComplete);
            // 
            // Edit_BT
            // 
            this.Edit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit_BT.Location = new System.Drawing.Point(489, 472);
            this.Edit_BT.Name = "Edit_BT";
            this.Edit_BT.Size = new System.Drawing.Size(162, 34);
            this.Edit_BT.TabIndex = 22;
            this.Edit_BT.Text = "Editar Ampliaciones";
            this.Edit_BT.UseVisualStyleBackColor = true;
            this.Edit_BT.Click += new System.EventHandler(this.Edit_BT_Click);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn8.HeaderText = "Código";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 80;
            // 
            // FechaDebida
            // 
            this.FechaDebida.DataPropertyName = "FechaDebida";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            this.FechaDebida.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaDebida.HeaderText = "Fecha Debida";
            this.FechaDebida.Name = "FechaDebida";
            this.FechaDebida.ReadOnly = true;
            this.FechaDebida.Width = 80;
            // 
            // FechaCierre
            // 
            this.FechaCierre.DataPropertyName = "FechaCierre";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.FechaCierre.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaCierre.HeaderText = "Fecha Cierre";
            this.FechaCierre.Name = "FechaCierre";
            this.FechaCierre.ReadOnly = true;
            this.FechaCierre.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Observaciones";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Observaciones";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 720;
            // 
            // InformeAmpliacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1142, 551);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "InformeAmpliacionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "InformeAmpliacionForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Ampliaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ampliaciones_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.BindingSource Datos_Ampliaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.TextBox numeroTextBox;
        protected System.Windows.Forms.DataGridView Ampliaciones_Grid;
        protected System.Windows.Forms.Button Edit_BT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDebida;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		

    }
}
