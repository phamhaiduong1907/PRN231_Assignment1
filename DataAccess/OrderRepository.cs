using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        Ass1Context _context;
        public OrderRepository() 
        {
            _context = new Ass1Context();
        }

        public async Task CreateOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Can not create order");
            }
        }

        public async Task DeleteOrder(int id)
        {
            try
            {
                Order order = await _context.Orders.FindAsync(id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Can not find order!");
                }
            }
            catch 
            {
                throw new Exception("Can not delete order!");
            }
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                Order orderToUpdate = await _context.Orders.FindAsync(order.OrderId);
                if(orderToUpdate != null)
                {
                    orderToUpdate.Freight = order.Freight;
                    orderToUpdate.ShippedDate = order.ShippedDate;
                    _context.Orders.Update(orderToUpdate);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Can not find order!");
                }
            }
            catch
            {
                throw new Exception("Can not update order!");
            }
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.Include(o => o.Member).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByMemberId(int memberId)
        {
            return await _context.Orders.Include(o => o.Member).Where(o => o.MemberId == memberId).AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            List<OrderDetail> orderDetails = await _context.OrderDetails.Where(od => od.OrderId == orderId).Include(od => od.Product).AsNoTracking().ToListAsync();
            Order order = await _context.Orders.Include(o => o.Member).Where(o => o.OrderId ==  orderId).AsNoTracking().FirstOrDefaultAsync();
            if(order != null)
            {
                order.OrderDetails = orderDetails;
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersWithDetail(DateTime? startDate, DateTime? endDate)
        {
            List<Order> orders = await _context.Orders.Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .Include( o => o.Member)
                .Where(o => o.ShippedDate.HasValue)
                .AsNoTracking()
                .ToListAsync();
            if(startDate != null && endDate != null)
            {
                orders = orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
            }
            return orders;
        }

        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetail od = await _context.OrderDetails.Where(o => o.OrderId == orderDetail.OrderId && o.ProductId == orderDetail.ProductId).FirstOrDefaultAsync();
            if(od != null)
            {
                od.Quantity = orderDetail.Quantity;
                od.Discount = orderDetail.Discount;
                _context.OrderDetails.Update(od);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can not update order detail");
            }
        }

        public async Task DeleteOrderDetail(int orderId, int productId)
        {
            OrderDetail od = await _context.OrderDetails.Where(o => o.OrderId == orderId && o.ProductId == productId).FirstOrDefaultAsync();
            if (od != null)
            {
                _context.OrderDetails.Remove(od);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can not delete order detail");
            }
        }
    }
}
