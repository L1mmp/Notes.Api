﻿using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using Notes.Domian.Services.Interface;
using System;

namespace Notes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool Create(Note note)
        {
            if (String.IsNullOrWhiteSpace(note.Title)) return false;
            if (String.IsNullOrWhiteSpace(note.Text)) return false;
            else
            {
                _noteRepository.Add(note);
                _noteRepository.Save();
                return true;
            }
        }
        public void Delete(int id)
        {
            _noteRepository.Delete(id);
        }

        public Note[] Get(string title)
        {
            return _noteRepository.Get(title);
        }

        public Note[] GetAllNotes()
        {
            return _noteRepository.GetAllNotes();
        }

        public Note GetById(int id)
        {
            return _noteRepository.GetById(id);
        }
        public void Update(int id, Note note)
        {
            _noteRepository.Update(id,note);
        }
    }
}
