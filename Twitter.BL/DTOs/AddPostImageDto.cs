using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;

namespace Twitter.BL.DTOs
{
    public class AddPostImageDto
    {
        public string ImgName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        //Foreign Keys
        public string PostId { get; set; } = string.Empty;

    }
}
