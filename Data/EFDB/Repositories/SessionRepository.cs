using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class SessionRepository : Repository<Session> {
        public SessionRepository() : base(new  Context()) { }

        public override void Create(Session entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Session> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override Session Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(Session entity) {
            throw new NotImplementedException();
        }
    }
}
