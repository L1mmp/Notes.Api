using System;
using System.ComponentModel.DataAnnotations;

namespace Notes.DataAccess.Entites
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        public string[]? Hashtags { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastEditionDate { get; set; }
    }
}
