using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Properties.model;

namespace WebApplication9.Properties.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerRegister, Customer>();
            CreateMap<AdminRegister, Admin>();
            CreateMap<ProductDetails, Product>();
            CreateMap<catDetails, Category>();

        }
    }
}
