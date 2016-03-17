using System;
using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Converters {
    public class DtoToSnapshotConverter : ITypeConverter<SnapshotDto, Snapshot> {
        public Snapshot Convert(ResolutionContext context) {
            SnapshotDto dto = (SnapshotDto) context.SourceValue;

            string organisers = String.Join(";", dto.Organisers);
            string participants = String.Join(";", dto.Participants);

            return new Snapshot(dto.SessionId, organisers, participants) {
                Id = dto.Id,
                ChatMessages = ModelMapper.Map<ICollection<ChatMessageDto>, ICollection<ChatMessage>>(dto.ChatMessages),
                SessionCards = ModelMapper.Map<ICollection<CardDto>, ICollection<SessionCard>>(dto.SessionCards),
            };
        }
    }
}