namespace BarTender.Data.Models
{
    using BarTender.Data.Common;
    using System.Collections.Generic;

    public class Drink : BaseModel<string>
    {
        public string Name { get; set; }

        public string RecipeBy { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public string Image { get; set; }

        public ICollection<DrinksIngredients> Ingredients { get; set; }

        public ICollection<DrinksIngredientsInfo> IngredientsInfo { get; set; }

        public ICollection<UsersLikes> Likes { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
