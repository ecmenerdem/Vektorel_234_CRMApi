using CRM.DAL.Concrete.Mapping.Base;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.DAL.Concrete.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(q => q.Name).IsRequired().HasMaxLength(200);

            //builder.HasMany(q=>q.Products)
            //    .WithOne(q=>q.Category)
            //    .HasForeignKey(q=>q.CategoryID)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
