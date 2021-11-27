using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using Notes.Domian.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool Create(string title, string text, string[] hashtags)
        {
            if (String.IsNullOrWhiteSpace(title)) return false;
            if (String.IsNullOrWhiteSpace(text)) return false;
            else
            {
                Note note = new Note
                {
                    Title = title,
                    Text = text,
                    Hashtags = hashtags,
                    CreationDate = DateTime.UtcNow,
                    LastEditionDate = null
                };

                _noteRepository.Add(note);
                return true;
            }
        }

        public void Delete(Note note)
        {
            _noteRepository.Delete(note);
        }

        public Note[] Get(string title)
        {
            return _noteRepository.Get(title);
        }

        public Note[] GetAllNotes()
        {
            return _noteRepository.GetAllNotes();
        }
        public void Update(Note note, string title, string text, string[] hashtags)
        {
            _noteRepository.Update(note);
        }
    }
}
