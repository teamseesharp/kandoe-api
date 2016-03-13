using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class OrganisationProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Organisation, OrganisationDto>();

            this.CreateMap<OrganisationDto, Organisation>()
                .ConstructUsing(
                    dto => new Organisation(
                        dto.Name,
                        dto.OrganiserId
                    ));
        }
    }
}