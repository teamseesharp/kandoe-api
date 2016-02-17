using System;
using System.Collections.Generic;

using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Connection;

namespace Kandoe.Data.EFDB.Repositories {
    public class ThemeRepository : Repository<Theme> {
        public ThemeRepository() : base(new Context()) { }

        public override void Create(Theme entity) {
            throw new NotImplementedException();
        }

        public override void Delete(int id) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Theme> Read(bool lazy = true) {
            throw new NotImplementedException();
        }

        public override Theme Read(int id, bool lazy = true) {
            throw new NotImplementedException();
        }

        public override void Update(Theme entity) {
            throw new NotImplementedException();
        }
    }
}
