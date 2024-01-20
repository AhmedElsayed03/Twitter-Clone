using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.CustomValidations;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.Users;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IUnitOfWork _unitOfWork;
        UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public UsersManager(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _configuration = configuration;

        }

        public void Register(RegisterDTO newUser)
        {
            User user = new User
            {
                DateOfBirth = newUser.DateOfBirth,
                Email = newUser.Email,
                Name = newUser.Name,
                Bio = newUser.Bio,
                Location = newUser.Location,
                Website = newUser.Website,
                UserName = newUser.UserName,
                JoinDate = newUser.JoinDate,
                ProfilePicture = newUser.ProfilePicture,
                HeaderImage = newUser.HeaderImage
                
            };
            var creationResult = _userManager.CreateAsync(user, newUser.Password).Result;
            if (!creationResult.Succeeded)
            {
                return;
            }

            var claims = new List<Claim>
                {
                new (ClaimTypes.Role, "User"),
                new (ClaimTypes.NameIdentifier, user.Id),
                new ("sub",user.Id), //Subject is the user
                new (ClaimTypes.Name, user.Name)

                };
            var addingClaimsResult = _userManager.AddClaimsAsync(user, claims).Result;
            if (!addingClaimsResult.Succeeded)
            {
                return;
            }

            //if (_usersRepo.GetByUsername(newUser.UserName) == null)
            //{

            //}
            //else
            //    return;
        }

        public TokenDTO Login(LoginDTO credentials)
        {
            IdentityUser? user = _userManager.FindByNameAsync(credentials.UserName).Result;
            if (user == null)
            {
                return null;
            }

            bool isPasswordCorrect = _userManager.CheckPasswordAsync(user, credentials.Password).Result;
            if (!isPasswordCorrect)
            {
                var attempts = _userManager.AccessFailedAsync(user); //Faild Accessing Attempts
                return null;
            }


            //Create Token => Claims, Hashing Algorithm, SecretKey


            //Claims => Already Registered with user
            List<Claim> claimsList = _userManager.GetClaimsAsync(user).Result.ToList();

            //Access SecretKey
            string? keyString = _configuration.GetSection("SecretKey").Value;
            byte[] keyInBytes = Encoding.ASCII.GetBytes(keyString!);
            SymmetricSecurityKey key = new SymmetricSecurityKey(keyInBytes);

            //Hashing Criteria
            //Install-package microsoft.identitymodel.tokens => Hashing
            SigningCredentials signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            //Generate Token
            //Install-package system.identitymodel.tokens.jwt => (input: token parts, output: token)

            DateTime expiration = DateTime.Now.AddMinutes(20);
            JwtSecurityToken token = new JwtSecurityToken
            (
                claims: claimsList,
                signingCredentials: signingCredentials,
                issuer: "TwitterBackend", //Token Generator
                audience: "Posts", //Secured API
                notBefore: DateTime.Now, //Start now
                expires: expiration  //Expires after 20 mins
            );

            string stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            //Fetching user id from token
            var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(stringToken);
            string UserID = tokenHandler.Subject;
            return new TokenDTO { Token = stringToken, Expiry = expiration, UserId = UserID };

        }

        public UserProfileDTO GetProfile(string Id)
        {
            User? user = _unitOfWork.UserRepo.GetByID(Id);
            UserProfileDTO userProfile = new UserProfileDTO
            {
                Name=user.Name,
                Bio=user.Bio,
                Location = user.Location,
                Website = user.Website,
                DateOfBirth = user.DateOfBirth,
                JoinDate=user.JoinDate,
                HeaderImage=user.HeaderImage,
                ProfilePicture=user.ProfilePicture
            };
            return userProfile;
        }

        public void Logout(string token)
        {    
            //_userManager.RemoveAuthenticationTokenAsync(user!, "AuthName", token);
        }
        public string getUserFormToken(string token)
        {
            return _unitOfWork.UserRepo.getUserFormToken(token);
        }


    }
}
