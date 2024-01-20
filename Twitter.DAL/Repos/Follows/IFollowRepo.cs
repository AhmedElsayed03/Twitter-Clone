using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.Follows
{
    public interface IFollowRepo:IGenericRepo<Follow>
    {
        IEnumerable<string> GetFollowers(string userId);
        IEnumerable<string> GetFollowing(string userId);
    }
}
