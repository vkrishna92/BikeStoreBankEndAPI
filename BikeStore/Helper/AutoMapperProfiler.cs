using AutoMapper;
using BikeStore.Data;
using BikeStore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Helper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Product, ProductDto>().
                ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id)).
                ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id));
            CreateMap<ProductDto, Product>().
                ForPath(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId)).
                ForPath(dest => dest.Brand.Id, opt => opt.MapFrom(src => src.BrandId));
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<SalesOrder, SalesOrderDto>().
                ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id)).
                ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Warehouse.Id));
            CreateMap<SalesOrderDto, SalesOrder>().
                ForPath(dest => dest.Customer.Id, opt => opt.MapFrom(src => src.CustomerId)).
                ForPath(dest => dest.Warehouse.Id, opt => opt.MapFrom(src => src.WarehouseId));
            //ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.ProductName));
            //CreateMap<SalesOrderDto, SalesOrder>().
            //    ForPath(dest => dest.Customer.FirstName, opt => opt.MapFrom(src => src.Customer)).
            //    ForPath(dest => dest.Warehouse.WarehouseName, opt => opt.MapFrom(src => src.Warehouse));
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Brand, GetBrandsDto>();
            CreateMap<BrandDto, Brand>();
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<WarehouseDto, Warehouse>();
            CreateMap<OrderItem, GetOrderItemDto>().
                 ForMember(dest => dest.SalesOrderId, opt => opt.MapFrom(src => src.SalesOrderId)).
                 ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<SalesOrder, GetSalesOrderDto>().
                ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName)).
                ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName));

            CreateMap<OrderItem, OrderItemDto>().
                ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));


        }


    }
}
