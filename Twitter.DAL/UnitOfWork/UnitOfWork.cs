using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.Repos.Follows;
using Twitter.DAL.Repos.GroupChat;
using Twitter.DAL.Repos.Likes;
using Twitter.DAL.Repos.OnlineUsers;
using Twitter.DAL.Repos.PostImages;
using Twitter.DAL.Repos.Posts;
using Twitter.DAL.Repos.Replies;
using Twitter.DAL.Repos.UserGroups;
using Twitter.DAL.Repos.Users;

namespace Twitter.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TwitterDBContext _context;
        public IFollowRepo FollowRepo { get; }

        public ILikeRepo LikeRepo { get; }

        public IPostImagesRepo PostImagesRepo { get; }

        public IPostsRepo PostRepo { get; }

        public IReplyRepo ReplyRepo { get; }

        public IUsersRepo UserRepo { get; }

        public IOnlineUserRepo OnlineUserRepo { get; }

        public IGroupChatRepo GroupChatRepo { get; }

        public IUserGroupRepo UserGroupsRepo { get; }


        public UnitOfWork(TwitterDBContext context, IFollowRepo _followRepo, ILikeRepo _likeRepo,
            IPostImagesRepo _postImagesRepo, IPostsRepo _postRepo, IReplyRepo _replyRepo,
            IUsersRepo _userRepo, IOnlineUserRepo _onlineUserRepo, IGroupChatRepo _groupChatRepo,
            IUserGroupRepo _userGroupsRepo)
        {
            _context = context;
            PostImagesRepo = _postImagesRepo;
            PostRepo = _postRepo;
            ReplyRepo = _replyRepo;
            UserRepo = _userRepo;
            FollowRepo = _followRepo;
            LikeRepo = _likeRepo;
            OnlineUserRepo = _onlineUserRepo;
            GroupChatRepo = _groupChatRepo;
            UserGroupsRepo = _userGroupsRepo;
        }


        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
