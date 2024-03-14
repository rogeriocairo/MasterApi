using MasterApi.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Stocks.Infra.Data.Context;

public class DataContext : DbContext
{
    public DbSet<RotaEntity> Rotas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // connect to sql server with connection string from app settings             
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Rotas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }    

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
