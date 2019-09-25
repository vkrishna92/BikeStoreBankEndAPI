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
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customer)
        {
            var custToCreate = _mapper.Map<Customer>(customer);
            _context.Add(custToCreate);
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            var custReturnList = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(custReturnList);

        }
        [HttpGet("{id}")]
        public IActionResult GetCustomers(int id)
        {
            var customers = _context.Customers.FirstOrDefault(c => c.Id == id);
            var custReturn = _mapper.Map<CustomerDto>(customers);
            return Ok(custReturn);

        }
    }
}