using eCopy.Model;
using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmEmpDet : Form
    {
        private EmpModel model;

        public APIServ employeeService = new APIServ("Employee");
        public frmEmpDet(EmpModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void frmEmpDet_Load(object sender, EventArgs e)
        {
            loadData();
        } 
        private async void loadData()
        {
            var emp = await employeeService.GetById<EmployeeResponse>(model.Id);

            txtFN.Text = emp.Person.FirstName;
            txtLN.Text = emp.Person.LastName;
            txtMN.Text = emp.Person.MiddleName;
            txtGen.Text = emp.Person.Gender;
            txtCN.Text = emp.Copier.Name;
            pbSlika.ImageLocation = emp.ProfilePhotoPath;

            if(emp.ProfilePhotoPath == null)
            {
                label6.Text = "No profile photo";
            }

            txtFN.ReadOnly = true; 
            txtLN.ReadOnly = true; 
            txtMN.ReadOnly = true; 
            txtGen.ReadOnly = true; 
            txtCN.ReadOnly = true;


        }
    }
}
