using BikeStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.DTOs
{
    public class SalesOrderDto
    {
        public int Id { get; set; }
        public int  CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int WarehouseId { get; set; }

    }
}
