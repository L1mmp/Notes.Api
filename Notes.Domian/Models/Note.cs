using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Models
{
    public class Note
    {
        public string[]? Hashtags { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastEditionDate { get; set; }

    }
}
