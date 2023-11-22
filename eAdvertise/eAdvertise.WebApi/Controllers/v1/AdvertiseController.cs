using eAdvertise.Application.DTOs.Advertise;
using eAdvertise.Application.Features.Advertise.Command;
using eAdvertise.Application.Features.Advertise.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace eAdvertise.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/advertise")]
    [ApiVersion("1.0")]
    public class AdvertiseController : BaseApiController
    {
        [HttpPost, Route("api/create/car")]
        public async Task<IActionResult> Car(CarDto command)
        {
            var resp = await Mediator.Send(new AddCarCommand(command, GetUserId()));
            return CustomResult(resp, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/create/mobile")]
        public async Task<IActionResult> Mobile(MobileDto command)
        {
            var resp = await Mediator.Send(new AddMobileCommand(command, GetUserId()));
            return CustomResult(resp, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/create/misc")]
        public async Task<IActionResult> Misc(MiscDto command)
        {
            var resp = await Mediator.Send(new AddMiscCommand(command, GetUserId()));
            return CustomResult(resp, HttpStatusCode.OK);
        }

        [HttpGet, Route("api/getAll")]
        public async Task<IActionResult> GetAll()
        {
            var resp = await Mediator.Send(new GetAllAdvertisesQuery(GetUserId()));
            return CustomResult(resp, HttpStatusCode.OK);
        }
    }
}
