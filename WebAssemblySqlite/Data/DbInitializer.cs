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
            new Product { Id = 1, Name = "Apple", Price = 10, Description = "Fresh and crisp red apples, rich in fiber and vitamins", ImageUrl = "https://images.unsplash.com/photo-1568702846914-96b305d2aaeb" },
            new Product { Id = 2, Name = "Banana", Price = 20, Description = "Yellow bananas, high in potassium and energy-boosting", ImageUrl = "https://images.unsplash.com/photo-1587132137056-bfbf0166836e" },
            new Product { Id = 3, Name = "Orange", Price = 30, Description = "Juicy citrus oranges packed with vitamin C", ImageUrl = "https://www.quanta.org/orange/orange.jpg" },
            new Product { Id = 4, Name = "Grapes", Price = 40, Description = "Sweet seedless grapes, perfect for snacking", ImageUrl = "https://images.unsplash.com/photo-1537640538966-79f369143f8f" },
            new Product { Id = 5, Name = "Strawberry", Price = 50, Description = "Sweet and juicy red strawberries, perfect for desserts", ImageUrl = "https://images.unsplash.com/photo-1587393855524-087f83d95bc9" },
            new Product { Id = 6, Name = "Pineapple", Price = 60, Description = "Tropical pineapple with sweet and tangy flavor", ImageUrl = "https://images.unsplash.com/photo-1550258987-190a2d41a8ba" },
            new Product { Id = 7, Name = "Watermelon", Price = 70, Description = "Refreshing watermelon with high water content", ImageUrl = "https://i5.walmartimages.com/seo/Fresh-Seedless-Watermelon-Each_e2ec527d-fe7b-4309-9373-186de34557cf.1c562d1a69a2a8f4cb7b5de8f125fc76.jpeg" },
            new Product { Id = 8, Name = "Mango", Price = 80, Description = "King of fruits, sweet and creamy tropical mango", ImageUrl = "https://www.heddensofwoodtown.co.uk/wp-content/uploads/2020/07/Mango_opt.jpg" },
            new Product { Id = 9, Name = "Kiwi", Price = 90, Description = "Vitamin-rich kiwi with unique green flesh", ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2020/02/Kiwi-fruits-582a07b.jpg" },
            new Product { Id = 10, Name = "Peach", Price = 100, Description = "Soft fuzzy peaches with sweet aromatic flavor", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQItaiSlHW2h6-zlgngHxFl5yVaJhXeckvWsA&s" }
        );
    }
}
