using ImageShare.Core;

namespace ImageShare.Web.Models
{
    public class ImagesViewModel
    {
        public Library? Library { get; set; }
        public Guid LibraryId { get; set; }

        public Album? Album { get; set; }
        public Guid AlbumId { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();

    }
}
