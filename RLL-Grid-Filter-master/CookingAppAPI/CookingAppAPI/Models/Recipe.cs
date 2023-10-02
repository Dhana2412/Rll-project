using System;
using System.Collections.Generic;

namespace CookingAppAPI.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Ingredients { get; set; }

    public string? Category { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public string? ImageUrl { get; set; }
}
