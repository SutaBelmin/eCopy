using eCopy.Model;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
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
    public partial class frmAddEmployee : Form
    {
        public APIService cityService = new APIService("City");
        public APIService employeeService = new APIService("Employee");
        private string imagePath { get; set; }
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private async void frmAddEmployee_Load(object sender, EventArgs e)
        {
            SetGender();
            await SetCity();
        }

        void SetGender()
        {
            cmbGender.DataSource = Enum.GetValues<Gender>().Select(x => new
            {
                Name = x.ToString(),
                Value = x
            }).ToList();

            cmbGender.DisplayMember = "Name";
            cmbGender.ValueMember = "Value";
        }

        public async Task SetCity()
        {
            var list = await cityService.Get<List<CityResponse>>();

            cmbCit.DataSource = list;

            cmbCit.DisplayMember = "Name";
            cmbCit.ValueMember = "ID";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                byte[] data = null;

                if (pbSlika.Image != null)
                {
                    data = ImageHelper.FromImageToByte(pbSlika.Image);
                }
                var emp = new EmployeeRequest
                {
                    Person = new Model.PersonRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        MiddleName = txtMiddleName.Text,
                        Address = txtAdress.Text,
                        BirthDate = dtpBirthDate.Value,
                        CityId = (int)cmbCit.SelectedValue,
                        Gender = (Gender)cmbGender.SelectedValue
                    },
                    Active = cbActive.Checked,
                    User = new ApplicationUserRequest
                    {
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        PasswordConfirm = txtPasswordConfirm.Text,
                        PhoneNumber = txtPhone.Text,
                        Username = txtUsername.Text
                    },
                    ProfilePhoto = data,
                    ProfilePhotoExtension = Path.GetExtension(imagePath),
                    ProfilePhotoName = Path.GetFileNameWithoutExtension(imagePath),
                    CopierId = 1
                };

                await employeeService.Post<EmployeeResponse>(emp);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                pbSlika.Image = Image.FromFile(imagePath);
            }
        }

        private bool ValidirajUnos()
        {
            return Validator.ObaveznoPolje(txtFirstName, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtLastName, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtMiddleName, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(cmbGender, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(cmbCity, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtAdress, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(cbActive, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtUsername, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtEmail, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtPhone, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtPassword, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(txtPasswordConfirm, err, "Obavezan unos") &&
            Validator.ObaveznoPolje(pbSlika, err, "Obavezan unos");
        }
    }
}
