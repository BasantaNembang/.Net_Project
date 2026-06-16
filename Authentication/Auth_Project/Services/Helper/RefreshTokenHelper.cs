using Auth_Project.DTO;
using Auth_Project.Entity;
using Auth_Project.Exceptions;
using Auth_Project.Services.Interface;

namespace Auth_Project.Services.Helper
{
    public class RefreshTokenHelper(IAuthService authService, 
        JwtHelper jwtHelper)
    {

        public async Task<AuthResponse> GenerateRefreshToken(RefreshRequestDTO refreshRequest)
        {
            var refreshToken = await authService.GetRefreshToken(refreshRequest);

            if (refreshToken == null) throw new RefreshTokenNotFoundException("Refresh-Token miss matach");

            await verifyExpirationRefreshToken(refreshToken);

            var user = await authService.GetUserInfo(refreshToken.UserId);

            if (user == null) throw new UserNotFoundException("User Not Found");

            //all done -> generate Token now
            var jwtToken = jwtHelper.CreateJwtTOKEN(user);

            return new AuthResponse()
            {
                JwtToken = jwtToken,
                RefreshToken = refreshRequest.Token
            };

        }



        private async Task verifyExpirationRefreshToken(RefreshToken refreshToken)
        {
            if (refreshToken.ExpiryTime.CompareTo(DateTime.UtcNow) < 0)
            {
                //also delete from DB
                var result = await authService.DeleteRefreshToken(refreshToken.Id);
                if (result == null) throw new RefreshTokenDeletionFailedException("Unbale to delete Refresh-Token");
                throw new RefreshTokenExpiredException("Token expired");
            }
        }


    }
}


