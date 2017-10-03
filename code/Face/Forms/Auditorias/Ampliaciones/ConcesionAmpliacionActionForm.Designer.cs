namespace moleQule.Face.Quality
{
    partial class ConcesionAmpliacionActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcesionAmpliacionActionForm));
            this.Datos = new System.Windows.Forms.BindingSource(this.components);
            this.Navegador = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FechaCierre_DTP = new System.Windows.Forms.DateTimePicker();
            this.FechaDebida_DTP = new System.Windows.Forms.DateTimePicker();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            this.nivelTextBox = new System.Windows.Forms.TextBox();
            fechaCierreLabel = new System.Windows.Forms.Label();
            fechaDebidaLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            nivelLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            textoLabel = new System.Windows.Forms.Label();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navegador)).BeginInit();
            this.Navegador.SuspendLayout();
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
            this.Source_GB.Controls.Add(numeroLabel);
            this.Source_GB.Controls.Add(this.codigoTextBox);
            this.Source_GB.Controls.Add(nivelLabel);
            this.Source_GB.Controls.Add(codigoLabel);
            this.Source_GB.Controls.Add(this.numeroTextBox);
            this.Source_GB.Controls.Add(this.FechaCierre_DTP);
            this.Source_GB.Controls.Add(fechaCierreLabel);
            this.Source_GB.Controls.Add(fechaDebidaLabel);
            this.Source_GB.Controls.Add(this.nivelTextBox);
            this.Source_GB.Controls.Add(this.FechaDebida_DTP);
            this.Source_GB.Location = new System.Drawing.Point(18, 21);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(536, 94);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            this.PanelesV.Location = new System.Drawing.Point(0, 25);
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.PanelesV.Panel1.Controls.Add(textoLabel);
            this.PanelesV.Panel1.Controls.Add(this.textoTextBox);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(567, 434);
            this.PanelesV.SplitterDistance = 394;
            // 
            // fechaCierreLabel
            // 
            fechaCierreLabel.AutoSize = true;
            fechaCierreLabel.Location = new System.Drawing.Point(290, 63);
            fechaCierreLabel.Name = "fechaCierreLabel";
            fechaCierreLabel.Size = new System.Drawing.Size(80, 13);
            fechaCierreLabel.TabIndex = 0;
            fechaCierreLabel.Text = "Fecha Cierre:";
            // 
            // fechaDebidaLabel
            // 
            fechaDebidaLabel.AutoSize = true;
            fechaDebidaLabel.Location = new System.Drawing.Point(26, 63);
            fechaDebidaLabel.Name = "fechaDebidaLabel";
            fechaDebidaLabel.Size = new System.Drawing.Size(85, 13);
            fechaDebidaLabel.TabIndex = 2;
            fechaDebidaLabel.Text = "Fecha Debida:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(26, 23);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 4;
            codigoLabel.Text = "Código:";
            // 
            // nivelLabel
            // 
            nivelLabel.AutoSize = true;
            nivelLabel.Location = new System.Drawing.Point(373, 23);
            nivelLabel.Name = "nivelLabel";
            nivelLabel.Size = new System.Drawing.Size(37, 13);
            nivelLabel.TabIndex = 6;
            nivelLabel.Text = "Nivel:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(194, 23);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(54, 13);
            numeroLabel.TabIndex = 8;
            numeroLabel.Text = "Número:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            observacionesLabel.Location = new System.Drawing.Point(22, 266);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(93, 13);
            observacionesLabel.TabIndex = 10;
            observacionesLabel.Text = "Observaciones:";
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textoLabel.Location = new System.Drawing.Point(70, 135);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(43, 13);
            textoLabel.TabIndex = 12;
            textoLabel.Text = "Texto:";
            // 
            // Datos
            // 
            this.Datos.AllowNew = true;
            this.Datos.DataSource = typeof(moleQule.Library.Quality.Discrepancia);
            // 
            // Navegador
            // 
            this.Navegador.AddNewItem = null;
            this.Navegador.BindingSource = this.Datos;
            this.Navegador.CountItem = this.bindingNavigatorCountItem;
            this.Navegador.DeleteItem = null;
            this.Navegador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.Navegador.Location = new System.Drawing.Point(0, 0);
            this.Navegador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Navegador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Navegador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Navegador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Navegador.Name = "Navegador";
            this.Navegador.PositionItem = this.bindingNavigatorPositionItem;
            this.Navegador.Size = new System.Drawing.Size(567, 25);
            this.Navegador.TabIndex = 1;
            this.Navegador.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
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
            // FechaCierre_DTP
            // 
            this.FechaCierre_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaCierre", true));
            this.FechaCierre_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaCierre_DTP.Location = new System.Drawing.Point(376, 59);
            this.FechaCierre_DTP.Name = "FechaCierre_DTP";
            this.FechaCierre_DTP.Size = new System.Drawing.Size(110, 21);
            this.FechaCierre_DTP.TabIndex = 1;
            // 
            // FechaDebida_DTP
            // 
            this.FechaDebida_DTP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "FechaAmpliacion", true));
            this.FechaDebida_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDebida_DTP.Location = new System.Drawing.Point(117, 59);
            this.FechaDebida_DTP.Name = "FechaDebida_DTP";
            this.FechaDebida_DTP.Size = new System.Drawing.Size(110, 21);
            this.FechaDebida_DTP.TabIndex = 3;
            this.FechaDebida_DTP.CloseUp += new System.EventHandler(this.FechaDebida_DTP_ValueChanged);
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(80, 20);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(97, 21);
            this.codigoTextBox.TabIndex = 5;
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(254, 20);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.ReadOnly = true;
            this.numeroTextBox.Size = new System.Drawing.Size(97, 21);
            this.numeroTextBox.TabIndex = 9;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(121, 263);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.ReadOnly = true;
            this.observacionesTextBox.Size = new System.Drawing.Size(410, 110);
            this.observacionesTextBox.TabIndex = 11;
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(121, 132);
            this.textoTextBox.Multiline = true;
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.ReadOnly = true;
            this.textoTextBox.Size = new System.Drawing.Size(410, 105);
            this.textoTextBox.TabIndex = 13;
            // 
            // nivelTextBox
            // 
            this.nivelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nivel", true));
            this.nivelTextBox.Location = new System.Drawing.Point(416, 20);
            this.nivelTextBox.Name = "nivelTextBox";
            this.nivelTextBox.ReadOnly = true;
            this.nivelTextBox.Size = new System.Drawing.Size(97, 21);
            this.nivelTextBox.TabIndex = 7;
            // 
            // ConcesionAmpliacionActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(567, 459);
            this.Controls.Add(this.Navegador);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "ConcesionAmpliacionActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "ConcesionAmpliacionActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConcesionAmpliacionActionForm_FormClosing);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.BindingSource Datos;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.DateTimePicker FechaCierre_DTP;
        private System.Windows.Forms.TextBox nivelTextBox;
        private System.Windows.Forms.DateTimePicker FechaDebida_DTP;
        private System.Windows.Forms.TextBox textoTextBox;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        protected System.Windows.Forms.BindingNavigator Navegador;
    }
}
