using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCopy.WinUI
{
    public partial class frmLogin : Form
    {
        public APIService loginService = new APIService("Authentication/Login");
        public Role Role { get; set; }
        public bool Success { get; set; } = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var model = new AuthenticationRequest();
            model.Username = txtUsername.Text;
            model.Password = txtPassword.Text;

            if (model.Username != null && model.Password != null)
            {
                try
                {
                    var result = await loginService.Post<AuthenticationResponse>(model);
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(result.Token);

                    var role = Enum.Parse<Role>(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "role").Value);
                    
                    Success = true;
                    Role = role;
                    User.Token = result.Token;
                    User.Id = int.Parse(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
                    this.Close();
                }
                catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Invalid username or password");
                }
                
            }
        }
    }
}
