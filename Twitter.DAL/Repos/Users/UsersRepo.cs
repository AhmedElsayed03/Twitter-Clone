using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Users
{
    public class UsersRepo:GenericRepo<User>,IUsersRepo
    {
        private readonly TwitterDBContext _context;
        public UsersRepo(TwitterDBContext context):base(context)
        {
            _context = context;
        }

        public User? GetByUsername(string username)
        {
            return _context.Set<User>().Find(username);
        }


    }
}
