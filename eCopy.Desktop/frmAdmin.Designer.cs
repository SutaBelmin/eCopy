﻿namespace eCopy.Desktop
{
    partial class frmAdmin
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
            this.dgvListEmp = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.btnRes = new System.Windows.Forms.Button();
            this.btnAddEm = new System.Windows.Forms.Button();
            this.btnLogO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListEmp
            // 
            this.dgvListEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListEmp.Location = new System.Drawing.Point(12, 146);
            this.dgvListEmp.Name = "dgvListEmp";
            this.dgvListEmp.RowHeadersWidth = 51;
            this.dgvListEmp.RowTemplate.Height = 24;
            this.dgvListEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListEmp.Size = new System.Drawing.Size(776, 316);
            this.dgvListEmp.TabIndex = 0;
            this.dgvListEmp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListEmp_CellDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(604, 86);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 38);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "First name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 94);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(170, 22);
            this.txtFirstName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(205, 94);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(170, 22);
            this.txtLastName.TabIndex = 5;
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(699, 86);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(89, 38);
            this.btnRes.TabIndex = 6;
            this.btnRes.Text = "Reset";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // btnAddEm
            // 
            this.btnAddEm.Location = new System.Drawing.Point(12, 12);
            this.btnAddEm.Name = "btnAddEm";
            this.btnAddEm.Size = new System.Drawing.Size(184, 32);
            this.btnAddEm.TabIndex = 7;
            this.btnAddEm.Text = "Add employee";
            this.btnAddEm.UseVisualStyleBackColor = true;
            this.btnAddEm.Click += new System.EventHandler(this.btnAddEm_Click);
            // 
            // btnLogO
            // 
            this.btnLogO.Location = new System.Drawing.Point(670, 12);
            this.btnLogO.Name = "btnLogO";
            this.btnLogO.Size = new System.Drawing.Size(118, 32);
            this.btnLogO.TabIndex = 8;
            this.btnLogO.Text = "Logout";
            this.btnLogO.UseVisualStyleBackColor = true;
            this.btnLogO.Click += new System.EventHandler(this.btnLogO_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.btnLogO);
            this.Controls.Add(this.btnAddEm);
            this.Controls.Add(this.btnRes);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvListEmp);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListEmp;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Button btnAddEm;
        private System.Windows.Forms.Button btnLogO;
    }
}