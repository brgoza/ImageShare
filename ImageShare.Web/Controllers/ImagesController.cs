using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using ImageShare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ImageShare.Web.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private readonly ILogger<ImagesController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ImageService _imageService;
        private readonly LibraryService _libraryService;
        private readonly UserManager<AppUser> _userManager;
        public ImagesController(ILogger<ImagesController> logger, ApplicationDbContext context,
            ImageService imageService, UserManager<AppUser> userManager, LibraryService libraryService)
        {
            _logger = logger;
            _context = context;
            _imageService = imageService;
            _libraryService = libraryService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile uploadFile, Guid libraryId, Guid albumId)
        {
            Library? library = _context.Libraries.Find(libraryId);
            if (library == null) return new StatusCodeResult(StatusCodes.Status424FailedDependency);
            Album? album = _context.Albums.Find(albumId);

            Image image = new()
            {
                Owner = await _userManager.GetUserAsync(User),
                Title = uploadFile.FileName,
                Created = DateTime.Now,
            };
            image = await _imageService.UploadAsync(image, uploadFile.OpenReadStream());
            image = await _imageService.AddAsync(image, library, album);
            _logger.LogInformation("Image added:\n\tId:{id}\n\tTitle:{title}\n\tBlobName:{blobName}",
                image.Id, image.Title, image.BlobName);

            return Ok(image.Url);

        }
    }
}
