using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public Task DeleteOrderDetail(int orderId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
