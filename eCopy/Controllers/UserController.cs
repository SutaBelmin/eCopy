using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase 
    {
        private readonly IUserService service;

        public UserController(IUserService service) 
        {
            this.service = service;
        }

        [HttpGet("GetByUsrnameOrEmail")]
        [AllowAnonymous]
        public GetByUsernameOrEmail GetByUsrnameOrEmail(string username, string email)
        {
            return service.GetByUsrnameOrEmail(username, email);
        }
    }
}
