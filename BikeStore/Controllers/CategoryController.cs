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
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            var returnCategories = _mapper.Map<IEnumerable<GetCategoryDto>>(categories);
            return Ok(returnCategories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id==id);
            var returnCatg = _mapper.Map<GetCategoryDto>(category);
            return Ok(returnCatg);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryDto category)
        {
            var tobeCreatedCatg = _mapper.Map<Category>(category);
            _context.Categories.Add(tobeCreatedCatg);
            _context.SaveChanges();
            return Ok(category);
            
        }
    }
}