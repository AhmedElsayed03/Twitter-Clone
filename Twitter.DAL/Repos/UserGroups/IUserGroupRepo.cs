using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.DomainModels;
using Twitter.DAL.GenericRepo;

namespace Twitter.DAL.Repos.UserGroups
{
    public interface IUserGroupRepo:IGenericRepo<UserGroup>
    {
        UserGroup GetByFK(UserGroup group);
        void DeleteByFK(UserGroup group);
        
    }
}
