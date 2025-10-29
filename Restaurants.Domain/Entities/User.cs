﻿
using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities;

public class User : IdentityUser
{
    public DateTime DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}
