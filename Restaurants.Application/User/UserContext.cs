﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Restaurants.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContext) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContext?.HttpContext?.User;

        if (user is null)
        {
            throw new InvalidOperationException("User Context is not present");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

        /*USER CONTEXT SU AN PROJE GEREGI BUYUTULMEMISTIR. GEREKLI DURUMLARDA GEREKLI CLAIMLER EKLENEBILIR.*/
        return new CurrentUser(userId, email, roles);
    }
}
