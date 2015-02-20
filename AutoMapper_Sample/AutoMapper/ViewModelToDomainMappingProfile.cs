using AutoMapper;
using AutoMapper_Sample.Models;
using AutoMapper_Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<NewsViewModel, News>();
            Mapper.CreateMap<CommentViewModel, Comment>();
            Mapper.CreateMap<CarViewModel, Car>();
            Mapper.CreateMap<ColorViewModel, Color>();
        }
    }
}