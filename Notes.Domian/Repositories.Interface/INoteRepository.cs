using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Repositories.Interface
{
    public interface INoteRepository
    {
        void Add(Note note);
        Note[] GetAllNotes();
        Note[] Get(string title);
        Note GetById(int id);
        void Update(int id,Note note);
        void Delete(int id);
    }
}
