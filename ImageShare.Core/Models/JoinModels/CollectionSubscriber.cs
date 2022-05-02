using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core.Models
{
    public class CollectionSubscriber
    {
        public AppUser Subscriber { get; set; } = null!;
        public Guid SubscriberId { get; set; }
        public Collection Collection { get; set; } = null!;
        public Guid CollectionId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
