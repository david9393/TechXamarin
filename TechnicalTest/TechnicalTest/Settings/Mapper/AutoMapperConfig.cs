using AutoMapper;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Settings.Mapper.Profiles;

namespace TechnicalTest.Settings.Mapper
{
    public static class AutoMapperConfig
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration((config) =>
            {
                config.AddProfile(new GeneralProfile());
            
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            containerRegistry.RegisterInstance(typeof(IMapper), mapper);
        }
    }
}
