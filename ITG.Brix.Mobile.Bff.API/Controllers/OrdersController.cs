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
    public class OrdersController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        public OrdersController(IMobileService mobileService)
        {
            _mobileService = mobileService ?? throw new ArgumentNullException(nameof(mobileService));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> List([FromBody] FiltersFromBody filters)
        {
            var result = await _mobileService.GetOrders(filters);

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

        [HttpPost]
        [Route("start")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrderWithFlow([FromBody] StartOrderFromBody body)
        {
            var result = await _mobileService.GetWorkOrderWithFlow(body);

            if (result.IsSuccess)
            {
                var data = result.Value;
                var response = Envelope.Ok(data);
                return Ok(response);
            }
            else
            {
                var response = new JsonResult(Envelope.Error(result.Error));
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                return response;
            }
        }

        [HttpPost]
        [Route("markStarted")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> MarkOrderStarted([FromBody] MarkOrderStartedFromBody body)
        {
            var result = await _mobileService.MarkWorkOrderStarted(body);

            if (result.IsSuccess)
            {
                var data = result.Value;
                var response = new JsonResult(Envelope.Ok(data));
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

        [HttpPost]
        [Route("updateStatus")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusFromBody body)
        {
            var result = await _mobileService.UpdateWorkOrderStatus(body);

            if (result.IsSuccess)
            {
                var data = result.Value;
                var response = new JsonResult(Envelope.Ok(data));
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

        [HttpPost]
        [Route("updateOperational")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateOperational([FromBody] UpdateOperationalFromBody body)
        {
            var result = await _mobileService.UpdateOperational(body);

            if (result.IsSuccess)
            {
                var data = result.Value;
                var response = new JsonResult(Envelope.Ok(data));
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

        [HttpPost]
        [Route("getLocation")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetLocation([FromBody] GetLocationFromBody getLocationFromBody)
        {
            var result = await _mobileService.GetLocation(getLocationFromBody);

            if (result.IsSuccess)
            {
                var data = result.Value;
                var response = new JsonResult(Envelope.Ok(data));
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

        [HttpGet]
        [Route("damageCodes")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDamageCodes()
        {
            var result = await _mobileService.GetDamageCodes();

            if (result.IsSuccess)
            {
                var data = result.Value;
                return new JsonResult(Envelope.Ok(data))
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return new JsonResult(Envelope.Error(result.Error))
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
