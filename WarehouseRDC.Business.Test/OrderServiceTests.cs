using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WarehouseRDC.Entities;
using WarehouseRDC.Entities.Entities;

namespace WarehouseRDC.Business.Test
{

    [TestClass]
    public class OrderServiceTests
    {
        //Follow the 80/20 rule
        [TestMethod]
        void UnresolvedFillOrdersCanBeRetrieved()
        {
            //arrange
            var order = new Order
            {
                Id = "1",
                Name = "test",
                IsFullfilled = false
            };
            var mockOrderRepo = Substitute.For<IOrdersRepository>();
            mockOrderRepo.GetUnProcessedOrders().Returns(order);

            var orderService = new OrdersService(mockOrderRepo);

            //act
            try
            {
                IEnumerable<Order>expectedOrders = orderService.GetAllOpenOrders();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Ticket Already Closed", ex.Message);
                return;
            }
            //assert
            Assert.Fail("");
        }

        [TestMethod]
        void UnresolvedFillOrderCanBeProcessed()
        {

        }

        [TestMethod]
        void ProcessedFillOrderCannontBeModified()
        {
            var order = new Order
            {
                Id = "1",
                Name = "test",
                IsFullfilled = false
            };
            var mockOrderRepo = Substitute.For<IOrdersRepository>();
            mockOrderRepo.GetUnProcessedOrders().Returns(order);

        }
    }
}