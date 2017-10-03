namespace moleQule.Face.Quality
{
    partial class AreaForm
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
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaForm));
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            codigoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paneles2)).BeginInit();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.Progress_Panel.SuspendLayout();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(nombreLabel);
            this.PanelesV.Panel1.Controls.Add(this.nombreTextBox);
            this.PanelesV.Panel1.Controls.Add(codigoLabel);
            this.PanelesV.Panel1.Controls.Add(this.codigoTextBox);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            this.PanelesV.Panel1MinSize = 211;
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(455, 266);
            this.PanelesV.SplitterDistance = 211;
            // 
            // Submit_BT
            // 
            this.Submit_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Submit_BT.Location = new System.Drawing.Point(255, 6);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel_BT.Location = new System.Drawing.Point(345, 6);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Paneles2
            // 
            this.ErrorMng_EP.SetError(this.Paneles2, "F1 Ayuda        ");
            // 
            // Paneles2.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel1, true);
            // 
            // Paneles2.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.Paneles2.Panel2, true);
            this.HelpProvider.SetShowHelp(this.Paneles2, true);
            this.Paneles2.Size = new System.Drawing.Size(453, 52);
            this.Paneles2.SplitterDistance = 30;
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Imprimir_Button.Location = new System.Drawing.Point(165, 6);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Docs_BT.Location = new System.Drawing.Point(282, 9);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.Area);
            // 
            // Progress_Panel
            // 
            this.Progress_Panel.Location = new System.Drawing.Point(48, 96);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Size = new System.Drawing.Size(455, 266);
            // 
            // ProgressInfo_PB
            // 
            this.ProgressInfo_PB.Location = new System.Drawing.Point(190, 181);
            // 
            // Progress_PB
            // 
            this.Progress_PB.Location = new System.Drawing.Point(190, 96);
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(65, 31);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "C�digo:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(59, 69);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(48, 13);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(20, 110);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 4;
            observacionesLabel.Text = "Observaciones:";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(119, 28);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(100, 21);
            this.codigoTextBox.TabIndex = 1;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(119, 66);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(297, 21);
            this.nombreTextBox.TabIndex = 3;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(119, 107);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(297, 92);
            this.observacionesTextBox.TabIndex = 5;
            // 
            // AreaForm
            // 
            this.ClientSize = new System.Drawing.Size(455, 266);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AreaForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "AreaForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelesV)).EndInit();
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Paneles2)).EndInit();
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMng_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.Progress_Panel.ResumeLayout(false);
            this.Progress_Panel.PerformLayout();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Progress_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
    }
}
