using ITG.Brix.Mobile.Bff.API.Utils;
using ITG.Brix.Mobile.Bff.Application.Models.From;
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
    public class SetupController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public SetupController(IMobileService mobileService)
        {
            _mobileService = mobileService ?? throw new ArgumentNullException(nameof(mobileService));
        }

        [HttpPost]
        [Route("flow")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetFlow([FromBody]FlowFilterFromBody filterData)
        {
            var result = await _mobileService.GetFlow(filterData);

            if (result.IsSuccess)
            {
                if (result.Value == null)
                {
                    var responseNoContent = new NoContentResult();
                    return responseNoContent;
                }
                var data = result.Value;
                var response = Envelope.Ok(data);
                return Ok(response);
            }
            else
            {
                var responseBadRequest = new BadRequestResult();
                return responseBadRequest;
            }
        }        
    }
}

