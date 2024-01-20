using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.CustomValidations;

namespace Twitter.DAL.DomainModels
{
    public class User : IdentityUser
    {
 
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MustBePlusEighteen]
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfilePicture { get; set; } = "https://localhost:7298/Images/ProfilePictures/Default.png";
        public string HeaderImage { get; set; } = "https://localhost:7298/Images/CoverImages/Default.png";
        public string Bio { get; set; } = string.Empty;
        public string Location { get; set;} = string.Empty;
        public string Website { get; set;} = string.Empty;


        //Navigation Properties
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Reply> Replies { get; set; } = new List<Reply>();
        public List<Follow> Follower { get; set; } = new List<Follow>();
        public List<Follow> Following { get; set; } = new List<Follow>();
        public List<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
    }
}
