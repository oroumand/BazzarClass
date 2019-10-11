using Bazzar.Core.Domain.Advertisements.Entities;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazzar.Infrastructures.Data.SqlServer.Advertisments
{
    public class AdvertismentConfig : IEntityTypeConfiguration<Advertisment>
    {
        public void Configure(EntityTypeBuilder<Advertisment> builder)
        {
            builder.Property(c => c.Price).HasConversion(c => c.Value.Value, d => Price.FromLong(d));
            builder.Property(c => c.OwnerId).HasConversion(c => c.Value.ToString(), d => UserId.FromString(d));
            builder.Property(c => c.ApprovedBy).HasConversion(c => c.Value.ToString(), d => UserId.FromString(d));
            builder.Property(c => c.Text).HasConversion(c => c.Value, d => AdvertismentText.FromString(d));
            builder.Property(c => c.Title).HasConversion(c => c.Value, d => AdvertismentTitle.FromString(d));
        }
    }
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(c => c.Location).HasConversion(c => c.Url, d => PictureUrl.FromString(d));
            builder.OwnsOne(c => c.Size);
        }
    }
}
