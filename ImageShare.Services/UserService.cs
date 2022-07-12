using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ImageShare.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(ILogger<UserService> logger, ApplicationDbContext context,
                          UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                          IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsSignedIn =>
            _signInManager.IsSignedIn(_httpContextAccessor.HttpContext!.User);
        public async Task<AppUser> GetCurrentUserAsync() =>
            await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

        public List<Library> GetOwnedLibraries(AppUser user)
        {
            return user.LibrarySubscribers
                .Where(ls => ls.IsOwner)
                .Select(ls => ls.Library).ToList();
        }
        public List<Library> GetSubscribedLibraries(AppUser user)
        {
            return user.SubscribedLibraries;
        }
    }
}
