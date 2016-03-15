using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Profiles
{
    public class SnapshotProfile: Profile{
        protected override void Configure(){
            this.CreateMap<Snapshot, SnapshotDto>();

            this.CreateMap<SnapshotDto, Snapshot>()
                .ConstructUsing(
                    dto => new Snapshot(
                        dto.SessionId,
                        dto.Participants,
                        dto.Organisers
                    ));
        }
    }
}