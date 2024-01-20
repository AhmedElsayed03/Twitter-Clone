using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.OnlineUsers
{
    public class OnlineUsersManager:IOnlineUsersManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public OnlineUsersManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddOnlineUser(OnlineUserDto newOnlineUser)
        {
            OnlineUser onlineUser = new OnlineUser()
            {
                ConnectionId = newOnlineUser.ConnectionId,
                UserId = newOnlineUser.UserId
            };
            _unitOfWork.OnlineUserRepo.Add(onlineUser);
            _unitOfWork.Save();
        }
        public void RemoveOnlineUser(OnlineUserDto newOnlineUser)
        {
            OnlineUser onlineUser = new OnlineUser()
            {
                ConnectionId = newOnlineUser.ConnectionId,
                UserId = newOnlineUser.UserId
            };
            _unitOfWork.OnlineUserRepo.Delete(onlineUser);
            _unitOfWork.Save();
        }
    }
}
