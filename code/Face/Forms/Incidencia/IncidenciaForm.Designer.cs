

namespace moleQule.Face.Quality
{
    partial class IncidenciaForm
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
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label observacionesLabel;
            System.Windows.Forms.Label tipoAgenteLabel;
            System.Windows.Forms.Label textoLabel;
            System.Windows.Forms.Label agenteLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidenciaForm));
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.observacionesTextBox = new System.Windows.Forms.TextBox();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            this.Agente_TB = new System.Windows.Forms.TextBox();
            this.TipoAgente_CB = new System.Windows.Forms.ComboBox();
            this.hComboBoxSourceListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Selecionar_B = new System.Windows.Forms.Button();
            codigoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            observacionesLabel = new System.Windows.Forms.Label();
            tipoAgenteLabel = new System.Windows.Forms.Label();
            textoLabel = new System.Windows.Forms.Label();
            agenteLabel = new System.Windows.Forms.Label();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.ProgressBK_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hComboBoxSourceListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(this.Selecionar_B);
            this.PanelesV.Panel1.Controls.Add(this.TipoAgente_CB);
            this.PanelesV.Panel1.Controls.Add(agenteLabel);
            this.PanelesV.Panel1.Controls.Add(this.Agente_TB);
            this.PanelesV.Panel1.Controls.Add(textoLabel);
            this.PanelesV.Panel1.Controls.Add(this.textoTextBox);
            this.PanelesV.Panel1.Controls.Add(tipoAgenteLabel);
            this.PanelesV.Panel1.Controls.Add(observacionesLabel);
            this.PanelesV.Panel1.Controls.Add(this.observacionesTextBox);
            this.PanelesV.Panel1.Controls.Add(fechaLabel);
            this.PanelesV.Panel1.Controls.Add(this.fechaDateTimePicker);
            this.PanelesV.Panel1.Controls.Add(codigoLabel);
            this.PanelesV.Panel1.Controls.Add(this.codigoTextBox);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(592, 334);
            this.PanelesV.SplitterDistance = 288;
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
            this.Paneles2.Size = new System.Drawing.Size(590, 43);
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
            this.Datos.DataSource = typeof(moleQule.Library.Quality.Incidencia);
            this.Datos.DataSourceChanged += new System.EventHandler(this.Datos_DataSourceChanged);
            // 
            // ProgressBK_Panel
            // 
            this.ProgressBK_Panel.Location = new System.Drawing.Point(87, 85);
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(425, 29);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(264, 66);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 2;
            fechaLabel.Text = "Fecha:";
            // 
            // observacionesLabel
            // 
            observacionesLabel.AutoSize = true;
            observacionesLabel.Location = new System.Drawing.Point(9, 136);
            observacionesLabel.Name = "observacionesLabel";
            observacionesLabel.Size = new System.Drawing.Size(82, 13);
            observacionesLabel.TabIndex = 4;
            observacionesLabel.Text = "Observaciones:";
            // 
            // tipoAgenteLabel
            // 
            tipoAgenteLabel.AutoSize = true;
            tipoAgenteLabel.Location = new System.Drawing.Point(24, 66);
            tipoAgenteLabel.Name = "tipoAgenteLabel";
            tipoAgenteLabel.Size = new System.Drawing.Size(69, 13);
            tipoAgenteLabel.TabIndex = 6;
            tipoAgenteLabel.Text = "Tipo Agente:";
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Location = new System.Drawing.Point(59, 29);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(37, 13);
            textoLabel.TabIndex = 8;
            textoLabel.Text = "Título:";
            // 
            // agenteLabel
            // 
            agenteLabel.AutoSize = true;
            agenteLabel.Location = new System.Drawing.Point(51, 100);
            agenteLabel.Name = "agenteLabel";
            agenteLabel.Size = new System.Drawing.Size(46, 13);
            agenteLabel.TabIndex = 10;
            agenteLabel.Text = "Agente:";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(479, 26);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(100, 21);
            this.codigoTextBox.TabIndex = 1;
            this.codigoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Location = new System.Drawing.Point(313, 62);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.fechaDateTimePicker.TabIndex = 2;
            // 
            // observacionesTextBox
            // 
            this.observacionesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Observaciones", true));
            this.observacionesTextBox.Location = new System.Drawing.Point(108, 133);
            this.observacionesTextBox.Multiline = true;
            this.observacionesTextBox.Name = "observacionesTextBox";
            this.observacionesTextBox.Size = new System.Drawing.Size(471, 75);
            this.observacionesTextBox.TabIndex = 4;
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(108, 26);
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.Size = new System.Drawing.Size(303, 21);
            this.textoTextBox.TabIndex = 0;
            // 
            // Agente_TB
            // 
            this.Agente_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Agente", true));
            this.Agente_TB.Location = new System.Drawing.Point(108, 97);
            this.Agente_TB.Name = "Agente_TB";
            this.Agente_TB.ReadOnly = true;
            this.Agente_TB.Size = new System.Drawing.Size(365, 21);
            this.Agente_TB.TabIndex = 11;
            // 
            // TipoAgente_CB
            // 
            this.TipoAgente_CB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "TipoAgente", true));
            this.TipoAgente_CB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.Datos, "TipoAgente", true));
            this.TipoAgente_CB.DataSource = this.hComboBoxSourceListBindingSource;
            this.TipoAgente_CB.DisplayMember = "Texto";
            this.TipoAgente_CB.FormattingEnabled = true;
            this.TipoAgente_CB.Location = new System.Drawing.Point(108, 63);
            this.TipoAgente_CB.Name = "TipoAgente_CB";
            this.TipoAgente_CB.Size = new System.Drawing.Size(121, 21);
            this.TipoAgente_CB.TabIndex = 1;
            this.TipoAgente_CB.ValueMember = "Texto";
            this.TipoAgente_CB.SelectedIndexChanged += new System.EventHandler(this.TipoAgente_CB_SelectedIndexChanged);
            // 
            // hComboBoxSourceListBindingSource
            // 
            this.hComboBoxSourceListBindingSource.DataSource = typeof(moleQule.Library.Quality.HComboBoxSourceList);
            // 
            // Selecionar_B
            // 
            this.Selecionar_B.Location = new System.Drawing.Point(492, 95);
            this.Selecionar_B.Name = "Selecionar_B";
            this.Selecionar_B.Size = new System.Drawing.Size(86, 23);
            this.Selecionar_B.TabIndex = 3;
            this.Selecionar_B.Text = "Seleccionar";
            this.Selecionar_B.UseVisualStyleBackColor = true;
            this.Selecionar_B.Click += new System.EventHandler(this.Selecionar_B_Click);
            // 
            // IncidenciaForm
            // 
            this.ClientSize = new System.Drawing.Size(592, 334);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidenciaForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "IncidenciaForm";
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ProgressBK_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hComboBoxSourceListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textoTextBox;
        private System.Windows.Forms.TextBox observacionesTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.ComboBox TipoAgente_CB;
        private System.Windows.Forms.Button Selecionar_B;
        protected System.Windows.Forms.TextBox Agente_TB;
        private System.Windows.Forms.BindingSource hComboBoxSourceListBindingSource;




    }
}
