using CommonShared.Dependencies.EntityFrameworkCore;
using Domain.Services.Tip;
using Infrastructure.Repositories.Database.Tip;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Classes.EntityFrameworkCore;

namespace TechnicalTest.Settings
{
    public static class DependencyInjectionContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            ///Dependency
            containerRegistry.RegisterSingleton<IEntityFrameworkCoreDependency, EntityFrameworkCoreDependency>();
            ////Repositories             
            containerRegistry.RegisterSingleton<ITipRepository,TipRepository>();       
            ////Services
            containerRegistry.RegisterSingleton<ITipService,TipService>();
      
        }
    }
}
