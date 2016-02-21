using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping {
    public class SessionProfile : Profile {
        protected override void Configure() {
            this.CreateMap<Session, SessionDto>();
            this.CreateMap<SessionDto, Session>();
        }
    }
}