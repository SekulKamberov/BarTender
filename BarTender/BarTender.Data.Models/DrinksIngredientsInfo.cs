namespace BarTender.Data.Models
{
    public class DrinksIngredientsInfo
    {
        public int Id { get; set; }

        public string DrinkId { get; set; }

        public Drink Drink { get; set; }

        public int IngredientsInfoId { get; set; }

        public IngredientsInfo IngredientsInfo { get; set; }
    }
}
