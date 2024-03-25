using Microsoft.EntityFrameworkCore;
using ShoeWebStore.Models.Models;

namespace ShoeWebStore.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }

}
