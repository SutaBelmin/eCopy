namespace eCopy.WinUI
{
    partial class frmPrintSettings
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrintOptions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLetter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrientation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCollate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.txtSideOptions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Print settings view:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Print pages options";
            // 
            // txtPrintOptions
            // 
            this.txtPrintOptions.Location = new System.Drawing.Point(26, 103);
            this.txtPrintOptions.Name = "txtPrintOptions";
            this.txtPrintOptions.ReadOnly = true;
            this.txtPrintOptions.Size = new System.Drawing.Size(278, 27);
            this.txtPrintOptions.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Side print options";
            // 
            // txtLetter
            // 
            this.txtLetter.Location = new System.Drawing.Point(328, 167);
            this.txtLetter.Name = "txtLetter";
            this.txtLetter.ReadOnly = true;
            this.txtLetter.Size = new System.Drawing.Size(278, 27);
            this.txtLetter.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Letter";
            // 
            // txtOrientation
            // 
            this.txtOrientation.Location = new System.Drawing.Point(26, 167);
            this.txtOrientation.Name = "txtOrientation";
            this.txtOrientation.ReadOnly = true;
            this.txtOrientation.Size = new System.Drawing.Size(278, 27);
            this.txtOrientation.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Orientation";
            // 
            // txtCollate
            // 
            this.txtCollate.Location = new System.Drawing.Point(328, 232);
            this.txtCollate.Name = "txtCollate";
            this.txtCollate.ReadOnly = true;
            this.txtCollate.Size = new System.Drawing.Size(278, 27);
            this.txtCollate.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Collate";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(26, 232);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.Size = new System.Drawing.Size(278, 27);
            this.txtPage.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Page per sheet";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(328, 324);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(278, 28);
            this.cmbStatus.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Status";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(497, 371);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(109, 34);
            this.btnUpdateStatus.TabIndex = 17;
            this.btnUpdateStatus.Text = "Update status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // txtSideOptions
            // 
            this.txtSideOptions.Location = new System.Drawing.Point(328, 103);
            this.txtSideOptions.Name = "txtSideOptions";
            this.txtSideOptions.ReadOnly = true;
            this.txtSideOptions.Size = new System.Drawing.Size(278, 27);
            this.txtSideOptions.TabIndex = 18;
            // 
            // frmPrintSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 436);
            this.Controls.Add(this.txtSideOptions);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtCollate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLetter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOrientation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrintOptions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPrintSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrintSettings";
            this.Load += new System.EventHandler(this.frmPrintSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPrintOptions;
        private Label label3;
        private TextBox txtLetter;
        private Label label4;
        private TextBox txtOrientation;
        private Label label5;
        private TextBox txtCollate;
        private Label label6;
        private TextBox txtPage;
        private Label label7;
        private ComboBox cmbStatus;
        private Label label8;
        private Button btnUpdateStatus;
        private TextBox txtSideOptions;
    }
}