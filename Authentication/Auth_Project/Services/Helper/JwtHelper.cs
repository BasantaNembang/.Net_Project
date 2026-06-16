using Auth_Project.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth_Project.Services.Helper
{
    public class JwtHelper(IConfiguration configuration)
    {

        public string CreateTOKEN(User user)
        {
            var jwtToken = CreateJwtTOKEN(user);
            return jwtToken;
        }


        public string CreateJwtTOKEN(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDes = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(6),
                signingCredentials: creds
                );

            var JwtToken = new JwtSecurityTokenHandler().WriteToken(tokenDes);

            return JwtToken;
        }


        public RefreshToken GenerateRefreshTOKEN(Guid refreshID)
        {
          var response =  new RefreshToken()
            {
                Id = refreshID,
                Token = Guid.NewGuid().ToString(),
                ExpiryTime = DateTime.UtcNow.AddMinutes(15),
            };
            return response;
        }

    }
}






