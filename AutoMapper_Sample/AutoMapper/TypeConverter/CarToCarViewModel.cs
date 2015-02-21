using AutoMapper;
using AutoMapper_Sample.Context;
using AutoMapper_Sample.Models;
using AutoMapper_Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.AutoMapper.TypeConverter
{
    public class CarToCarViewModel : TypeConverter<Car, CarViewModel>
    {
        public CarToCarViewModel(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public CarToCarViewModel()
        { }

        private ApplicationDbContext Context { get; set; }
        protected override CarViewModel ConvertCore(Car source)
        {
            return new CarViewModel();
            // use this.Context to lookup whatever you need
            //return CreateCatVM(source, this.Context.Categories);
        }
    }
}