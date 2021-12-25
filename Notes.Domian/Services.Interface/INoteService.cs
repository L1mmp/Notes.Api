using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domian.Services.Interface
{
    public interface INoteService
    {
        Task<bool> Create(Note note);
        List<Note> GetByTitle(string title);
        Note GetById(uint id);
        void Update(uint id, Note note);
        void Delete(uint id);
        List<Note> GetAllNotes();
    }
}
