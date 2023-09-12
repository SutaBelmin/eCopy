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

            dgvListEmp.Columns[0].Visible = false;
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvListEmp.Rows[e.RowIndex];

                int employeeId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var emp = await employeeService.GetById<EmployeeResponse>(employeeId);

                frmAdminEdit frm = new frmAdminEdit(emp);
                frm.ShowDialog();

                btnSearch_Click(null, null);
            }
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

    }
}
