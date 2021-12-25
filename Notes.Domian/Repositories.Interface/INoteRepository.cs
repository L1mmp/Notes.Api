using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domian.Repositories.Interface
{
    public interface INoteRepository
    {
        Task<int> Add(Note note);
        List<Note> GetAllNotes();
        List<Note> GetByTitle(string title);
        Note GetById(uint id);
        void Update(uint id,Note note);
        void Delete(uint id);
        void SaveAsync();
    }
}
