namespace moleQule.Face.Quality
{
    partial class ActaComiteForm
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
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label revisionLabel;
            System.Windows.Forms.Label tituloLabel;
            System.Windows.Forms.Label motivoLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActaComiteForm));
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.revisionTextBox = new System.Windows.Forms.TextBox();
            this.tituloTextBox = new System.Windows.Forms.TextBox();
            this.motivoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Datos_Puntos = new System.Windows.Forms.BindingSource(this.components);
            this.Puntos_Grid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Edit_BT = new System.Windows.Forms.Button();
            codigoLabel = new System.Windows.Forms.Label();
            revisionLabel = new System.Windows.Forms.Label();
            tituloLabel = new System.Windows.Forms.Label();
            motivoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Puntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Puntos_Grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.Edit_BT);
            this.PanelesV.Panel1.Controls.Add(this.label1);
            this.PanelesV.Panel1.Controls.Add(this.Puntos_Grid);
            this.PanelesV.Panel1.Controls.Add(codigoLabel);
            this.PanelesV.Panel1.Controls.Add(this.codigoTextBox);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(708, 605);
            this.PanelesV.SplitterDistance = 564;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(255, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Size = new System.Drawing.Size(87, 23);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(345, 6);
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
            this.Paneles2.Size = new System.Drawing.Size(706, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Enabled = true;
            this.Imprimir_Button.Location = new System.Drawing.Point(165, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            this.Imprimir_Button.Size = new System.Drawing.Size(87, 23);
            this.Imprimir_Button.Visible = true;
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(201, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            this.Docs_BT.Visible = true;
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.ActaComite);
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(48, 45);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // revisionLabel
            // 
            revisionLabel.AutoSize = true;
            revisionLabel.Location = new System.Drawing.Point(243, 33);
            revisionLabel.Name = "revisionLabel";
            revisionLabel.Size = new System.Drawing.Size(51, 13);
            revisionLabel.TabIndex = 2;
            revisionLabel.Text = "Revisión:";
            // 
            // tituloLabel
            // 
            tituloLabel.AutoSize = true;
            tituloLabel.Location = new System.Drawing.Point(33, 75);
            tituloLabel.Name = "tituloLabel";
            tituloLabel.Size = new System.Drawing.Size(37, 13);
            tituloLabel.TabIndex = 4;
            tituloLabel.Text = "Título:";
            // 
            // motivoLabel
            // 
            motivoLabel.AutoSize = true;
            motivoLabel.Location = new System.Drawing.Point(27, 120);
            motivoLabel.Name = "motivoLabel";
            motivoLabel.Size = new System.Drawing.Size(43, 13);
            motivoLabel.TabIndex = 6;
            motivoLabel.Text = "Motivo:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(463, 33);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 8;
            fechaLabel.Text = "Fecha:";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(102, 42);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(100, 21);
            this.codigoTextBox.TabIndex = 1;
            // 
            // revisionTextBox
            // 
            this.revisionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Revision", true));
            this.revisionTextBox.Location = new System.Drawing.Point(307, 30);
            this.revisionTextBox.Name = "revisionTextBox";
            this.revisionTextBox.Size = new System.Drawing.Size(100, 21);
            this.revisionTextBox.TabIndex = 3;
            // 
            // tituloTextBox
            // 
            this.tituloTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Titulo", true));
            this.tituloTextBox.Location = new System.Drawing.Point(81, 72);
            this.tituloTextBox.Name = "tituloTextBox";
            this.tituloTextBox.Size = new System.Drawing.Size(540, 21);
            this.tituloTextBox.TabIndex = 5;
            // 
            // motivoTextBox
            // 
            this.motivoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Motivo", true));
            this.motivoTextBox.Location = new System.Drawing.Point(81, 117);
            this.motivoTextBox.Multiline = true;
            this.motivoTextBox.Name = "motivoTextBox";
            this.motivoTextBox.Size = new System.Drawing.Size(540, 50);
            this.motivoTextBox.TabIndex = 7;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(512, 29);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(109, 21);
            this.fechaDateTimePicker.TabIndex = 9;
            // 
            // Datos_Puntos
            // 
            this.Datos_Puntos.DataSource = typeof(moleQule.Library.Quality.PuntoActa);
            // 
            // Puntos_Grid
            // 
            this.Puntos_Grid.AllowUserToAddRows = false;
            this.Puntos_Grid.AllowUserToDeleteRows = false;
            this.Puntos_Grid.AllowUserToOrderColumns = true;
            this.Puntos_Grid.AutoGenerateColumns = false;
            this.Puntos_Grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Puntos_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn7});
            this.Puntos_Grid.DataSource = this.Datos_Puntos;
            this.Puntos_Grid.Location = new System.Drawing.Point(21, 242);
            this.Puntos_Grid.Name = "Puntos_Grid";
            this.Puntos_Grid.ReadOnly = true;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Puntos_Grid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Puntos_Grid.Size = new System.Drawing.Size(664, 264);
            this.Puntos_Grid.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "Código";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Número";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Texto";
            this.dataGridViewTextBoxColumn7.HeaderText = "Texto";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 430;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.revisionTextBox);
            this.groupBox1.Controls.Add(revisionLabel);
            this.groupBox1.Controls.Add(motivoLabel);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Controls.Add(this.motivoTextBox);
            this.groupBox1.Controls.Add(this.fechaDateTimePicker);
            this.groupBox1.Controls.Add(tituloLabel);
            this.groupBox1.Controls.Add(this.tituloTextBox);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 181);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "PUNTOS A TRATAR";
            // 
            // Edit_BT
            // 
            this.Edit_BT.Location = new System.Drawing.Point(272, 525);
            this.Edit_BT.Name = "Edit_BT";
            this.Edit_BT.Size = new System.Drawing.Size(163, 23);
            this.Edit_BT.TabIndex = 13;
            this.Edit_BT.Text = "Editar Puntos";
            this.Edit_BT.UseVisualStyleBackColor = true;
            this.Edit_BT.Click += new System.EventHandler(this.Edit_BT_Click);
            // 
            // ActaComiteForm
            // 
            this.ClientSize = new System.Drawing.Size(708, 605);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActaComiteForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ActaComiteForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Puntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Puntos_Grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DataGridView Puntos_Grid;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox motivoTextBox;
        private System.Windows.Forms.TextBox tituloTextBox;
        private System.Windows.Forms.TextBox revisionTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.BindingSource Datos_Puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        protected System.Windows.Forms.Button Edit_BT;
    }
}
