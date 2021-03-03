namespace BarTender.Data.Models
{
    public class UsersLikes
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string DrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}
