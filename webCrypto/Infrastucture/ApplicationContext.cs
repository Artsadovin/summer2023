using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastucture;
internal class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<Crypto> Cryptos => Set<Crypto>();
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=postgres;Port=2007;User Id=postgres;Password=1q2w3e4r5t");
        optionsBuilder.LogTo( Console.WriteLine, new[] { RelationalEventId.CommandExecuted } );
    }

    public void Commit()
    {
        SaveChanges();
    }
}
