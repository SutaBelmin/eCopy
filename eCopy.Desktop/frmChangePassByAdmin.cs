using eCopy.Model.Requests;
using System;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmChangePassByAdmin : Form
    {
        public APIServ employeeService = new APIServ("Employee");

        private bool passwordVisible = false;
        private bool passwordConVisible = false;
        private bool oldPasswordVisible = false;

        int empId;
        public frmChangePassByAdmin(int empId)
        {
            InitializeComponent();
            this.empId = empId;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (fieldsValidation())
            {
                PassRequest passRequest = new PassRequest();
                passRequest.oldPass = txtOldPass.Text;
                passRequest.newPass = txtNewPass.Text;
                passRequest.confPass = txtPassCon.Text;

                var empResponse = await employeeService.ChangePassByAdmin(empId, passRequest);

                if (empResponse == true)
                {
                    MessageBox.Show("Successfully changed password! ", "Success", MessageBoxButtons.OK);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    err.SetError(txtOldPass, "Incorrect");
                }
            }
        }

        private bool fieldsValidation()
        {
            return Validation.requiredField(txtOldPass, err, "Enter some text") &&
            Validation.PasswordValidation(txtNewPass, err) &&
            Validation.requiredField(txtPassCon, err, "Enter some text") &&
            Validation.equalFields(txtNewPass, txtPassCon, err, "New Password and Password Confirm do not match");
        }

        private void btnShowOldPass_Click(object sender, EventArgs e)
        {
            oldPasswordVisible = !oldPasswordVisible;

            if (oldPasswordVisible)
            {
                txtOldPass.PasswordChar = '\0';
                btnShowOldPass.Text = "Hide Password";
            }
            else
            {
                txtOldPass.PasswordChar = '*';
                btnShowOldPass.Text = "Show Password";
            }
        }

        private void btnShowNewPass_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                txtNewPass.PasswordChar = '\0';
                btnShowNewPass.Text = "Hide Password";
            }
            else
            {
                txtNewPass.PasswordChar = '*';
                btnShowNewPass.Text = "Show Password";
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
