using System;
using System.Collections.Generic;

namespace WarehouseRDC.Entities
{
    public interface IOrdersRepository
    {
        Order GetOrderById(int id);
        void UpdateOrder(Order o);
        Order CreateOrder(Order data);
        IEnumerable<Order> GetUnProcessedOrders();
        IEnumerable<Order> GetOrdersByProductId(int productId);
    }





}
