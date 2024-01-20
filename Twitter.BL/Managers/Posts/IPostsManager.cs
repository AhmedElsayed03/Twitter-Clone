using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;

namespace Twitter.BL.Managers.Posts
{
    public interface IPostsManager
    {
        void AddPost(AddPostDTO newPost);
        IEnumerable<ReadPostDTO> GetPost(string Id);
        string getUserFormToken(string Id);


    }
}
