using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Repositories.Interface
{
    public interface INoteRepository
    {
        Note[] GetAllNotes();
        Note[] Get(string title);
        void Add(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}
