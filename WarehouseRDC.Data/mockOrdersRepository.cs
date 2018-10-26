using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WarehouseRDC.Entities;
using WarehouseRDC.Entities.Entities;

namespace WarehouseRDC.Data
{
    public class mockOrdersRepository : IOrdersRepository
    {
        private readonly IDbConnection _db;

        public Order CreateOrder(Order data)
        {
            var newOrder = new Order
            {
                Id = mockOrderDB.NextId,
                Name = data.Name,
                IsFullfilled = false

            };
            var successful = true;

            if (successful)
            {
                return newOrder;
            }
            return null;
        }

        public Order GetOrderById(string id)
        {
            return mockOrderDB.Orders.Find(o => o.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return mockOrderDB.Orders;
        }

        public IEnumerable<Order> GetOrdersByProductId(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetUnProcessedOrders()
        {
            return mockOrderDB.Orders.Where(o => o.IsFullfilled == false);
        }

        public void UpdateOrder(Order o)
        {
            var b = GetOrderById(o.Id);
            b.Name = o.Name;
            b.IsFullfilled = o.IsFullfilled;
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            return mockOrderDB.Orders.Where(o => o.IsFullfilled == true);
        }
    }
    class mockOrderDB
    {
        public static string NextId = "7";
        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = "1",
                Name = "First Order!",
                IsFullfilled = false
            },

            new Order()
            {
                Id = "2",
                Name = "Bought more stuff",
                IsFullfilled = false
            },

            new Order()
            {
                Id = "3",
                Name = "Bought domr more stuff",
                IsFullfilled = false
            },

            new Order()
            {
                Id = "4",
                Name = "Bought more stuff and shipped!",
                IsFullfilled = true
            },

            new Order()
            {
                Id = "5",
                Name = "shipped more stuff",
                IsFullfilled = true
            },

            new Order()
            {
                Id = "6",
                Name = "Bought even more stuff",
                IsFullfilled = true
            },

        };

    }
}
