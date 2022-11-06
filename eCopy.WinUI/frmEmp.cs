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

namespace eCopy.WinUI
{
    public partial class frmEmp : Form
    {
        public APIService printRequestService = new APIService("PrintRequest");
        public bool logout = false;
        public frmEmp()
        {
            InitializeComponent();
        }

        private void frmEmp_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {

            var list = await printRequestService.Get<List<PrintRequestModel>>();

            dgvRequests.DataSource = list.Select(x => new PRDataGridModel
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
            }).ToList();
        }


        private void dgvRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var req = dgvRequests.SelectedRows[0].DataBoundItem as PRDataGridModel;

            if (req != null)
            {
                frmPrintSettings frm = new frmPrintSettings(req);

                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                   loadData();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.logout = true;
            this.Close();
        }
    }
}
