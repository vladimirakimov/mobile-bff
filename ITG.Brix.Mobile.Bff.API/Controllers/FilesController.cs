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
    public class FilesController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public FilesController(IMobileService mobileService)
        {
            _mobileService = mobileService ?? throw new ArgumentNullException();
        }

        [HttpPost]
        [Route("upload")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadPicture([FromForm]UploadPictureFromForm body)
        {
            var result = await _mobileService.UploadPicture(body);

            if (result.IsSuccess)
            {
                var response = new JsonResult(Envelope.Ok());
                response.StatusCode = (int)HttpStatusCode.OK;

                return response;
            }
            else
            {
                var response = new JsonResult(Envelope.Error(result.Error));
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                return response;
            }
        }
    }
}
