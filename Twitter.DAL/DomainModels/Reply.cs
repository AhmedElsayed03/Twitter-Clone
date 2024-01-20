using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.DomainModels
{
    public class Reply
    {
        //Properties
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(280), MinLength(1)]
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public List<PostImage> Images { get; set; } = new List<PostImage>();

        //Foreign Keys
        public string UserId { get; set; } = string.Empty;
        public string PostId { get; set; } = string.Empty;

        //Nav Properties
        public User User { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
