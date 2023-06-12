using eCopy.Model.Enum;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using Flurl.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public partial class frmLog : Form
    {
        //public ApiIdentityServ loginService = new ApiIdentityServ("Account/Login");
        public APIServ loginService = new APIServ("Authentication/Login");
        public Role Role { get; set; }
        public bool Success { get; set; } = false;

        public frmLog()
        {
            InitializeComponent();
        }

        private async void btnLog_Click(object sender, EventArgs e)
        {
            var model = new AuthenticationRequest();
            model.Username = txtUserN.Text;
            model.Password = txtPass.Text;

            if (model.Username != null && model.Password != null)
            {
                try
                {
                    var result = await loginService.Post<AuthenticationResponse>(model);
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(result.Token);

                    Role role = (Role)Enum.Parse(typeof(Role), jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "role").Value);

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
