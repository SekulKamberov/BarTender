namespace BarTender.Data.Models
{
    public class DrinksIngredients
    {
        public int Id { get; set; }

        public string DrinkId { get; set; }

        public Drink Drink { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

    }
}
