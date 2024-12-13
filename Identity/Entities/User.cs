
using Microsoft.AspNetCore.Identity;
namespace Identity.Entities;

public class User:IdentityUser
{
    public string Country { get; set; }
    public string City { get; set; }

    public bool IsSubscribed { get; set; } = false;
}
