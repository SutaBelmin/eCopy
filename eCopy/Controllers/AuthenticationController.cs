using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public IActionResult Login(AuthenticationRequest authenticationRequest)
        {
            var result = authenticationService.Authenticate(authenticationRequest);

            if(result == null)
            {
                return BadRequest("Invalid");
            }
            return Ok(result);
        }
    }
}
