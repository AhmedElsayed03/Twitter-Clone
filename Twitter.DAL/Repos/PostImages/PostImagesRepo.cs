using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.PostImages
{
    public class PostImagesRepo : GenericRepo<PostImage>, IPostImagesRepo
    {
        private readonly TwitterDBContext _context;
        public PostImagesRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }

        public void AddImages(List<PostImage> imgs)
        {
            foreach (var img in imgs)
            {
                _context.Add(img);
                _context.SaveChanges();
            }
        }
    }
}
