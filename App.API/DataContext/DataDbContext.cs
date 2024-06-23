using App.API.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml;

namespace App.API.DataContext
{
    public class DataDbContext : DbContext
    {

        public DataDbContext( DbContextOptions<DataDbContext> option ):base(option)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<AppUser>()
            //.Property(e => e.DateOfBirth)
            //.HasConversion(
            //    v => v.ToDateTime(TimeOnly.MinValue),
            //    v => DateOnly.FromDateTime(v));


         // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    public DbSet<AppUser> Users { get; set; }
        //public DbSet<Photo> Photos { get; set; }
                                                 
    }
}
