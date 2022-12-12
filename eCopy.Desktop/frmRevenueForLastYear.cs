﻿using eCopy.Model.Response;
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
    public partial class frmRevenueForLastYear : Form
    {
        public APIServ reportService = new APIServ("Reporting");
        List<RevenueForLastYearResponse> _data;

        public frmRevenueForLastYear()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintRevenueForLastYear frm = new frmPrintRevenueForLastYear(_data);
            frm.ShowDialog();
        }

        private async void frmRevenueForLastYear_Load(object sender, EventArgs e)
        {
            await loadData();
        }

        private async Task loadData()
        {
            _data = await reportService.Get<List<RevenueForLastYearResponse>>("GetRevenueForLastYear");

            foreach (var item in _data)
            {
                chrtLastYearRevenue.Series["Data"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint
                {
                    XValue = item.Date,
                    YValues = new double[] { item.Revenue }
                });
            }
        }
    }
}