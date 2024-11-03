using CRM.DAL.Concrete.Mapping.Base;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.DAL.Concrete.Mapping
{
    public class GroupMap : BaseMap<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");
            builder.Property(q => q.Name).IsRequired().HasMaxLength(200);
        }
    }
}
