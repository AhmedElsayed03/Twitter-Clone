using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class Message
    {
        public string Id { get; set; } = string.Empty;
        public string SenderId { get; set; } = string.Empty;
        public string ReceiverId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool Seen { get; set; }
        public DateTime DateTime { get; set; }
    }
}
