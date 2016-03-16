using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kandoe.Business.Domain;

namespace Kandoe.Web.Model.Dto{
    public class SnapshotDto {
        public int Id { get; set; }
        public int SessionId { get; set; }

        public ICollection<int> Participants { get; set; }
        public ICollection<int> Organisers { get; set; }

        public ICollection<CardDto> SessionCards { get; set; }
        public ICollection<ChatMessageDto> ChatMessages { get; set; }
    }
}