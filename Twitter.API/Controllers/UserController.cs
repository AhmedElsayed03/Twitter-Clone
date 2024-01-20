using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.Follows;
using Twitter.BL.Managers.Users;
using Twitter.DAL.DomainModels;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUsersManager _usersManager;
        private readonly IFollowManager _FollowManager;
        public UserController(IUsersManager usersManager, IFollowManager followsManager)
        {
            _usersManager = usersManager;
            _FollowManager = followsManager;

        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterDTO register)
        {
            _usersManager.Register(register);
            return Ok("Account created successfully!");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<TokenDTO> Login(LoginDTO credentials)
        {
            var LoginDTO = _usersManager.Login(credentials);
            return Ok(LoginDTO);
        }

        [HttpGet]
        [Route("Profile")]
        [Authorize(Policy = "For Users")]
        public ActionResult<UserProfileDTO> userProfile()
        {
            string userId = _usersManager.getUserFormToken(Request.Headers.Authorization!);
            var profile = _usersManager.GetProfile(userId);
            return Ok(profile);
        }

        [HttpPost]
        [Route("Logout")]
        [Authorize(AuthenticationSchemes = "AuthName")]
        public ActionResult Logout() {
            return Ok("Account Logged out Successfully!");
        }
    }
}
