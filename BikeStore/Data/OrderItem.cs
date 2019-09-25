using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Data
{
    public class OrderItem
    {
        public SalesOrder SalesOrder { get; set; }
        public Product Product { get; set; }
        public int SalesOrderId { get; set; }        
        public int ProductId { get; set; }
        public int Quantity { get; set; }        
        public int Discount { get; set; }
    }
}
