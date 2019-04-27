using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft.Components
{
    public class ListItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public Action Command { get; set; }
    }
}
