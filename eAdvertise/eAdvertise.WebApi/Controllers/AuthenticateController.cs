using eAdvertise.Application.DTOs.Authenticate;
using eAdvertise.Application.Features.Authenticate.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace eAdvertise.WebApi.Controllers
{

    [Route("api/authentcate")]
    [ApiController]
    public class AuthenticateController : BaseApiController
    {
        private readonly ISender _iSender;

        public AuthenticateController(ISender iSender) => _iSender = iSender;


        [AllowAnonymous]
        [HttpPost, Route("api/sign-in")]
        public async Task<IActionResult> SignIn(SignIn model)
        {
            var result = await _iSender.Send(new SignInCommand(model));
            return CustomResult(result, HttpStatusCode.OK);
        }
    }
}
