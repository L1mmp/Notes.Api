using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Services.Interface
{
    public interface INoteService
    {
        bool Create(Note note);
        Note[] GetByTitle(string title);
        Note GetById(uint id);
        void Update(uint id, Note note);
        void Delete(uint id);
        Note[] GetAllNotes();
    }
}
