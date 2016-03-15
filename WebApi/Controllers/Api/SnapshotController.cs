using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Filters.Authorization;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api
{
    public class SnapshotController : ApiController
    {
        [Authenticate]
        [System.Web.Mvc.RoutePrefix("api/snapshots")]
        public class SubthemeController : ApiController
        {
            private readonly IService<Snapshot> snapshots;

            public SubthemeController()
            {
                this.snapshots = new SnapshotService();
            }

            [System.Web.Mvc.Route("")]
            public IHttpActionResult Get()
            {
                IEnumerable<Snapshot> entities = this.snapshots.Get();
                IEnumerable<SnapshotDto> dtos = ModelMapper.Map<IEnumerable<Snapshot>, IEnumerable<SnapshotDto>>(entities);
                return Ok(dtos);
            }

            [System.Web.Mvc.Route("{id}")]
            public IHttpActionResult Get(int id)
            {
                Snapshot entity = this.snapshots.Get(id);
                SnapshotDto dto = ModelMapper.Map<SnapshotDto>(entity);
                return Ok(dto);
            }

            [SnapshotAuthorize]
            [System.Web.Mvc.Route("")]
            public IHttpActionResult Post([FromBody]SnapshotDto dto)
            {
                Snapshot entity = ModelMapper.Map<Snapshot>(dto);
                this.snapshots.Add(entity);
                dto = ModelMapper.Map<SnapshotDto>(entity);
                return Ok(dto);
            }

            [SnapshotAuthorize]
            [System.Web.Mvc.Route("")]
            public IHttpActionResult Put([FromBody]SnapshotDto dto)
            {
                Snapshot entity = ModelMapper.Map<Snapshot>(dto);
                this.snapshots.Change(entity);
                return Ok();
            }

            [System.Web.Mvc.Route("{id}")]
            public IHttpActionResult Delete(int id)
            {
                throw new NotSupportedException();
            }

            [Route("by-session/{id}")]
            [HttpGet]
            public IHttpActionResult GetBySsession(int id)
            {
                IEnumerable<Snapshot> entities = this.snapshots.Get(Snapshot => Snapshot.SessionId == id);
                IEnumerable<SnapshotDto> dtos = ModelMapper.Map<IEnumerable<Snapshot>, IEnumerable<SnapshotDto>>(entities);
                return Ok(dtos);
            }
        }
    }
}