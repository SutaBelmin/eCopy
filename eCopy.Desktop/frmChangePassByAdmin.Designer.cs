namespace eCopy.Desktop
{
    partial class frmChangePassByAdmin
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
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassCon = new System.Windows.Forms.TextBox();
            this.btnShowOldPass = new System.Windows.Forms.Button();
            this.btnShowNewPass = new System.Windows.Forms.Button();
            this.btnShowPassCon = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(150, 31);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(279, 22);
            this.txtOldPass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(150, 113);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(279, 22);
            this.txtNewPass.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password Confirm";
            // 
            // txtPassCon
            // 
            this.txtPassCon.Location = new System.Drawing.Point(150, 193);
            this.txtPassCon.Name = "txtPassCon";
            this.txtPassCon.PasswordChar = '*';
            this.txtPassCon.Size = new System.Drawing.Size(279, 22);
            this.txtPassCon.TabIndex = 4;
            // 
            // btnShowOldPass
            // 
            this.btnShowOldPass.Location = new System.Drawing.Point(150, 68);
            this.btnShowOldPass.Name = "btnShowOldPass";
            this.btnShowOldPass.Size = new System.Drawing.Size(87, 28);
            this.btnShowOldPass.TabIndex = 6;
            this.btnShowOldPass.Text = "Show";
            this.btnShowOldPass.UseVisualStyleBackColor = true;
            this.btnShowOldPass.Click += new System.EventHandler(this.btnShowOldPass_Click);
            // 
            // btnShowNewPass
            // 
            this.btnShowNewPass.Location = new System.Drawing.Point(150, 150);
            this.btnShowNewPass.Name = "btnShowNewPass";
            this.btnShowNewPass.Size = new System.Drawing.Size(87, 28);
            this.btnShowNewPass.TabIndex = 7;
            this.btnShowNewPass.Text = "Show";
            this.btnShowNewPass.UseVisualStyleBackColor = true;
            this.btnShowNewPass.Click += new System.EventHandler(this.btnShowNewPass_Click);
            // 
            // btnShowPassCon
            // 
            this.btnShowPassCon.Location = new System.Drawing.Point(150, 231);
            this.btnShowPassCon.Name = "btnShowPassCon";
            this.btnShowPassCon.Size = new System.Drawing.Size(87, 28);
            this.btnShowPassCon.TabIndex = 8;
            this.btnShowPassCon.Text = "Show";
            this.btnShowPassCon.UseVisualStyleBackColor = true;
            this.btnShowPassCon.Click += new System.EventHandler(this.btnShowPassCon_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(342, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmChangePassByAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 322);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowPassCon);
            this.Controls.Add(this.btnShowNewPass);
            this.Controls.Add(this.btnShowOldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassCon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldPass);
            this.Name = "frmChangePassByAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangePassByAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassCon;
        private System.Windows.Forms.Button btnShowOldPass;
        private System.Windows.Forms.Button btnShowNewPass;
        private System.Windows.Forms.Button btnShowPassCon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider err;
    }
}