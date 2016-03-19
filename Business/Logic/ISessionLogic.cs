using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kandoe.Business.Domain;

namespace Kandoe.Business.Logic {
    public interface ISessionLogic {
        void Add(Session session, Account organiser);

        void End(int id);

        void Join(int accountId);

        void SelectCards(ICollection<SelectionCard> selection);
    }
}
