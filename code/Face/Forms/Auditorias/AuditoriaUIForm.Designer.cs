namespace moleQule.Face.Quality
{
    partial class AuditoriaUIForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Auditores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Usuarios_Auditores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Usuarios_Responsables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Informes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Cuestiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Estados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Ampliaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_AccionesCorrectoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Responsables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Departamentos_Auditores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Departamentos_Responsables)).BeginInit();
            this.Discrepancia_SC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Historia)).BeginInit();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Paneles2.Panel1.SuspendLayout();
            this.Paneles2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Auditor_CB
            // 
            this.Auditor_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Auditor_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // PlanAnual_CB
            // 
            this.PlanAnual_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PlanAnual_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PlanAnual_CB.SelectedIndexChanged += new System.EventHandler(this.PlanAnual_CB_SelectedIndexChanged);
            // 
            // Comunicar_BT
            // 
            this.Comunicar_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Comunicar_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Comunicar_BT.Click += new System.EventHandler(this.Comunicar_BT_Click);
            // 
            // Responsable_CB
            // 
            this.Responsable_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Responsable_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // Estado_TB
            // 
            this.Estado_TB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Estado_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Estado_TB.ForeColor = System.Drawing.Color.Black;
            this.Estado_TB.TabStop = false;
            // 
            // Referencia_TB
            // 
            this.Referencia_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Referencia_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // FechaInicio_DTP
            // 
            this.FechaInicio_DTP.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.FechaInicio_DTP.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FechaInicio_DTP.ShowCheckBox = true;
            this.FechaInicio_DTP.Size = new System.Drawing.Size(100, 21);
            // 
            // FechaFin_DTP
            // 
            this.FechaFin_DTP.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.FechaFin_DTP.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FechaFin_DTP.ShowCheckBox = true;
            this.FechaFin_DTP.Size = new System.Drawing.Size(100, 21);
            // 
            // Observaciones_TB
            // 
            this.Observaciones_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Observaciones_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // Desbloquear_BT
            // 
            this.Desbloquear_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Desbloquear_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Desbloquear_BT.Click += new System.EventHandler(this.Desbloquear_BT_Click);
            // 
            // NoConformidad_BT
            // 
            this.FinAuditoria_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FinAuditoria_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // Aprobar_BT
            // 
            this.Aprobar_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Aprobar_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Aprobar_BT.Click += new System.EventHandler(this.Aprobar_BT_Click);
            // 
            // Usuario_Responsable_CB
            // 
            this.Usuario_Responsable_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Usuario_Responsable_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // Usuario_Auditor_CB
            // 
            this.Usuario_Auditor_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Usuario_Auditor_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // Dpto_CB
            // 
            this.Dpto_CB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Dpto_CB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            // 
            // Aceptado_CBC
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.NullValue = false;
            this.Aceptado_CBC.DefaultCellStyle = dataGridViewCellStyle2;
            // 
            // TipoAuditoria_TB
            // 
            this.TipoAuditoria_TB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TipoAuditoria_TB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.TipoAuditoria_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TipoAuditoria_TB.TabStop = false;
            // 
            // Iniciar_BT
            // 
            this.Iniciar_BT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Iniciar_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Iniciar_BT.Click += new System.EventHandler(this.Iniciar_BT_Click);
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
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(281, 7);
            this.HelpProvider.SetShowHelp(this.Submit_BT, true);
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(377, 7);
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
            // 
            // Imprimir_Button
            // 
            this.Imprimir_Button.Location = new System.Drawing.Point(569, 7);
            this.HelpProvider.SetShowHelp(this.Imprimir_Button, true);
            // 
            // Docs_BT
            // 
            this.Docs_BT.Location = new System.Drawing.Point(473, 7);
            this.HelpProvider.SetShowHelp(this.Docs_BT, true);
            // 
            // AuditoriaUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(938, 702);
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Name = "AuditoriaUIForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "AuditoriaUIForm";
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Auditores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Usuarios_Auditores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Usuarios_Responsables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Informes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Cuestiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Estados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Ampliaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_AccionesCorrectoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Responsables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Departamentos_Auditores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Departamentos_Responsables)).EndInit();
            this.Discrepancia_SC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Historia)).EndInit();
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Paneles2.Panel1.ResumeLayout(false);
            this.Paneles2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
