using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IService<Account> service;

        public AccountController() {
            this.service = new AccountService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Account> entities = this.service.Get();
            IEnumerable<AccountDto> dtos = ModelMapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Account entity = this.service.Get(id);
            AccountDto dto = ModelMapper.Map<AccountDto>(entity);
            return Ok(dto);
        }

        [AllowAnonymous]
        [Route("")]
        public IHttpActionResult Post([FromBody]AccountDto dto) {
            Account entity = ModelMapper.Map<Account>(dto);
            this.service.Add(entity);
            dto = ModelMapper.Map<AccountDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]AccountDto dto) {
            Account entity = ModelMapper.Map<Account>(dto);
            this.service.Change(entity);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-auth0-user-id/{id}")]
        [HttpGet]
        public IHttpActionResult GetByAuth0UserId(string id) {
            IEnumerable<Account> entities = this.service.Get(a => a.Secret == id);
            AccountDto dto = ModelMapper.Map<AccountDto>(entities.First());
            return Ok(dto);
        }
    }
}
