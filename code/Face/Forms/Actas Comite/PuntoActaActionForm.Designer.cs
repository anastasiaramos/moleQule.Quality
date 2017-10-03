namespace moleQule.Face.Quality
{
    partial class PuntoActaActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoActaActionForm));
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label textoLabel;
            this.Datos = new System.Windows.Forms.BindingSource(this.components);
            this.Navegador = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.puntoActaBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            codigoLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
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
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(163, 8);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(textoLabel);
            this.Source_GB.Controls.Add(this.textoTextBox);
            this.Source_GB.Controls.Add(numeroLabel);
            this.Source_GB.Controls.Add(this.numeroTextBox);
            this.Source_GB.Controls.Add(codigoLabel);
            this.Source_GB.Controls.Add(this.codigoTextBox);
            this.Source_GB.Location = new System.Drawing.Point(18, 18);
            this.Source_GB.Size = new System.Drawing.Size(567, 282);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            this.PanelesV.Location = new System.Drawing.Point(0, 25);
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Size = new System.Drawing.Size(605, 359);
            this.PanelesV.SplitterDistance = 319;
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.PuntoActa);
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
            this.puntoActaBindingNavigatorSaveItem});
            this.Navegador.Location = new System.Drawing.Point(0, 0);
            this.Navegador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Navegador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Navegador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Navegador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Navegador.Name = "Navegador";
            this.Navegador.PositionItem = this.bindingNavigatorPositionItem;
            this.Navegador.Size = new System.Drawing.Size(605, 25);
            this.Navegador.TabIndex = 1;
            this.Navegador.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // puntoActaBindingNavigatorSaveItem
            // 
            this.puntoActaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.puntoActaBindingNavigatorSaveItem.Enabled = false;
            this.puntoActaBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("puntoActaBindingNavigatorSaveItem.Image")));
            this.puntoActaBindingNavigatorSaveItem.Name = "puntoActaBindingNavigatorSaveItem";
            this.puntoActaBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.puntoActaBindingNavigatorSaveItem.Text = "Guardar datos";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(30, 42);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(84, 39);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(100, 21);
            this.codigoTextBox.TabIndex = 1;
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(270, 42);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(54, 13);
            numeroLabel.TabIndex = 2;
            numeroLabel.Text = "Número:";
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(330, 39);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(100, 21);
            this.numeroTextBox.TabIndex = 3;
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Location = new System.Drawing.Point(35, 92);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(43, 13);
            textoLabel.TabIndex = 4;
            textoLabel.Text = "Texto:";
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(84, 89);
            this.textoTextBox.Multiline = true;
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.Size = new System.Drawing.Size(432, 166);
            this.textoTextBox.TabIndex = 5;
            // 
            // PuntoActaActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(605, 384);
            this.Controls.Add(this.Navegador);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "PuntoActaActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Controls.SetChildIndex(this.Navegador, 0);
            this.Controls.SetChildIndex(this.PanelesV, 0);
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
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

        private System.Windows.Forms.TextBox textoTextBox;
        private System.Windows.Forms.BindingSource Datos;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.BindingNavigator Navegador;
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
        private System.Windows.Forms.ToolStripButton puntoActaBindingNavigatorSaveItem;
    }
}
