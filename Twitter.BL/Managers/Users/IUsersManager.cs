using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;

namespace Twitter.BL.Managers.Users
{
    public interface IUsersManager
    {
       void Register(RegisterDTO register);
       TokenDTO Login(LoginDTO credentials);
       UserProfileDTO GetProfile(string Id);
       string getUserFormToken(string token);
       void Logout(string token);
    }
}
