using System;
using System.Collections.Generic;
using System.Web.Http;

using Authenticate = System.Web.Http.AuthorizeAttribute;

using Kandoe.Business;
using Kandoe.Business.Domain;
using Kandoe.Web.Filters.Authorization;
using Kandoe.Web.Model.Dto;
using Kandoe.Web.Model.Mapping;

namespace Kandoe.Web.Controllers.Api {
    [Authenticate]
    [RoutePrefix("api/snapshots")]
    public class SnapshotController : ApiController {
        private readonly IService<Snapshot> snapshots;

        public SnapshotController() {
            this.snapshots = new SnapshotService();
        }

        [Route("")]
        public IHttpActionResult Get() {
            IEnumerable<Snapshot> entities = this.snapshots.Get();
            IEnumerable<SnapshotDto> dtos = ModelMapper.Map<IEnumerable<Snapshot>, IEnumerable<SnapshotDto>>(entities);
            return Ok(dtos);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            Snapshot entity = this.snapshots.Get(id);
            SnapshotDto dto = ModelMapper.Map<SnapshotDto>(entity);
            return Ok(dto);
        }

        [AuthorizeOrganiser]
        [Route("")]
        public IHttpActionResult Post([FromBody]SnapshotDto dto) {
            Snapshot entity = ModelMapper.Map<Snapshot>(dto);
            this.snapshots.Add(entity);
            dto = ModelMapper.Map<SnapshotDto>(entity);
            return Ok(dto);
        }

        [Route("")]
        public IHttpActionResult Put([FromBody]SnapshotDto dto) {
            throw new NotSupportedException();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            throw new NotSupportedException();
        }

        [Route("by-session/{id}")]
        [HttpGet]
        public IHttpActionResult GetBySsession(int id) {
            IEnumerable<Snapshot> entities = this.snapshots.Get(Snapshot => Snapshot.SessionId == id);
            IEnumerable<SnapshotDto> dtos = ModelMapper.Map<IEnumerable<Snapshot>, IEnumerable<SnapshotDto>>(entities);
            return Ok(dtos);
        }
    }
}
