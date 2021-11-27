using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Services.Interface
{
    public interface INoteService
    {
        bool Create(string title, string text, string[] hashtags);
        Note[] Get(string title);
        void Update(Note note,string title, string text, string[] hashtags);
        void Delete(Note note);

        Note[] GetAllNotes();
    }
}
