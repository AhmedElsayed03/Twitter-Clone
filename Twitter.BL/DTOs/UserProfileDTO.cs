using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;

namespace Twitter.BL.DTOs
{
    //This DTO Returns User information
    public class UserProfileDTO
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;
        public string HeaderImage { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;

    }
}
