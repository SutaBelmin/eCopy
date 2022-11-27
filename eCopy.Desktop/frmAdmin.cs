using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eCopy.Model;
using eCopy.Model.SearchObjects;
using Flurl;
using Flurl.Http;

namespace eCopy.Desktop
{
    public partial class frmAdmin : Form
    {
        public APIServ employeeService = new APIServ("Employee");
        public bool logout = false;
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var searchObject = new EmployeeSearch();
            searchObject.FirstName = txtFirstName.Text;
            searchObject.LastName = txtLastName.Text;

            var list = await employeeService.Get<List<EmployeeResponse>>(searchObject);

            dgvListEmp.DataSource = list.Select(x => new EmpModel
            {
                Id = x.Id,
                FirstName = x.Person.FirstName,
                LastName = x.Person.LastName,
                MiddleName = x.Person.MiddleName,
                //Active = x.Active,
                //CopierName = x.Copier.Name,
                Gender = x.Person.Gender,
                //ProfilePhoto = x.ProfilePhoto
            }).ToList();
        }

        private void btnAddEm_Click(object sender, EventArgs e)
        {
            frmAddEmp frmAddE = new frmAddEmp();

            var result = frmAddE.ShowDialog();

            if (result == DialogResult.OK)
            {
                btnSearch_Click(null, null);
            }
        }

        private async void btnRes_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";

            var list = await employeeService.Get<List<EmployeeResponse>>();

            dgvListEmp.DataSource = list.Select(x => new EmpModel
            {
                Id = x.Id,
                FirstName = x.Person.FirstName,
                LastName = x.Person.LastName,
                MiddleName = x.Person.MiddleName,
                //Active = x.Active,
                //CopierName = x.Copier.Name,
                Gender = x.Person.Gender,
                //ProfilePhoto = x.ProfilePhoto
            }).ToList();
        }

        private void dgvListEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var req = dgvListEmp.SelectedRows[0].DataBoundItem as EmpModel;

            if (req != null)
            {
                frmEmpDet frm = new frmEmpDet(req);

                frm.ShowDialog();
            }
        }

        private void btnLogO_Click(object sender, EventArgs e)
        {
            this.logout = true;
            this.Close();
        }
    }
}
