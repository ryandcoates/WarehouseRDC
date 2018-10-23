using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseRDC.Entities.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsFullfilled { get; set; }
    }
}
