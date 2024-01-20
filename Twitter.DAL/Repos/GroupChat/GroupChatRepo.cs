using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.GroupChat
{
    public class GroupChatRepo : GenericRepo<Groupchat>,IGroupChatRepo
    {
        private readonly TwitterDBContext _context;
        public GroupChatRepo(TwitterDBContext context) : base(context)
        {
            _context = context;
        }
        public Groupchat? GetByName(string Name)
        {
            return _context.Set<Groupchat>().First(i => i.Name == Name);
        }
        public bool IfGroupExists(string Name)
        {
            var exists = _context.Set<Groupchat>().FirstOrDefault(i => i.Name == Name);
            if (exists==null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
