using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.OnlineUsers
{
    public class OnlineUsersRepo:GenericRepo<OnlineUser>, IOnlineUserRepo
    {
        private readonly TwitterDBContext _context;
        public OnlineUsersRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
