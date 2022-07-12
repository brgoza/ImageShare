using System.ComponentModel.DataAnnotations;

namespace ImageShare.Core
{
    public class Tag
    {
        public Tag() { }
        public Tag(string text) { TagText = text; }

        [Key, StringLength(255)]
        public string TagText { get; set; } = null!;
        public virtual List<Image> Images { get; set; } = null!;
        public virtual List<Album> Albums { get; set; } = null!;
        public virtual List<Library> Libraries { get; set; } = null!;
    }
}
