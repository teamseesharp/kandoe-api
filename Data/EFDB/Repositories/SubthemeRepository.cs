using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class SubthemeRepository : Repository<Subtheme> {
        public SubthemeRepository() : base(new Context()) { }

        public override void Create(Subtheme entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Subtheme> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override Subtheme Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(Subtheme entity) {
            throw new NotImplementedException();
        }
    }
}
