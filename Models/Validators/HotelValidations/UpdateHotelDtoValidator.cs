using FluentValidation;
using HotelManagementAPI.Models.HotelModels;

namespace HotelManagementAPI.Models.Validators.HotelValidations
{
    public class UpdateHotelDtoValidator : AbstractValidator<UpdateHotelDto>
    {
        public UpdateHotelDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.ContactNumber)
                .NotEmpty().WithMessage("Contact number is required.")
                .Matches(@"^\d{3}-\d{3}-\d{3}$").WithMessage("Phone number must by in this pattern: ###-###-###.");
        }
    }
}
