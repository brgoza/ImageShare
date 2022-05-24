using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using ImageShare.Services;
using ImageShare.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ImageShare.Web.Controllers
{
    [Authorize]
    public class LibrariesController : Controller
    {
        private readonly ILogger<LibrariesController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly LibraryService _libraryService;
        private readonly UserService _userService;
       
        public LibrariesController(ILogger<LibrariesController> logger, ApplicationDbContext context,
            UserService userService, LibraryService libraryService) =>
            (_logger, _context, _libraryService, _userService) =
            (logger, context, libraryService, userService);

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateLibraryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateLibraryViewModel obj)
        {
            AppUser? currentUser = await _userService.GetCurrentUserAsync();
            var newLib = _libraryService.CreateLibrary(
                currentUser, obj.Title, obj.Description, obj.TagsText.Split(',').ToList());
            return RedirectToAction("Index","Home", new { libraryId = newLib.Id });
        }
    }
}
