using Microsoft.IdentityModel.Tokens;
using samplepro2.Interfaces.Business;
using samplepro2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace samplepro2.Business
{
    public class UserManager: IUserManager
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, UserName = "admin", Password = "admin@123", Role = "admin"},
            new User { Id = 2, UserName = "deepika", Password = "admin@123", Role = "admin"},
            new User { Id = 3, UserName = "user", Password = "user@123", Role = "guest"},
            new User { Id = 4, UserName = "guest", Password = "guest@123", Role = "guest"}
        };

        public string Login(string userName, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            // return null if user not found
            if (user == null)
            {
                return string.Empty;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my secret key");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.Token;
        }
    }
}
