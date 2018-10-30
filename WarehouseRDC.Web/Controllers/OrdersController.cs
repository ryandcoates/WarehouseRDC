using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseRDC.Business;
using WarehouseRDC.Entities.Entities;

namespace WarehouseRDC.Web.Controllers
{
    [Route("[controller]")]
    [Controller]
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
        [HttpGet("Details/{id}")]
        public IActionResult Details(string id)
        {
            var outView = _ordersService.GetOrderByID(id);
            return View(outView);
        }

        [HttpPost("Create")]
        public IActionResult Create(Order o)
        {
            if (ModelState.IsValid)
            {
                Order _o = _ordersService.CreateOrder(o);
                return RedirectToAction(nameof(GetAllOrders));
            }
            return RedirectToAction("GetOpenOrders");
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FullfillOrder([FromForm]string id)
        {
            _ordersService.FullfillOrder(id);
            var outView = _ordersService.GetAllOpenOrders().ToList();

            if (outView.Count > 0)
            {
                return RedirectToAction("GetOpenOrders");
            }
            else
            {
                return RedirectToAction("GetAllOrders");
            }
        }
    }
}
