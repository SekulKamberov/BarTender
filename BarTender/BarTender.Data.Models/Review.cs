namespace BarTender.Data.Models
{
    using System;
    using BarTender.Data.Common;
    
    public class Review : BaseModel<string>
    {
        public string Text { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string DrinkId { get; set; }

        public Drink Drink { get; set; }

        public DateTime LastModified { get; set; }
    }
}
