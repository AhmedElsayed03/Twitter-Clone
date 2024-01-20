using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class PostImage
    {
        public string ImgName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        //Foreign Keys
        public string PostId { get; set; } = string.Empty;

        //Nav Properties
        public Post Post { get; set; } = null!;
    }
}
