namespace eCopy.Desktop
{
    partial class frmEmpDet
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(252, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name";
            // 
            // txtFN
            // 
            this.txtFN.Location = new System.Drawing.Point(365, 29);
            this.txtFN.Multiline = true;
            this.txtFN.Name = "txtFN";
            this.txtFN.ReadOnly = true;
            this.txtFN.Size = new System.Drawing.Size(225, 29);
            this.txtFN.TabIndex = 1;
            // 
            // txtLN
            // 
            this.txtLN.Location = new System.Drawing.Point(365, 80);
            this.txtLN.Multiline = true;
            this.txtLN.Name = "txtLN";
            this.txtLN.ReadOnly = true;
            this.txtLN.Size = new System.Drawing.Size(225, 29);
            this.txtLN.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(252, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last name";
            // 
            // txtMN
            // 
            this.txtMN.Location = new System.Drawing.Point(365, 128);
            this.txtMN.Multiline = true;
            this.txtMN.Name = "txtMN";
            this.txtMN.ReadOnly = true;
            this.txtMN.Size = new System.Drawing.Size(225, 29);
            this.txtMN.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(252, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Middle name";
            // 
            // txtGen
            // 
            this.txtGen.Location = new System.Drawing.Point(365, 178);
            this.txtGen.Multiline = true;
            this.txtGen.Name = "txtGen";
            this.txtGen.ReadOnly = true;
            this.txtGen.Size = new System.Drawing.Size(225, 29);
            this.txtGen.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(252, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gender";
            // 
            // txtCN
            // 
            this.txtCN.Location = new System.Drawing.Point(365, 225);
            this.txtCN.Multiline = true;
            this.txtCN.Name = "txtCN";
            this.txtCN.ReadOnly = true;
            this.txtCN.Size = new System.Drawing.Size(225, 29);
            this.txtCN.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(252, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Copier name";
            // 
            // pbSlika
            // 
            this.pbSlika.Location = new System.Drawing.Point(12, 29);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(223, 215);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 10;
            this.pbSlika.TabStop = false;
            // 
            // frmEmpDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 282);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.txtCN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.label1);
            this.Name = "frmEmpDet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmpDet";
            this.Load += new System.EventHandler(this.frmEmpDet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbSlika;
    }
}