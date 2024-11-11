using GraphQLMySQLQueryMutation.Domain.Vendedores.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GraphQLMySQLQueryMutation.Infrastructure.DBContexts;

public class AppDbContext : DbContext
{
    public DbSet<Vendedor> Vendedores { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    { }
}
