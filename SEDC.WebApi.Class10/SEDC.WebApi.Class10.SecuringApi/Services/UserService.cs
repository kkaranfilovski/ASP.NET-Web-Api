using Microsoft.IdentityModel.Tokens;
using SEDC.WebApi.Class10.SecuringApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.WebApi.Class10.SecuringApi.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                Firstname = "Trajan",
                Lastname = "Stevkovski",
                Username = "trastev",
                Password = "asdzxc123"

            },
            new User
            {
                Id = 2,
                Firstname = "Kristijan",
                Lastname = "Karanfilovski",
                Username = "krikar",
                Password = "asdzxc123"

            }
        };

        public void Register(RegisterModel request)
        {
            User? user = ValidateUser(request.Username);

            if (user != null)
            {
                throw new Exception("Username already exist");
            }

            if (!ValidatePassword(request.Password))
            {
                throw new Exception("Password not valid");
            }

            string hashedPassword = Hashpassword(request.Password);

            var newUser = new User
            {
                Id = _users.Count() + 1,
                Username = request.Username,
                Password = hashedPassword,
                Lastname = request.Lastname,
                Firstname = request.Firstname
            };

            _users.Add(newUser);
        }



        public UserDto Login(LoginModel request)
        {
            var user = ValidateUser(request.Username);

            if(user == null)
            {
                throw new Exception("User does not exist");
            }

            var password = Hashpassword(request.Password);

            if(user.Password != password)
            {
                throw new Exception("Not valid password");
            }

            // generate token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is secret from appsettings");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[] 
                    {
                        new Claim(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    } 
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserDto
            {
                FullName = $"{user.Firstname} {user.Lastname}",
                Id = user.Id,
                Token = tokenHandler.WriteToken(token)
            };
        }
        
        private static string Hashpassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);
            return hashedPassword;
        }

        private User? ValidateUser(string username)
        {
            return _users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }

        private bool ValidatePassword(string password)
        {
            foreach(var c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
