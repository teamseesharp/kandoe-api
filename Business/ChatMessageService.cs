using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class ChatMessageService : Service<ChatMessage> {
        public ChatMessageService() : base(new ChatMessageRepository()) { }
    }
}
