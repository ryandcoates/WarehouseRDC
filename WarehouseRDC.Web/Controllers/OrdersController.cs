using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseRDC.Business;
 
namespace WarehouseRDC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private OrdersService _ordersService;
        public OrdersController(OrdersService orderService)
        {
            _ordersService = orderService;
        }

        [HttpGet()]
        public IActionResult GetAllOrders()
        {
            var outView = _ordersService.GetAllOrders();
            return View(outView);
        }

        [HttpGet("open")]
        public IActionResult GetOpenOrders()
        {
            var outView = _ordersService.GetAllOpenOrders();
            return View(outView);
        }


        public IActionResult FullfillOrder()
        {
            return View();
        }
    }
}
