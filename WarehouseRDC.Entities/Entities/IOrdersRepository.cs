using System;
using System.Collections.Generic;
using WarehouseRDC.Entities.Entities;

namespace WarehouseRDC.Entities
{
    public interface IOrdersRepository
    {
        Order GetOrderById(string id);
        void UpdateOrder(Order o);
        Order CreateOrder(Order data);
        IEnumerable<Order> GetUnProcessedOrders();
        IEnumerable<Order> GetProcessedOrders();
        IEnumerable<Order> GetOrdersByProductId(int productId);
        IEnumerable<Order> GetOrders();
    }





}
