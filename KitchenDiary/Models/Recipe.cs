namespace KitchenDiary.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PrepTime { get; set; }      // Hazırlık süresi (dk)
        public int CookTime { get; set; }      // Pişirme süresi (dk)
        public int Servings { get; set; }      // Kaç kişilik
        public double Rating { get; set; }     // Puan (0-5)
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
        public List<RecipeStep> Steps { get; set; } = new();
    }
}
