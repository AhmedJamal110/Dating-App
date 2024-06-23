using App.API.Entites;

namespace App.API.Dtos
{
    public class AppUserDto
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        //public byte[] PasswordHash { get; set; }
        //public byte[] Passwordsalt { get; set; }

        public int Age { get; set; }
        public string KnownAs { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Created { get; set; } 
        public DateTime LastActive { get; set; }

        public string Gender { get; set; }
        public string Intodaction { get; set; }
        public string lookingFor { get; set; }
        public string Interested { get; set; }

        public string City { get; set; }
        public string Countery { get; set; }

        public List<PhotoDto> Photos { get; set; } 
    }
}
