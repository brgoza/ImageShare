using System.ComponentModel.DataAnnotations;
using ImageShare.Core.Models;

namespace ImageShare.Core
{
    public class Image : ITaggable
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(256)]
        public string Title { get; set; } = null!;

        [Required, StringLength(512)]
        public string Url { get; set; } = null!;

        [Required, StringLength(256)]
        public string BlobName { get; set; } = null!;

        [StringLength(2048)]
        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public virtual AppUser Owner { get; set; } = null!;
        public Guid OwnerId { get; set; }
        public virtual List<Library> Libraries { get; set; } = null!;
        public virtual List<Album> Albums { get; set; } = null!;
        public virtual List<Tag> Tags { get; set; } = null!;
    }
}