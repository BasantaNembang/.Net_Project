using Auth_Project.Data;
using Auth_Project.DTO;
using Auth_Project.Entity;
using Auth_Project.Services.Helper;
using Auth_Project.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth_Project.Services
{
    public class AuthServicecs(AppDbContext appDbContext,
        JwtHelper jwtHelper) : IAuthService
    {       


        public async Task<AuthResponse?> RegisterNewUserAysnc(UserDto userDto)
        {

            var present = appDbContext.Users
                .FirstOrDefault(u => u.Username == userDto.Username);

            if (present != null) return null;  //i.e user already exits

            Guid refreshID = Guid.NewGuid();

            User u = new User()
            {
                Username = userDto.Username,
                RefreshToken = new List<RefreshToken>
                {
                  jwtHelper.GenerateRefreshTOKEN(refreshID)
                }
            };
            u.PasswordHash = new PasswordHasher<User>()
                                .HashPassword(u, userDto.Password);

            await appDbContext.Users.AddAsync(u);
            await appDbContext.SaveChangesAsync();

            //creating token
            var token = jwtHelper.CreateTOKEN(u);

            //get the refresh-token
            var refresh = u.RefreshToken.Where(r=>r.Id == refreshID)
                .FirstOrDefault();

            return new AuthResponse()
            {
                JwtToken = token,
                RefreshToken = refresh!.Token
            };
   
        }


        public async Task<AuthResponse?> LoginUser(UserDto userDto)
        {
            var user = appDbContext.Users
                     .FirstOrDefault(u => u.Username.ToLower() == userDto.Username.ToLower());

            if (user == null) return null; //i.e user does`t exits

            //check password
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password)
                == PasswordVerificationResult.Failed)
                return null;

            //generate JWT-TOKEN
            var token = jwtHelper.CreateTOKEN(user);

            //get refresh-Token
            Guid refreshID = Guid.NewGuid();
            var refreshToken = jwtHelper.GenerateRefreshTOKEN(refreshID);
            //save the changes
            appDbContext.RefreshTokens.Add(refreshToken);
            refreshToken.UserId = user.Id;  //main tain the realationship
            await appDbContext.SaveChangesAsync();

            return new AuthResponse()
            {
                JwtToken = token,
                RefreshToken=refreshToken.Token
             };
        }


        public Task<RefreshToken?> GetRefreshToken(RefreshRequestDTO requestDTO)
        {
           var refreshToken = appDbContext.RefreshTokens.Where(r => r.Token == requestDTO.Token)
                .FirstOrDefaultAsync();
            return refreshToken;
        }



        public async Task<string?> DeleteRefreshToken(Guid Id)
        {
           var result = await appDbContext.RefreshTokens.Where(r => r.Id == Id).ExecuteDeleteAsync();
           
           if(result == 0) return null;

           return "success";
        }



        public async Task<User?> GetUserInfo(int Id)
        {
            var user = await appDbContext.Users
                 .FirstOrDefaultAsync(u => u.Id == Id);
            return user;
        }

    }
}




