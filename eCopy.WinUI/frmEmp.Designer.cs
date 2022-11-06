namespace eCopy.WinUI
{
    partial class frmEmp
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
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.printRequestRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnTurnover = new System.Windows.Forms.Button();
            this.btnTop5 = new System.Windows.Forms.Button();
            this.btnTLY = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printRequestRBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequests
            // 
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(12, 76);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.RowTemplate.Height = 29;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(902, 337);
            this.dgvRequests.TabIndex = 0;
            this.dgvRequests.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellDoubleClick);
            // 
            // printRequestRBindingSource
            // 
            this.printRequestRBindingSource.DataSource = typeof(eCopy.Model.Response.PrintRequestR);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of active requests:";
            // 
            // btnTurnover
            // 
            this.btnTurnover.Location = new System.Drawing.Point(12, 466);
            this.btnTurnover.Name = "btnTurnover";
            this.btnTurnover.Size = new System.Drawing.Size(159, 38);
            this.btnTurnover.TabIndex = 2;
            this.btnTurnover.Text = "Turnover";
            this.btnTurnover.UseVisualStyleBackColor = true;
            // 
            // btnTop5
            // 
            this.btnTop5.Location = new System.Drawing.Point(187, 466);
            this.btnTop5.Name = "btnTop5";
            this.btnTop5.Size = new System.Drawing.Size(159, 38);
            this.btnTop5.TabIndex = 3;
            this.btnTop5.Text = "Top 5 customers";
            this.btnTop5.UseVisualStyleBackColor = true;
            // 
            // btnTLY
            // 
            this.btnTLY.Location = new System.Drawing.Point(361, 466);
            this.btnTLY.Name = "btnTLY";
            this.btnTLY.Size = new System.Drawing.Size(159, 38);
            this.btnTLY.TabIndex = 4;
            this.btnTLY.Text = "Turnover for last year";
            this.btnTLY.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reports:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(820, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(94, 29);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 528);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTLY);
            this.Controls.Add(this.btnTop5);
            this.Controls.Add(this.btnTurnover);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRequests);
            this.Name = "frmEmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmp";
            this.Load += new System.EventHandler(this.frmEmp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printRequestRBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvRequests;
        private Label label1;
        private Button btnTurnover;
        private Button btnTop5;
        private Button btnTLY;
        private Label label2;
        private BindingSource printRequestRBindingSource;
        private Button btnLogout;
    }
}