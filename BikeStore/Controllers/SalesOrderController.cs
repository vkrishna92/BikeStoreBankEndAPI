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
    public class SalesOrderController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SalesOrderController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var salesOrders= _context.SalesOrders.Include(w=>w.Warehouse).Include(c=>c.Customer).ToList();
            var salesOrderDtoList = _mapper.Map<IEnumerable<GetSalesOrderDto>>(salesOrders);
            return Ok(salesOrderDtoList);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var salesOrder = _context.SalesOrders.Include(w => w.Warehouse).Include(c => c.Customer).FirstOrDefault(x => x.Id == id);
            var salesOrderDto = _mapper.Map<GetSalesOrderDto>(salesOrder);
            return Ok(salesOrderDto);
        }
        [HttpPost]
        public IActionResult CreateSalesOrder(SalesOrderDto salesOrderDto)
        {

            //var salesOrderMapped = _mapper.Map<SalesOrder>(salesOrder);
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.Customer = _context.Customers.FirstOrDefault(x => x.Id == salesOrderDto.CustomerId);
            salesOrder.Warehouse = _context.Warehouses.FirstOrDefault(x => x.Id == salesOrderDto.WarehouseId);
            salesOrder.OrderDate = salesOrderDto.OrderDate;
            salesOrder.OrderStatus = salesOrderDto.OrderStatus;
            salesOrder.ShippedDate = salesOrderDto.ShippedDate;

            _context.SalesOrders.Add(salesOrder);
            _context.SaveChanges();
            return Ok(salesOrder.Id);
        }

        
    }
}