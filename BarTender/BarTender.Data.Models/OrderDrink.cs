namespace BarTender.Data.Models
{
    using Common;

    public class OrderDrink : BaseModel<int>
    {
        public string DrinkId { get; set; }

        public Drink Drink { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
