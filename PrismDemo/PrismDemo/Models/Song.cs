using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.Models
{
    public partial class Song
    {
        [Column(IsIdentity = true)]
        public int Id { get; set; }
        public DateTime? Create_time { get; set; }
        public bool? Is_deleted { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
    public partial class Song_tag
    {
        public int Song_id { get; set; }
        public virtual Song Song { get; set; }

        public int Tag_id { get; set; }
        public virtual Tag Tag { get; set; }
    }
    public partial class Tag
    {
        [Column(IsIdentity = true)]
        public int Id { get; set; }
        public int? Parent_id { get; set; }
        public virtual Tag Parent { get; set; }

        public decimal? Ddd { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
