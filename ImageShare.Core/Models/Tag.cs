using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
