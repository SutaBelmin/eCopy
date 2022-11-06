using eCopy.Model;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
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
    public partial class frmAdm : Form
    {
        public APIService employeeService = new APIService("Employee");
        public bool logout = false;
        public frmAdm()
        {
            InitializeComponent();
        }

        private void frmAdm_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var searchObject = new EmployeeSearch();
            searchObject.FirstName = txtFName.Text;
            searchObject.LastName = txtLName.Text;

            var list = await employeeService.Get<List<EmployeeResponse>>(searchObject);

            dgvEmployees.DataSource = list.Select(x=> new EmployeeModel
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

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddEmployee frmAddEmp = new frmAddEmployee();
            
            var result = frmAddEmp.ShowDialog();

            if(result == DialogResult.OK)
            {
                btnSearch_Click(null, null);
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";

            var list = await employeeService.Get<List<EmployeeResponse>>();

            dgvEmployees.DataSource = list.Select(x => new EmployeeModel
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

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var req = dgvEmployees.SelectedRows[0].DataBoundItem as EmployeeModel;

            if (req != null)
            {
                frmEmpDetails frm = new frmEmpDetails(req);

                frm.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.logout = true;
            this.Close();
        }
    }
}
