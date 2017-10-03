namespace moleQule.Face.Quality
{
    partial class DepartamentoForm
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
            System.Windows.Forms.Label telefonosLabel;
            System.Windows.Forms.Label faxLabel;
            System.Windows.Forms.Label emailLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartamentoForm));
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.telefonosTextBox = new System.Windows.Forms.TextBox();
            this.faxTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            codigoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            telefonosLabel = new System.Windows.Forms.Label();
            faxLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.Controls.Add(emailLabel);
            this.PanelesV.Panel1.Controls.Add(this.emailTextBox);
            this.PanelesV.Panel1.Controls.Add(faxLabel);
            this.PanelesV.Panel1.Controls.Add(this.faxTextBox);
            this.PanelesV.Panel1.Controls.Add(telefonosLabel);
            this.PanelesV.Panel1.Controls.Add(this.telefonosTextBox);
            this.PanelesV.Panel1.Controls.Add(nombreLabel);
            this.PanelesV.Panel1.Controls.Add(this.nombreTextBox);
            this.PanelesV.Panel1.Controls.Add(codigoLabel);
            this.PanelesV.Panel1.Controls.Add(this.codigoTextBox);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(489, 342);
            this.PanelesV.SplitterDistance = 301;
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
            this.Paneles2.Size = new System.Drawing.Size(487, 38);
            this.Paneles2.SplitterDistance = 37;
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
            this.Datos.DataSource = typeof(moleQule.Library.Quality.Departamento);
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(47, 43);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(41, 86);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(54, 13);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre:";
            // 
            // telefonosLabel
            // 
            telefonosLabel.AutoSize = true;
            telefonosLabel.Location = new System.Drawing.Point(30, 162);
            telefonosLabel.Name = "telefonosLabel";
            telefonosLabel.Size = new System.Drawing.Size(65, 13);
            telefonosLabel.TabIndex = 4;
            telefonosLabel.Text = "Teléfonos:";
            // 
            // faxLabel
            // 
            faxLabel.AutoSize = true;
            faxLabel.Location = new System.Drawing.Point(65, 205);
            faxLabel.Name = "faxLabel";
            faxLabel.Size = new System.Drawing.Size(30, 13);
            faxLabel.TabIndex = 6;
            faxLabel.Text = "Fax:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(55, 248);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(40, 13);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Email:";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(101, 40);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(100, 21);
            this.codigoTextBox.TabIndex = 1;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(101, 83);
            this.nombreTextBox.Multiline = true;
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(340, 57);
            this.nombreTextBox.TabIndex = 3;
            // 
            // telefonosTextBox
            // 
            this.telefonosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Telefonos", true));
            this.telefonosTextBox.Location = new System.Drawing.Point(101, 159);
            this.telefonosTextBox.Name = "telefonosTextBox";
            this.telefonosTextBox.Size = new System.Drawing.Size(340, 21);
            this.telefonosTextBox.TabIndex = 5;
            // 
            // faxTextBox
            // 
            this.faxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Fax", true));
            this.faxTextBox.Location = new System.Drawing.Point(101, 202);
            this.faxTextBox.Name = "faxTextBox";
            this.faxTextBox.Size = new System.Drawing.Size(340, 21);
            this.faxTextBox.TabIndex = 7;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(101, 245);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(340, 21);
            this.emailTextBox.TabIndex = 9;
            // 
            // DepartamentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(489, 342);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DepartamentoForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "DepartamentoForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox faxTextBox;
        private System.Windows.Forms.TextBox telefonosTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
    }
}
