using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class OrganisationProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Organisation, OrganisationDto>();
            this.CreateMap<OrganisationDto, Organisation>();
        }
    }
}