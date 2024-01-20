using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;

namespace Twitter.BL.Managers.Replies
{
    public interface IReplyManager
    {
        void AddReply(AddReplyDTO newReply);
        string getUserFormToken(string Id);
        IEnumerable<GetReplyDTO> GetUserReplies(string userId);
        IEnumerable<GetReplyDTO> GetPostReplies(string postId);
    }
}
