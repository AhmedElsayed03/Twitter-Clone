using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.Posts;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.Posts
{
    public class PostsManager : IPostsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPost(AddPostDTO newPost)
        {
            Post post = new Post
            {
                Id=Guid.NewGuid().ToString(),
                Content=newPost.Content,
                Date=DateTime.Now,
                UserId=newPost.UserId
            };
            _unitOfWork.PostRepo.Add(post);
            _unitOfWork.Save();
        }

        public IEnumerable<ReadPostDTO> GetPost(string Id)
        {
            var posts = _unitOfWork.PostRepo.GetAllPostsById(Id);
            var postsToRead = posts.Select(post => new ReadPostDTO
            {
                Date = post.Date,
                Content = post.Content,
                ImagesUrls = post.Images.Select(image => image.Url).ToList()

            }).OrderBy(i => i.Date)
              .ToList();
            return postsToRead;
        }
        public string getUserFormToken(string Id)
        {
            return _unitOfWork.PostRepo.getUserFormToken(Id);
        }

    }
}
