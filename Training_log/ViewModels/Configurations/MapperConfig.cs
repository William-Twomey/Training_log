using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Training_log.Models;

namespace Training_log.ViewModels.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Bench, LiftsVM>().ReverseMap();
            CreateMap<Deadlift, LiftsVM>().ReverseMap();
            CreateMap<Squat, LiftsVM>().ReverseMap();
        }
    }
}