using System;
using System.Collections.Generic;
using System.Text;
using WarehouseRDC.Entities.Entities;

namespace WarehouseRDC.Data
{
    class mockOrdersRepository
    {
        public static int NextId = 7;
        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                Name = "First Order!",
                IsFullfilled = false
            },

            new Order()
            {
                Id = 2,
                Name = "Bought more stuff",
                IsFullfilled = false
            },

            new Order()
            {
                Id = 3,
                Name = "Bought domr more stuff",
                IsFullfilled = false
            },

            new Order()
            {
                Id = 4,
                Name = "Bought more stuff and shipped!",
                IsFullfilled = true
            },

            new Order()
            {
                Id = 5,
                Name = "shipped more stuff",
                IsFullfilled = true
            },

            new Order()
            {
                Id = 6,
                Name = "Bought even more stuff",
                IsFullfilled = true
            },

        }

    }
}
