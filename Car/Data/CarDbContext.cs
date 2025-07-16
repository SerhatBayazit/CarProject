using Microsoft.EntityFrameworkCore;
using Car.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Bu satırı ekleyin!
using Microsoft.AspNetCore.Identity; // IdentityUser için ekleyin (ileride kullanılabilir)

namespace Car.Data
{
    
    public class CarDbContext : IdentityDbContext<IdentityUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }

        public DbSet<Car.Models.CarModel> Cars { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}