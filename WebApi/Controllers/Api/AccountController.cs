using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Filters.Authorization;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/accounts")]
    public class AccountController : ApiController {
        private readonly IService<Account> accounts;

        public AccountController() {
            this.accounts = new AccountService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Account> entities = this.accounts.Get();
            IEnumerable<AccountDto> dtos = ModelMapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Account entity = this.accounts.Get(id);
            AccountDto dto = ModelMapper.Map<AccountDto>(entity);
            return Ok(dto);
        }
        
        [Route("")]
        // validation of DTO very needed - geen bestaande id toelaten?
        public IHttpActionResult Post([FromBody]AccountDto dto) {
            IEnumerable<Account> accounts = this.accounts.Get(a => a.Secret == dto.Secret);
            bool exists = (accounts.Count() >= 1);

            if (exists) {
                return Ok(accounts.First());
            }

            Account entity = ModelMapper.Map<Account>(dto);
            this.accounts.Add(entity);
            dto = ModelMapper.Map<AccountDto>(entity);

            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]AccountDto dto) {
            throw new NotSupportedException();
        }

        [Route("")]
        // almost no validation needed? we only use non-harmful info of account
        public IHttpActionResult Patch([FromBody]AccountDto dto) {
            string secret = Thread.CurrentPrincipal.Identity.Name;
            Account entity = this.accounts.Get(a => a.Secret == secret).First();

            entity.Email = dto.Email ?? entity.Email;
            entity.Name = dto.Name ?? entity.Name;
            entity.Picture = dto.Picture ?? entity.Picture;
            entity.Surname = dto.Surname ?? entity.Surname;

            this.accounts.Change(entity);

            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-auth0-user-id/{id}")]
        [HttpGet]
        public IHttpActionResult GetByAuth0UserId(string id) {
            IEnumerable<Account> entities = this.accounts.Get(a => a.Secret == id);

            // if no accounts were found
            if (entities.Count() < 1) { return Ok(new AccountDto()); }

            AccountDto dto = ModelMapper.Map<AccountDto>(entities.First());
            return Ok(dto);
        }
    }
}
