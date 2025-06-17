using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thumanya.DataAccessLayer.DatabaseEntities;

namespace Thumanya.DataAccessLayer.DatabaseConfigurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            // Configure foreign key relationship
            builder.HasOne(e => e.ChannelType)
                .WithMany()
                .HasForeignKey(e => e.ChannelTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Create index on foreign key for better performance
            builder.HasIndex(e => e.ChannelTypeId);
        }
    }
}
