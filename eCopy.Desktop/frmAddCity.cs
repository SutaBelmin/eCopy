using eCopy.Model.Requests;
using eCopy.Model.Response;
using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmAddCity : Form
    {
        public APIServ cityService = new APIServ("City");

        public frmAddCity()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(fieldsValidation())
            {
                CityRequest newCity = new CityRequest();
                newCity.Name = txtName.Text;
                newCity.ShortName = txtShortN.Text;
                newCity.PostalCode = int.Parse(txtPCode.Text);
                newCity.CountryID = 1;
                newCity.Active = true;

                await cityService.Post<CityResponse>(newCity);

                MessageBox.Show("Successfully added new City! ", "Success", MessageBoxButtons.OK);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtName, err, "Enter some text") &&
            Validation.requiredField(txtPCode, err, "Enter some number");
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
    }
}
