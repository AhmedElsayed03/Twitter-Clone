using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class OnlineUser
    {
        public string UserId { get; set; } = string.Empty;
        public string ConnectionId { get; set; } = string.Empty;
    }
}
