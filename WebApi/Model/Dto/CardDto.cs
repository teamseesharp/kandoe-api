using System;
using System.Collections.Generic;

namespace Kandoe.Web.Model.Dto {
    public class CardDto {
        public int Id { get; set; }
        public String Image { get; set; }
        public int SessionId { get; set; }
        public int SessionLevel { get; set; }
        public int SnapshotId { get; set; }
        public int? SubthemeId { get; set; }
        public String Text { get; set; }
        public int ThemeId { get; set; }
    }
}
