using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Security;

public class ClaimsFactory : UserClaimsPrincipalFactory<User, IdentityRole>
{
    public ClaimsFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
    }

    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);

        id.AddClaim(new Claim("app:userDateOfBirth", user.DateOfBirth.ToString("yyyy-MM-dd")));

        if (user.Nationality is not null)
        {
            id.AddClaim(new Claim("app:userNationality", user.Nationality));
        }

        return new ClaimsPrincipal(id);
    }
}
