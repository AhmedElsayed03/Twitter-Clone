using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Replies
{
    public interface IReplyRepo:IGenericRepo<Reply>
    {
        IEnumerable<Reply> getUserReplies(string userId);
        IEnumerable<Reply> getPostReplies(string postId);
    }
}
