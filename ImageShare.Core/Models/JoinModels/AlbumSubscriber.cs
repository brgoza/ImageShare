namespace ImageShare.Core.Models
{
    public class AlbumSubscriber
    {
        public AlbumSubscriber(AppUser subscriber, Album album, bool isAdmin, bool isOwner)
            => (Subscriber, Album, IsAdmin, IsOwner) = (subscriber, album, isAdmin, isOwner);

        public virtual AppUser Subscriber { get; set; } = null!;
        public Guid SubscriberId { get; set; }
        public virtual Album Album { get; set; } = null!;
        public Guid AlbumId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
