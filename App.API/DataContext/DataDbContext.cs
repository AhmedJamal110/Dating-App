using App.API.Entites;
using Microsoft.EntityFrameworkCore;

namespace App.API.DataContext
{
    public class DataDbContext : DbContext
    {

        public DataDbContext( DbContextOptions<DataDbContext> option ):base(option)
        {
            
        }


        public DbSet<AppUser> Users { get; set; }

    }
}
