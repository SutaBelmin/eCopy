using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmEmployee : Form
    {
        public APIServ printRequestService = new APIServ("PrintRequest");
        public bool logout = false;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            var list = await printRequestService.Get<List<PrintReqModel>>();

            dgvReq.DataSource = list.Select(x => new PRDGridModel
            {
                ID = x.ID,
                Collate = x.Collate.ToString(),
                Letter = x.Letter.ToString(),
                Options = x.Options.ToString(),
                Orientation = x.Orientation.ToString(),
                Pages = x.Pages.ToString(),
                RequestDate = x.RequestDate,
                Status = x.Status.ToString(),
                Side = x.Side.ToString(),
                IsPaid = x.IsPaid,
                ClientName = x.ClientName,
                Price = x.Price.ToString("F2") 
            }).ToList();
        }

        private void dgvReq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var req = dgvReq.SelectedRows[0].DataBoundItem as PRDGridModel;

            if (req != null)
            {
                frmPSettings frm = new frmPSettings(req);

                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    loadData();
                }
            }
        }
        
        private void btnLogO_Click(object sender, EventArgs e)
        {
            this.logout = true;
            this.Close();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            frmRevenueForPeriod frm = new frmRevenueForPeriod();
            frm.ShowDialog();
        }
        
        private void btnTopC_Click(object sender, EventArgs e)
        {
            frmTop5Customers frm = new frmTop5Customers();
            frm.ShowDialog();
        }

        private void btnRforLY_Click(object sender, EventArgs e)
        {
            frmRevenueForLastYear frm = new frmRevenueForLastYear();
            frm.ShowDialog();
        }
    }
}
