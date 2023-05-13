using eCopy.Model;
using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmAddEmp : Form
    {
        public APIServ cityService = new APIServ("City");
        public APIServ employeeService = new APIServ("Employee");
        private string imagePath { get; set; }
        public frmAddEmp()
        {
            InitializeComponent();
        }

        private async void frmAddEmp_Load(object sender, EventArgs e)
        {
            SetGender();
            await SetCity();
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

        public async Task SetCity()
        {
            var list = await cityService.Get<List<CityResponse>>();

            cmbCi.DataSource = list;

            cmbCi.DisplayMember = "Name";
            cmbCi.ValueMember = "ID";
        }

        private async void btnS_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
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
                        MiddleName = txtMiddleName.Text,
                        Address = txtAdr.Text,
                        BirthDate = dtpBD.Value,
                        CityId = (int)cmbCi.SelectedValue,
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

        private bool ValidirajUnos()
        {
            return Validacija.ObaveznoPolje(txtFirstName, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtLastName, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtMiddleName, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(cmbGe, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(cmbCi, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtAdr, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(cbAct, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtUsrnm, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtEm, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtPh, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtPassw, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(txtPassCon, error, "Obavezan unos") &&
            Validacija.ObaveznoPolje(pbPF, error, "Obavezan unos");
        }
    }
}
