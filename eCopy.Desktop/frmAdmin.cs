using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using eCopy.Model;
using eCopy.Model.SearchObjects;

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
                Gender = x.Person.Gender,
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
                Gender = x.Person.Gender,
            }).ToList();
        }

        private async void dgvListEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*var req = dgvListEmp.SelectedRows[0].DataBoundItem as EmpModel;

            if (req != null)
            {
                frmEmpDet frm = new frmEmpDet(req);

                frm.ShowDialog();
            }*/
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvListEmp.Rows[e.RowIndex];

                // Assuming the ID is in the first column (index 0)
                int employeeId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var emp = await employeeService.GetById<EmployeeResponse>(employeeId);

                frmAdminEdit frm = new frmAdminEdit(emp);
                frm.ShowDialog();

                btnSearch_Click(null, null);
            }
        }

        private void btnLogO_Click(object sender, EventArgs e)
        {
            this.logout = true;
            this.Close();
        }

        private async void dgvListEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "Do you want to delete the employee?";
            string title = "Delete employee";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons);
            if(result == DialogResult.Yes)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    var employeeId = senderGrid.Rows[e.RowIndex].Cells["Id"].Value;

                    if (employeeId != null && Convert.ToInt32(employeeId) != 1)
                    {
                        await employeeService.Delete(Convert.ToInt32(employeeId)); 
                        btnSearch_Click(null, null);
                    }
                    
                }
            }
            else
            {
                return;
            }
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            frmCity frmCit = new frmCity();
            frmCit.ShowDialog();
        }
    }
}
