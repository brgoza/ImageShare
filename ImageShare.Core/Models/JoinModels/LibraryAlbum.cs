namespace ImageShare.Core.Models
{
    public class LibraryAlbum
    {
        public virtual Library Library { get; set; } = null!;
        public Guid LibraryId { get; set; }
        public virtual Album Album { get; set; } = null!;
        public Guid AlbumId { get; set; }

    }
}
