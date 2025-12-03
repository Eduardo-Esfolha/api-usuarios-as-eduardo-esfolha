using ApiUser.domain.Entities;

namespace ApiUser.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=meuBanco.db");
        
        // ou UseSqlServer / UseNpgsql dependendo do seu banco
    }
}
