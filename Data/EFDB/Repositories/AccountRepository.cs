using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class AccountRepository : Repository<Account> {
        public AccountRepository() : base(new Context()) { }

        public override void Create(Account entity) {
            this.context
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Account> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override Account Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(Account entity) {
            throw new NotImplementedException();
        }
    }
}
