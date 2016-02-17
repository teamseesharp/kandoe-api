﻿using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class SessionService : Service<Session> {
        public SessionService() : base(new SessionRepository()) { }
    }
}
