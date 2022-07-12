using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using ImageShare.Services;
using ImageShare.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageShare.Web.ViewComponents
{
    public class ImagesAreaViewComponent : ViewComponent
    {
        private readonly ILogger<ImagesAreaViewComponent> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserService _userService;
        public ImagesAreaViewComponent(ILogger<ImagesAreaViewComponent> logger, ApplicationDbContext context,
            UserService userService) => (_logger, _context, _userService) = (logger, context, userService);

        public IViewComponentResult Invoke(Guid libraryId, Guid? albumId)
        {
            AppUser user = _userService.GetCurrentUserAsync().Result;
            Library? library =
                _context.Libraries.Find(libraryId) ?? _userService.GetSubscribedLibraries(user).FirstOrDefault();
            if (library == null) return View("NoLibrary");
            Album? album = _context.Albums.Find(albumId);

            var vm = new ImagesViewModel()
            {
                Library = library,
                LibraryId = library.Id,
                Album = album

            };
            if (vm.Album != null)
            {
                vm.AlbumId = vm.Album.Id;
                vm.Images = vm.Album.Images;
            }
            else vm.Images = vm.Library.Images;

            return View(vm);

        }
    }
}
