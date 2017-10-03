namespace moleQule.Face.Quality
{
    partial class SeguimientoAuditoriasActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeguimientoAuditoriasActionForm));
            this.Auditoria_GB = new System.Windows.Forms.GroupBox();
            this.Auditoria_TB = new System.Windows.Forms.TextBox();
            this.Auditoria_BT = new System.Windows.Forms.Button();
            this.TodosAuditorias_CkB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FFinal_DTP = new moleQule.Face.Controls.mQDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FInicial_DTP = new moleQule.Face.Controls.mQDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Fechas_GB = new System.Windows.Forms.GroupBox();
            this.Planes_GB = new System.Windows.Forms.GroupBox();
            this.Plan_TB = new System.Windows.Forms.TextBox();
            this.Plan_BT = new System.Windows.Forms.Button();
            this.TodosPlanes_CkB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Estado_GB = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Estado_CB = new System.Windows.Forms.ComboBox();
            this.Datos_Estados = new System.Windows.Forms.BindingSource(this.components);
            this.TodosEstados_CkB = new System.Windows.Forms.CheckBox();
            this.FechaComunicacion_GB = new System.Windows.Forms.GroupBox();
            this.FComunicacion_DTP = new moleQule.Face.Controls.mQDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Source_GB.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Auditoria_GB.SuspendLayout();
            this.Fechas_GB.SuspendLayout();
            this.Planes_GB.SuspendLayout();
            this.Estado_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Estados)).BeginInit();
            this.FechaComunicacion_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(242, 7);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            this.Submit_BT.Text = "&Imprimir";
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(332, 7);
            this.HelpProvider.SetShowHelp(this.Cancel_BT, true);
            // 
            // Source_GB
            // 
            this.Source_GB.Controls.Add(this.FechaComunicacion_GB);
            this.Source_GB.Controls.Add(this.Estado_GB);
            this.Source_GB.Controls.Add(this.Planes_GB);
            this.Source_GB.Controls.Add(this.Fechas_GB);
            this.Source_GB.Controls.Add(this.Auditoria_GB);
            this.Source_GB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Source_GB.Location = new System.Drawing.Point(0, 0);
            this.HelpProvider.SetShowHelp(this.Source_GB, true);
            this.Source_GB.Size = new System.Drawing.Size(661, 313);
            this.Source_GB.Text = "";
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel1
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel1, true);
            // 
            // PanelesV.Panel2
            // 
            this.HelpProvider.SetShowHelp(this.PanelesV.Panel2, true);
            this.HelpProvider.SetShowHelp(this.PanelesV, true);
            this.PanelesV.Size = new System.Drawing.Size(663, 355);
            this.PanelesV.SplitterDistance = 315;
            // 
            // Auditoria_GB
            // 
            this.Auditoria_GB.Controls.Add(this.Auditoria_TB);
            this.Auditoria_GB.Controls.Add(this.Auditoria_BT);
            this.Auditoria_GB.Controls.Add(this.TodosAuditorias_CkB);
            this.Auditoria_GB.Controls.Add(this.label2);
            this.Auditoria_GB.Location = new System.Drawing.Point(47, 21);
            this.Auditoria_GB.Name = "Auditoria_GB";
            this.Auditoria_GB.Size = new System.Drawing.Size(568, 51);
            this.Auditoria_GB.TabIndex = 24;
            this.Auditoria_GB.TabStop = false;
            this.Auditoria_GB.Text = "Auditoría";
            // 
            // Auditoria_TB
            // 
            this.Auditoria_TB.Location = new System.Drawing.Point(86, 19);
            this.Auditoria_TB.Name = "Auditoria_TB";
            this.Auditoria_TB.ReadOnly = true;
            this.Auditoria_TB.Size = new System.Drawing.Size(290, 21);
            this.Auditoria_TB.TabIndex = 16;
            // 
            // Auditoria_BT
            // 
            this.Auditoria_BT.Enabled = false;
            this.Auditoria_BT.Image = global::moleQule.Face.Quality.Properties.Resources.seleccionar_16;
            this.Auditoria_BT.Location = new System.Drawing.Point(382, 18);
            this.Auditoria_BT.Name = "Auditoria_BT";
            this.Auditoria_BT.Size = new System.Drawing.Size(42, 23);
            this.Auditoria_BT.TabIndex = 15;
            this.Auditoria_BT.UseVisualStyleBackColor = true;
            this.Auditoria_BT.Click += new System.EventHandler(this.Cliente_BT_Click);
            // 
            // TodosAuditorias_CkB
            // 
            this.TodosAuditorias_CkB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TodosAuditorias_CkB.AutoSize = true;
            this.TodosAuditorias_CkB.Checked = true;
            this.TodosAuditorias_CkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodosAuditorias_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodosAuditorias_CkB.Location = new System.Drawing.Point(455, 21);
            this.TodosAuditorias_CkB.Name = "TodosAuditorias_CkB";
            this.TodosAuditorias_CkB.Size = new System.Drawing.Size(95, 17);
            this.TodosAuditorias_CkB.TabIndex = 14;
            this.TodosAuditorias_CkB.Text = "Mostrar Todos";
            this.TodosAuditorias_CkB.UseVisualStyleBackColor = true;
            this.TodosAuditorias_CkB.CheckedChanged += new System.EventHandler(this.TodosCliente_CkB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selección:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FFinal_DTP
            // 
            this.FFinal_DTP.Checked = false;
            this.FFinal_DTP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FFinal_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FFinal_DTP.Location = new System.Drawing.Point(382, 18);
            this.FFinal_DTP.Name = "FFinal_DTP";
            this.FFinal_DTP.ShowCheckBox = true;
            this.FFinal_DTP.Size = new System.Drawing.Size(112, 21);
            this.FFinal_DTP.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Fecha Final:";
            // 
            // FInicial_DTP
            // 
            this.FInicial_DTP.Checked = false;
            this.FInicial_DTP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FInicial_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FInicial_DTP.Location = new System.Drawing.Point(150, 18);
            this.FInicial_DTP.Name = "FInicial_DTP";
            this.FInicial_DTP.ShowCheckBox = true;
            this.FInicial_DTP.Size = new System.Drawing.Size(112, 21);
            this.FInicial_DTP.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Fecha Inicial:";
            // 
            // Fechas_GB
            // 
            this.Fechas_GB.Controls.Add(this.FInicial_DTP);
            this.Fechas_GB.Controls.Add(this.label4);
            this.Fechas_GB.Controls.Add(this.FFinal_DTP);
            this.Fechas_GB.Controls.Add(this.label3);
            this.Fechas_GB.Location = new System.Drawing.Point(47, 192);
            this.Fechas_GB.Name = "Fechas_GB";
            this.Fechas_GB.Size = new System.Drawing.Size(568, 49);
            this.Fechas_GB.TabIndex = 37;
            this.Fechas_GB.TabStop = false;
            this.Fechas_GB.Text = "Fechas";
            // 
            // Planes_GB
            // 
            this.Planes_GB.Controls.Add(this.Plan_TB);
            this.Planes_GB.Controls.Add(this.Plan_BT);
            this.Planes_GB.Controls.Add(this.TodosPlanes_CkB);
            this.Planes_GB.Controls.Add(this.label1);
            this.Planes_GB.Location = new System.Drawing.Point(47, 135);
            this.Planes_GB.Name = "Planes_GB";
            this.Planes_GB.Size = new System.Drawing.Size(568, 51);
            this.Planes_GB.TabIndex = 38;
            this.Planes_GB.TabStop = false;
            this.Planes_GB.Text = "Planes Anuales";
            // 
            // Plan_TB
            // 
            this.Plan_TB.Location = new System.Drawing.Point(86, 19);
            this.Plan_TB.Name = "Plan_TB";
            this.Plan_TB.ReadOnly = true;
            this.Plan_TB.Size = new System.Drawing.Size(290, 21);
            this.Plan_TB.TabIndex = 18;
            // 
            // Plan_BT
            // 
            this.Plan_BT.Enabled = false;
            this.Plan_BT.Image = global::moleQule.Face.Quality.Properties.Resources.seleccionar_16;
            this.Plan_BT.Location = new System.Drawing.Point(382, 18);
            this.Plan_BT.Name = "Plan_BT";
            this.Plan_BT.Size = new System.Drawing.Size(42, 23);
            this.Plan_BT.TabIndex = 17;
            this.Plan_BT.UseVisualStyleBackColor = true;
            this.Plan_BT.Click += new System.EventHandler(this.Producto_BT_Click);
            // 
            // TodosPlanes_CkB
            // 
            this.TodosPlanes_CkB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TodosPlanes_CkB.AutoSize = true;
            this.TodosPlanes_CkB.Checked = true;
            this.TodosPlanes_CkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodosPlanes_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodosPlanes_CkB.Location = new System.Drawing.Point(455, 22);
            this.TodosPlanes_CkB.Name = "TodosPlanes_CkB";
            this.TodosPlanes_CkB.Size = new System.Drawing.Size(95, 17);
            this.TodosPlanes_CkB.TabIndex = 14;
            this.TodosPlanes_CkB.Text = "Mostrar Todos";
            this.TodosPlanes_CkB.UseVisualStyleBackColor = true;
            this.TodosPlanes_CkB.CheckedChanged += new System.EventHandler(this.TodosProducto_CkB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selección:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Estado_GB
            // 
            this.Estado_GB.Controls.Add(this.label7);
            this.Estado_GB.Controls.Add(this.Estado_CB);
            this.Estado_GB.Controls.Add(this.TodosEstados_CkB);
            this.Estado_GB.Location = new System.Drawing.Point(47, 78);
            this.Estado_GB.Name = "Estado_GB";
            this.Estado_GB.Size = new System.Drawing.Size(568, 51);
            this.Estado_GB.TabIndex = 40;
            this.Estado_GB.TabStop = false;
            this.Estado_GB.Text = "Estados de Auditoría";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Estado de Auditoría:";
            // 
            // Estado_CB
            // 
            this.Estado_CB.DataSource = this.Datos_Estados;
            this.Estado_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estado_CB.Enabled = false;
            this.Estado_CB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estado_CB.FormattingEnabled = true;
            this.Estado_CB.Location = new System.Drawing.Point(134, 21);
            this.Estado_CB.Name = "Estado_CB";
            this.Estado_CB.Size = new System.Drawing.Size(290, 21);
            this.Estado_CB.TabIndex = 18;
            // 
            // TodosEstados_CkB
            // 
            this.TodosEstados_CkB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TodosEstados_CkB.AutoSize = true;
            this.TodosEstados_CkB.Checked = true;
            this.TodosEstados_CkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodosEstados_CkB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodosEstados_CkB.Location = new System.Drawing.Point(455, 23);
            this.TodosEstados_CkB.Name = "TodosEstados_CkB";
            this.TodosEstados_CkB.Size = new System.Drawing.Size(95, 17);
            this.TodosEstados_CkB.TabIndex = 13;
            this.TodosEstados_CkB.Text = "Mostrar Todos";
            this.TodosEstados_CkB.UseVisualStyleBackColor = true;
            this.TodosEstados_CkB.CheckedChanged += new System.EventHandler(this.TodosExpediente_CkB_CheckedChanged);
            // 
            // FechaComunicacion_GB
            // 
            this.FechaComunicacion_GB.Controls.Add(this.FComunicacion_DTP);
            this.FechaComunicacion_GB.Controls.Add(this.label5);
            this.FechaComunicacion_GB.Location = new System.Drawing.Point(47, 247);
            this.FechaComunicacion_GB.Name = "FechaComunicacion_GB";
            this.FechaComunicacion_GB.Size = new System.Drawing.Size(568, 49);
            this.FechaComunicacion_GB.TabIndex = 38;
            this.FechaComunicacion_GB.TabStop = false;
            this.FechaComunicacion_GB.Text = "Fecha de Comunicación";
            // 
            // FComunicacion_DTP
            // 
            this.FComunicacion_DTP.Checked = false;
            this.FComunicacion_DTP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FComunicacion_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FComunicacion_DTP.Location = new System.Drawing.Point(285, 15);
            this.FComunicacion_DTP.Name = "FComunicacion_DTP";
            this.FComunicacion_DTP.ShowCheckBox = true;
            this.FComunicacion_DTP.Size = new System.Drawing.Size(112, 21);
            this.FComunicacion_DTP.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(171, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Fecha Comunicación:";
            // 
            // SeguimientoAuditoriasActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(663, 355);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeguimientoAuditoriasActionForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Informe de Seguimiento de Auditorías";
            this.Source_GB.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Auditoria_GB.ResumeLayout(false);
            this.Auditoria_GB.PerformLayout();
            this.Fechas_GB.ResumeLayout(false);
            this.Fechas_GB.PerformLayout();
            this.Planes_GB.ResumeLayout(false);
            this.Planes_GB.PerformLayout();
            this.Estado_GB.ResumeLayout(false);
            this.Estado_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Estados)).EndInit();
            this.FechaComunicacion_GB.ResumeLayout(false);
            this.FechaComunicacion_GB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Auditoria_GB;
        private System.Windows.Forms.CheckBox TodosAuditorias_CkB;
        private System.Windows.Forms.Label label2;
        private moleQule.Face.Controls.mQDateTimePicker FFinal_DTP;
        private System.Windows.Forms.Label label3;
        private moleQule.Face.Controls.mQDateTimePicker FInicial_DTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Auditoria_TB;
        private System.Windows.Forms.Button Auditoria_BT;
        private System.Windows.Forms.GroupBox Fechas_GB;
        private System.Windows.Forms.GroupBox Planes_GB;
        private System.Windows.Forms.TextBox Plan_TB;
        private System.Windows.Forms.Button Plan_BT;
        private System.Windows.Forms.CheckBox TodosPlanes_CkB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Estado_GB;
        private System.Windows.Forms.CheckBox TodosEstados_CkB;
        private System.Windows.Forms.BindingSource Datos_Estados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Estado_CB;
        private System.Windows.Forms.GroupBox FechaComunicacion_GB;
        private moleQule.Face.Controls.mQDateTimePicker FComunicacion_DTP;
        private System.Windows.Forms.Label label5;
    }
}
