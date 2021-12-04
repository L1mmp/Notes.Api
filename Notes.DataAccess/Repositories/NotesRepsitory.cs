﻿using System.Linq;
using System;
using AutoMapper;
using Notes.DataAccess.DataAccess;
using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using Notes.DataAccess.NoteConvertor;

namespace Notes.DataAccess.Repositories
{
    public class NotesRepsitory : INoteRepository
    {
        private readonly NotesDbContext _context;
        private readonly INoteConverter _noteConverter;

        public NotesRepsitory(NotesDbContext context, INoteConverter noteConverter)
        {
            _context = context;
            _noteConverter = noteConverter;
        }

        public void Add(Note note)
        {
            var _note = _noteConverter.ConvertNoteToEntity(note);
            _context.Notes.Add(_note);
            Save();
        }

        public void Delete(uint id)
        {
            var noteToRemove = _context.Notes.Find(id);
            if (!noteToRemove.Equals(null))
            {
                _context.Notes.Remove(noteToRemove);
                Save();
            }
        }
        public Note[] GetByTitle(string title)
        {
            var notes = _context.Notes.Where(n => n.Title.ToLower() == title.ToLower()).ToArray();
            Note[] convertedNotes = new Note[notes.Length + 1];
            for (int i = 0; i < notes.Length; i++)
            {
                convertedNotes[i] = _noteConverter.ConvertEntityToNote(notes[i]);
            }

            return convertedNotes;
        }

        public Note[] GetAllNotes()
        {
            var notes = _context.Notes.ToArray();
            Note[] convertedNotes = new Note[notes.Length + 1];
            for (int i = 0; i < notes.Length; i++)
            {
                convertedNotes[i] = _noteConverter.ConvertEntityToNote(notes[i]);
            }
            return convertedNotes;
        }

        public Note GetById(uint id)
        {
            if (!_context.Notes.Find(id).Equals(null))
            {
                var note = _context.Notes.Find(id);
                return _noteConverter.ConvertEntityToNote(note);
            }
            return null;
        }

        public void Update(uint id, Note note)
        {
            if (!_context.Notes.Find(id).Equals(null))
            {
                var _noteToUpdate = _context.Notes.Find(id);
                var convertedNote = _noteConverter.ConvertNoteToEntity(note);

                _noteToUpdate.Title = convertedNote.Title;
                _noteToUpdate.Text = convertedNote.Text;
                _noteToUpdate.Hashtags = convertedNote.Hashtags;
                _noteToUpdate.LastEditionDate = DateTime.UtcNow;

                _context.Notes.Update(_noteToUpdate);
                Save();
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
