using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.Replies;
using Twitter.DAL.DomainModels;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : Controller
    {
        private readonly IReplyManager _replyManager;
        public RepliesController(IReplyManager replyManager)
        {
            _replyManager = replyManager;
        }
        [HttpPost]
        [Authorize(Policy = "For Users")]
        [Route("AddReply")]
        public ActionResult AddReply(AddReplyDTO newPost)
        {
            newPost.UserId = _replyManager.getUserFormToken(Request.Headers.Authorization!);
            _replyManager.AddReply(newPost);
            return Ok("Reply Added!");
        }
        [HttpGet]
        [Route("UserReplies")]
        public ActionResult<List<GetReplyDTO>> GetUserReplies()
        {
            var userId = _replyManager.getUserFormToken(Request.Headers.Authorization!);
            var userReplies = _replyManager.GetUserReplies(userId);
            return Ok(userReplies);
        }

        [HttpGet]
        [Route("PostReplies")]
        public ActionResult<List<GetReplyDTO>> GetPostReplies(string postId)
        { 
            var postReplies = _replyManager.GetPostReplies(postId);
            return Ok(postReplies);
        }
        [HttpGet]
        [Route("PostRepliesCount")]
        public ActionResult<int> GetPostRepliesCount(string postId)
        {
            var postReplies = _replyManager.GetPostReplies(postId).ToList().Count();
            return Ok(postReplies);
        }
    }
}
