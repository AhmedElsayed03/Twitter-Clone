using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;

namespace Twitter.BL.Managers.PostImages
{
    public interface IPostImagesManager
    {
        void addImages(List<AddPostImageDto> addPostImage);
    }
}
