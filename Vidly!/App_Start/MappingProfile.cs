using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly_.Models;
using Vidly_.DTOS;

namespace Vidly_.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}