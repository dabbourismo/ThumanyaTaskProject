using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thumanya.DataAccessLayer.DatabaseEntities
{
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }


        [MaxLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }


        [MaxLength(500)]
        public string Thumbnail { get; set; }

        [MaxLength(500)]
        public string Cover { get; set; }

        [MaxLength(500)]
        public string AudioUrl { get; set; }

        [MaxLength(500)]
        public string VideoUrl { get; set; }

        public bool IsPaidContent { get; set; }

        public DateTime PublishDate { get; set; }

        [MaxLength(200)]
        public string SponsoredBy { get; set; }

        public int? Duration { get; set; }

        // Navigation properties
        public int AuthorId { get; set; }
        public virtual Auther Auther { get; set; }
        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
    }
}
