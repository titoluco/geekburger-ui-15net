using AutoMapper;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<FaceToUpsert, FaceModel>();
            CreateMap<FaceModel, FaceToUpsert>();
            CreateMap<FaceModel, FaceToUpsert>();
            CreateMap<FaceToUpsert, FaceModel>();
        }
    }
}
