using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieApp.Dtos;
using MovieApp.Models;

namespace MovieApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain To Dto
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            // Dto To Domain
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}