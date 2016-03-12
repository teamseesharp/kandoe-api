using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Filters.Authorization
{
    public class SessionAuthorizeAttribute: ActionFilterAttribute{
        private readonly IService<Account> accounts;
        private readonly IService<Subtheme> subthemes;

        public SessionAuthorizeAttribute()
        {
            this.accounts = new AccountService();
            this.subthemes = new SubthemeService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            SessionDto dto = (SessionDto)actionContext.ActionArguments["dto"];

            Subtheme subtheme = this.subthemes.Get(dto.SubthemeId);

            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account organiser = this.accounts.Get(subtheme.OrganiserId);

            Account organisers = ModelMapper.Map<Account>(dto.Organisers);


            ///BLEEEHHHH
            // in case the session organiserId does not correspond with organiser id
           // if (!dto.Organisers.Contains(organisers.Id))
           // {
           //    throw new ArgumentException();
           // }

            // in case the issuer is not the organiser of the subtheme
            if (organiser.Secret != secret)
            {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}