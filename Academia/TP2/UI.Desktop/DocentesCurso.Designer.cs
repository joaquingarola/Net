
namespace UI.Desktop
{
    partial class DocentesCurso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocentesCurso));
            this.tcDocentesCurso = new System.Windows.Forms.ToolStripContainer();
            this.tlDocentesCurso = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocentesCurso = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.docente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcDocentesCurso.ContentPanel.SuspendLayout();
            this.tcDocentesCurso.TopToolStripPanel.SuspendLayout();
            this.tcDocentesCurso.SuspendLayout();
            this.tlDocentesCurso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentesCurso)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDocentesCurso
            // 
            // 
            // tcDocentesCurso.ContentPanel
            // 
            this.tcDocentesCurso.ContentPanel.Controls.Add(this.tlDocentesCurso);
            this.tcDocentesCurso.ContentPanel.Size = new System.Drawing.Size(425, 271);
            this.tcDocentesCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDocentesCurso.Location = new System.Drawing.Point(0, 0);
            this.tcDocentesCurso.Name = "tcDocentesCurso";
            this.tcDocentesCurso.Size = new System.Drawing.Size(425, 296);
            this.tcDocentesCurso.TabIndex = 0;
            this.tcDocentesCurso.Text = "toolStripContainer1";
            // 
            // tcDocentesCurso.TopToolStripPanel
            // 
            this.tcDocentesCurso.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlDocentesCurso
            // 
            this.tlDocentesCurso.ColumnCount = 2;
            this.tlDocentesCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentesCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentesCurso.Controls.Add(this.dgvDocentesCurso, 0, 0);
            this.tlDocentesCurso.Controls.Add(this.btnActualizar, 0, 1);
            this.tlDocentesCurso.Controls.Add(this.btnSalir, 1, 1);
            this.tlDocentesCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentesCurso.Location = new System.Drawing.Point(0, 0);
            this.tlDocentesCurso.Name = "tlDocentesCurso";
            this.tlDocentesCurso.RowCount = 2;
            this.tlDocentesCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentesCurso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentesCurso.Size = new System.Drawing.Size(425, 271);
            this.tlDocentesCurso.TabIndex = 0;
            // 
            // dgvDocentesCurso
            // 
            this.dgvDocentesCurso.AllowUserToAddRows = false;
            this.dgvDocentesCurso.AllowUserToDeleteRows = false;
            this.dgvDocentesCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentesCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docente,
            this.cargo});
            this.tlDocentesCurso.SetColumnSpan(this.dgvDocentesCurso, 2);
            this.dgvDocentesCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocentesCurso.Location = new System.Drawing.Point(3, 3);
            this.dgvDocentesCurso.Name = "dgvDocentesCurso";
            this.dgvDocentesCurso.ReadOnly = true;
            this.dgvDocentesCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocentesCurso.Size = new System.Drawing.Size(419, 236);
            this.dgvDocentesCurso.TabIndex = 0;
            this.dgvDocentesCurso.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocentes_DataBindingComplete);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(266, 245);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(347, 245);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(58, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // docente
            // 
            this.docente.HeaderText = "Docente";
            this.docente.Name = "docente";
            this.docente.ReadOnly = true;
            this.docente.Width = 250;
            // 
            // cargo
            // 
            this.cargo.DataPropertyName = "cargo";
            this.cargo.HeaderText = "Cargo";
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            this.cargo.Width = 125;
            // 
            // DocentesCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 296);
            this.Controls.Add(this.tcDocentesCurso);
            this.Name = "DocentesCurso";
            this.Text = "DocentesCurso";
            this.tcDocentesCurso.ContentPanel.ResumeLayout(false);
            this.tcDocentesCurso.TopToolStripPanel.ResumeLayout(false);
            this.tcDocentesCurso.TopToolStripPanel.PerformLayout();
            this.tcDocentesCurso.ResumeLayout(false);
            this.tcDocentesCurso.PerformLayout();
            this.tlDocentesCurso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentesCurso)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcDocentesCurso;
        private System.Windows.Forms.TableLayoutPanel tlDocentesCurso;
        private System.Windows.Forms.DataGridView dgvDocentesCurso;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn docente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
    }
}