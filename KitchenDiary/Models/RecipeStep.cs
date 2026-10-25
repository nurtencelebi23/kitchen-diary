namespace KitchenDiary.Models
{
    public class RecipeStep
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }                // 1, 2, 3...
        public string Text { get; set; } = string.Empty;   // "Soğanı kavurun."

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}