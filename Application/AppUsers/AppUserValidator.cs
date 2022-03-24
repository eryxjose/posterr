using FluentValidation;
using Domain;

namespace Application.AppUsers
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(o => o.UserName).NotEmpty().Length(3, 14).Matches("^[a-zA-Z0-9_]*$");
        }
    }
}