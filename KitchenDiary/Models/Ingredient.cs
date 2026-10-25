namespace KitchenDiary.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;   // "1 adet soğan"

        public int RecipeId { get; set; }                  // hangi tarife ait
        public Recipe? Recipe { get; set; }
    }
}