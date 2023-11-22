using eAdvertise.Application.DTOs.Authenticate;
using eAdvertise.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace eAdvertise.Application.Features.Authenticate.Commands
{
    public class SignInCommandValidator : AbstractValidator<SignIn>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SignInCommandValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage(x => "username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage(x => "Password is required");

            When(x => !string.IsNullOrEmpty(x.Username) && !string.IsNullOrEmpty(x.Password), () =>
            {
                RuleFor(o => o).MustAsync(IsValidCreds)
                .WithMessage("Invalid login");
            });
        }

        private async Task<bool> IsValidCreds(SignIn model, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return true;
            };
            return false;
        }
    }
}
