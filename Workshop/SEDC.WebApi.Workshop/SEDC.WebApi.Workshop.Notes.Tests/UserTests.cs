using Microsoft.Extensions.Options;
using SEDC.WebApi.Workshop.Notes.Common.Models;
using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.UserModels;
using SEDC.WebApi.Workshop.Notes.Sevices;

namespace SEDC.WebApi.Workshop.Notes.Tests
{
    [TestClass]
    public class UserTests
    {
        private Mock<IRepository<User>> _userRepo;
        private IOptions<AppSettings> _options;

        public UserTests(IRepository<User> userRepo)
        {
            _userRepo = new Mock<IRepository<User>>();
            _options = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "SECRET FOR TESTING"
            });
        }

        [TestMethod]
        public void Register_Username_Exists()
        {
            //Arrange 
            var users = new List<User>
            {
                new User
                {
                    Id = 3,
                    FirstName = "Trajan",
                    LastName = "Stevkovski",
                    Password = "somePwrd",
                    Username = "stevt"
                }
            };

            _userRepo.Setup(x => x.GetAll()).Returns(users);
            var request = new RegisterUser
            {
                Username = "stevt",
            };

            var service = new UserService(_userRepo.Object, _options);

            //Act
            //Assert
            Assert.ThrowsException<Exception>(() => service.Register(request));
        }

        [TestMethod]
        public void Register_Password_Exists()
        {
            //Arrange 
            var users = new List<User>
            {
                new User
                {
                    Id = 3,
                    FirstName = "Trajan",
                    LastName = "Stevkovski",
                    Password = "somePwrd",
                    Username = "stevt"
                }
            };

            _userRepo.Setup(x => x.GetAll()).Returns(users);
            var request = new RegisterUser
            {
                Username = "stevt1",
                Password = "ASD123"
            };

            var service = new UserService(_userRepo.Object, _options);

            //Act
            //Assert
            Assert.ThrowsException<Exception>(() => service.Register(request));
        }
    }
}
