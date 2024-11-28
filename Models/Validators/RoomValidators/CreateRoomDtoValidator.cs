using FluentValidation;
using HotelManagementAPI.Entities;
using HotelManagementAPI.Models.RoomModels;

namespace HotelManagementAPI.Models.Validators.RoomValidators
{
    public class CreateRoomDtoValidator : AbstractValidator<CreateRoomDto>
    {
        private readonly string[] roomTypes = new string[]
        {
            "Single", "Double", "Twin", "Triple", "Quad", "Suite",
            "King", "Queen", "Family", "Connecting", "Accessible",
            "Penthouse", "Dormitory"
        };

        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;
        public CreateRoomDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(30).WithMessage("Description must be atleast 30 characters long");

            RuleFor(room => room.Type)
                .NotEmpty().WithMessage("Room type is required.")
                .Must(type => roomTypes.Contains(type))
                .WithMessage("Room type must be one of the following: " + string.Join(", ", roomTypes));

            RuleFor(x => x.IsAvailable)
                .Equal(true)
                .WithMessage("IsAvailable must always be true when creating a room.");

            RuleFor(x => x.Capacity)
                .NotEmpty().WithMessage("Room's capacity is at least 1")
                .LessThanOrEqualTo(10).WithMessage("Room capacity is maximum 10");

            RuleFor(x => x.PricePerNight)
                .GreaterThan(0).WithMessage("Price per night must be greater than 0.");
        }
    }
}
