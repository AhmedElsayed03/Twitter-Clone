using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;

namespace Twitter.BL.Managers.Follows
{
    public interface IFollowManager
    {
        void Follow(FollowDTO newFollow);
        IEnumerable<string> getFollowers(string userID);
        IEnumerable<string> getFollowings(string userID);
        string getUserFormToken(string Id);

    }
}
