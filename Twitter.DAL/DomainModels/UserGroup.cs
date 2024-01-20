using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class UserGroup
    {
        public string UserId { get; set; } = string.Empty;
        public string GroupId { get; set; } = string.Empty;
        public User? User { get; set; }
        public Groupchat? Groupchat { get; set; }

    }
}
