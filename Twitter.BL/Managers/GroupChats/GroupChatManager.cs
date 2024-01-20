using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.GroupChats
{
    public class GroupChatManager:IGroupChatManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupChatManager(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void CreateGroup(GroupChatDTO group)
        {
            bool exist = _unitOfWork.GroupChatRepo.IfGroupExists(group.Name);
            if (exist == false)
            {
                Groupchat newGroup = new Groupchat()
                {
                    Name = group.Name,
                    Id = group.Id,
                };
                _unitOfWork.GroupChatRepo.Add(newGroup);
                _unitOfWork.Save();
            }
            else
                return;

        }
        public Groupchat? GetByName(string name)
        {
            Groupchat? group = _unitOfWork.GroupChatRepo.GetByName(name);
            return group;
        }
        public void DeleteGroup(string name)
        {
            var groupToDelete = GetByName(name);
            if (groupToDelete!=null) {
                _unitOfWork.GroupChatRepo.Delete(groupToDelete!);
            }
            else
                return;
            
        }
        

    }
}
