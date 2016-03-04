using System;
using System.Collections.Generic;
using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;
using System.Linq;

namespace Kandoe.Data.EFDB.Repositories {
    public class AccountRepository : Repository<Account> {
        public AccountRepository() : base(new Context()) { }

        public override void Create(Account entity) {
            this.context.Accounts.Add(entity);
            this.context.SaveChanges();
        }

        public override IEnumerable<Account> Read(bool lazy = true) {
            return this.context.Accounts.AsEnumerable();
        }

        public override Account Read(int id, bool lazy = true) {
            return this.context.Accounts.Find(id);
        }

        public override void Update(Account entity) {
            this.context.Accounts.Attach(entity);
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }

        public override void Delete(int id) {
            this.context.Accounts.Remove(this.Read(id));
            this.context.SaveChanges();
        }
    }
}
