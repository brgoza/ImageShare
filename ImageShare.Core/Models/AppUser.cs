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
        public AppUser() { }
        public AppUser(string email) { UserName = email; Email = email; }

        public virtual List<Image> Images { get; set; } = null!;
        public virtual List<Album> SubscribedAlbums { get; set; } = null!;
        public virtual List<Library> SubscribedLibraries { get; set; } = null!;
        
        // join models
        public virtual List<AlbumSubscriber> AlbumSubscribers { get; set; } = null!;
        public virtual List<LibrarySubscriber> LibrarySubscribers { get; set; } = null!;
   
    }
}
