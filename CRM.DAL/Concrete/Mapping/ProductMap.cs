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
    public class ProductMap:BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q=>q.Name).IsRequired().HasMaxLength(1000);

            builder.HasOne(q=>q.Category)
                .WithMany(q=>q.Products)
                .HasForeignKey(q=>q.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
