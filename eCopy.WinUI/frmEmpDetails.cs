using eCopy.Model;
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
    public partial class frmEmpDetails : Form
    {
        private EmployeeModel model;

        public APIService employeeService = new APIService("Employee");
        public frmEmpDetails(EmployeeModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void frmEmpDetails_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
           var emp = await employeeService.GetById<EmployeeResponse>(model.Id);

            txtFName.Text = emp.Person.FirstName;
            txtLName.Text = emp.Person.LastName;
            txtMName.Text = emp.Person.MiddleName;
            txtGender.Text = emp.Person.Gender;
            txtCopierName.Text = emp.Copier.Name;
            pbSlika.ImageLocation = emp.ProfilePhotoPath;
        }
    }
}
