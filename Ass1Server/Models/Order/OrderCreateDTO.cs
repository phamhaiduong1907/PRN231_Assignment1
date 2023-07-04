using Ass1Server.Models.OrderDetail;

namespace Ass1Server.Models.Order
{
    public class OrderCreateDTO
    {
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public virtual ICollection<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}
