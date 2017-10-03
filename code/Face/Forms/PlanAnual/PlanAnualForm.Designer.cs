namespace moleQule.Face.Quality
{
    partial class PlanAnualForm
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
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label edicionLabel;
            System.Windows.Forms.Label revisionLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanAnualForm));
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.revisionTextBox = new System.Windows.Forms.TextBox();
            this.edicionTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.Clases_Grid = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clase_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_ComboClases = new System.Windows.Forms.BindingSource(this.components);
            this.TipoAuditoria_CBC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Datos_ComboTipos = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_Planes_Tipos = new System.Windows.Forms.BindingSource(this.components);
            observacionesLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            edicionLabel = new System.Windows.Forms.Label();
            revisionLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_ComboClases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_ComboTipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes_Tipos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.Clases_Grid);
            this.PanelesV.Panel1.Controls.Add(this.groupBox1);
            this.PanelesV.Panel1.Controls.Add(this.label1);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(992, 609);
            this.PanelesV.SplitterDistance = 568;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(540, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Size = new System.Drawing.Size(93, 23);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(630, 6);
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
            this.Paneles2.Size = new System.Drawing.Size(990, 38);
            this.Paneles2.SplitterDistance = 37;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Enabled = true;
            this.Imprimir_Button.Location = new System.Drawing.Point(450, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            this.Imprimir_Button.Size = new System.Drawing.Size(87, 23);
            this.Imprimir_Button.Visible = true;
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(300, 6);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.PlanAnual);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(287, 223);
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            observacionesLabel.Location = new System.Drawing.Point(23, 107);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 14;
            observacionesLabel.Text = "Observaciones:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaLabel.Location = new System.Drawing.Point(143, 59);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 10;
            fechaLabel.Text = "Fecha:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreLabel.Location = new System.Drawing.Point(343, 23);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(54, 13);
            nombreLabel.TabIndex = 8;
            nombreLabel.Text = "Nombre*:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoLabel.Location = new System.Drawing.Point(139, 23);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 14;
            codigoLabel.Text = "Código:";
            // 
            // edicionLabel
            // 
            edicionLabel.AutoSize = true;
            edicionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            edicionLabel.Location = new System.Drawing.Point(519, 59);
            edicionLabel.Name = "edicionLabel";
            edicionLabel.Size = new System.Drawing.Size(44, 13);
            edicionLabel.TabIndex = 15;
            edicionLabel.Text = "Edición:";
            // 
            // revisionLabel
            // 
            revisionLabel.AutoSize = true;
            revisionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            revisionLabel.Location = new System.Drawing.Point(780, 59);
            revisionLabel.Name = "revisionLabel";
            revisionLabel.Size = new System.Drawing.Size(51, 13);
            revisionLabel.TabIndex = 16;
            revisionLabel.Text = "Revisión:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(361, 59);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 13);
            label2.TabIndex = 18;
            label2.Text = "Año:";
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(111, 104);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(830, 74);
            this.observacionesTextBox.TabIndex = 2;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(192, 55);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(123, 21);
            this.fechaDateTimePicker.TabIndex = 1;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(402, 20);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(539, 21);
            this.nombreTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(562, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLASES TEÓRICAS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(revisionLabel);
            this.groupBox1.Controls.Add(this.revisionTextBox);
            this.groupBox1.Controls.Add(edicionLabel);
            this.groupBox1.Controls.Add(this.edicionTextBox);
            this.groupBox1.Controls.Add(codigoLabel);
            this.groupBox1.Controls.Add(this.codigoTextBox);
            this.groupBox1.Controls.Add(observacionesLabel);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.observacionesTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Controls.Add(this.fechaDateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(965, 197);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Ano", true));
            this.textBox1.Location = new System.Drawing.Point(402, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 21);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // revisionTextBox
            // 
            this.revisionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Revision", true));
            this.revisionTextBox.Location = new System.Drawing.Point(837, 56);
            this.revisionTextBox.Name = "revisionTextBox";
            this.revisionTextBox.Size = new System.Drawing.Size(104, 21);
            this.revisionTextBox.TabIndex = 17;
            this.revisionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // edicionTextBox
            // 
            this.edicionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Edicion", true));
            this.edicionTextBox.Location = new System.Drawing.Point(574, 56);
            this.edicionTextBox.Name = "edicionTextBox";
            this.edicionTextBox.Size = new System.Drawing.Size(176, 21);
            this.edicionTextBox.TabIndex = 16;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(192, 20);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(123, 21);
            this.codigoTextBox.TabIndex = 15;
            // 
            // Clases_Grid
            // 
            this.Clases_Grid.AllowUserToOrderColumns = true;
            this.Clases_Grid.AutoGenerateColumns = false;
            this.Clases_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.Numero,
            this.ordenDataGridViewTextBoxColumn,
            this.Clase_CBC,
            this.TipoAuditoria_CBC});
            this.Clases_Grid.DataSource = this.Datos_Planes_Tipos;
            this.Clases_Grid.Location = new System.Drawing.Point(14, 244);
            this.Clases_Grid.Name = "Clases_Grid";
            this.Clases_Grid.Size = new System.Drawing.Size(965, 275);
            this.Clases_Grid.TabIndex = 2;
            this.Clases_Grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Clases_Grid_CellValueChanged);
            this.Clases_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Clases_Grid_DataError);
            this.Clases_Grid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Clases_Grid_RowsAdded);
            this.Clases_Grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Clases_Grid_UserDeletingRow);
            this.Clases_Grid.DoubleClick += new System.EventHandler(this.Clases_Grid_DoubleClick);
            // 
            // Tipo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 150;
            // 
            // Numero
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 80;
            // 
            // ordenDataGridViewTextBoxColumn
            // 
            this.ordenDataGridViewTextBoxColumn.DataPropertyName = "Orden";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ordenDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ordenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.ordenDataGridViewTextBoxColumn.Name = "ordenDataGridViewTextBoxColumn";
            this.ordenDataGridViewTextBoxColumn.Width = 80;
            // 
            // Clase_CBC
            // 
            this.Clase_CBC.DataPropertyName = "OidClase";
            this.Clase_CBC.DataSource = this.Datos_ComboClases;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Clase_CBC.DefaultCellStyle = dataGridViewCellStyle4;
            this.Clase_CBC.DisplayMember = "Texto";
            this.Clase_CBC.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Clase_CBC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clase_CBC.HeaderText = "Clase";
            this.Clase_CBC.Name = "Clase_CBC";
            this.Clase_CBC.ValueMember = "Oid";
            this.Clase_CBC.Width = 200;
            // 
            // Datos_ComboClases
            // 
            this.Datos_ComboClases.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // TipoAuditoria_CBC
            // 
            this.TipoAuditoria_CBC.DataPropertyName = "OidTipo";
            this.TipoAuditoria_CBC.DataSource = this.Datos_ComboTipos;
            this.TipoAuditoria_CBC.DisplayMember = "Texto";
            this.TipoAuditoria_CBC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TipoAuditoria_CBC.HeaderText = "Nombre de Auditoría";
            this.TipoAuditoria_CBC.Name = "TipoAuditoria_CBC";
            this.TipoAuditoria_CBC.ValueMember = "Oid";
            this.TipoAuditoria_CBC.Width = 390;
            // 
            // Datos_ComboTipos
            // 
            this.Datos_ComboTipos.DataSource = typeof(moleQule.Library.Quality.HComboBoxSourceList);
            // 
            // Datos_Planes_Tipos
            // 
            this.Datos_Planes_Tipos.DataSource = typeof(moleQule.Library.Quality.Planes_Tipos);
            // 
            // PlanAnualForm
            // 
            this.ClientSize = new System.Drawing.Size(992, 609);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1255, 813);
            this.Name = "PlanAnualForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PlanAnualForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clases_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_ComboClases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_ComboTipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes_Tipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.TextBox revisionTextBox;
        private System.Windows.Forms.TextBox edicionTextBox;
        protected System.Windows.Forms.BindingSource Datos_ComboClases;
        protected System.Windows.Forms.DataGridView Clases_Grid;
        protected System.Windows.Forms.BindingSource Datos_ComboTipos;
        protected System.Windows.Forms.BindingSource Datos_Planes_Tipos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Clase_CBC;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoAuditoria_CBC;

    }
}
