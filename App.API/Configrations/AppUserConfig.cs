//using App.API.Entites;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace App.API.Configrations
//{
//    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
//    {
//        public void Configure(EntityTypeBuilder<AppUser> builder)
//        {
//            builder.HasMany(A => A.Photos)
//                    .WithOne(P => P.AppUser)
//                    .HasForeignKey(p => p.AppUserId);

//        }
//    }
//}
