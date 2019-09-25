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
    public class BrandController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BrandController(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _dataContext.Brands.ToList();
            var brandsDto = _mapper.Map<IEnumerable<GetBrandsDto>>(brands);
            return Ok(brandsDto);
        }
        [HttpPost]
        public IActionResult CreateBrand(BrandDto brand)
        {
            var toBeInsertedBrand = _mapper.Map<Brand>(brand);
                _dataContext.Brands.Add(toBeInsertedBrand);
            _dataContext.SaveChanges();
            return Ok(brand);

        }
    }
}