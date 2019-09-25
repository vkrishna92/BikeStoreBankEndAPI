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
    public class WarehouseController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WarehouseController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllWarehouses()
        {
            var wareshouses = _context.Warehouses.ToList();
            var returnList= _mapper.Map<IEnumerable<WarehouseDto>>(wareshouses);

            return Ok(returnList);
        }

        [HttpPost]
        public IActionResult CreateWareHouse(WarehouseDto warehouseDto)
        {
            var warehouse= _mapper.Map<Warehouse>(warehouseDto);
            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);
        }
    }
}