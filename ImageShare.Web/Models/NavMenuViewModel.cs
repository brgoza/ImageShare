using ImageShare.Core;

namespace ImageShare.Web.Models
{
    public class NavMenuViewModel
    {
        public bool IsSignedIn { get; set; }
        public string? UserName { get; set; }
        public List<Library> Libraries { get; set; } = new List<Library>();
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
