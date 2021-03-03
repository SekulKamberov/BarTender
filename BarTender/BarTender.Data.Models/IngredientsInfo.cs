namespace BarTender.Data.Models
{
    using BarTender.Data.Common;
    using System.Collections.Generic;

    public class IngredientsInfo : BaseModel<int>
    {
        public string Name { get; set; }

        public ICollection<DrinksIngredients> Drinks { get; set; }
    }
}

