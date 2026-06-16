using Auth_Project.DTO;
using Auth_Project.Entity;

namespace Auth_Project.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginUser(UserDto user);
        Task<AuthResponse?> RegisterNewUserAysnc(UserDto user);
        Task<RefreshToken?> GetRefreshToken(RefreshRequestDTO requestDTO);
        Task<string?> DeleteRefreshToken(Guid Id);

        Task<User?> GetUserInfo(int Id);

    }
}













