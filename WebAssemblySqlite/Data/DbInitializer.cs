using Microsoft.EntityFrameworkCore;

namespace WebAssemblySqlite.Data;


public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
            new User { Id = 3, Name = "Michael Johnson", Email = "michael.j@example.com" },
            new User { Id = 4, Name = "Sarah Williams", Email = "sarah.w@example.com" },
            new User { Id = 5, Name = "Robert Brown", Email = "robert.b@example.com" },
            new User { Id = 6, Name = "Emily Davis", Email = "emily.d@example.com" },
            new User { Id = 7, Name = "David Wilson", Email = "david.w@example.com" }
        );

        _modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Apple", Price = 10 },
            new Product { Id = 2, Name = "Banana", Price = 20 },
            new Product { Id = 3, Name = "Orange", Price = 30 },
            new Product { Id = 4, Name = "Grapes", Price = 40 }
        );
    }
}
