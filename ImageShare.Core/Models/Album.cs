using ImageShare.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core
{
    public class Album : ITaggable
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(256)]
        public string Title { get; set; } = null!;

        [StringLength(2048)]
        public string? Description { get; set; }
        public DateTime Created { get; set; }

        public virtual List<Image> Images { get; set; } = null!;
        public virtual List<Library> Libraries { get; set; } = null!;
        public virtual List<AppUser> Subscribers { get; set; } = null!;
        public virtual List<Tag> Tags { get; set; } = null!;

        // join models
        public virtual List<AlbumSubscriber> AlbumSubscribers { get; set; } = null!;
        public virtual List<LibraryAlbum> LibraryAlbums { get; set; } = null!;

    }
}
