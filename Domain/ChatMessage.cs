using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kandoe.Business.Domain {
    public class ChatMessage {
        public ChatMessage(String text) {
            this.Text = text;
        }

        public int Id { get; set; }
        public String Text { get; private set; }
    }
}
