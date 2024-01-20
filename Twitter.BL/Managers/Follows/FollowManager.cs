using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.Follows;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.Follows
{
    public class FollowManager:IFollowManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void Follow(FollowDTO newFollow)
        {
            Follow follow = new Follow();
            follow.FollowerID= newFollow.FollowerID;
            follow.FollowingID= newFollow.FollowingID;
            _unitOfWork.FollowRepo.Add(follow);
            _unitOfWork.Save();
        }
        public string getUserFormToken(string Id)
        {
            return _unitOfWork.FollowRepo.getUserFormToken(Id);
        }

        public IEnumerable<string> getFollowers(string userID)
        {
            return _unitOfWork.FollowRepo.GetFollowers(userID);
        }

        public IEnumerable<string> getFollowings(string userID)
        {
            return _unitOfWork.FollowRepo.GetFollowing(userID);
        }
    }
}
