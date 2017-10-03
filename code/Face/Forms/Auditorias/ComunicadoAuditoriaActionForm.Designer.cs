namespace moleQule.Face.Quality
{
    partial class ComunicadoAuditoriaActionForm
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
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label asuntoLabel;
            System.Windows.Forms.Label comentariosLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.Datos = new System.Windows.Forms.BindingSource(this.components);
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.asuntoTextBox = new System.Windows.Forms.TextBox();
            this.comentariosTextBox = new System.Windows.Forms.TextBox();
            this.Imprimir_BT = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            codigoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            asuntoLabel = new System.Windows.Forms.Label();
            comentariosLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(73, 8);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(165, 8);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(numeroLabel);
            this.Source_GB.Controls.Add(this.numeroTextBox);
            this.Source_GB.Controls.Add(fechaLabel);
            this.Source_GB.Controls.Add(this.fechaDateTimePicker);
            this.Source_GB.Controls.Add(codigoLabel);
            this.Source_GB.Controls.Add(this.codigoTextBox);
            this.Source_GB.Location = new System.Drawing.Point(11, 21);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(628, 59);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.PanelesV.Panel1.AutoScroll = true;
            this.PanelesV.Panel1.Controls.Add(label2);
            this.PanelesV.Panel1.Controls.Add(this.textBox2);
            this.PanelesV.Panel1.Controls.Add(label1);
            this.PanelesV.Panel1.Controls.Add(this.textBox1);
            this.PanelesV.Panel1.Controls.Add(this.comentariosTextBox);
            this.PanelesV.Panel1.Controls.Add(asuntoLabel);
            this.PanelesV.Panel1.Controls.Add(this.asuntoTextBox);
            this.PanelesV.Panel1.Controls.Add(comentariosLabel);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.PanelesV.Panel2.Controls.Add(this.Imprimir_BT);
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(652, 562);
            this.PanelesV.SplitterDistance = 522;
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoLabel.Location = new System.Drawing.Point(32, 23);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fechaLabel.Location = new System.Drawing.Point(427, 23);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 2;
            fechaLabel.Text = "Fecha:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numeroLabel.Location = new System.Drawing.Point(221, 23);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(48, 13);
            numeroLabel.TabIndex = 4;
            numeroLabel.Text = "Número:";
            // 
            // asuntoLabel
            // 
            asuntoLabel.AutoSize = true;
            asuntoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            asuntoLabel.Location = new System.Drawing.Point(59, 197);
            asuntoLabel.Name = "asuntoLabel";
            asuntoLabel.Size = new System.Drawing.Size(45, 13);
            asuntoLabel.TabIndex = 1;
            asuntoLabel.Text = "Asunto:";
            // 
            // comentariosLabel
            // 
            comentariosLabel.AutoSize = true;
            comentariosLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            comentariosLabel.Location = new System.Drawing.Point(33, 370);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(71, 13);
            comentariosLabel.TabIndex = 3;
            comentariosLabel.Text = "Comentarios:";
            // 
            // Datos
            // 
            this.Datos.DataSource = typeof(moleQule.Library.Quality.NotificacionInterna);
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Codigo", true));
            this.codigoTextBox.Location = new System.Drawing.Point(86, 20);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(100, 21);
            this.codigoTextBox.TabIndex = 1;
            this.codigoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Datos, "Fecha", true));
            this.fechaDateTimePicker.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(476, 20);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(120, 21);
            this.fechaDateTimePicker.TabIndex = 3;
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(281, 20);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(100, 21);
            this.numeroTextBox.TabIndex = 5;
            this.numeroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // asuntoTextBox
            // 
            this.asuntoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Asunto", true));
            this.asuntoTextBox.Location = new System.Drawing.Point(110, 194);
            this.asuntoTextBox.Multiline = true;
            this.asuntoTextBox.Name = "asuntoTextBox";
            this.asuntoTextBox.Size = new System.Drawing.Size(497, 150);
            this.asuntoTextBox.TabIndex = 2;
            // 
            // comentariosTextBox
            // 
            this.comentariosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Comentarios", true));
            this.comentariosTextBox.Location = new System.Drawing.Point(110, 367);
            this.comentariosTextBox.Multiline = true;
            this.comentariosTextBox.Name = "comentariosTextBox";
            this.comentariosTextBox.Size = new System.Drawing.Size(497, 150);
            this.comentariosTextBox.TabIndex = 4;
            // 
            // Imprimir_BT
            // 
            this.Imprimir_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Imprimir_BT.Location = new System.Drawing.Point(257, 8);
            this.Imprimir_BT.Name = "Imprimir_BT";
            this.Imprimir_BT.Size = new System.Drawing.Size(75, 23);
            this.Imprimir_BT.TabIndex = 204;
            this.Imprimir_BT.Text = "Imprimir";
            this.Imprimir_BT.UseVisualStyleBackColor = true;
            this.Imprimir_BT.Click += new System.EventHandler(this.Imprimir_BT_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(59, 107);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 13);
            label1.TabIndex = 5;
            label1.Text = "A la atención de:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Atencion", true));
            this.textBox1.Location = new System.Drawing.Point(153, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(454, 21);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(80, 148);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 13);
            label2.TabIndex = 7;
            label2.Text = "Con copia a:";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Datos, "Copia", true));
            this.textBox2.Location = new System.Drawing.Point(153, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(454, 21);
            this.textBox2.TabIndex = 8;
            // 
            // ComunicadoAuditoriaActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(652, 562);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "ComunicadoAuditoriaActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Comunicado de Auditoría";
            this.Source_GB.ResumeLayout(false);
            this.Source_GB.PerformLayout();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel1.PerformLayout();
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.BindingSource Datos;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.TextBox comentariosTextBox;
        private System.Windows.Forms.TextBox asuntoTextBox;
        private System.Windows.Forms.Button Imprimir_BT;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
