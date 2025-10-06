using Microsoft.AspNetCore.Identity;

namespace DCPC.Challenge.Escola.Api.Models.Identity;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
}
