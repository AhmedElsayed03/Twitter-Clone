using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.BL.DTOs;
using Twitter.DAL.DomainModels;
using Twitter.DAL.Repos.PostImages;
using Twitter.DAL.UnitOfWork;

namespace Twitter.BL.Managers.PostImages
{
    
    public class PostImagesManager:IPostImagesManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostImagesManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void addImages(List<AddPostImageDto> addPostImage)
        {
            List<PostImage> imgs = addPostImage.Select(i => new PostImage
            {
                ImgName = i.ImgName,
                PostId = i.PostId,
                Url = i.Url,

            }).ToList();
            //_postImagesRepo.AddImages(imgs);
            foreach (var Img in imgs)
            {
                _unitOfWork.PostImagesRepo.Add(Img);
                _unitOfWork.Save();
            }
            

        }
    }
}
