using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Notes.DataAccess.Entites
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public HashSet<string> Hashtags { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastEditionDate { get; set; }
    }
}
