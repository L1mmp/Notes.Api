using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domian.Services.Interface
{
    public interface INoteService
    {
        bool Create(Note note);
        Note[] Get(string title);
        Note GetById(int id);
        void Update(int id, Note note);
        void Delete(int id);
        Note[] GetAllNotes();
    }
}
