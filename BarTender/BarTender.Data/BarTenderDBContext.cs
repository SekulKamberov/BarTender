namespace BarTender.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BarTenderDBContext : IdentityDbContext<User>
    {
        public BarTenderDBContext(DbContextOptions<BarTenderDBContext> options)
            : base(options) { }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientsInfo> IngredientsInfos { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
