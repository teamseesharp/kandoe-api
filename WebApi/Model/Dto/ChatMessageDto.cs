﻿using System;

namespace Kandoe.Web.Model.Dto {
    public class ChatMessageDto {
        public int Id { get; set; }
        public int MessengerId { get; set; }
        public int SessionId { get; set; }
        public int? SnapshotId { get; set; }
        public String Text { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
