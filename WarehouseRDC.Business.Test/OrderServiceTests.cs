using System;
using System.Collections.Generic;
using System.Linq;
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
        public void UnresolvedFillOrdersCanBeRetrieved()
        {
            //arrange
            var order = new List<Order>
            {
                new Order
                {
                    Id = "1",
                    Name = "test",
                    IsFullfilled = false
                },
                new Order
                {
                    Id = "2",
                    Name = "test2",
                    IsFullfilled = false
                }
                   
            };

            var mockOrderRepo = Substitute.For<IOrdersRepository>();
            mockOrderRepo.GetUnProcessedOrders().Returns(order);

            var orderService = new OrdersService(mockOrderRepo);

            //act

            List<Order>expectedOrders = orderService.GetAllOpenOrders().ToList();

            
            //assert
            Assert.AreEqual("1", expectedOrders[0].Id);
            Assert.AreEqual(2, expectedOrders.Count);
            Assert.AreEqual(false, expectedOrders[0].IsFullfilled);
            //return;
        }

        [TestMethod]
        public void UnresolvedFillOrderCanBeProcessed()
        {
            //arrange
            var orders = new List<Order>
            {
                new Order
                {
                    Id = "1",
                    Name = "test",
                    IsFullfilled = false
                },
                new Order
                {
                    Id = "2",
                    Name = "test2",
                    IsFullfilled = false
                }

            };

            var mockOrderRepo = Substitute.For<IOrdersRepository>();
            mockOrderRepo.GetUnProcessedOrders().Returns(orders.ToList());
            mockOrderRepo.GetOrderById(orders[0].Id).Returns(orders[0]);
            var orderService = new OrdersService(mockOrderRepo);

            //act


            orderService.FullfillOrder("1");
            var expectedOrders = orderService.GetAllOpenOrders().ToList();


            //assert
            Assert.AreEqual(true, expectedOrders[0].IsFullfilled);
            Assert.AreEqual(false, expectedOrders[1].IsFullfilled);

        }

        [TestMethod]
        public void ProcessedFillOrderCannontBeModified()
        {
            var order = new List<Order>
            {
                new Order
                {
                    Id = "1",
                    Name = "test",
                    IsFullfilled = true
                },
                new Order
                {
                    Id = "2",
                    Name = "test2",
                    IsFullfilled = true
                }
            };

            var mockOrderRepo = Substitute.For<IOrdersRepository>();
            mockOrderRepo.GetUnProcessedOrders().Returns(order);
            mockOrderRepo.GetOrderById("1").Returns(order[0]);
            OrdersService orderService = new OrdersService(mockOrderRepo);

            try
            {

               List<Order> expectedOrders = orderService.GetAllOpenOrders().ToList();

               orderService.FullfillOrder("1");

            }

            catch (Exception e)
            {
                Assert.AreEqual("Order already fullfilled", e.Message);
                return;
            }
        }
    }
}