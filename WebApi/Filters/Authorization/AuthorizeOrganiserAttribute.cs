using System;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Filters.Authorization {
    public class AuthorizeOrganiserAttribute :  ActionFilterAttribute {
        private readonly IService<Account> accounts;

        public AuthorizeOrganiserAttribute() {
            this.accounts = new AccountService();
        }

        public override void OnActionExecuting(HttpActionContext actionContext) {
            OrganisedDto dto;

            string controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            switch (controller) {
                case "Organisation":
                    OrganisationDto organisationDto = (OrganisationDto) actionContext.ActionArguments["dto"];
                    dto = ModelMapper.Map<OrganisedDto>(organisationDto);
                    break;
                case "Subtheme":
                    SubthemeDto subthemeDto = (SubthemeDto) actionContext.ActionArguments["dto"];
                    dto = ModelMapper.Map<OrganisedDto>(subthemeDto);
                    break;
                case "Theme":
                    ThemeDto themeDto = (ThemeDto) actionContext.ActionArguments["dto"];
                    dto = ModelMapper.Map<OrganisedDto>(themeDto);
                    break;
                default:    // to prevent the dto from being null
                    dto = new OrganisedDto { OrganiserId = -1 };
                    break;
            }

            // issuer secret
            string secret = Thread.CurrentPrincipal.Identity.Name;
            // organiser secret
            Account organiser = this.accounts.Get(dto.OrganiserId);

            // if account does not exist
            if (organiser == null) {
                throw new UnauthorizedAccessException();
            }

            // unauthorized action if issuer != organiser
            if (organiser.Secret != secret) {
                throw new UnauthorizedAccessException();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}