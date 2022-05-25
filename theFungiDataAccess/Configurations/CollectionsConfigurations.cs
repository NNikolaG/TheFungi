using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiDomain.Entities;

namespace theFungiDataAccess.Configurations
{

    public class CollectionsConfigurations : IEntityTypeConfiguration<Collections>
    {
        public void Configure(EntityTypeBuilder<Collections> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.HasIndex(x => x.Title).IsUnique();

            builder.HasMany(x => x.CollectionItems).WithOne(x => x.Collection).HasForeignKey(x => x.CollectionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CollectionFollowers).WithOne(x => x.Collection).HasForeignKey(x => x.CollectionId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
