using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class SubthemeProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Subtheme, SubthemeDto>();

            this.CreateMap<SubthemeDto, Subtheme>()
                .ConstructUsing(
                    dto => new Subtheme(
                        dto.Name,
                        dto.OrganiserId,
                        dto.ThemeId
                    ));
        }
    }
}