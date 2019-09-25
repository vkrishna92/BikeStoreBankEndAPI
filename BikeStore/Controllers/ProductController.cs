using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Data;
using BikeStore.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> productsList = _context.Products.Include(c=>c.Category).Include(b=>b.Brand).ToList();
            List<GetProductsList> productDtoList = new List<GetProductsList>();
            foreach(Product product in productsList)
            {
                GetProductsList prodDto = new GetProductsList();
                prodDto.Id = product.Id;
                prodDto.ProductName = product.ProductName;
                prodDto.ModelYear = product.ModelYear;
                prodDto.ListPrice = product.ListPrice;
                prodDto.Category = _context.Categories.FirstOrDefault(x => x.Id == product.Category.Id).CategoryName;
                prodDto.Brand = _context.Brands.FirstOrDefault(x => x.Id == product.Brand.Id).BrandName;
                productDtoList.Add(prodDto);
            }

            return Ok(productDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
             var product = _context.Products.Include(c => c.Category).Include(b=>b.Brand).FirstOrDefault(p => p.Id == id);
            var productToReturn = _mapper.Map<ProductDto>(product);
            return Ok(productToReturn);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto product)
        {
            var catId = _context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);
            var brandId = _context.Brands.FirstOrDefault(b => b.Id == product.BrandId);
            Product p = new Product();
            p.ProductName = product.ProductName;
            p.ModelYear = product.ModelYear;
            p.ListPrice = product.ListPrice;
            p.Category =catId ;
            p.Brand = brandId ;
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok(product);
        }

        //[HttpPost]
        public IActionResult CreateProductV2(ProductDto productDto)
        {
            var toBeInserted = _mapper.Map<Product>(productDto);
            _context.Add(toBeInserted);
            _context.SaveChanges();
            return Ok(productDto);
        }
    }
}