using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using ImageShare.Services;
using ImageShare.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ImageShare.Web.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly AlbumService _albumService;
        private readonly UserService _userService;
        public AlbumsController(ILogger<AlbumsController> logger, ApplicationDbContext context,
            UserService userService, AlbumService albumService) =>
            (_logger, _context, _albumService, _userService) =
            (logger, context, albumService, userService)

        public IActionResult Index(Guid libraryId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateAlbumViewModel vm = new CreateAlbumViewModel();
            vm.Title = $"{User.Identity!.Name}'s album";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAlbumViewModel obj)
        {
            AppUser? currentUser = await _userService.GetCurrentUserAsync();
            List<string> tagTexts = new List<string>();
            if (obj.TagsText != null) tagTexts = obj.TagsText.Split(',').ToList();

            var newAlbum = _albumService.Create(currentUser, obj.Title, obj.Description, tagTexts);
            return RedirectToAction("Index", "Home", new { albumId = newAlbum.Id });

        }
    }
}
