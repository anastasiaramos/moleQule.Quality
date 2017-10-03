namespace moleQule.Face.Quality
{
    partial class DiscrepanciaActionForm
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
            System.Windows.Forms.Label fechaCierreLabel;
            System.Windows.Forms.Label fechaDebidaLabel;
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label nivelLabel;
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label textoLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscrepanciaActionForm));
            System.Windows.Forms.Label label3;
            this.Datos = new System.Windows.Forms.BindingSource(this.components);
            this.Navegador = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.discrepanciaBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.FechaCierre_DTP = new System.Windows.Forms.DateTimePicker();
            this.FechaDebida_DTP = new System.Windows.Forms.DateTimePicker();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            this.Nivel_NUD = new System.Windows.Forms.NumericUpDown();
            this.Cuestion_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Cuestiones = new System.Windows.Forms.BindingSource(this.components);
            this.Cuestion_TB = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            fechaCierreLabel = new System.Windows.Forms.Label();
            fechaDebidaLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            nivelLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            textoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navegador)).BeginInit();
            this.Navegador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nivel_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Cuestiones)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.BackColor = System.Drawing.SystemColors.Control;
            this.Source_GB.Controls.Add(this.checkBox1);
            this.Source_GB.Controls.Add(label3);
            this.Source_GB.Controls.Add(this.Cuestion_CB);
            this.Source_GB.Controls.Add(label1);
            this.Source_GB.Controls.Add(this.Nivel_NUD);
            this.Source_GB.Controls.Add(numeroLabel);
            this.Source_GB.Controls.Add(this.codigoTextBox);
            this.Source_GB.Controls.Add(nivelLabel);
            this.Source_GB.Controls.Add(codigoLabel);
            this.Source_GB.Controls.Add(this.numeroTextBox);
            this.Source_GB.Controls.Add(this.FechaCierre_DTP);
            this.Source_GB.Controls.Add(fechaCierreLabel);
            this.Source_GB.Controls.Add(fechaDebidaLabel);
            this.Source_GB.Controls.Add(this.FechaDebida_DTP);
            this.Source_GB.Location = new System.Drawing.Point(18, 21);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(607, 94);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            this.PanelesV.Location = new System.Drawing.Point(0, 25);
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.PanelesV.Panel1.Controls.Add(label2);
            this.PanelesV.Panel1.Controls.Add(this.Cuestion_TB);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(textoLabel);
            this.PanelesV.Panel1.Controls.Add(this.textoTextBox);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(638, 580);
            this.PanelesV.SplitterDistance = 540;
            // 
            // fechaCierreLabel
            // 
            fechaCierreLabel.AutoSize = true;
            fechaCierreLabel.Location = new System.Drawing.Point(231, 63);
            fechaCierreLabel.Name = "fechaCierreLabel";
            fechaCierreLabel.Size = new System.Drawing.Size(80, 13);
            fechaCierreLabel.TabIndex = 0;
            fechaCierreLabel.Text = "Fecha Cierre:";
            // 
            // fechaDebidaLabel
            // 
            fechaDebidaLabel.AutoSize = true;
            fechaDebidaLabel.Location = new System.Drawing.Point(12, 63);
            fechaDebidaLabel.Name = "fechaDebidaLabel";
            fechaDebidaLabel.Size = new System.Drawing.Size(85, 13);
            fechaDebidaLabel.TabIndex = 2;
            fechaDebidaLabel.Text = "Fecha Debida:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(19, 23);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 4;
            codigoLabel.Text = "Código:";
            // 
            // nivelLabel
            // 
            nivelLabel.AutoSize = true;
            nivelLabel.Location = new System.Drawing.Point(504, 23);
            nivelLabel.Name = "nivelLabel";
            nivelLabel.Size = new System.Drawing.Size(37, 13);
            nivelLabel.TabIndex = 6;
            nivelLabel.Text = "Nivel:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(174, 23);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(54, 13);
            numeroLabel.TabIndex = 8;
            numeroLabel.Text = "Número:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            observacionesLabel.Location = new System.Drawing.Point(22, 415);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(93, 13);
            observacionesLabel.TabIndex = 10;
            observacionesLabel.Text = "Observaciones:";
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textoLabel.Location = new System.Drawing.Point(70, 280);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(43, 13);
            textoLabel.TabIndex = 12;
            textoLabel.Text = "Texto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(334, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 13);
            label1.TabIndex = 11;
            label1.Text = "Cuestión:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(56, 146);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 13);
            label2.TabIndex = 14;
            label2.Text = "Cuestión:";
            // 
            // Datos
            // 
            this.Datos.AllowNew = true;
            this.Datos.DataSource = typeof(moleQule.Library.Quality.Discrepancia);
            // 
            // Navegador
            // 
            this.Navegador.AddNewItem = this.bindingNavigatorAddNewItem;
            this.Navegador.BindingSource = this.Datos;
            this.Navegador.CountItem = this.bindingNavigatorCountItem;
            this.Navegador.DeleteItem = this.bindingNavigatorDeleteItem;
            this.Navegador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.discrepanciaBindingNavigatorSaveItem});
            this.Navegador.Location = new System.Drawing.Point(0, 0);
            this.Navegador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Navegador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Navegador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Navegador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Navegador.Name = "Navegador";
            this.Navegador.PositionItem = this.bindingNavigatorPositionItem;
            this.Navegador.Size = new System.Drawing.Size(638, 25);
            this.Navegador.TabIndex = 1;
            this.Navegador.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // discrepanciaBindingNavigatorSaveItem
            // 
            this.discrepanciaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.discrepanciaBindingNavigatorSaveItem.Enabled = false;
            this.discrepanciaBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("discrepanciaBindingNavigatorSaveItem.Image")));
            this.discrepanciaBindingNavigatorSaveItem.Name = "discrepanciaBindingNavigatorSaveItem";
            this.discrepanciaBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.discrepanciaBindingNavigatorSaveItem.Text = "Guardar datos";
            // 
            // FechaCierre_DTP
            // 
            this.FechaCierre_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaCierre", true));
            this.FechaCierre_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaCierre_DTP.Location = new System.Drawing.Point(317, 59);
            this.FechaCierre_DTP.Name = "FechaCierre_DTP";
            this.FechaCierre_DTP.Size = new System.Drawing.Size(110, 21);
            this.FechaCierre_DTP.TabIndex = 1;
            // 
            // FechaDebida_DTP
            // 
            this.FechaDebida_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaDebida", true));
            this.FechaDebida_DTP.Enabled = false;
            this.FechaDebida_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDebida_DTP.Location = new System.Drawing.Point(103, 59);
            this.FechaDebida_DTP.Name = "FechaDebida_DTP";
            this.FechaDebida_DTP.Size = new System.Drawing.Size(110, 21);
            this.FechaDebida_DTP.TabIndex = 3;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(73, 20);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(75, 21);
            this.codigoTextBox.TabIndex = 5;
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(234, 20);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(74, 21);
            this.numeroTextBox.TabIndex = 9;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(121, 412);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(504, 110);
            this.observacionesTextBox.TabIndex = 11;
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(121, 277);
            this.textoTextBox.Multiline = true;
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.Size = new System.Drawing.Size(504, 105);
            this.textoTextBox.TabIndex = 13;
            // 
            // Nivel_NUD
            // 
            this.Nivel_NUD.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Nivel", true));
            this.Nivel_NUD.Location = new System.Drawing.Point(547, 20);
            this.Nivel_NUD.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Nivel_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nivel_NUD.Name = "Nivel_NUD";
            this.Nivel_NUD.Size = new System.Drawing.Size(41, 21);
            this.Nivel_NUD.TabIndex = 10;
            this.Nivel_NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nivel_NUD.ValueChanged += new System.EventHandler(this.Nivel_NUD_ValueChanged);
            // 
            // Cuestion_CB
            // 
            this.Cuestion_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.Datos, "OidCuestion", true));
            this.Cuestion_CB.DataSource = this.Datos_Cuestiones;
            this.Cuestion_CB.DisplayMember = "Texto";
            this.Cuestion_CB.FormattingEnabled = true;
            this.Cuestion_CB.Location = new System.Drawing.Point(399, 20);
            this.Cuestion_CB.Name = "Cuestion_CB";
            this.Cuestion_CB.Size = new System.Drawing.Size(87, 21);
            this.Cuestion_CB.TabIndex = 12;
            this.Cuestion_CB.ValueMember = "Oid";
            this.Cuestion_CB.SelectedIndexChanged += new System.EventHandler(this.Cuestion_CB_SelectedIndexChanged);
            // 
            // Datos_Cuestiones
            // 
            this.Datos_Cuestiones.DataSource = typeof(moleQule.Library.Quality.HComboBoxSourceList);
            // 
            // Cuestion_TB
            // 
            this.Cuestion_TB.Location = new System.Drawing.Point(121, 143);
            this.Cuestion_TB.Multiline = true;
            this.Cuestion_TB.Name = "Cuestion_TB";
            this.Cuestion_TB.ReadOnly = true;
            this.Cuestion_TB.Size = new System.Drawing.Size(504, 105);
            this.Cuestion_TB.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(446, 63);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 13);
            label3.TabIndex = 13;
            label3.Text = "Discrepancia:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.Datos, "EsDiscrepancia", true));
            this.checkBox1.Location = new System.Drawing.Point(534, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DiscrepanciaActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(638, 605);
            this.Controls.Add(this.Navegador);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "DiscrepanciaActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "DiscrepanciaActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiscrepanciaActionForm_FormClosing);
            this.Controls.SetChildIndex(this.Navegador, 0);
            this.Controls.SetChildIndex(this.PanelesV, 0);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navegador)).EndInit();
            this.Navegador.ResumeLayout(false);
            this.Navegador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nivel_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Cuestiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.BindingSource Datos;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.DateTimePicker FechaCierre_DTP;
        private System.Windows.Forms.DateTimePicker FechaDebida_DTP;
        private System.Windows.Forms.TextBox textoTextBox;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton discrepanciaBindingNavigatorSaveItem;
        protected System.Windows.Forms.BindingNavigator Navegador;
        private System.Windows.Forms.NumericUpDown Nivel_NUD;
        private System.Windows.Forms.ComboBox Cuestion_CB;
        private System.Windows.Forms.BindingSource Datos_Cuestiones;
        private System.Windows.Forms.TextBox Cuestion_TB;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
