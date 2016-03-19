using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class SnapshotDto {
        public int SessionId { get; set; }

        public ICollection<AccountDto> Participants { get; set; }
        public ICollection<AccountDto> Organisers { get; set; }

        public ICollection<SessionCardDto> SessionCards { get; set; }
        public ICollection<ChatMessageDto> ChatMessages { get; set; }
    }
}