using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        // contructor for entityframeworkcore (ctor tab tab)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // pass options to base class, which is DbContext
        {

        }

        // for whatever models you have to create inside db, you have to create db set 
        public DbSet<Category> Categories { get; set; } // creates table named Categories with 4 cols from Category model (Id, name, displayorder, createdatetime)
    }
}
