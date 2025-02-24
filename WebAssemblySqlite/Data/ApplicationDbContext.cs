using Microsoft.EntityFrameworkCore;

namespace WebAssemblySqlite.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var dbInitializer = new DbInitializer(modelBuilder);
        dbInitializer.Seed();
    }
}
