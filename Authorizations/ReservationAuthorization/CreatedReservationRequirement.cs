using Microsoft.AspNetCore.Authorization;

namespace HotelManagementAPI.Authorizations.ReservationAuthorization
{
    public class CreatedReservationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation Operation { get; set; }
        public CreatedReservationRequirement(ResourceOperation operation)
        {
            Operation = operation;
        }        
    }
}
