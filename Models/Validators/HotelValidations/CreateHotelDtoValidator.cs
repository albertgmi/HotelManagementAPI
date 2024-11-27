using FluentValidation;
using HotelManagementAPI.Models.HotelModels;

namespace HotelManagementAPI.Models.Validators.HotelValidations
{
    public class CreateHotelDtoValidator : AbstractValidator<CreateHotelDto>
    {
        public CreateHotelDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.");
        }
    }
}
