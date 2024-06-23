using App.API.Extension;


namespace App.API.Entites
{
    public class AppUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] Passwordsalt { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public string Gender { get; set; }
        public string Intodaction { get; set; }
        public string lookingFor { get; set; }
        public string Interested { get; set; }

        public string City { get; set; }
        public string Countery { get; set; }

        public List<Photo> Photos { get; set; } = new();

        //public int GetAge()
        //{
        //    return DateOfBirth.CalculateAge();
        //}

    }
}
