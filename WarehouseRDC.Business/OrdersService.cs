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

        public void FullfillOrder()
        {

        }
    }

}
