using ImageShare.Data;
using ImageShare.Services;
using ImageShare.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageShare.Web.ViewComponents
{
    public class NavMenuViewComponent : ViewComponent
    {
        private readonly UserService _userService;
        private readonly ApplicationDbContext _context;

        public NavMenuViewComponent(UserService userService, ApplicationDbContext context) =>
            (_userService, _context) = (userService, context);

        public IViewComponentResult Invoke()
        {
            var vm = new NavMenuViewModel();

            if (_userService.IsSignedIn)
            {
                var currentUser = _userService.GetCurrentUserAsync().Result;
                vm.IsSignedIn = true;
                vm.UserName = currentUser.UserName;
                vm.Libraries = currentUser.SubscribedLibraries;
                vm.Albums = currentUser.SubscribedAlbums;
            }
            else { vm.IsSignedIn = false; }

            return View(vm);
        }

    }
}
