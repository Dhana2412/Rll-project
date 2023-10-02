namespace CookingAppMVC.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Ingredients { get; set; } = null!;

        public string Category { get; set; } = null!;

        public DateTime SubmissionDate { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
