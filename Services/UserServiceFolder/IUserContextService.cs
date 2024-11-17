using System.Security.Claims;

namespace HotelManagementAPI.Services.UserServiceFolder
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
    }
}
