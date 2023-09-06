using eCopy.Model.Enum;
using eCopy.Model.SearchObjects;
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
        public APIServ employeeService = new APIServ("Employee");
        public bool logout = false;
        private List<Status> status;
        public frmEmployee()
        {
            InitializeComponent();
            this.status = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            loadData("New");
            loadStatus();
        }

        private async void loadData(string search=null)
        {
            var searchObject = new PrintRequestSearch();
            searchObject.Status = search;

            var list = await printRequestService.Get<List<PrintReqModel>>(searchObject);


            dgvReq.DataSource = list.Select(x => new PRDGridModel
            {
                ID = x.ID,
                RequestDate = x.RequestDate,
                Status = x.Status.ToString(),
                IsPaid = x.IsPaid,
                ClientName = x.ClientName,
                Price = x.Price.ToString("F2") 
            }).ToList();

        }

        void loadStatus()
        {
            cmbStatus.DataSource = status.Select(x => new
            {
                Name = x.ToString(),
                Value = x
            }).ToList();

            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Value";

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
                    cmbStatus.SelectedIndex = 0;
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

        private async void cmbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Status obj = (Status)cmbStatus.SelectedValue;
            if (obj != null)
            {
                loadData(obj.ToString());
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private async void btnAccount_Click(object sender, EventArgs e)
        {
            var emp = await employeeService.GetEmployeeAccount();

            frmEmployeeAccount frm = new frmEmployeeAccount(emp);
            frm.ShowDialog();
        }
    }
}
