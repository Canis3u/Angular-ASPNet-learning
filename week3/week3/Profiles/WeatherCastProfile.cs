using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using week3.ServiceModels;
using week3.ViewModels;
using week3.Models;

namespace week3.Profiles
{
    public class WeatherCastProfile:Profile
    {
        public WeatherCastProfile()
        {
            // Call
            // controller -> service
            CreateMap<WeatherCastViewModel, WeatherCastServiceModel>();
            // service -> DB
            CreateMap<WeatherCastServiceModel, WeatherCast>()
                .ForMember(
                    member => member.TempF,
                    opt => opt.MapFrom(src => src.TempC * 9 / 5 + 32)
                )
                .ForMember(
                    member => member.IsDeleted,
                    opt => opt.MapFrom(src => 0)
                );
            // Return
            // DB -> service
            CreateMap<WeatherCast, WeatherCastRespServiceModel>();
            // service -> controller
            CreateMap<WeatherCastRespServiceModel, WeatherCastRespViewModel>();
        }
    }
}
