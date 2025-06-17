using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thumanya.DataAccessLayer.DatabaseEntities;

namespace Thumanya.DataAccessLayer.DatabaseConfigurations
{
    public class ChannelTypeConfiguration : IEntityTypeConfiguration<ChannelType>
    {
        public void Configure(EntityTypeBuilder<ChannelType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Seed data
            builder.HasData(
                new ChannelType { Id = 1, Name = "Podcast" },
                new ChannelType { Id = 2, Name = "Video" }
            );
        }
    }
}
