using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.CustomValidations;

namespace Twitter.BL.DTOs
{
    public class AddUserDTO
    {
        [Required]
        public string UserName { get; set; } = null!; //null! => Supress Null Warning
        [Required]
        public string Name { get; set; } = null!;

        //[Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MustBePlusEighteen]
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfilePicture { get; set; } = "https://www.svgrepo.com/show/532363/user-alt-1.svg"; // = "Insert Default Profile Picture URL";
        public string HeaderImage { get; set; } = string.Empty; // = "Insert Default HeaderImage URL";
        public string Bio { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
    }
}
