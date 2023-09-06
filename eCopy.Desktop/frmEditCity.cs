using eCopy.Model.Response;
using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmEditCity : Form
    {
        private CityModel model;
        public APIServ cityService = new APIServ("City");

        public frmEditCity(CityModel model)
        {
            InitializeComponent();
            this.model = model;
        }
        
        private void frmEditCity_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            var city = await cityService.GetById<CityResponse>(model.ID);

            txtName.Text = model.Name;
            txtShortN.Text = model.ShortName;
            txtPCode.Text = model.PostalCode.ToString();

        }


        private void txtPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPCode_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPCode.Text, out _))
            {
                txtPCode.Text = "";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                await cityService.Put<CityResponse>(model.ID, new UpdateCityModel
                {
                    Name = txtName.Text,
                    ShortName = txtShortN.Text,
                    PostalCode = int.Parse(txtPCode.Text),
                    Active = true
                });

                MessageBox.Show("Successfully updated City! ", "Success", MessageBoxButtons.OK);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, err, "Enter some text") &&
            Validation.requiredField(txtPCode, err, "Enter some number");
        }
    }
}
