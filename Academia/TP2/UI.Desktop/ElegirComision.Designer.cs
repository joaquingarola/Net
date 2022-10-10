
namespace UI.Desktop
{
    partial class ElegirComision
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
            this.dgvElegirComision = new System.Windows.Forms.DataGridView();
            this.id_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirComision)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvElegirComision, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInscribirse, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 239);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvElegirComision
            // 
            this.dgvElegirComision.AllowUserToAddRows = false;
            this.dgvElegirComision.AllowUserToDeleteRows = false;
            this.dgvElegirComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElegirComision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_curso,
            this.anioEspecialidad,
            this.comision});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvElegirComision, 2);
            this.dgvElegirComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElegirComision.Location = new System.Drawing.Point(3, 3);
            this.dgvElegirComision.MultiSelect = false;
            this.dgvElegirComision.Name = "dgvElegirComision";
            this.dgvElegirComision.ReadOnly = true;
            this.dgvElegirComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvElegirComision.Size = new System.Drawing.Size(268, 204);
            this.dgvElegirComision.TabIndex = 0;
            this.dgvElegirComision.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvElegirComision_DataBindingComplete);
            // 
            // id_curso
            // 
            this.id_curso.HeaderText = "ID Curso";
            this.id_curso.Name = "id_curso";
            this.id_curso.ReadOnly = true;
            this.id_curso.Visible = false;
            // 
            // anioEspecialidad
            // 
            this.anioEspecialidad.HeaderText = "Año";
            this.anioEspecialidad.Name = "anioEspecialidad";
            this.anioEspecialidad.ReadOnly = true;
            this.anioEspecialidad.Width = 75;
            // 
            // comision
            // 
            this.comision.HeaderText = "Comision";
            this.comision.Name = "comision";
            this.comision.ReadOnly = true;
            this.comision.Width = 150;
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInscribirse.Location = new System.Drawing.Point(115, 213);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(75, 23);
            this.btnInscribirse.TabIndex = 1;
            this.btnInscribirse.Text = "Inscribirse";
            this.btnInscribirse.UseVisualStyleBackColor = true;
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(196, 213);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ElegirComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 239);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ElegirComision";
            this.Text = "ElegirComision";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirComision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvElegirComision;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
    }
}