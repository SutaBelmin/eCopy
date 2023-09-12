namespace eCopy.Desktop
{
    partial class frmTop5Customers
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
            this.dgvTop5Customers = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5Customers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTop5Customers
            // 
            this.dgvTop5Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop5Customers.Location = new System.Drawing.Point(12, 12);
            this.dgvTop5Customers.Name = "dgvTop5Customers";
            this.dgvTop5Customers.RowHeadersWidth = 51;
            this.dgvTop5Customers.RowTemplate.Height = 24;
            this.dgvTop5Customers.Size = new System.Drawing.Size(737, 320);
            this.dgvTop5Customers.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(655, 350);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 32);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmTop5Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 394);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvTop5Customers);
            this.Name = "frmTop5Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top 5 customers";
            this.Load += new System.EventHandler(this.frmTop5Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5Customers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTop5Customers;
        private System.Windows.Forms.Button btnPrint;
    }
}