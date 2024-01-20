using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;

namespace Twitter.BL.Managers.UserGroups
{
    public interface IUserGroupsManager
    {
        void JoinGroup(UserGroupDTO userGroup);
        void LeaveGroup(UserGroupDTO userGroup);
    }
}
