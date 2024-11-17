using FluentValidation;
using HotelManagementAPI.Models.HotelModels;

namespace HotelManagementAPI.Models.Validators.HotelValidations
{
    public class UpdateHotelDtoValidator : AbstractValidator<UpdateHotelDto>
    {
        public UpdateHotelDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}
