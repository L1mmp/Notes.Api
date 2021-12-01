using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Notes.DataAccess.Entites
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Hashtags { get; set; }
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastEditionDate { get; set; }
    }
}
