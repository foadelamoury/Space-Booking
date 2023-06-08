using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }






        public DbSet<Country> Countries => Set<Country>();





        public DbSet<User> Users => Set<User>();

        public DbSet<PhoneNumber> PhoneNumbers => Set<PhoneNumber>();



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {

            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("DatabaseConnection");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
