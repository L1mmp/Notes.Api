using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using Notes.Domian.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Create(Note note)
        {
            if (String.IsNullOrWhiteSpace(note.Title)) return false;
            if (String.IsNullOrWhiteSpace(note.Text)) return false;
            else
            {
                await _noteRepository.Add(note);
                _noteRepository.SaveAsync();
                return true;
            }
        }
        public void Delete(uint id)
        {
            _noteRepository.Delete(id);
        }

        public List<Note> GetByTitle(string title)
        {
            return _noteRepository.GetByTitle(title);
        }

        public List<Note> GetAllNotes()
        {
            return _noteRepository.GetAllNotes();
        }

        public Note GetById(uint id)
        {
            return _noteRepository.GetById(id);
        }
        public void Update(uint id, Note note)
        {
            _noteRepository.Update(id,note);
        }
    }
}
