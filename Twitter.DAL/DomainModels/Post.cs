using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class Post
    {
        //Properties
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(280),MinLength(1)]
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public List<PostImage> Images { get; set; } = new List<PostImage>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Reply> Replies { get; set; } = new List<Reply>();

        //Foreign Keys
        public string UserId { get; set; } = string.Empty;

        //Nav Properties
        public User User { get; set; } = null!;
    }
}
