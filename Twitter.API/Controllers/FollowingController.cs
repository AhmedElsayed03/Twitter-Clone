using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.Follows;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowingController : Controller
    {
        private readonly IFollowManager _followManager;
        public FollowingController(IFollowManager followManager) {
            
            _followManager = followManager;
        }


        [HttpPost]
        [Route("AddFollow")]
        [Authorize(Policy = "For Users")]
        public ActionResult Follow(string followingUserId)
        {
            string userId = _followManager.getUserFormToken(Request.Headers.Authorization!);
            FollowDTO follow = new FollowDTO();
            follow.FollowerID = userId;
            follow.FollowingID = followingUserId;
            _followManager.Follow(follow);
            return Ok("Followed!");
        }

        [HttpGet]
        [Route("Followers")]
        public ActionResult<List<string>> GetFollowers()
        {
            string userId = _followManager.getUserFormToken(Request.Headers.Authorization!);
            var followers = _followManager.getFollowers(userId);
            return Ok(followers);
        }

        [HttpGet]
        [Route("Followings")]
        public ActionResult<List<string>> GetFollowings()
        {
            string userId = _followManager.getUserFormToken(Request.Headers.Authorization!);
            var followings = _followManager.getFollowings(userId);
            return Ok(followings);
        }

        [HttpGet]
        [Route("FollowersCount")]
        public ActionResult<int> GetFollowersCount()
        {
            string userId = _followManager.getUserFormToken(Request.Headers.Authorization!);
            var followers = _followManager.getFollowers(userId).ToList().Count();
            return Ok(followers);
        }

        [HttpGet]
        [Route("FollowingsCount")]
        public ActionResult<int> GetFollowingsCount()
        {
            string userId = _followManager.getUserFormToken(Request.Headers.Authorization!);
            var followings = _followManager.getFollowings(userId).ToList().Count();
            return Ok(followings);
        }


    }
}
