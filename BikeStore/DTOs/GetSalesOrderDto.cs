using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.DTOs
{
    public class GetSalesOrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string WarehouseName { get; set; }
    }
}
