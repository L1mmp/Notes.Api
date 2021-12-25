using System.Linq;
using System;
using AutoMapper;
using Notes.DataAccess.DataAccess;
using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using Notes.DataAccess.NoteConvertor;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Notes.DataAccess.Repositories
{
    public class NoteRepsitory : INoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly INoteConverter _noteConverter;

        public NoteRepsitory(ApplicationDbContext context, INoteConverter noteConverter)
        {
            _context = context;
            _noteConverter = noteConverter;
        }

        public async Task<int> Add(Note note)
        {
            var _note = _noteConverter.ConvertNoteToEntity(note);

            var result = await _context.Notes.AddAsync(_note);

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public void Delete(uint id)
        {
            var noteToRemove = _context.Notes.Find(id);
            if (!noteToRemove.Equals(null))
            {
                _context.Notes.Remove(noteToRemove);
                SaveAsync();
            }
        }
        public List<Note> GetByTitle(string title)
        {
            var notes = _context.Notes
                .Where(n => n.Title.ToLower() == title.ToLower()).ToList();
            List<Note> convertedNotes = new List<Note>();
            foreach (var note in notes)
            {
                convertedNotes.Add(_noteConverter.ConvertEntityToNote(note));
            }

            return convertedNotes;
        }

        public List<Note> GetAllNotes()
        {
            var notes = _context.Notes.ToList();
            List<Note> convertedNotes = new List<Note>();

            foreach (var note in notes)
            {
                convertedNotes.Add(_noteConverter.ConvertEntityToNote(note));
            }

            return convertedNotes;
        }

        public Note GetById(uint id)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Id == id);
            if (note is null)
            {
                return null;
            }

            return _noteConverter.ConvertEntityToNote(note);
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
                SaveAsync();
            }

        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
