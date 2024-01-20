using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Replies
{
    public class ReplyRepo:GenericRepo<Reply>, IReplyRepo
    {
        private readonly TwitterDBContext _context;
        public ReplyRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Reply> getUserReplies(string userId)
        {
            return _context.Set<Reply>()
            .Include(i => i.Images)
            .Where(i => i.UserId == userId)
            .ToList();
        }
        public IEnumerable<Reply> getPostReplies(string postId)
        {
            return _context.Set<Reply>()
            .Include(i => i.Images)
            .Where(i => i.PostId == postId)
            .ToList();
        }
    }
}
