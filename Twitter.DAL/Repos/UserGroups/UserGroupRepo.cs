using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.UserGroups
{
    public class UserGroupRepo:GenericRepo<UserGroup>, IUserGroupRepo
    {
        private readonly TwitterDBContext _context;
        public UserGroupRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }
        public void DeleteByFK(UserGroup group)
        {
            var delete = _context.Set<UserGroup>()
                .FirstOrDefault(i => i.UserId == group.UserId && i.GroupId == group.GroupId);
        }
        public UserGroup? GetByFK(UserGroup group)
        {
            var userGroup = _context.Set<UserGroup>()
                .FirstOrDefault(i => i.UserId == group.UserId && i.GroupId == group.GroupId);
            return userGroup;
        }
    }
    }

