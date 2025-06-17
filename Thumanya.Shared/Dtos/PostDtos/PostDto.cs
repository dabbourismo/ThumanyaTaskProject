using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thumanya.Shared.Dtos.PostDtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Cover { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool IsPaidContent { get; set; }
        public DateTime PublishDate { get; set; }
        public string SponsoredBy { get; set; }
        public int? Duration { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelUrl { get; set; }
    }

    public class PostCreateDto
    {
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 500 characters")]
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
        public DateTime? PublishDate { get; set; }
        [MaxLength(200)]
        public string SponsoredBy { get; set; }
        public int? Duration { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int ChannelId { get; set; }
    }


    public class PostUpdateDto
    {
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
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int ChannelId { get; set; }
    }

    public class PostSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public bool IsPaidContent { get; set; }
        public DateTime PublishDate { get; set; }
        public int? Duration { get; set; }
        public string AuthorName { get; set; }
        public string ChannelName { get; set; }
    }
}
