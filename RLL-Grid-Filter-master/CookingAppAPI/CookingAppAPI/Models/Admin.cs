using System;
using System.Collections.Generic;

namespace CookingAppAPI.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Adminname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
