
namespace UI.Desktop
{
    partial class VerInscripcionesAlumno
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvVerInscripciones = new System.Windows.Forms.DataGridView();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inscripcion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerInscripciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvVerInscripciones, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 301);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvVerInscripciones
            // 
            this.dgvVerInscripciones.AllowUserToAddRows = false;
            this.dgvVerInscripciones.AllowUserToDeleteRows = false;
            this.dgvVerInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materia,
            this.comision,
            this.inscripcion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvVerInscripciones, 2);
            this.dgvVerInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVerInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvVerInscripciones.Name = "dgvVerInscripciones";
            this.dgvVerInscripciones.ReadOnly = true;
            this.dgvVerInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVerInscripciones.Size = new System.Drawing.Size(443, 266);
            this.dgvVerInscripciones.TabIndex = 0;
            this.dgvVerInscripciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerInscripciones_CellContentClick);
            this.dgvVerInscripciones.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvVerInscripciones_DataBindingComplete);
            // 
            // materia
            // 
            this.materia.HeaderText = "Materia";
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            this.materia.Width = 175;
            // 
            // comision
            // 
            this.comision.HeaderText = "Comisión";
            this.comision.Name = "comision";
            this.comision.ReadOnly = true;
            this.comision.Width = 125;
            // 
            // inscripcion
            // 
            this.inscripcion.HeaderText = "Inscripción";
            this.inscripcion.Name = "inscripcion";
            this.inscripcion.ReadOnly = true;
            this.inscripcion.Text = "Eliminar inscripción";
            this.inscripcion.UseColumnTextForButtonValue = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(371, 275);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // VerInscripcionesAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 301);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VerInscripcionesAlumno";
            this.Text = "VerInscripcionesAlumno";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerInscripciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvVerInscripciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewButtonColumn inscripcion;
        private System.Windows.Forms.Button btnSalir;
    }
}