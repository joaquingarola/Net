
namespace UI.Desktop
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuABMC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProfesores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripcionCursado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistroNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReporteCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportePlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.mnuMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(96, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuABMC,
            this.mnuInscripcionCursado,
            this.mnuVerInscripciones,
            this.mnuRegistroNotas,
            this.mnuReporteCursos,
            this.mnuReportePlanes});
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(50, 20);
            this.mnuMenu.Text = "Menu";
            // 
            // mnuABMC
            // 
            this.mnuABMC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemUsuarios,
            this.menuItemAlumnos,
            this.menuItemProfesores,
            this.mnuItemEspecialidades,
            this.mnuItemPlanes,
            this.mnuItemComisiones,
            this.menuItemCursos});
            this.mnuABMC.Name = "mnuABMC";
            this.mnuABMC.Size = new System.Drawing.Size(186, 22);
            this.mnuABMC.Text = "ABMC";
            // 
            // mnuItemUsuarios
            // 
            this.mnuItemUsuarios.Name = "mnuItemUsuarios";
            this.mnuItemUsuarios.Size = new System.Drawing.Size(165, 22);
            this.mnuItemUsuarios.Text = "Usuarios";
            this.mnuItemUsuarios.Click += new System.EventHandler(this.mnuItemUsuarios_Click);
            // 
            // menuItemAlumnos
            // 
            this.menuItemAlumnos.Name = "menuItemAlumnos";
            this.menuItemAlumnos.Size = new System.Drawing.Size(165, 22);
            this.menuItemAlumnos.Text = "Alumnos";
            this.menuItemAlumnos.Click += new System.EventHandler(this.mnuItemAlumnos_Click);
            // 
            // menuItemProfesores
            // 
            this.menuItemProfesores.Name = "menuItemProfesores";
            this.menuItemProfesores.Size = new System.Drawing.Size(165, 22);
            this.menuItemProfesores.Text = "Profesores";
            this.menuItemProfesores.Click += new System.EventHandler(this.mnuItemProfesores_Click);
            // 
            // mnuItemEspecialidades
            // 
            this.mnuItemEspecialidades.Name = "mnuItemEspecialidades";
            this.mnuItemEspecialidades.Size = new System.Drawing.Size(165, 22);
            this.mnuItemEspecialidades.Text = "Especialidades";
            this.mnuItemEspecialidades.Click += new System.EventHandler(this.mnuItemEspecialidades_Click);
            // 
            // mnuItemPlanes
            // 
            this.mnuItemPlanes.Name = "mnuItemPlanes";
            this.mnuItemPlanes.Size = new System.Drawing.Size(165, 22);
            this.mnuItemPlanes.Text = "Planes y materias";
            this.mnuItemPlanes.Click += new System.EventHandler(this.mnuItemPlanes_Click);
            // 
            // mnuItemComisiones
            // 
            this.mnuItemComisiones.Name = "mnuItemComisiones";
            this.mnuItemComisiones.Size = new System.Drawing.Size(165, 22);
            this.mnuItemComisiones.Text = "Comisiones";
            this.mnuItemComisiones.Click += new System.EventHandler(this.mnuItemComisiones_Click);
            // 
            // menuItemCursos
            // 
            this.menuItemCursos.Name = "menuItemCursos";
            this.menuItemCursos.Size = new System.Drawing.Size(165, 22);
            this.menuItemCursos.Text = "Cursos";
            this.menuItemCursos.Click += new System.EventHandler(this.mnuItemCursos_Click);
            // 
            // mnuInscripcionCursado
            // 
            this.mnuInscripcionCursado.Name = "mnuInscripcionCursado";
            this.mnuInscripcionCursado.Size = new System.Drawing.Size(186, 22);
            this.mnuInscripcionCursado.Text = "Inscripción a cursado";
            this.mnuInscripcionCursado.Click += new System.EventHandler(this.mnuInscripcionCursado_Click);
            // 
            // mnuVerInscripciones
            // 
            this.mnuVerInscripciones.Name = "mnuVerInscripciones";
            this.mnuVerInscripciones.Size = new System.Drawing.Size(186, 22);
            this.mnuVerInscripciones.Text = "Ver inscripciones";
            this.mnuVerInscripciones.Click += new System.EventHandler(this.mnuVerInscripciones_Click);
            // 
            // mnuRegistroNotas
            // 
            this.mnuRegistroNotas.Name = "mnuRegistroNotas";
            this.mnuRegistroNotas.Size = new System.Drawing.Size(186, 22);
            this.mnuRegistroNotas.Text = "Registro de notas";
            this.mnuRegistroNotas.Click += new System.EventHandler(this.mnuRegistroDeNotas_Click);
            // 
            // mnuReporteCursos
            // 
            this.mnuReporteCursos.Name = "mnuReporteCursos";
            this.mnuReporteCursos.Size = new System.Drawing.Size(186, 22);
            this.mnuReporteCursos.Text = "Reporte cursos";
            this.mnuReporteCursos.Click += new System.EventHandler(this.mnuReporteCursos_Click);
            // 
            // mnuReportePlanes
            // 
            this.mnuReportePlanes.Name = "mnuReportePlanes";
            this.mnuReportePlanes.Size = new System.Drawing.Size(186, 22);
            this.mnuReportePlanes.Text = "Reporte planes";
            this.mnuReportePlanes.Click += new System.EventHandler(this.mnuReportePlanes_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(449, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Academia";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuABMC;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuItemComisiones;
        private System.Windows.Forms.ToolStripMenuItem menuItemAlumnos;
        private System.Windows.Forms.ToolStripMenuItem menuItemProfesores;
        private System.Windows.Forms.ToolStripMenuItem menuItemCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripcionCursado;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistroNotas;
        private System.Windows.Forms.ToolStripMenuItem mnuVerInscripciones;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuReportePlanes;
    }
}