using App.API.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace App.API.DataContext
{
    public  class DbContextSeeding
    {
       public static async Task DatabseSeedingData(DataDbContext context , ILoggerFactory loggerFactory)
        {

            try
            {
                if (!context.Users.Any())
                {
                    var userDataText = File.ReadAllText("./DataSeeding/UserSeedData.json");
                    var userData = JsonSerializer.Deserialize<List<AppUser>>(userDataText);

                    if (userData?.Count() > 0)
                    {
                        foreach (var user in userData)
                        {
                           using var hmac =  new HMACSHA512();
                            user.UserName = user.UserName.ToLower();
                            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                            user.Passwordsalt = hmac.Key;
                            
                            await context.Users.AddAsync(user);
                        }
                        await context.SaveChangesAsync();
                    }

                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DbContextSeeding>();
                logger.LogError(ex, ex.Message);
            }

        }

    }
}
