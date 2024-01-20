using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.GroupChats;
using Twitter.BL.Managers.OnlineUsers;
using Twitter.BL.Managers.UserGroups;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.GroupChat;
using Twitter.DAL.Repos.OnlineUsers;
using Twitter.DAL.Repos.UserGroups;
using Twitter.DAL.UnitOfWork;

namespace Twitter.API.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IOnlineUsersManager _onlineUsersManager;
        private readonly IGroupChatManager _groupChatManager;
        private readonly IUserGroupsManager _userGroupsManager;
        private readonly IUnitOfWork _unitOfWork;

        public ChatHub(IOnlineUsersManager onlineUsersManager, IGroupChatManager groupChatManager,
            IUserGroupsManager userGroupsManager, IUnitOfWork unitOfWork)
        {
            _onlineUsersManager = onlineUsersManager;
            _groupChatManager = groupChatManager;
            _userGroupsManager = userGroupsManager;
            _unitOfWork = unitOfWork;


        }

        //Send Message To User
        public void SendUserMsg(string message, string UserId)
        {
            Clients.User(UserId).SendAsync($"{Context.User!.Identity!.Name}: {message}",
                CancellationToken.None);
        }

        //Send Message To Group
        public void SendGroupMsg(string message,string groupName)
        {
            Clients.OthersInGroup(groupName).SendAsync($"{Context.User!.Identity!.Name}: {message}",
                CancellationToken.None);
        }

        //User Joins Group. If Group doesn't Exist, SignalR Creates it and joins the user
        //Notify Others in group that new member has joined group
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId!, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("Send", $"{Context.User!.Identity!.Name} Joined {groupName}"); //Notify

            #region Using Manager
            GroupChatDTO groupChat = new GroupChatDTO() { Name = groupName, Id = Guid.NewGuid().ToString() };
            _groupChatManager.CreateGroup(groupChat);
            UserGroupDTO user = new UserGroupDTO() { UserId = Context.UserIdentifier!, GroupId = groupChat.Id };
            _userGroupsManager.JoinGroup(user);
            #endregion

            #region Using Repo
            //Groupchat groupchat = new Groupchat() { Id = Guid.NewGuid().ToString(), Name = groupName };
            //_unitOfWork.GroupChatRepo.Add(groupchat);
            //UserGroup userGroup = new UserGroup() { UserId = Context.UserIdentifier!, GroupId = groupchat.Id };
            //_unitOfWork.UserGroupsRepo.Add(userGroup);
            //_unitOfWork.Save();
            #endregion

        }

        //User Leaves Group
        public void LeaveGroup(string groupName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            var group = _groupChatManager.GetByName(groupName);
            _userGroupsManager.LeaveGroup(new UserGroupDTO { UserId = Context.UserIdentifier!, GroupId = group!.Id });
        }
        //Delete Group
        public void DeleteGroup(string groupName)
        {
            _groupChatManager.DeleteGroup(groupName);
        }
    
        //Executes Automatically Once User Is Connected
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendMessageToAll", $"{Context.User!.Identity!.Name} with " +
                $"Connection ID: {Context.ConnectionId} with Id: {Context.UserIdentifier} is Online!", CancellationToken.None);
            OnlineUserDto newOnlineUser = new OnlineUserDto(Context.UserIdentifier!, Context.ConnectionId);
            _onlineUsersManager.AddOnlineUser(newOnlineUser);

        }
        //Executes Automatically Once User Is Disconnected
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            OnlineUserDto OnlineUser = new OnlineUserDto(Context.UserIdentifier!, Context.ConnectionId);
            _onlineUsersManager.RemoveOnlineUser(OnlineUser);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
