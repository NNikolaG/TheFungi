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
    public class CollectionItemConfiguration : IEntityTypeConfiguration<CollectionItems>
    {
        public void Configure(EntityTypeBuilder<CollectionItems> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Image).IsRequired();

            builder.HasMany(x => x.CollectionItemInfos).WithOne(x => x.CollectionItem).HasForeignKey(x => x.CollectionItemId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
