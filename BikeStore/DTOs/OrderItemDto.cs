using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.DTOs
{
    public class OrderItemDto
    {
        public string ProductName { get; set; }
        public int SalesOrderId { get; set; }
        public int Quantity { get; set; }
        public int ListPrice { get; set; }
        public int Discount { get; set; }
    }
}
