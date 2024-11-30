using FluentValidation;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.UserModels;

namespace HotelManagementAPI.Models.Validators.UserValidators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(HotelDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Invalid email type.");
            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must be atleast 6 characters long.");
            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password).WithMessage("Passwords are not the same.");
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(e => e.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "This email is already taken.");
                    }
                });
        }
    }
}
