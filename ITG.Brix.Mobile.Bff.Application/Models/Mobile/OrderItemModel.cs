using System;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public string CreatedOn { get; set; }
        public List<OrderItemPropsModel> Props { get; set; }
    }
}
