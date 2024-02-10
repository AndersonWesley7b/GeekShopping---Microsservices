using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Model;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}
