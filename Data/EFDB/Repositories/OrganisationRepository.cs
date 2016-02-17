using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class OrganisationRepository : Repository<Organisation> {
        public OrganisationRepository() : base(new Context()) { }

        public override void Create(Organisation entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Organisation> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override Organisation Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(Organisation entity) {
            throw new NotImplementedException();
        }
    }
}
