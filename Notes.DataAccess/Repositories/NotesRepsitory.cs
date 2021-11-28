using System.Linq;
using AutoMapper;
using Notes.DataAccess.DataAccess;
using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;

namespace Notes.DataAccess.Repositories
{
    public class NotesRepsitory : INoteRepository
    {
        private readonly NotesDbContext _context;
        private readonly IMapper _mapper;

        public NotesRepsitory(NotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Note note)
        {
            var _note = _mapper.Map<Entites.Note>(note);
            _note.CreationDate = System.DateTime.UtcNow;
            _note.LastEditionDate = System.DateTime.UtcNow;
            _context.Notes.Add(_note);
        }

        public void Delete(int id)
        {
            _context.Notes.Remove(_context.Notes.Find(id));
        }
        public Note[] Get(string title)
        {
            var notes = _context.Notes.Where(n => n.Title.ToLower() == title.ToLower()).ToArray();
            return _mapper.Map<Note[]>(notes);
        }

        public Note[] GetAllNotes()
        {
            var notes = _context.Notes.ToArray();
            return _mapper.Map<Note[]>(notes);
        }

        public Note GetById(int id)
        {
            var note = _context.Notes.Find(id);
            return _mapper.Map<Note>(note);
        }

        public void Update(int id, Note note)
        {
            var _noteToUpdate = _context.Notes.Find(id);
            _mapper.Map(note, _noteToUpdate);
            _context.Update(_noteToUpdate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
