using Microsoft.AspNetCore.Mvc;
using Twitter.BL.DTOs;
using Twitter.BL.Managers.PostImages;
using Twitter.BL.Managers.Posts;
using Twitter.BL.Managers.Users;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IPostImagesManager _postImagesManager;
        public ImageController(IPostImagesManager postImagesManager)
        {
            _postImagesManager = postImagesManager;
        }

        [HttpPost]
        [Route("AddProfilePicture")]
        public ActionResult<string> AddProfilePicture([FromForm] IFormFile ImageFile)
        {
            #region Extention Checking
            var extension = Path.GetExtension(ImageFile.FileName);
            var extensionList = new string[]
            {
                ".png",
                ".jpg",
                ".jpeg",
                ".svg"
            };

            bool isExtensionAllowed = extensionList.Contains(extension,
                StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest("Format not allowed");
            }
            #endregion

            #region Length Checking

            bool isSizeAllowed = ImageFile.Length is > 0 and < 5_000_000; //Picture Size (Minimum: >0 and Max: 5MB)

            if (!isSizeAllowed)
            {
                return BadRequest("Size is Larger than allowed size");
            }
            #endregion

            #region Storing Image
            var generatedPictureName = $"{Guid.NewGuid()}{extension}";
            var savedPicturesPath = Environment.CurrentDirectory + "/Images/ProfilePictures/" + generatedPictureName;
            using var stream = new FileStream(savedPicturesPath, FileMode.Create);
            ImageFile.CopyTo(stream);
            #endregion

            #region URL Generating
            var url = $"{Request.Scheme}://{Request.Host}/Images/ProfilePictures/{generatedPictureName}";
            #endregion
            
            return Ok(url);
        }

        [HttpPost]
        [Route("AddHeaderImg")]
        public ActionResult<string> AddHeaderImg([FromForm] IFormFile ImageFile)
        {
            #region Extention Checking
            var extension = Path.GetExtension(ImageFile.FileName);
            var extensionList = new string[]
            {
                ".png",
                ".jpg",
                ".jpeg",
                ".svg"
            };

            bool isExtensionAllowed = extensionList.Contains(extension,
                StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest("Format not allowed");
            }
            #endregion

            #region Length Checking

            bool isSizeAllowed = ImageFile.Length is > 0 and < 5_000_000; //Picture Size (Minimum: >0 and Max: 5MB)

            if (!isSizeAllowed)
            {
                return BadRequest("Size is Larger than allowed size");
            }
            #endregion

            #region Storing Image
            var generatedPictureName = $"{Guid.NewGuid()}{extension}";
            var savedPicturesPath = Environment.CurrentDirectory + "/Images/CoverImages/" + generatedPictureName;
            using var stream = new FileStream(savedPicturesPath, FileMode.Create);
            ImageFile.CopyTo(stream);
            #endregion

            #region URL Generating
            var url = $"{Request.Scheme}://{Request.Host}/Images/CoverImages/{generatedPictureName}";
            #endregion


            return Ok(url);
        }

        [HttpPost]
        [Route("PostPictures")]
        public ActionResult<List<AddPostImageDto>> PostPictures([FromForm] List<IFormFile> ImageFile, string postID)
        {

            var listOfImgs = new List<AddPostImageDto>();

            foreach (var img in ImageFile) {

            #region Extention Checking
            var extension = Path.GetExtension(img.FileName);
            var extensionList = new string[]
            {
                ".png",
                ".jpg",
                ".jpeg",
                ".svg"
            };

            bool isExtensionAllowed = extensionList.Contains(extension,
                StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest("Format not allowed");
            }
            #endregion

            #region Length Checking

            bool isSizeAllowed = img.Length is > 0 and < 5_000_000; //Picture Size (Minimum: >0 and Max: 5MB)

            if (!isSizeAllowed)
            {
                return BadRequest("Size is Larger than allowed size");
            }
            #endregion

            #region Storing Image
            var generatedPictureName = $"{Guid.NewGuid()}{extension}";
            var savedPicturesPath = Environment.CurrentDirectory + "/Images/Posts/" + generatedPictureName;
            using var stream = new FileStream(savedPicturesPath, FileMode.Create);
            img.CopyTo(stream);
            #endregion

            #region URL Generating
            var url = $"{Request.Scheme}://{Request.Host}/Images/Posts/{generatedPictureName}";
            #endregion

            var newImg = new AddPostImageDto { ImgName = generatedPictureName,PostId=postID
            ,Url= url};

            listOfImgs.Add(newImg);
            }
            _postImagesManager.addImages(listOfImgs);
            return Ok(listOfImgs);
        }
    }
}
