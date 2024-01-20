using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Likes
{
    public interface ILikeRepo:IGenericRepo<Like>
    {
        IEnumerable<string> PostLikes(string postID);
        IEnumerable<string> UserLikes(string userID);
    }
}
