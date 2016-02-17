using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class ChatMessageRepository : Repository<ChatMessage> {
        public ChatMessageRepository() : base(new Context()) { }

        public override void Create(ChatMessage entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<ChatMessage> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override ChatMessage Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(ChatMessage entity) {
            throw new NotImplementedException();
        }
    }
}
