using System.Linq;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Actions {
    public class SortChatMessagesByDatetime : IMappingAction<Session, SessionDto> {
        public void Process(Session source, SessionDto destination) {
            destination.ChatMessages = destination.ChatMessages.OrderBy(cm => cm.Timestamp).ToList();
        }
    }
}