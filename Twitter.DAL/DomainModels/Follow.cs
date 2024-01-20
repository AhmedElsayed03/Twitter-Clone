using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class Follow
    {
        public string FollowingID { get; set; } = string.Empty;
        public string FollowerID { get; set; } = string.Empty;
        public User? Follower { get; set; } 
        public User? Following { get; set; }

    }
}
