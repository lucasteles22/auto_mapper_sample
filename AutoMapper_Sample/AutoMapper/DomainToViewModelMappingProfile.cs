using AutoMapper;
using AutoMapper_Sample.AutoMapper.TypeConverter;
using AutoMapper_Sample.Models;
using AutoMapper_Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<News, NewsViewModel>();
            Mapper.CreateMap<Comment, CommentViewModel>();
            Mapper.CreateMap<Color, ColorViewModel>();
            Mapper.CreateMap<Car, CarViewModel>().ConvertUsing<CarToCarViewModel>();
        }
    }
}