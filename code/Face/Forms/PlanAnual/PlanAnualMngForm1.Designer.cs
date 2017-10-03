namespace molApp.Face.Modules.Quality
{
    partial class PlanAnualMngForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanAnualMngForm));
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.Nombre_TP = new System.Windows.Forms.TabPage();
            this.Datos_Planes = new System.Windows.Forms.BindingSource(this.components);
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.childsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nHMngDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelesH.Panel1.SuspendLayout();
            this.PanelesH.Panel2.SuspendLayout();
            this.PanelesH.SuspendLayout();
            this.PanelesV.Panel1.SuspendLayout();
            this.PanelesV.Panel2.SuspendLayout();
            this.PanelesV.SuspendLayout();
            this.Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_Button
            // 
            this.Close_Button.Location = new System.Drawing.Point(10, 470);
            // 
            // PanelesH
            // 
            // 
            // PanelesH.Panel1
            // 
            this.PanelesH.Panel1.BackColor = System.Drawing.Color.SlateGray;
            this.PanelesH.SplitterDistance = 114;
            // 
            // PanelesV
            // 
            // 
            // PanelesV.Panel2
            // 
            this.PanelesV.Panel2.Controls.Add(this.Tabla);
            this.PanelesV.Size = new System.Drawing.Size(727, 514);
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.Nombre_TP);
            this.Filtros.Location = new System.Drawing.Point(237, 3);
            this.Filtros.Size = new System.Drawing.Size(252, 25);
            this.Filtros.Controls.SetChildIndex(this.Advanced_TP, 0);
            this.Filtros.Controls.SetChildIndex(this.Nombre_TP, 0);
            this.Filtros.Controls.SetChildIndex(this.Todos_TP, 0);
            // 
            // Todos_TP
            // 
            this.Todos_TP.Size = new System.Drawing.Size(244, 0);
            // 
            // Advanced_TP
            // 
            this.Advanced_TP.Size = new System.Drawing.Size(244, -1);
            // 
            // Datos
            // 
            this.Datos.DataSource = this.Datos_Planes;
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.AllowUserToOrderColumns = true;
            this.Tabla.AutoGenerateColumns = false;
            this.Tabla.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Tabla.ColumnHeadersHeight = 34;
            this.Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.serialDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn,
            this.edicionDataGridViewTextBoxColumn,
            this.revisionDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.oidDataGridViewTextBoxColumn,
            this.sessionCodeDataGridViewTextBoxColumn,
            this.childsDataGridViewCheckBoxColumn,
            this.nHMngDataGridViewTextBoxColumn});
            this.Tabla.DataSource = this.Datos;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Tabla.DefaultCellStyle = dataGridViewCellStyle13;
            this.Tabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.Tabla.Location = new System.Drawing.Point(0, 0);
            this.Tabla.MultiSelect = false;
            this.Tabla.Name = "Tabla";
            this.Tabla.ReadOnly = true;
            this.Tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tabla.Size = new System.Drawing.Size(727, 488);
            this.Tabla.TabIndex = 0;
            this.Tabla.DoubleClick += new System.EventHandler(this.Tabla_DoubleClick);
            // 
            // Nombre_TP
            // 
            this.Nombre_TP.Location = new System.Drawing.Point(4, 22);
            this.Nombre_TP.Name = "Nombre_TP";
            this.Nombre_TP.Size = new System.Drawing.Size(244, 0);
            this.Nombre_TP.TabIndex = 7;
            this.Nombre_TP.Text = "Nombre";
            this.Nombre_TP.UseVisualStyleBackColor = true;
            // 
            // Datos_Planes
            // 
            this.Datos_Planes.DataSource = typeof(molApp.Library.Modules.Quality.PlanAnualInfo);
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.codigoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serialDataGridViewTextBoxColumn
            // 
            this.serialDataGridViewTextBoxColumn.DataPropertyName = "Serial";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "N0";
            this.serialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.serialDataGridViewTextBoxColumn.HeaderText = "Serial";
            this.serialDataGridViewTextBoxColumn.Name = "serialDataGridViewTextBoxColumn";
            this.serialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nombreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.observacionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // edicionDataGridViewTextBoxColumn
            // 
            this.edicionDataGridViewTextBoxColumn.DataPropertyName = "Edicion";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.edicionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.edicionDataGridViewTextBoxColumn.HeaderText = "Edicion";
            this.edicionDataGridViewTextBoxColumn.Name = "edicionDataGridViewTextBoxColumn";
            this.edicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // revisionDataGridViewTextBoxColumn
            // 
            this.revisionDataGridViewTextBoxColumn.DataPropertyName = "Revision";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.revisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.revisionDataGridViewTextBoxColumn.HeaderText = "Revision";
            this.revisionDataGridViewTextBoxColumn.Name = "revisionDataGridViewTextBoxColumn";
            this.revisionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.Format = "d";
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oidDataGridViewTextBoxColumn
            // 
            this.oidDataGridViewTextBoxColumn.DataPropertyName = "Oid";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Format = "N0";
            this.oidDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.oidDataGridViewTextBoxColumn.HeaderText = "Oid";
            this.oidDataGridViewTextBoxColumn.Name = "oidDataGridViewTextBoxColumn";
            this.oidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sessionCodeDataGridViewTextBoxColumn
            // 
            this.sessionCodeDataGridViewTextBoxColumn.DataPropertyName = "SessionCode";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sessionCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.sessionCodeDataGridViewTextBoxColumn.HeaderText = "SessionCode";
            this.sessionCodeDataGridViewTextBoxColumn.Name = "sessionCodeDataGridViewTextBoxColumn";
            this.sessionCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // childsDataGridViewCheckBoxColumn
            // 
            this.childsDataGridViewCheckBoxColumn.DataPropertyName = "Childs";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.NullValue = false;
            this.childsDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.childsDataGridViewCheckBoxColumn.HeaderText = "Childs";
            this.childsDataGridViewCheckBoxColumn.Name = "childsDataGridViewCheckBoxColumn";
            this.childsDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nHMngDataGridViewTextBoxColumn
            // 
            this.nHMngDataGridViewTextBoxColumn.DataPropertyName = "nHMng";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nHMngDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.nHMngDataGridViewTextBoxColumn.HeaderText = "nHMng";
            this.nHMngDataGridViewTextBoxColumn.Name = "nHMngDataGridViewTextBoxColumn";
            this.nHMngDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PlanAnualMngForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(844, 516);
            this.HelpProvider.SetHelpKeyword(this, "30");
            this.HelpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlanAnualMngForm";
            this.HelpProvider.SetShowHelp(this, true);
            this.Text = "Planes Anuales";
            this.Controls.SetChildIndex(this.PanelesH, 0);
            this.PanelesH.Panel1.ResumeLayout(false);
            this.PanelesH.Panel2.ResumeLayout(false);
            this.PanelesH.ResumeLayout(false);
            this.PanelesV.Panel1.ResumeLayout(false);
            this.PanelesV.Panel2.ResumeLayout(false);
            this.PanelesV.ResumeLayout(false);
            this.Filtros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_Planes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.TabPage Nombre_TP;
        private System.Windows.Forms.BindingSource Datos_Planes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn edicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn revisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn childsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nHMngDataGridViewTextBoxColumn;



    }
}
