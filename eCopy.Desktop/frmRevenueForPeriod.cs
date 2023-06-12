using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmRevenueForPeriod : Form
    {
        public APIServ reportService = new APIServ("Reporting");
        List<RevenueForPeriodResponse> _data;

        public frmRevenueForPeriod()
        {
            InitializeComponent();
        }
        
        private void frmRevenueForPeriod_Load(object sender, EventArgs e)
        {
             btnSearch_Click(null, null);
        }

        private async  void btnSearch_Click(object sender, EventArgs e)
        {
            _data = await reportService.Get<List<RevenueForPeriodResponse>>("GetRevenueForPeriod", new
            {
                dateTime1 = dateTimePicker1.Value, 
                dateTime2 = dateTimePicker2.Value
            });

            dgvTurnoverForPeriod.DataSource = _data;
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintRevenueForPeriod frm = new frmPrintRevenueForPeriod(_data);
            frm.ShowDialog();
        }
    }
}
