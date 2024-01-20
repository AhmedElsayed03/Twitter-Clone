using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.Posts;
using Twitter.BL.Managers.Users;
using Twitter.DAL.DomainModels;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostsManager _postsManager;
        public PostController(IPostsManager postsManager)
        {
            _postsManager = postsManager;
        }

        [HttpPost]
        [Authorize(Policy = "For Users")]
        public ActionResult AddPost(AddPostDTO newPost)
        {
            newPost.UserId = _postsManager.getUserFormToken(Request.Headers.Authorization!);
            _postsManager.AddPost(newPost);
            return Ok("Post Added Successfully!");
        }

        [HttpGet]
        [Authorize(Policy = "For Users")]
        public ActionResult<List<ReadPostDTO>> GetAllPost()
        {
            string userId = _postsManager.getUserFormToken(Request.Headers.Authorization!);
            var posts = _postsManager.GetPost(userId).ToList();

            return posts;
        }

    }
}
