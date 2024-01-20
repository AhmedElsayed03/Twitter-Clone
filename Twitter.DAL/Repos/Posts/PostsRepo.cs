using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Posts
{
    public class PostsRepo:GenericRepo<Post>,IPostsRepo
    {
        private readonly TwitterDBContext _context;
        public PostsRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAllPostsById(string userId)
        {
            return _context.Set<Post>()
                .Include(i=>i.Images)
                .Where(i=>i.UserId == userId)
                .ToList();
        }

    }
}
