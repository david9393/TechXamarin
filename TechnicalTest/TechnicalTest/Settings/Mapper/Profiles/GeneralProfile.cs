using AutoMapper;
using CommonShared.DTO.Tips;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.ViewModels.Domain;

namespace TechnicalTest.Settings.Mapper.Profiles
{
   public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TipModel,TipViewModel>().
            ReverseMap();

        }
     
    }
}
