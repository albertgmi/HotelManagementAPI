﻿using FluentValidation;
using HotelManagementAPI.Models.ReservationModels;

namespace HotelManagementAPI.Models.Validators.ReservationValidators
{
    public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
    {
        public UpdateReservationDtoValidator()
        {
            RuleFor(x => x.CheckInDate)
                .NotEmpty().WithMessage("Check in date is required.")
                .Must(r => r >= DateTime.Now)
                .WithMessage("Date can't be from the past.");
            RuleFor(x => x.CheckOutDate)
                .NotEmpty().WithMessage("Check out date is required.");
        }
    }
}
