using eAdvertise.Application.DTOs;
using eAdvertise.Domain.Settings;
using MediatR;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using eAdvertise.Domain.Entities;
using eAdvertise.Application.Exceptions;
using eAdvertise.Application.Extensions;
using eAdvertise.Application.DTOs.Authenticate;

namespace eAdvertise.Application.Features.Authenticate.Commands
{
    public record SignInCommand(SignIn model) : IRequest<SingInToken>;

    public sealed class SignInHandler : IRequestHandler<SignInCommand, SingInToken>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTSettings _jwtSetting;
        public SignInHandler(UserManager<ApplicationUser> userManager, JWTSettings jwtSetting)
        {
            _userManager = userManager;
            _jwtSetting = jwtSetting;
        }

        public async Task<SingInToken> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            SignInCommandValidator validationRules = new SignInCommandValidator(_userManager);
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByNameAsync(request.model.Username);
            var userRoles = await _userManager.GetRolesAsync(user);

            var tokenDto = await new Token(user.Id, user.UserName, string.Join(",", userRoles)).GenerateTokenAsync(_jwtSetting);
            return tokenDto;
        }
    }
}
