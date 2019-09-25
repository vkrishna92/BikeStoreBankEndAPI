using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ModelYear { get; set; }
        public int ListPrice { get; set; }        
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
    }
}
