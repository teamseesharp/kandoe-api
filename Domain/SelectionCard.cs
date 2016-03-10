﻿using System;
using System.Collections.Generic;

namespace Kandoe.Business.Domain {
    public class SelectionCard {
        protected SelectionCard() { }
        public SelectionCard(String image, String text, int themeId, int? subthemeId = null) {
            this.Image = image;
            this.SubthemeId = subthemeId;
            this.Text = text;
            this.ThemeId = themeId;
        }

        public int Id { get; set; }
        public String Image { get;  set; }
        public String Text { get; set; }
        public int ThemeId { get; set; }

        public int? SubthemeId { get; protected set; }
    }
}
