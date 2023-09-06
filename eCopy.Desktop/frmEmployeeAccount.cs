using eCopy.Model;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmEmployeeAccount : Form
    {
        public APIServ employeeService = new APIServ("Employee");
        public APIServ cityService = new APIServ("City");
        public APIServ userService = new APIServ("User");
        EmployeeResponse model;
        private string imagePath { get; set; }


        public frmEmployeeAccount(EmployeeResponse model)
        {
            InitializeComponent();
            this.model = model;
        }

        private async void frmEmployeeAccount_Load(object sender, EventArgs e)
        {
            SetGender();
            await setAccountData();
        }

        void SetGender()
        {
            cmbGen.DataSource = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(x => new
            {
                Name = x.ToString(),
                Value = x
            }).ToList();

            cmbGen.DisplayMember = "Name";
            cmbGen.ValueMember = "Value";
        }

        private async Task setAccountData()
        {   
            var list = await cityService.Get<List<CityResponse>>();

            cmbCity.DataSource = list;
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "ID";

            txtFirst.Text = model.Person.FirstName;
            txtLast.Text = model.Person.LastName;
            txtMiddle.Text = model.Person.MiddleName;

            string genderString = model.Person.Gender;
            if (Enum.TryParse<Gender>(genderString, out var gender))
            {
                cmbGen.SelectedValue = gender;
            }

            cbActive.Checked = model.Active;
            dtpBirthD.Value = model.Person.BirthDate;
            txtAdress.Text = model.Person.Address;
            cmbCity.SelectedValue = model.Person.City.ID;

            txtUsername.Text = model.ApplicationUser.Username;
            txtEmail.Text = model.ApplicationUser.Email;
            txtPhone.Text = model.ApplicationUser.PhoneNumber;

        }

        private void btnChPass_Click(object sender, EventArgs e)
        {
            frmChangePass frmChPass = new frmChangePass();
            frmChPass.ShowDialog();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                error.Clear();

                var getUsr = await userService.GetByUsrnameOrEmail(txtUsername.Text, txtEmail.Text);

                if (getUsr.Username == true)
                {
                    txtUsername.Focus();
                    error.SetError(txtUsername, "Username already exist");
                    return;
                }

                if (getUsr.Email == true)
                {
                    txtEmail.Focus();
                    error.SetError(txtEmail, "Email already exist");
                    return;
                }

                UpdateEmployeeRequest updateModel = new UpdateEmployeeRequest();

                updateModel.FirstName = txtFirst.Text;
                updateModel.LastName = txtLast.Text;
                updateModel.MiddleName = txtMiddle.Text;
                updateModel.Gender = (Gender)cmbGen.SelectedValue;
                updateModel.Address = txtAdress.Text;
                updateModel.CityId = (int)cmbCity.SelectedValue;
                updateModel.BirthDate = dtpBirthD.Value;
                updateModel.Active = cbActive.Checked;
                updateModel.Email = txtEmail.Text;
                updateModel.Username = txtUsername.Text;
                updateModel.PhoneNumber = txtPhone.Text;

                var resp = await employeeService.UpdateEmp(updateModel);

                if (resp != null)
                {
                    MessageBox.Show("Successfully updated Employee! ", "Success", MessageBoxButtons.OK);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtFirst, error, "Enter some text") &&
            Validation.requiredField(txtLast, error, "Enter some text") &&
            Validation.requiredField(txtMiddle, error, "Enter some text") &&
            Validation.requiredField(cmbGen, error, "Enter some text") &&
            Validation.requiredField(txtAdress, error, "Enter some text") &&
            Validation.UsernameValidation(txtUsername, error) &&
            Validation.EmailValidation(txtEmail, error) &&
            Validation.PhoneValidation(txtPhone, error);
        }

    }
}
