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
            _context.Notes.Add(_note);
        }

        public void Delete(Note note)
        {
            var _note = _mapper.Map<Entites.Note>(note);
            _context.Notes.Remove(_context.Notes.Find(_note.Id));
        }
        public Note[] Get(string title)
        {
            var notes = _context.Notes.Where(n => n.Title == title).ToArray();
            return _mapper.Map<Note[]>(notes);
        }

        public Note[] GetAllNotes()
        {
            var notes = _context.Notes.ToArray();
            return _mapper.Map<Note[]>(notes);
        }

        public void Update(Note note)
        {
            var _note = _mapper.Map<Entites.Note>(note);
            _context.Update(_note);    
        }
    }
}
