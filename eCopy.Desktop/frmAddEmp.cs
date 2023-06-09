﻿using eCopy.Model;
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
                        MiddleName = txtMidName.Text,
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
            return Validacija.ObaveznoPolje(txtFirstName, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtLastName, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtMiddleName, error, "Enter some text") &&
            Validacija.ObaveznoPolje(cmbGe, error, "Enter some text") &&
            Validacija.ObaveznoPolje(cmbCi, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtAdr, error, "Enter some text") &&
            Validacija.ObaveznoPolje(cbAct, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtUsrnm, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtEm, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtPh, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtPassw, error, "Enter some text") &&
            Validacija.ObaveznoPolje(txtPassCon, error, "Enter some text") &&
            Validacija.ObaveznoPolje(pbPF, error, "Enter some text") &&
            Validacija.JednakoPolje(txtPassw, txtPassCon, error, "Password is not equal to Password Confirm");
            
        }
    }
}
