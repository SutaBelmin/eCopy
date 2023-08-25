using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmEmployeeAccount : Form
    {
        public APIServ employeeService = new APIServ("Employee");
        public APIServ cityService = new APIServ("City");

        private string imagePath { get; set; }


        public frmEmployeeAccount()
        {
            InitializeComponent();
            txtPostalCode.KeyPress += txtPostalCode_KeyPress;
            txtPostalCode.TextChanged += txtPostalCode_TextChanged;
        }

        private async void frmEmployeeAccount_Load(object sender, EventArgs e)
        {
            SetGender();
            await setAccountData();
        }

        private void txtPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPostalCode.Text, out _))
            {
                txtPostalCode.Text = "";
            }
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
            var emp = await employeeService.GetEmployeeAccount();

            txtFirst.Text = emp.Person.FirstName;
            txtLast.Text = emp.Person.LastName;
            txtMiddle.Text = emp.Person.MiddleName;

            string genderString = emp.Person.Gender; 
            if (Enum.TryParse<Gender>(genderString, out var gender)) 
            { 
                cmbGen.SelectedValue = gender; 
            }

            cbActive.Checked = emp.Active;
            dtpBirthD.Value = emp.Person.BirthDate;

            txtCity.Text = emp.Person.City.Name;
            txtPostalCode.Text = emp.Person.City.PostalCode.ToString();
            txtAdress.Text = emp.Person.Address;
            
            txtUsername.Text = emp.ApplicationUser.Username;
            txtEmail.Text = emp.ApplicationUser.Email;
            txtPhone.Text = emp.ApplicationUser.PhoneNumber;

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
                var emp = await employeeService.GetEmployeeAccount();
                UpdateEmployeeRequest updateModel = new UpdateEmployeeRequest();


                if (emp.Person.City.Name != txtCity.Text)
                {
                    var newCityId = 0;
                    var postalId = 0;


                    CityRequest newCity = new CityRequest();
                    newCity.Name = txtCity.Text;
                    newCity.ShortName = txtCity.Text;
                    newCity.PostalCode = int.Parse(txtPostalCode.Text);
                    newCity.CountryID = 1;
                    newCity.Active = true;

                    var cityRes = await cityService.Post<CityResponse>(newCity);
                    if (cityRes != null)
                    {
                        updateModel.CityId = cityRes.ID;
                    }
                }
                else
                {
                    updateModel.CityId = emp.Person.CityId;
                }
                updateModel.FirstName = txtFirst.Text;
                updateModel.LastName = txtLast.Text;
                updateModel.MiddleName = txtMiddle.Text;
                updateModel.Gender = (Gender)cmbGen.SelectedValue;
                updateModel.Address = txtAdress.Text;
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
