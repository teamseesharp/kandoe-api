using System.Collections.Generic;

using AutoMapper;

using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;

namespace Kandoe.Web.Model.Mapping.Actions {
    public class FilterSessionCircularReferences : IMappingAction<Session, SessionDto> {
        public void Process(Session source, SessionDto destination) {
            // filter out many-to-many circular reference collections
            this.Filter(destination.Participants);

            // filter out many-to-many circular reference collections
            this.Filter(destination.Organisers);
        }

        private void Filter(ICollection<AccountDto> accounts) {
            foreach (AccountDto account in accounts) {
                account.OrganisedSessions = null;
                account.ParticipatingSessions = null;
            }
        }
    }
}