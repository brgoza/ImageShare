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

        public List<Image> Images { get; set; } = null!;
        public List<Collection> Collections { get; set; } = null!;
        public List<AppUser> Subscribers { get; set; } = null!;
        public List<AlbumSubscriber> AlbumSubscribers { get; set; } = null!;
        public List<Tag> Tags { get; set; } = null!;
    }
}
