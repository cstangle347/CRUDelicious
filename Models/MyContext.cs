using Microsoft.EntityFrameworkCore;

namespace Crud.Models
{
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<Dish> Dishs { get; set; }
    }
}