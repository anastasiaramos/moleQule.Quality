namespace moleQule.Face.Quality
{
    partial class AccionCorrectoraActionForm
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
            System.Windows.Forms.Label nivelLabel;
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label textoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccionCorrectoraActionForm));
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
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.Discrepancia_TB = new System.Windows.Forms.TextBox();
            this.Nivel_TB = new System.Windows.Forms.TextBox();
            this.Numero_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Numeros = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Numeros)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            // 
            // Source_GB
            // 
            this.Source_GB.BackColor = System.Drawing.SystemColors.Control;
            this.Source_GB.Controls.Add(this.Numero_CB);
            this.Source_GB.Controls.Add(numeroLabel);
            this.Source_GB.Controls.Add(this.codigoTextBox);
            this.Source_GB.Controls.Add(nivelLabel);
            this.Source_GB.Controls.Add(codigoLabel);
            this.Source_GB.Controls.Add(this.Nivel_TB);
            this.Source_GB.Location = new System.Drawing.Point(18, 21);
            this.Source_GB.Size = new System.Drawing.Size(536, 57);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            this.PanelesV.Location = new System.Drawing.Point(0, 25);
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.PanelesV.Panel1.Controls.Add(this.Discrepancia_TB);
            this.PanelesV.Panel1.Controls.Add(textoLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Size = new System.Drawing.Size(567, 434);
            this.PanelesV.SplitterDistance = 394;
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
            observacionesLabel.Location = new System.Drawing.Point(68, 221);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(47, 13);
            observacionesLabel.TabIndex = 10;
            observacionesLabel.Text = "Acción:";
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textoLabel.Location = new System.Drawing.Point(33, 100);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(82, 13);
            textoLabel.TabIndex = 12;
            textoLabel.Text = "Discrepancia:";
            // 
            // Datos
            // 
            this.Datos.AllowNew = true;
            this.Datos.DataSource = typeof(moleQule.Library.Quality.AccionCorrectora);
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
            this.Navegador.Size = new System.Drawing.Size(567, 25);
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
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(80, 20);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(97, 21);
            this.codigoTextBox.TabIndex = 5;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Texto", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(121, 218);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(410, 161);
            this.observacionesTextBox.TabIndex = 11;
            // 
            // Discrepancia_TB
            // 
            this.Discrepancia_TB.Location = new System.Drawing.Point(121, 97);
            this.Discrepancia_TB.Multiline = true;
            this.Discrepancia_TB.Name = "Discrepancia_TB";
            this.Discrepancia_TB.ReadOnly = true;
            this.Discrepancia_TB.Size = new System.Drawing.Size(410, 105);
            this.Discrepancia_TB.TabIndex = 13;
            // 
            // Nivel_TB
            // 
            this.Nivel_TB.Location = new System.Drawing.Point(416, 20);
            this.Nivel_TB.Name = "Nivel_TB";
            this.Nivel_TB.ReadOnly = true;
            this.Nivel_TB.Size = new System.Drawing.Size(97, 21);
            this.Nivel_TB.TabIndex = 7;
            // 
            // Numero_CB
            // 
            this.Numero_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.Datos, "OidDiscrepancia", true));
            this.Numero_CB.DataSource = this.Datos_Numeros;
            this.Numero_CB.DisplayMember = "Texto";
            this.Numero_CB.FormattingEnabled = true;
            this.Numero_CB.Location = new System.Drawing.Point(255, 19);
            this.Numero_CB.Name = "Numero_CB";
            this.Numero_CB.Size = new System.Drawing.Size(97, 21);
            this.Numero_CB.TabIndex = 9;
            this.Numero_CB.ValueMember = "Oid";
            this.Numero_CB.SelectedIndexChanged += new System.EventHandler(this.Numero_CB_SelectedIndexChanged);
            // 
            // Datos_Numeros
            // 
            this.Datos_Numeros.DataSource = typeof(moleQule.Library.Application.HComboBoxSourceList);
            // 
            // AccionCorrectoraActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(567, 459);
            this.Controls.Add(this.Navegador);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "AccionCorrectoraActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "AccionCorrectoraActionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccionCorrectoraActionForm_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Numeros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.BindingSource Datos;
        private System.Windows.Forms.TextBox Nivel_TB;
        private System.Windows.Forms.TextBox Discrepancia_TB;
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
        private System.Windows.Forms.ComboBox Numero_CB;
        private System.Windows.Forms.BindingSource Datos_Numeros;
    }
}
