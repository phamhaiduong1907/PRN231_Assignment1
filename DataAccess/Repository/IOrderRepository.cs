﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByMemberId(int memberId);
        Task<Order> GetOrderById(int orderId);
        Task<IEnumerable<Order>> GetOrdersWithDetail(DateTime? startDate, DateTime? endDate);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
        Task UpdateOrderDetail(OrderDetail orderDetail);
        Task DeleteOrderDetail(int orderId, int productId);
    }
}
