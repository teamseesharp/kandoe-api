using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class SelectionCardProfile : Profile {
         protected override void Configure() {
            this.CreateMap<SelectionCard, CardDto>();

            this.CreateMap<CardDto, SelectionCard>()
                .ConstructUsing(
                    dto => new SelectionCard(
                        dto.Image,
                        dto.Text,
                        dto.ThemeId,
                        dto.SubthemeId
                    ));
        }
    }
}