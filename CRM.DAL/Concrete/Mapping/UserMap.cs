using CRM.DAL.Concrete.Mapping.Base;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Concrete.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(q => q.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(q=>q.LastName).IsRequired().HasMaxLength(100);
            builder.Property(q=>q.Username).IsRequired().HasMaxLength(50);
            builder.Property(q=>q.Password).IsRequired().HasMaxLength(100);
            builder.Property(q=>q.Email).IsRequired().HasMaxLength(100);

            builder.HasOne(q => q.Group)
                .WithMany(q => q.Users)
                .HasForeignKey(q=>q.GroupID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
