﻿namespace eCopy.Desktop
{
    partial class frmPSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrintPO = new System.Windows.Forms.TextBox();
            this.txtOrie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPagePS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLett = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSidePO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUStatus = new System.Windows.Forms.Button();
            this.cmbSt = new System.Windows.Forms.ComboBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPreviewPrnt = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Print pages options";
            // 
            // txtPrintPO
            // 
            this.txtPrintPO.Location = new System.Drawing.Point(19, 99);
            this.txtPrintPO.Name = "txtPrintPO";
            this.txtPrintPO.ReadOnly = true;
            this.txtPrintPO.Size = new System.Drawing.Size(265, 24);
            this.txtPrintPO.TabIndex = 1;
            // 
            // txtOrie
            // 
            this.txtOrie.Location = new System.Drawing.Point(19, 159);
            this.txtOrie.Name = "txtOrie";
            this.txtOrie.ReadOnly = true;
            this.txtOrie.Size = new System.Drawing.Size(265, 24);
            this.txtOrie.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orientation";
            // 
            // txtPagePS
            // 
            this.txtPagePS.Location = new System.Drawing.Point(19, 225);
            this.txtPagePS.Name = "txtPagePS";
            this.txtPagePS.ReadOnly = true;
            this.txtPagePS.Size = new System.Drawing.Size(265, 24);
            this.txtPagePS.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(16, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Page per sheet";
            // 
            // txtColl
            // 
            this.txtColl.Location = new System.Drawing.Point(332, 225);
            this.txtColl.Name = "txtColl";
            this.txtColl.ReadOnly = true;
            this.txtColl.Size = new System.Drawing.Size(265, 24);
            this.txtColl.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(328, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Collate";
            // 
            // txtLett
            // 
            this.txtLett.Location = new System.Drawing.Point(332, 159);
            this.txtLett.Name = "txtLett";
            this.txtLett.ReadOnly = true;
            this.txtLett.Size = new System.Drawing.Size(265, 24);
            this.txtLett.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(328, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Letter";
            // 
            // txtSidePO
            // 
            this.txtSidePO.Location = new System.Drawing.Point(332, 99);
            this.txtSidePO.Name = "txtSidePO";
            this.txtSidePO.ReadOnly = true;
            this.txtSidePO.Size = new System.Drawing.Size(265, 24);
            this.txtSidePO.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(328, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Side pages options";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(328, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(14, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 29);
            this.label8.TabIndex = 14;
            this.label8.Text = "Print settings ";
            // 
            // btnUStatus
            // 
            this.btnUStatus.Location = new System.Drawing.Point(461, 414);
            this.btnUStatus.Name = "btnUStatus";
            this.btnUStatus.Size = new System.Drawing.Size(136, 33);
            this.btnUStatus.TabIndex = 2;
            this.btnUStatus.Text = "Save";
            this.btnUStatus.UseVisualStyleBackColor = true;
            this.btnUStatus.Click += new System.EventHandler(this.btnUStatus_Click);
            // 
            // cmbSt
            // 
            this.cmbSt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSt.FormattingEnabled = true;
            this.cmbSt.Location = new System.Drawing.Point(332, 371);
            this.cmbSt.Name = "cmbSt";
            this.cmbSt.Size = new System.Drawing.Size(265, 26);
            this.cmbSt.TabIndex = 1;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(19, 371);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(265, 76);
            this.txtComment.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Add comment (External note)";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(461, 22);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(136, 33);
            this.btnDownload.TabIndex = 19;
            this.btnDownload.Text = "Download file";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPreviewPrnt
            // 
            this.btnPreviewPrnt.Location = new System.Drawing.Point(214, 21);
            this.btnPreviewPrnt.Name = "btnPreviewPrnt";
            this.btnPreviewPrnt.Size = new System.Drawing.Size(110, 33);
            this.btnPreviewPrnt.TabIndex = 22;
            this.btnPreviewPrnt.Text = "Preview";
            this.btnPreviewPrnt.UseVisualStyleBackColor = true;
            this.btnPreviewPrnt.Click += new System.EventHandler(this.btnPreviewPrnt_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(332, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 33);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(19, 287);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.ReadOnly = true;
            this.txtPayment.Size = new System.Drawing.Size(265, 24);
            this.txtPayment.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(16, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "Payment information";
            // 
            // frmPSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 474);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreviewPrnt);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.cmbSt);
            this.Controls.Add(this.btnUStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtColl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLett);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSidePO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPagePS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrintPO);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "frmPSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print settings";
            this.Load += new System.EventHandler(this.frmPSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrintPO;
        private System.Windows.Forms.TextBox txtOrie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPagePS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLett;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSidePO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUStatus;
        private System.Windows.Forms.ComboBox cmbSt;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnPreviewPrnt;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label10;
    }
}