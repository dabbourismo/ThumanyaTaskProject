using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thumanya.DataAccessLayer.DatabaseEntities;

namespace Thumanya.DataAccessLayer.DatabaseConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            // Required fields
            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.PublishDate)
                .IsRequired();

            // Optional fields with max lengths
            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Thumbnail)
                .HasMaxLength(500);

            builder.Property(e => e.Cover)
                .HasMaxLength(500);

            builder.Property(e => e.AudioUrl)
                .HasMaxLength(500);

            builder.Property(e => e.VideoUrl)
                .HasMaxLength(500);

            builder.Property(e => e.SponsoredBy)
                .HasMaxLength(200);

            // Content as TEXT type for long content
            builder.Property(e => e.Content)
                .HasColumnType("TEXT");

            // Default value
            builder.Property(e => e.IsPaidContent)
                .HasDefaultValue(false);

            // Duration conversion for SQLite
            builder.Property(e => e.Duration);

            // Relationships
            builder.HasOne(e => e.Auther)
                 .WithMany()
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Channel)
                .WithMany()
                .HasForeignKey(e => e.ChannelId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(e => e.Auther)
            // .WithMany()
            // .HasForeignKey(e => e.AuthorId)
            // .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(e => e.AuthorId);
            builder.HasIndex(e => e.ChannelId);
            builder.HasIndex(e => e.PublishDate);
            builder.HasIndex(e => e.IsPaidContent);
            builder.HasIndex(e => new { e.ChannelId, e.PublishDate });
        }
    }
}
