using HotelManagementAPI.Models.UserModels;

namespace HotelManagementAPI.Services.UserServiceFolder
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string GenerateJwt(LoginUserDto loginUserDto);
    }
}
