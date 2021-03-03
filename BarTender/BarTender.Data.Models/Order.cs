namespace BarTender.Data.Models
{
    using System;
    using BarTender.Data.Common;
    using BarTender.Data.Models.Enums;
    using System.Collections.Generic;

    public class Order : BaseModel<string>
    {
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<OrderDrink> Drinks { get; set; }
    }
}
