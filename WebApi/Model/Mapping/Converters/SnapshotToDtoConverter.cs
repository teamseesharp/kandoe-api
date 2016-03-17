using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Converters {
    public class SnapshotToDtoConverter : ITypeConverter<Snapshot, SnapshotDto> {
        public SnapshotDto Convert(ResolutionContext context) {
            Snapshot snapshot = (Snapshot) context.SourceValue;

            ICollection<int> organisers = snapshot.Organisers.Split(';').Select(Int32.Parse).ToList();
            ICollection<int> participants = snapshot.Participants.Split(';').Select(Int32.Parse).ToList();

            // sort chatmessages by timestamp
            ICollection<ChatMessageDto> chatmessageDtos = ModelMapper.Map<ICollection<ChatMessage>, ICollection<ChatMessageDto>>(snapshot.ChatMessages).OrderBy(cm => cm.Timestamp).ToList();

            return new SnapshotDto {
                Id = snapshot.Id,
                ChatMessages = chatmessageDtos,
                Organisers = organisers,
                Participants = participants,
                SessionCards = ModelMapper.Map<ICollection<SessionCard>, ICollection<CardDto>>(snapshot.SessionCards),
                SessionId = snapshot.SessionId
            };
        }
    }
}