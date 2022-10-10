
namespace UI.Desktop
{
    partial class Login
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
            this.tlLogin = new System.Windows.Forms.TableLayoutPanel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lnkOlvidaPass = new System.Windows.Forms.LinkLabel();
            this.tlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlLogin
            // 
            this.tlLogin.ColumnCount = 3;
            this.tlLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tlLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlLogin.Controls.Add(this.btnIngresar, 1, 3);
            this.tlLogin.Controls.Add(this.label1, 1, 0);
            this.tlLogin.Controls.Add(this.label2, 0, 1);
            this.tlLogin.Controls.Add(this.label3, 0, 2);
            this.tlLogin.Controls.Add(this.txtUsuario, 1, 1);
            this.tlLogin.Controls.Add(this.txtContraseña, 1, 2);
            this.tlLogin.Controls.Add(this.lnkOlvidaPass, 0, 3);
            this.tlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlLogin.Location = new System.Drawing.Point(0, 0);
            this.tlLogin.Name = "tlLogin";
            this.tlLogin.RowCount = 4;
            this.tlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlLogin.Size = new System.Drawing.Size(399, 204);
            this.tlLogin.TabIndex = 0;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIngresar.Location = new System.Drawing.Point(161, 177);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 0;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido al sistema!";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsuario.Location = new System.Drawing.Point(136, 77);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(125, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContraseña.Location = new System.Drawing.Point(136, 135);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(125, 20);
            this.txtContraseña.TabIndex = 5;
            // 
            // lnkOlvidaPass
            // 
            this.lnkOlvidaPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkOlvidaPass.AutoSize = true;
            this.lnkOlvidaPass.Location = new System.Drawing.Point(14, 182);
            this.lnkOlvidaPass.Name = "lnkOlvidaPass";
            this.lnkOlvidaPass.Size = new System.Drawing.Size(103, 13);
            this.lnkOlvidaPass.TabIndex = 6;
            this.lnkOlvidaPass.TabStop = true;
            this.lnkOlvidaPass.Text = "Olvidé mi contaseña";
            this.lnkOlvidaPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOlvidaPass_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 204);
            this.Controls.Add(this.tlLogin);
            this.Name = "Login";
            this.Text = "Login";
            this.tlLogin.ResumeLayout(false);
            this.tlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlLogin;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.LinkLabel lnkOlvidaPass;
    }
}