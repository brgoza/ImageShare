using ImageShare.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core
{
    public class Collection : ITaggable
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public List<Image> Images { get; set; } = null!;
        public List<Album> Albums { get; set; } = null!;
        public List<AppUser> Subscribers { get; set; } = null!;
        public List<CollectionSubscriber> CollectionSubscribers { get; set; } = null!;
        public List<Tag> Tags { get; set; } = null!;
    }
}
