using AutoMapper;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

using Kandoe.Web.Model.Mapping.Converters;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class SnapshotProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Snapshot, SnapshotDto>()
                .ConvertUsing<SnapshotToDtoConverter>();

            this.CreateMap<SnapshotDto, Snapshot>()
                .ConvertUsing<DtoToSnapshotConverter>();
        }
    }
}