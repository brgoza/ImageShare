using System.ComponentModel.DataAnnotations;
using ImageShare.Core.Models;

namespace ImageShare.Core
{
    public class Library : ITaggable
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public virtual List<Image> Images { get; set; } = null!;
        public virtual List<Album> Albums { get; set; } = null!;
        public virtual List<AppUser> Subscribers { get; set; } = null!;
        public virtual List<Tag> Tags { get; set; } = null!;

        // join models
        public virtual List<LibraryAlbum> LibraryAlbums { get; set; } = null!;
        public virtual List<LibrarySubscriber> LibrarySubscribers { get; set; } = null!;

    }
}
