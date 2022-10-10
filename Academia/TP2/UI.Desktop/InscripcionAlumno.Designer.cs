
namespace UI.Desktop
{
    partial class InscripcionAlumno
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
            this.dgvInscripcion = new System.Windows.Forms.DataGridView();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hs_semanales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hs_totales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inscripcion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvInscripcion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 324);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvInscripcion
            // 
            this.dgvInscripcion.AllowUserToAddRows = false;
            this.dgvInscripcion.AllowUserToDeleteRows = false;
            this.dgvInscripcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materia,
            this.hs_semanales,
            this.hs_totales,
            this.inscripcion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvInscripcion, 2);
            this.dgvInscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripcion.Location = new System.Drawing.Point(3, 3);
            this.dgvInscripcion.Name = "dgvInscripcion";
            this.dgvInscripcion.ReadOnly = true;
            this.dgvInscripcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripcion.Size = new System.Drawing.Size(468, 289);
            this.dgvInscripcion.TabIndex = 0;
            this.dgvInscripcion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInscripcion_CellContentClick);
            // 
            // materia
            // 
            this.materia.DataPropertyName = "Descripcion";
            this.materia.HeaderText = "Materia";
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            this.materia.Width = 175;
            // 
            // hs_semanales
            // 
            this.hs_semanales.DataPropertyName = "HSSemanales";
            this.hs_semanales.HeaderText = "Horas semanales";
            this.hs_semanales.Name = "hs_semanales";
            this.hs_semanales.ReadOnly = true;
            this.hs_semanales.Width = 75;
            // 
            // hs_totales
            // 
            this.hs_totales.DataPropertyName = "HSTotales";
            this.hs_totales.HeaderText = "Horas totales";
            this.hs_totales.Name = "hs_totales";
            this.hs_totales.ReadOnly = true;
            this.hs_totales.Width = 75;
            // 
            // inscripcion
            // 
            this.inscripcion.HeaderText = "Inscripcion";
            this.inscripcion.Name = "inscripcion";
            this.inscripcion.ReadOnly = true;
            this.inscripcion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.inscripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.inscripcion.Text = "Elegir comisión";
            this.inscripcion.UseColumnTextForButtonValue = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(315, 298);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(396, 298);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // InscripcionAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 324);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InscripcionAlumno";
            this.Text = "InscripcionAlumno";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvInscripcion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn hs_semanales;
        private System.Windows.Forms.DataGridViewTextBoxColumn hs_totales;
        private System.Windows.Forms.DataGridViewButtonColumn inscripcion;
    }
}