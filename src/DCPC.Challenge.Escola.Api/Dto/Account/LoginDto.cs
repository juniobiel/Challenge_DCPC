using System.ComponentModel.DataAnnotations;

namespace DCPC.Challenge.Escola.Api.Dto.Account;

public class LoginDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
