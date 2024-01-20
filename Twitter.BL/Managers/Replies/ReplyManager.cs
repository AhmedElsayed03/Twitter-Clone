using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.Replies;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.Replies
{
    public class ReplyManager:IReplyManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReplyManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddReply(AddReplyDTO newReply)
        {
            Reply reply = new Reply();
            reply.Id = Guid.NewGuid().ToString();
            reply.UserId = newReply.UserId;
            reply.PostId = newReply.PostId;
            reply.Content = newReply.Content;
            reply.Date = DateTime.Now;
            _unitOfWork.ReplyRepo.Add(reply);
            _unitOfWork.Save();
        }
        public IEnumerable<GetReplyDTO> GetUserReplies(string userId)
        {
            var userReplies = _unitOfWork.ReplyRepo.getUserReplies(userId);
            var userRepliesDTO = new List<GetReplyDTO>();
            userRepliesDTO= userReplies.Select(i => new GetReplyDTO
            {
                Date = i.Date,
                Content = i.Content,
                ImagesUrls = i.Images.Select(image => image.Url).ToList()

            }).OrderBy(i => i.Date)
              .ToList();
            return userRepliesDTO;
        }
        public IEnumerable<GetReplyDTO> GetPostReplies(string postId)
        {
            var userReplies = _unitOfWork.ReplyRepo.getPostReplies(postId);
            var userRepliesDTO = new List<GetReplyDTO>();
            userRepliesDTO = userReplies.Select(i => new GetReplyDTO
            {
                Date = i.Date,
                Content = i.Content,
                ImagesUrls = i.Images.Select(image => image.Url).ToList()

            }).OrderBy(i => i.Date)
              .ToList();
            return userRepliesDTO;
        }
        public string getUserFormToken(string Id)
        {
            return _unitOfWork.ReplyRepo.getUserFormToken(Id);
        }

    }
}
