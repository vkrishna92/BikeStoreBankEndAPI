using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Data;
using BikeStore.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerOrderController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[HttpPost]
        //public void CreateCustomerOrder(CustomerOrderDto customerOrder)
        //{
        //    var salesOrderDto = _mapper.Map<SalesOrderDto>(customerOrder);
        //    //var orderitemDto = _mapper.Map<OrderItemDto>(customerOrder);
        //    var salesordercanges = CreateSalesOrder(salesOrderDto);
        //  //  var orderitemChanges = CreateOrderItem(orderitemDto);
                        
        //}

        public int CreateSalesOrder(SalesOrderDto salesOrder)
        {
            var salesOrderMapped = _mapper.Map<SalesOrder>(salesOrder);
            _context.SalesOrders.Add(salesOrderMapped);
            var changes = _context.SaveChanges();            
            return changes;
        }
      
        //public int CreateOrderItem(OrderItemDto orderItem)
        //{
        //    var orderItemTobeCreated = _mapper.Map<OrderItem>(orderItem);
        //    _context.OrderItems.Add(orderItemTobeCreated);
        //    var changes = _context.SaveChanges();
        //    return changes;
        //}

    }
}