using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
}