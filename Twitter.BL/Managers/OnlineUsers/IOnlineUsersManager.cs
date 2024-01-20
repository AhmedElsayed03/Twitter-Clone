using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;

namespace Twitter.BL.Managers.OnlineUsers
{
    public interface IOnlineUsersManager
    {
        void AddOnlineUser(OnlineUserDto newOnlineUser);
        void RemoveOnlineUser(OnlineUserDto newOnlineUser);
    }
}
