using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Models;
using EpedimiologyReport.Services.Models;

namespace DAL
{
    public class AutoMapperProfile : AutoMapper.Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Location, Locations>();
            CreateMap<Locations, Location>();

            CreateMap<EpedimiologyReport.Services.Models.Patient, DAL.Models.Patient>();
            CreateMap<DAL.Models.Patient, EpedimiologyReport.Services.Models.Patient>();

        }
    }
}
