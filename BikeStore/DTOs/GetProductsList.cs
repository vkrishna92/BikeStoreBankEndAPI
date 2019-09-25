using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.DTOs
{
    public class GetProductsList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ModelYear { get; set; }
        public int ListPrice { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
