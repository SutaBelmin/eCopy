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
            this.dgvReq = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTrn = new System.Windows.Forms.Button();
            this.btnTopC = new System.Windows.Forms.Button();
            this.btnTforLY = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReq)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReq
            // 
            this.dgvReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReq.Location = new System.Drawing.Point(12, 82);
            this.dgvReq.Name = "dgvReq";
            this.dgvReq.RowHeadersWidth = 51;
            this.dgvReq.RowTemplate.Height = 24;
            this.dgvReq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReq.Size = new System.Drawing.Size(922, 306);
            this.dgvReq.TabIndex = 0;
            this.dgvReq.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReq_CellDoubleClick);
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
            this.btnTopC.Click += new System.EventHandler(this.btnTopC_Click);
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
            // btnLogO
            // 
            this.btnLogO.Location = new System.Drawing.Point(816, 21);
            this.btnLogO.Name = "btnLogO";
            this.btnLogO.Size = new System.Drawing.Size(118, 32);
            this.btnLogO.TabIndex = 9;
            this.btnLogO.Text = "Logout";
            this.btnLogO.UseVisualStyleBackColor = true;
            this.btnLogO.Click += new System.EventHandler(this.btnLogO_Click);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 501);
            this.Controls.Add(this.btnLogO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTforLY);
            this.Controls.Add(this.btnTopC);
            this.Controls.Add(this.btnTrn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReq);
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployee";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTrn;
        private System.Windows.Forms.Button btnTopC;
        private System.Windows.Forms.Button btnTforLY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogO;
    }
}