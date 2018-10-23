using System;
using WarehouseRDC.Entities.Entities;
using System.Data;
using System.Collections.Generic;
using WarehouseRDC.Entities;
using Dapper;

namespace WarehouseRDC.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IDbConnection _db;

        public Order CreateOrder(Order data)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Name = data.Name,
                IsFullfilled = false

            };
            var successful = _db.ExecuteAsync(@"
                INSERT INTO orders 
                (id, name, isfullfilled)
                VALUES (@Id, @Name, @IsFullfilled);
            ", newOrder);

            if (successful.Result == 1)
            {
                return newOrder;
            }
            return null;
        }

        public Order GetOrderById(int id)
        {
            return _db.QuerySingle<Order>("SELECT * FROM orders WHERE id = {0};", id);   
        }

        public IEnumerable<Order> GetOrders()
        {
            return _db.Query<Order>("SELECT * FROM orders;");
        }

        public IEnumerable<Order> GetOrdersByProductId(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetUnProcessedOrders()
        {
            return _db.Query<Order>("SELECT * FROM orders WHERE isfullfilled = false;");
        }

        public void UpdateOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            return _db.Query<Order>("SELECT * FROM orders WHERE isfullfilled = true;");
        }
    }
}
