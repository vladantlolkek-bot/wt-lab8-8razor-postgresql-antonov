using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_antonov.Models; // <-- Правильное имя твоего проекта!

namespace wt_lab5_5razor_antonov.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Обрати внимание: у тебя модель называется Car, а не Product!
    public DbSet<Car> Cars => Set<Car>();
}