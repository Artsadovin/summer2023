using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Crypter;
internal class ApplicationContext : DbContext
{
    public DbSet<Crypto> Cryptos => Set<Crypto>();
    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        optionsBuilder.UseNpgsql( "Server=localhost;Database=postgres;Port=2007;User Id=postgres;Password=1q2w3e4r5t" );
        optionsBuilder.LogTo( Console.WriteLine, new[] { RelationalEventId.CommandExecuted } );
    }
}
