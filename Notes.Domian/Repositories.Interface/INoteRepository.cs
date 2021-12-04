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
        Note[] GetByTitle(string title);
        Note GetById(uint id);
        void Update(uint id,Note note);
        void Delete(uint id);
        void Save();
    }
}
