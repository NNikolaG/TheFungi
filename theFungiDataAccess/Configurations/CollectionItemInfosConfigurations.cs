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
    internal class CollectionItemInfosConfigurations : IEntityTypeConfiguration<CollectionItemInfos>
    {
        public void Configure(EntityTypeBuilder<CollectionItemInfos> builder)
        {
            
        }
    }
}
