using SEDC.WebApi.Notes.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Notes.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUser request);
        UserLoginDto Login(LoginModelDto request)
    }
}
