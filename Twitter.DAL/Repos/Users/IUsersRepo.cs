using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Users
{
    public interface IUsersRepo : IGenericRepo<User>
    {
        User? GetByUsername(string username);
        
    }
}
