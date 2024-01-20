using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;

namespace Twitter.BL.Managers.GroupChats
{
    public interface IGroupChatManager
    {
        void CreateGroup(GroupChatDTO group);
        void DeleteGroup(string name);
        Groupchat? GetByName(string name);
    }
}
