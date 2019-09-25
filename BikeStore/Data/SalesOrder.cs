using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Data
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }                              
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Warehouse Warehouse { get; set; } 
        public List<OrderItem> OrderItems { get; set; }
    }
}
