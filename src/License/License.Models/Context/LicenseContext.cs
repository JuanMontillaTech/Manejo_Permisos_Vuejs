using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace License.Models.Context
{
     public  class LicenseContext : DbContext
    {
        public LicenseContext(DbContextOptions<LicenseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Licenses>(mbl =>
            {
                mbl.HasOne(x => x.LicenseType).WithMany(x => x.License).HasForeignKey(x => x.LicenseTypeID);
            });

        }
        #region AuditAndIdCompletions


        public override int SaveChanges()
        {
            CompleteFields();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            CompleteFields();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            CompleteFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CompleteFields();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void CompleteFields()
        {
            foreach (EntityEntry e in ChangeTracker.Entries())
            {

                if (e.Entity is BaseModel baseModel)
                {

                    if (e.State == EntityState.Added)
                    {

                        baseModel.CreatedDate = DateTime.UtcNow;
                    }

                    baseModel.LastModifiedDate = DateTime.UtcNow;
                }

            }
        }
        #endregion
        public DbSet<Licenses> Licenses { get; set; }
        public DbSet<LicenseType>  LicenseType { get; set; }
    }
}
