using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.Likes;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController:Controller
    {
        private readonly ILikesManager _likesManager;
        public LikeController(ILikesManager likesManager)
        {
            _likesManager = likesManager;
        }

        [HttpPost]
        [Route("GiveLike")]
        [Authorize(Policy = "For Users")]
        public ActionResult GiveLike(string postId)
        {
            string userId = _likesManager.getUserFormToken(Request.Headers.Authorization!);
            LikeDTO like = new LikeDTO();
            like.UserID = userId;
            like.PostId = postId;
            _likesManager.GiveLike(like);
            return Ok("Post Liked!");
        }

        [HttpGet]
        [Route("PostLikes")]
        public ActionResult<List<string>> GetPostLikes(string postId)
        {
            var PostLikes = _likesManager.PostLike(postId);
            return Ok(PostLikes);
        }

        [HttpGet]
        [Route("UserLikes")]
        public ActionResult<List<string>> GetUserLikes()
        {
            string userId = _likesManager.getUserFormToken(Request.Headers.Authorization!);
            var UserLikes = _likesManager.UserLikes(userId);
            return Ok(UserLikes);
        }

        [HttpGet]
        [Route("PostLikesCount")]

        public ActionResult<int> GetPostLikesCount(string postId)
        {
            var PostLikes = _likesManager.PostLike(postId).ToList().Count();
            return Ok(PostLikes);
        }

        [HttpGet]
        [Route("UserLikesCount")]
        public ActionResult<int> GetUserLikesCount()
        {
            string userId = _likesManager.getUserFormToken(Request.Headers.Authorization!);
            var UserLikes = _likesManager.UserLikes(userId).ToList().Count();
            return Ok(UserLikes);
        }

    }
}
