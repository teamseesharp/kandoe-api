using Kandoe.Business.Domain;
using Kandoe.Data.EFDB.Repositories;

namespace Kandoe.Business {
    public class AccountService : Service<Account> {
        public AccountService() : base(new AccountRepository()) { }
    }
}
