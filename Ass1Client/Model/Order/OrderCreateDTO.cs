using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1Client.Model.Order
{
    public class OrderCreateDTO
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public double? Freight { get; set; }
        public virtual ICollection<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}
