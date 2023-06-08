using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DatabaseFacade? Database { get; }

    DbSet<Country> Countries { get; }
    DbSet<User> Users { get; }

    DbSet<PhoneNumber> PhoneNumbers { get; }








    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
