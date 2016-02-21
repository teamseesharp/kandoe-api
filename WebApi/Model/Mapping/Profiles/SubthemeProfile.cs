﻿using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class SubthemeProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Subtheme, SubthemeDto>();
            this.CreateMap<SubthemeDto, Subtheme>();
        }
    }
}