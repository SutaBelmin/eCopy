using System;
using System.Windows.Forms;
using eCopy.Model.Requests;

namespace eCopy.Desktop
{
    public partial class frmChangePass : Form
    {
        public APIServ employeeService = new APIServ("Employee");

        private bool passwordVisible = false;
        private bool passwordConVisible = false;
        private bool oldPasswordVisible = false;


        public frmChangePass()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(fieldsValidation())
            {
                PassRequest passRequest = new PassRequest();
                passRequest.oldPass = txtOldPass.Text;
                passRequest.newPass = txtNewPass.Text;
                passRequest.confPass = txtPassConf.Text;

                var empResponse = await employeeService.ChangePass(passRequest);

                if(empResponse == true)
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
            Validation.requiredField(txtPassConf, err, "Enter some text") &&
            Validation.equalFields(txtNewPass, txtPassConf, err, "New Password and Password Confirm do not match");
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible; 

            if (passwordVisible)
            {
                txtNewPass.PasswordChar = '\0'; 
                btnShowPass.Text = "Hide Password";
            }
            else
            {
                txtNewPass.PasswordChar = '*'; 
                btnShowPass.Text = "Show Password";
            }
        }

        private void btnShowPassCon_Click(object sender, EventArgs e)
        {
            passwordConVisible = !passwordConVisible; 

            if (passwordConVisible)
            {
                txtPassConf.PasswordChar = '\0'; 
                btnShowPassCon.Text = "Hide Password";
            }
            else
            {
                txtPassConf.PasswordChar = '*'; 
                btnShowPassCon.Text = "Show Password";
            }
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
    }
}
