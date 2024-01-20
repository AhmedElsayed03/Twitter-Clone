using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;

namespace Twitter.BL.Managers.Likes
{ 
    public interface ILikesManager
    {
        void GiveLike(LikeDTO newLike);
        IEnumerable<string> PostLike(string postId);
        IEnumerable<string> UserLikes(string userId);
        string getUserFormToken(string Id);
    }
}
