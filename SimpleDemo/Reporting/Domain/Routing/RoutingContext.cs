using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Domain.Routing
{
    public class RoutingContext : DbContext
    {
        public DbSet<Wip> Wip { get; set; }
        public DbSet<WipProcessStepHistory> WipProcessStepHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WipMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class WipMap : EntityTypeConfiguration<Wip>
    {
        public WipMap()
        {
            this.HasKey(o => o.Id);
        }
    }

    public class WipProcessStepHistoryMap : EntityTypeConfiguration<WipProcessStepHistory>
    {
        public WipProcessStepHistoryMap()
        {
            this.HasKey(o => o.Id);

            this.HasRequired(o => o.Wip)
                .WithMany(o => o.History);
        }
    }
}
