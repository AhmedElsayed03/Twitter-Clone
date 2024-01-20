using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public interface IUnitOfWork
    {
        public IFollowRepo FollowRepo { get; }
        public ILikeRepo LikeRepo { get; }
        public IPostImagesRepo PostImagesRepo { get; }
        public IPostsRepo PostRepo { get; }
        public IReplyRepo ReplyRepo { get; }
        public IUsersRepo UserRepo { get; }
        public IOnlineUserRepo OnlineUserRepo { get; }
        public IGroupChatRepo GroupChatRepo { get; }
        public IUserGroupRepo UserGroupsRepo { get; }

        int Save();
    }
}
