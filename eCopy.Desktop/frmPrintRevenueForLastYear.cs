using eCopy.Model.Response;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPrintRevenueForLastYear : Form
    {
        List<RevenueForLastYearResponse> _data;
        public frmPrintRevenueForLastYear(List<RevenueForLastYearResponse> data)
        {
            InitializeComponent();
            _data = data;
        }

        private void frmPrintRevenueForLastYear_Load(object sender, EventArgs e)
        {
            LoadReport();
            this.reportViewer1.RefreshReport();
        }

        private void LoadReport()
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", _data);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
        }
    }
}
