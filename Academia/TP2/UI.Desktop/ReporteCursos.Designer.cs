
namespace UI.Desktop
{
    partial class ReporteCursos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.rvInscripciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cursosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.cursosTableAdapter();
            this.tableAdapterManager = new UI.Desktop.AcademiaDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cursosBindingSource
            // 
            this.cursosBindingSource.DataMember = "cursos";
            this.cursosBindingSource.DataSource = this.academiaDataSet;
            // 
            // academiaDataSet
            // 
            this.academiaDataSet.DataSetName = "AcademiaDataSet";
            this.academiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvInscripciones
            // 
            this.rvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "Cursos";
            reportDataSource2.Value = this.cursosBindingSource;
            this.rvInscripciones.LocalReport.DataSources.Add(reportDataSource2);
            this.rvInscripciones.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReporteCursos.rdlc";
            this.rvInscripciones.Location = new System.Drawing.Point(0, 0);
            this.rvInscripciones.Name = "rvInscripciones";
            this.rvInscripciones.ServerReport.BearerToken = null;
            this.rvInscripciones.Size = new System.Drawing.Size(789, 397);
            this.rvInscripciones.TabIndex = 0;
            // 
            // cursosTableAdapter
            // 
            this.cursosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = UI.Desktop.AcademiaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 397);
            this.Controls.Add(this.rvInscripciones);
            this.Name = "ReporteCursos";
            this.Text = "Reporte Cursos";
            this.Load += new System.EventHandler(this.ReporteAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvInscripciones;
        private AcademiaDataSet academiaDataSet;
        private System.Windows.Forms.BindingSource cursosBindingSource;
        private AcademiaDataSetTableAdapters.cursosTableAdapter cursosTableAdapter;
        private AcademiaDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}