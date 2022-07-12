using Azure;
using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using ImageShare.Services;
using ImageShare.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ImageShare.Web.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private readonly ILogger<ImagesController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ImageService _imageService;
        private readonly LibraryService _libraryService;
        private readonly UserService _userService;
        public ImagesController(ILogger<ImagesController> logger, ApplicationDbContext context,
            ImageService imageService, UserService userService, LibraryService libraryService)
        {
            _logger = logger;
            _context = context;
            _imageService = imageService;
            _libraryService = libraryService;
            _userService = userService;
        }

        public IActionResult Index(Guid libraryId, Guid albumId)
        {
            var vm = new ImagesViewModel
            {
                LibraryId = libraryId,
                AlbumId = albumId
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Image? img = _context.Images.Find(id);
            if (img == null) return NotFound();

            ImageViewModel vm = new()
            {
                ImageId = img.Id,
                ImageUrl = img.Url,
                Title = img.Title,
                Description = img.Description ?? String.Empty,
                Tags = img.Tags,
                Libraries = img.Libraries,
                Albums = img.Albums,
                IsOwner = img.Owner == _userService.GetCurrentUserAsync().Result
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IResult> Upload(IFormFile uploadFile, Guid libraryId, Guid albumId)
        {
            Library? library = _context.Libraries.Find(libraryId);
            if (library == null) return Results.Problem("No library selected",null,StatusCodes.Status406NotAcceptable);
            Album? album = _context.Albums.Find(albumId);
            Image image = new()
            {
                Owner = await _userService.GetCurrentUserAsync(),
                Title = uploadFile.FileName,
                Created = DateTime.Now,
            };
            
            image = await _imageService.UploadAsync(image, uploadFile.OpenReadStream());
            image = await _imageService.AddAsync(image, library, album);
            _logger.LogInformation("Image added:\n\tId:{id}\n\tTitle:{title}\n\tBlobName:{blobName}",
                image.Id, image.Title, image.BlobName);

            return Results.Ok(new { id = image.Id, url = image.Url });

        }
    }
}
