namespace eCopy.Desktop
{
    partial class frmEmployee
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
            this.dgvLofRequests = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTrn = new System.Windows.Forms.Button();
            this.btnTopC = new System.Windows.Forms.Button();
            this.btnTforLY = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLofRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLofRequests
            // 
            this.dgvLofRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLofRequests.Location = new System.Drawing.Point(12, 82);
            this.dgvLofRequests.Name = "dgvLofRequests";
            this.dgvLofRequests.RowHeadersWidth = 51;
            this.dgvLofRequests.RowTemplate.Height = 24;
            this.dgvLofRequests.Size = new System.Drawing.Size(922, 306);
            this.dgvLofRequests.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of active requests:";
            // 
            // btnTrn
            // 
            this.btnTrn.Location = new System.Drawing.Point(12, 438);
            this.btnTrn.Name = "btnTrn";
            this.btnTrn.Size = new System.Drawing.Size(108, 36);
            this.btnTrn.TabIndex = 2;
            this.btnTrn.Text = "Turnover";
            this.btnTrn.UseVisualStyleBackColor = true;
            // 
            // btnTopC
            // 
            this.btnTopC.Location = new System.Drawing.Point(136, 438);
            this.btnTopC.Name = "btnTopC";
            this.btnTopC.Size = new System.Drawing.Size(161, 36);
            this.btnTopC.TabIndex = 3;
            this.btnTopC.Text = "Top 5 customers";
            this.btnTopC.UseVisualStyleBackColor = true;
            // 
            // btnTforLY
            // 
            this.btnTforLY.Location = new System.Drawing.Point(317, 438);
            this.btnTforLY.Name = "btnTforLY";
            this.btnTforLY.Size = new System.Drawing.Size(160, 36);
            this.btnTforLY.TabIndex = 4;
            this.btnTforLY.Text = "Turnover for last year";
            this.btnTforLY.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reports:";
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTforLY);
            this.Controls.Add(this.btnTopC);
            this.Controls.Add(this.btnTrn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLofRequests);
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLofRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLofRequests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTrn;
        private System.Windows.Forms.Button btnTopC;
        private System.Windows.Forms.Button btnTforLY;
        private System.Windows.Forms.Label label2;
    }
}