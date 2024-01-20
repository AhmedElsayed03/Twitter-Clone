using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.CustomValidations;

namespace Twitter.BL.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; } = null!; //null! => Supress Null Warning
        [Required]
        public string Name { get; set; } = string.Empty;

        //[Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MustBePlusEighteen]
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string ProfilePicture { get; set; } = "https://localhost:7298/Images/ProfilePictures/Default.png"; // = "Insert Default Profile Picture URL";
        public string HeaderImage { get; set; } = "https://localhost:7298/Images/CoverImages/Default.png"; // = "Insert Default HeaderImage URL";
        public string Bio { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
