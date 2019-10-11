using Bazzar.Core.Domain.Shared.ValueObjects;
using Bazzar.Core.Domain.UserProfiles.Entities;
using Bazzar.Core.Domain.UserProfiles.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Infrastructures.Data.SqlServer.UserProfiles
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(c => c.FirstName).HasConversion(c => c.Value, d => FirstName.FromString(d));
            builder.Property(c => c.LastName).HasConversion(c => c.Value, d => LastName.FromString(d));
            builder.Property(c => c.DisplayName).HasConversion(c => c.Value, d => DisplayName.FromString(d));
            builder.Property(c => c.Email).HasConversion(c => c.Value, d => Email.FromString(d));

        }
    }
}
