using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ModelYear { get; set; }
        public int ListPrice { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
