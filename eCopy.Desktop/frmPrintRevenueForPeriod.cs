using eCopy.Model.Response;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmPrintRevenueForPeriod : Form
    {
        List<RevenueForPeriodResponse> _data;
        public frmPrintRevenueForPeriod(List<RevenueForPeriodResponse> data)
        {
            InitializeComponent();
            _data = data;
        }

        private void frmPrintRevenueForPeriod_Load(object sender, EventArgs e)
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
