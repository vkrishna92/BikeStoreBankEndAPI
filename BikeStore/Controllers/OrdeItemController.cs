using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Data;
using BikeStore.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdeItemController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrdeItemController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOrderItems()
        {
            var orderItemList = _context.OrderItems.Include(c=>c.SalesOrder).Include(p=>p.Product).ToList();
            var retunList = _mapper.Map<IEnumerable<GetOrderItemDto>>(orderItemList);
            return Ok(retunList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderItems(int id)
        {
            var orderItems = _context.OrderItems.Include(c => c.SalesOrder).Include(p => p.Product).FirstOrDefault(x => x.SalesOrderId == id);
            var returnList = _mapper.Map<OrderItemDto>(orderItems);
            return Ok(returnList);
        }

        [HttpPost]
        public IActionResult CreateOrderItme(GetOrderItemDto orderDto)
        {
            OrderItem order = new OrderItem();
            order.SalesOrderId = orderDto.SalesOrderId;
            order.ProductId = orderDto.ProductId;
            order.Quantity = orderDto.Quantity;
            order.Discount = orderDto.Discount;

            _context.OrderItems.Add(order);
            _context.SaveChanges();
          
            return Ok(order.SalesOrderId + "," + order.ProductId);

        }

    }
}