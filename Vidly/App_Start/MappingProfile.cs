using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile //Must inherit from Profile
    {
        public MappingProfile()
        {
            //Customers
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            //Movies
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
        }
    }
}