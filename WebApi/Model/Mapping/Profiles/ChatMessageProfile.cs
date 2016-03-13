using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Profiles {
    public class ChatMessageProfile : Profile {
        protected override void Configure() {
            this.CreateMap<ChatMessage, ChatMessageDto>();

            this.CreateMap<ChatMessageDto, ChatMessage>()
                .ConstructUsing(
                    dto => new ChatMessage(
                        dto.MessengerId,
                        dto.SessionId,
                        dto.Text,
                        dto.Timestamp
                    ));
        }
    }
}