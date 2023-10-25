using Microsoft.EntityFrameworkCore;

namespace Task2;

public class AppDbContext : DbContext
{
    public DbSet<Human> Humans { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DataBase.db");
    }
}