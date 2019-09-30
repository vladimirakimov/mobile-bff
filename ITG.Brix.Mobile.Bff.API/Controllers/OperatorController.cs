using ITG.Brix.Mobile.Bff.API.Utils;
using ITG.Brix.Mobile.Bff.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public OperatorController(IMobileService mobileService)
        {
            _mobileService = mobileService ?? throw new ArgumentNullException(nameof(mobileService));
        }

        [HttpPost]
        [Route("activities")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOperatorActivities([FromBody] JObject content)
        {
            var result = await _mobileService.CreateOperatorActivities(content);

            if (result.IsSuccess)
            {
                var response = new JsonResult("")
                {
                    StatusCode = (int)HttpStatusCode.Created
                };

                return response;
            }
            else
            {
                var response = new JsonResult(Envelope.Error(result.Error))
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };

                return response;
            };

        }
    }
}
