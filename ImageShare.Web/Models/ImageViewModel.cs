using ImageShare.Core;

namespace ImageShare.Web.Models
{
    public class ImageViewModel
    {
        public bool IsOwner { get; set; }
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new();
        public List<Library> Libraries { get; set; } = new();
        public List<Album> Albums { get; set; } = new();

    }
}
