using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Likes
{
    public class LikeRepo : GenericRepo<Like>, ILikeRepo
    {
        private readonly TwitterDBContext _context;
        public LikeRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<string> PostLikes(string postID)
        {
            List<string> result = new List<string>();
            var followers = _context.Set<Like>().Where(i => i.PostId==postID).ToList();
            result = followers.Select(i => i.UserID).ToList();
            return result;
        }

        public IEnumerable<string> UserLikes(string userID)
        {
            List<string> result = new List<string>();
            var followers = _context.Set<Like>().Where(i => i.UserID==userID).ToList();
            result = followers.Select(i => i.PostId).ToList();
            return result;
        }
    }
}
