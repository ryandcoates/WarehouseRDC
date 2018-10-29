using WarehouseRDC.Entities.Entities;
using System;
using WarehouseRDC.Entities;
using System.Collections.Generic;

namespace WarehouseRDC.Business
{
    public class OrdersService
    {
        private readonly IOrdersRepository _orderRepo;
        public OrdersService(IOrdersRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetOrders();
        }

        public IEnumerable<Order> GetAllOpenOrders()
        {
            return _orderRepo.GetUnProcessedOrders();
        }

        public IEnumerable<Order> GetAllFullfilledOrders()
        {
            return _orderRepo.GetProcessedOrders();
        }

        public void FullfillOrder(string id)
        {
            var o = _orderRepo.GetOrderById(id);

            if (!o.IsFullfilled)
            {
                o.IsFullfilled = true;
                _orderRepo.UpdateOrder(o);
            }
            else
            {
                Exception e = new Exception("Order already fullfilled");
                throw e;
            }
        }

        public Order GetOrderByID(string id)
        {
            return _orderRepo.GetOrderById(id);
        }
    }

}
