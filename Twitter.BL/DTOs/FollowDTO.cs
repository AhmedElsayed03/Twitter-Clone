using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.BL.DTOs
{
    public class FollowDTO
    {
        public string FollowerID { get; set; } = string.Empty;
        public string FollowingID { get; set; } = string.Empty;
    }
}
