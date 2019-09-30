using ITG.Brix.Mobile.Bff.API.Utils;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public AccountController(IMobileService mobileService)
        {
            _mobileService = mobileService ?? throw new ArgumentNullException(nameof(mobileService));
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Login([FromBody] LoginFromBody login)
        {
            var result = await _mobileService.LoginAndGetLayout(login);

            if (result.IsSuccess)
            {
                var data = result.Value;
                var response = Envelope.Ok(data);
                return Ok(response);
            }
            else
            {

                var response = new JsonResult(Envelope.Error(result.Error));
                response.StatusCode = (int)HttpStatusCode.Forbidden;

                return response;
            }
        }
    }
}
