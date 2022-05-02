using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public List<Image> Images { get; set; } = null!;
        public List<Album> SubscribedAlbums { get; set; } = null!;
        public List<AlbumSubscriber> AlbumSubscribers { get; set; } = null!;
        public List<Collection> SubscribedCollections { get; set; } = null!;
        public  List<CollectionSubscriber> CollectionSubscribers { get; set; } = null!;
    }
}
