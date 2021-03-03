using BarTender.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTender.Data.Models
{
    public class Ingredient : BaseModel<int>
    {
        public string Name { get; set; }

        public ICollection<DrinksIngredients> Drinks { get; set; }
    }
}
