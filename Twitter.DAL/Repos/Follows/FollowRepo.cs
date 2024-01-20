using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Follows
{
    public class FollowRepo : GenericRepo<Follow>, IFollowRepo
    {
        private readonly TwitterDBContext _context;
        public FollowRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<string> GetFollowers(string userId)
        {
            List<string> result = new List<string>();
            var followers = _context.Set<Follow>().Where(i=>i.FollowingID==userId).ToList();
            result=followers.Select(i=>i.FollowerID).ToList();
            return result;
        }
        public IEnumerable<string> GetFollowing(string userId)
        {
            List<string> result = new List<string>();
            var followings = _context.Set<Follow>().Where(i => i.FollowerID == userId).ToList();
            result = followings.Select(i => i.FollowingID).ToList();
            return result;
        }
    }
}
