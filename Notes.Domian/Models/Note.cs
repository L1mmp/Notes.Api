﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Models
{
    public class Note
    {
        public int Id { get; set; }
        public HashSet<string> Hashtags { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
