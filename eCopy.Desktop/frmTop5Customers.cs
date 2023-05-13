using eCopy.Model.Response;
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
    public partial class frmTop5Customers : Form
    {
        public APIServ reportService = new APIServ("Reporting");
        List<Top5CustomerResponse> _data;
        public frmTop5Customers()
        {
            InitializeComponent();

        }
        private void frmTop5Customers_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            _data = await reportService.Get<List<Top5CustomerResponse>>();

            dgvTop5Customers.DataSource = _data;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintTop5Customer frm = new frmPrintTop5Customer(_data);
            frm.ShowDialog();
        }
    }
}
