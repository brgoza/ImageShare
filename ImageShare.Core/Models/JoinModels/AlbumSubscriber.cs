using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core.Models
{
    public class AlbumSubscriber
    {
        public virtual AppUser Subscriber { get; set; } = null!;
        public Guid SubscriberId { get; set; }
        public virtual Album Album { get; set; } = null!;
        public Guid AlbumId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
