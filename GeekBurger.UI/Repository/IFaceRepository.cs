﻿using GeekBurger.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Repository
{
    public interface IFaceRepository
    {
        bool Add(FaceModel face);
        void Save();
    }
}
