using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.GroupChat
{
    public interface IGroupChatRepo:IGenericRepo<Groupchat>
    {
        Groupchat? GetByName(string Name);
        bool IfGroupExists(string Name);
    }
}
