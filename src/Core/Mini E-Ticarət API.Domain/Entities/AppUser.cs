using Microsoft.AspNetCore.Identity;

namespace Mini_E_Ticarət_API.Domain.Entities;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Product> Products { get; set; }
    public ICollection<Favourite> Favourites { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
