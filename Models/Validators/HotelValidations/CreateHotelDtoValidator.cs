using FluentValidation;
using HotelManagementAPI.Models.HotelModels;

namespace HotelManagementAPI.Models.Validators.HotelValidations
{
    public class CreateHotelDtoValidator : AbstractValidator<CreateHotelDto>
    {
        public CreateHotelDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(x => x.Street)
                .NotEmpty();
        }
    }
}
