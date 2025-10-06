using DCPC.Challenge.Escola.Api.Models.Identity;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces;

public interface ITokenService
{
    string CreateToken( AppUser user );
}
