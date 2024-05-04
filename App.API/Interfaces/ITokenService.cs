using App.API.Entites;

namespace App.API.Interfaces
{
    public interface ITokenService
    {

        string CreateToken(AppUser user);


    }

}
