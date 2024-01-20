using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.Likes;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.Likes
{
    public class LikesManager : ILikesManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikesManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GiveLike(LikeDTO newLike)
        {
            Like like = new Like();
            like.PostId = newLike.PostId;
            like.UserID = newLike.UserID;
            _unitOfWork.LikeRepo.Add(like);
            _unitOfWork.Save();
        }

        public string getUserFormToken(string Id)
        {
            return _unitOfWork.LikeRepo.getUserFormToken(Id);
        }

        public IEnumerable<string> PostLike(string postId)
        {
            return _unitOfWork.LikeRepo.PostLikes(postId);
        }

        public IEnumerable<string> UserLikes(string userId)
        {
            return _unitOfWork.LikeRepo.UserLikes(userId);
        }
    }
}
