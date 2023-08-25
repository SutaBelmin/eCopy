using eCopy.Model;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmAddEmp : Form
    {
        public APIServ cityService = new APIServ("City");
        public APIServ employeeService = new APIServ("Employee");
        public APIServ userService = new APIServ("User");

        private bool passwordVisible = false;
        private bool passwordConVisible = false;

        private string imagePath { get; set; }

        public frmAddEmp()
        {
            InitializeComponent();
            txtPostalCode.KeyPress += txtPostalCode_KeyPress;
            txtPostalCode.TextChanged += txtPostalCode_TextChanged;
        }

        private async void frmAddEmp_Load(object sender, EventArgs e)
        {
            SetGender();            
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
            cmbGe.DataSource = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(x => new
            {
                Name = x.ToString(),
                Value = x
            }).ToList();

            cmbGe.DisplayMember = "Name";
            cmbGe.ValueMember = "Value";
        }
        private async void btnS_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                error.Clear();

                var getUsr = await userService.GetByUsrnameOrEmail(txtUsrnm.Text, txtEm.Text);

                var newCityId = 0;
                var postalId = 0;

                if (getUsr.Username == true)
                {
                    txtUsrnm.Focus();
                    error.SetError(txtUsrnm, "Username already exist");
                    return;
                }

                if (getUsr.Email == true)
                {
                    txtEm.Focus();
                    error.SetError(txtEm, "Email already exist");
                    return;
                }

                CityRequest newCity = new CityRequest();
                newCity.Name = txtCity.Text;
                newCity.ShortName = txtCity.Text;
                
                newCity.PostalCode = int.Parse(txtPostalCode.Text);

                newCity.CountryID = 1;
                newCity.Active = true;

                var cityRes = await cityService.Post<CityResponse>(newCity);
                if (cityRes != null)
                {
                    newCityId = cityRes.ID;
                }
                byte[] data = null;

                if (pbPF.Image != null)
                {
                    data = ImageHelp.FromImageToByte(pbPF.Image);
                }
                var emp = new EmployeeRequest
                {
                Person = new Model.PersonRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        MiddleName = txtMidName.Text,
                        Address = txtAdr.Text,
                        BirthDate = dtpBD.Value,
                        CityId= newCityId,
                        Gender = (Gender)cmbGe.SelectedValue
                    },
                    Active = cbAct.Checked,
                    User = new ApplicationUserRequest
                    {
                        Email = txtEm.Text,
                        Password = txtPassw.Text,
                        PasswordConfirm = txtPassCon.Text,
                        PhoneNumber = txtPh.Text,
                        Username = txtUsrnm.Text
                    },
                    ProfilePhoto = data,
                    ProfilePhotoExtension = Path.GetExtension(imagePath),
                    ProfilePhotoName = Path.GetFileNameWithoutExtension(imagePath),
                    CopierId = 1
                };

                await employeeService.Post<EmployeeResponse>(emp);


                MessageBox.Show("Successfully added new Employee! ", "Success", MessageBoxButtons.OK);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void pbPF_DoubleClick(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                pbPF.Image = Image.FromFile(imagePath);
            }
        }

        private bool fieldsValidation()
        {
            int len = txtPostalCode.Text.Length;

            return Validation.requiredField(txtFirstName, error, "Enter some text") &&
            Validation.requiredField(txtLastName, error, "Enter some text") &&
            Validation.requiredField(txtMidName, error, "Enter some text") &&
            Validation.requiredField(cmbGe, error, "Enter some text") &&
            Validation.requiredField(txtCity, error, "Enter some text") &&
            Validation.requiredField(txtPostalCode, error, "Enter some number") &&
            Validation.requiredField(txtAdr, error, "Enter some text") &&
            Validation.requiredField(pbPF, error, "Choose a picture") &&
            Validation.UsernameValidation(txtUsrnm, error) &&
            Validation.EmailValidation(txtEm, error) &&
            Validation.PhoneValidation(txtPh, error) &&
            Validation.PasswordValidation(txtPassw, error) &&
            Validation.requiredField(txtPassCon, error, "Enter some text") &&
            Validation.equalFields(txtPassw, txtPassCon, error, "Password and Password Confirm do not match");
            
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                txtPassw.PasswordChar = '\0';
                btnShowPass.Text = "Hide Password";
            }
            else
            {
                txtPassw.PasswordChar = '*';
                btnShowPass.Text = "Show Password";
            }
        }

        private void btnShowPassCon_Click(object sender, EventArgs e)
        {
            passwordConVisible = !passwordConVisible;

            if (passwordConVisible)
            {
                txtPassCon.PasswordChar = '\0';
                btnShowPassCon.Text = "Hide Password";
            }
            else
            {
                txtPassCon.PasswordChar = '*';
                btnShowPassCon.Text = "Show Password";
            }
        }

    }
}
