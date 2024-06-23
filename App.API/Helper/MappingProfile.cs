using App.API.Dtos;
using App.API.Entites;
using App.API.Extension;
using AutoMapper;

namespace App.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDto>()
                .ForMember(D => D.PhotoUrl, opt => opt.MapFrom(S => S.Photos.FirstOrDefault(F => F.IsMine).Url))
              .ForMember(D => D.Age, opt => opt.MapFrom(S => S.DateOfBirth.CalculateAge() ));
            CreateMap<Photo, PhotoDto>();
        }

    }
}
