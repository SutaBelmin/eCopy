namespace eCopy.Desktop
{
    partial class frmRevenueForLastYear
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chrtLastYearRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrtLastYearRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(739, 550);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 33);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chrtLastYearRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtLastYearRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtLastYearRevenue.Legends.Add(legend1);
            this.chrtLastYearRevenue.Location = new System.Drawing.Point(12, 12);
            this.chrtLastYearRevenue.Name = "chrtLastYearRevenue";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Data";
            series1.XValueMember = "Date";
            series1.YValueMembers = "Revenue";
            this.chrtLastYearRevenue.Series.Add(series1);
            this.chrtLastYearRevenue.Size = new System.Drawing.Size(837, 532);
            this.chrtLastYearRevenue.TabIndex = 1;
            this.chrtLastYearRevenue.Text = "chart1";
            // 
            // frmRevenueForLastYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 589);
            this.Controls.Add(this.chrtLastYearRevenue);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmRevenueForLastYear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revenue for last year";
            this.Load += new System.EventHandler(this.frmRevenueForLastYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrtLastYearRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtLastYearRevenue;
    }
}