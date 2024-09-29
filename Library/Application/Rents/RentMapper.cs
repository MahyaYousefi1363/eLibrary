using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eLibrary.Library.Application.Rents.Dtos;
using eLibrary.Library.Domain.Rents;

namespace eLibrary.Library.Application.Rents
{
    public class RentMapper:Profile
    {
        public RentMapper()
        {
            CreateMap<Rent,RentForCreateDto>();
        }
    }
}