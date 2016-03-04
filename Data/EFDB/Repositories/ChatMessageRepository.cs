﻿using System.Collections.Generic;
using System.Linq;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class ChatMessageRepository : Repository<ChatMessage> {
        public ChatMessageRepository() : base(new Context()) { }

        public override void Create(ChatMessage entity) {
            this.context.ChatMessages.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<ChatMessage> Read(bool eager = false) {
            return this.context.ChatMessages.AsEnumerable();
        }

        public override ChatMessage Read(int id, bool eager = false) {
            return this.context.ChatMessages.Find(id);
        }

        public override void Update(ChatMessage entity) {
            this.context.ChatMessages.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.ChatMessages.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
