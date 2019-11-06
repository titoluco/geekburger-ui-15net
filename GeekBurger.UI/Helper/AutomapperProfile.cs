using AutoMapper;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.GeekBurguer.Users.Contract;

namespace GeekBurger.UI.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<FaceToUpsert, FaceModel>();
            CreateMap<FaceModel, FaceToUpsert>();

            CreateMap<FoodRestrictions, FoodRestrictionsToUpsert>();
            CreateMap<FoodRestrictionsToUpsert, FoodRestrictions>();

            //CreateMap<EntityEntry<FaceModel>, FaceChangedMessage>()
            //.ForMember(dest => dest.Face, opt => opt.MapFrom(src => src.Entity));
            //CreateMap<EntityEntry<FaceModel>, ShowDisplayEvent>()
            //.ForMember(dest => dest.Face, opt => opt.MapFrom(src => src.Entity));
        }
    }
}
