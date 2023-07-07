using System;
using System.Collections.Generic;

namespace Ass1Client.Model.Order
{
    public class OrderCreateDTO
    {
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public virtual ICollection<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}
