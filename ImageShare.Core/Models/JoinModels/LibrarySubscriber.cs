using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core.Models
{
    public class LibrarySubscriber
    {
        public LibrarySubscriber() { }
        public LibrarySubscriber(AppUser subscriber, Library library, bool isAdmin, bool isOwner)
            => (Subscriber, Library, IsAdmin, IsOwner) = (subscriber, library, isAdmin, isOwner);

        public virtual AppUser Subscriber { get; set; } = null!;
        public Guid SubscriberId { get; set; }
        public virtual Library Library { get; set; } = null!;
        public Guid LibraryId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
