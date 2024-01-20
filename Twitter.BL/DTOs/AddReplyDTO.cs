using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.BL.DTOs
{
    public class AddReplyDTO
    {
        public string PostId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> ImagesUrls { get; set; } = new List<string>();
    }
}
