using Microsoft.AspNetCore.Identity;

namespace InventoryShared.Models;

public class ApplicationUser : IdentityUser
{
    // Optional: add extra fields as needed
    public string? FullName { get; set; }
}
