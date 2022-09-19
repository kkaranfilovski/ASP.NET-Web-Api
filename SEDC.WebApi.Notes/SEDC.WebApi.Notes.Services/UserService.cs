using SEDC.WebApi.Notes.DataAccess;
using SEDC.WebApi.Notes.DataModels.Models;
using SEDC.WebApi.Notes.ServiceModels.UserModels;
using SEDC.WebApi.Notes.Services.Interfaces;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace SEDC.WebApi.Notes.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public void Register(RegisterUser request)
        {
            var user = _repository.GetAll().FirstOrDefault(u => u.UserName.Equals(request.UserName, StringComparison.InvariantCultureIgnoreCase));

            if(user != null)
            {
                throw new Exception("Username already exist");
            }

            if (!IsValidPassword(request.Password))
            {
                throw new Exception("Password is not valid");
            }

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = HashPassword(request.Password)
            };

            _repository.Insert(newUser);
        }

        public UserLoginDto Login(LoginModelDto request)
        {
            throw new NotImplementedException();
        }

        private bool IsValidPassword(string password)
        {
            var passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.
                ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5data);
        }

    }
}
