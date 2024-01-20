using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;

namespace Twitter.BL.DTOs
{
    public class ReadPostDTO
    {
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<string> ImagesUrls { get; set; } = new List<string>();
    }
}
