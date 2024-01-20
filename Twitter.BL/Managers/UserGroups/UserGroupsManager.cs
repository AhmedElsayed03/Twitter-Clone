using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.UserGroups
{
    public class UserGroupsManager:IUserGroupsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserGroupsManager(IUnitOfWork UnitOfWork) {
            _unitOfWork = UnitOfWork;
        }
        public void JoinGroup(UserGroupDTO userGroup)
        {
            UserGroup newGroup = new UserGroup()
            {
                GroupId = userGroup.GroupId,
                UserId = userGroup.UserId,
            };
            var ifExists = _unitOfWork.UserGroupsRepo.GetByFK(newGroup);
            if (ifExists == null)
            {
                _unitOfWork.UserGroupsRepo.Add(newGroup);
                _unitOfWork.Save();
            }
            else
                return;

        }
        public void LeaveGroup(UserGroupDTO userGroup)
        {
            UserGroup userToLeave = new UserGroup()
            {
                GroupId = userGroup.GroupId,
                UserId = userGroup.UserId,
            };

            _unitOfWork.UserGroupsRepo.DeleteByFK(userToLeave);
            _unitOfWork.Save();
        }

    }
}
