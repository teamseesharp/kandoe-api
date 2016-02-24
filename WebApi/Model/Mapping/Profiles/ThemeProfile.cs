using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class ThemeProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Theme, ThemeDto>();

            this.CreateMap<ThemeDto, Theme>()
                .ConstructUsing(
                    dto => new Theme(
                        dto.Description,
                        dto.Name,
                        dto.OrganisationId,
                        dto.Tags
                    ));
        }
    }
}