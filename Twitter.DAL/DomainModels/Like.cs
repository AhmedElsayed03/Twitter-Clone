using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class Like
    {
        public string PostId { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
        }
}
