using AutoMapper;
using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccess.NoteConvertor
{
    public class NoteConverter : INoteConverter
    {
        private readonly IMapper _mapper;

        public NoteConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Entites.Note ConvertNoteToEntity(Note note)
        {
            var _note = _mapper.Map<Entites.Note>(note);

            _note.CreationDate = System.DateTime.UtcNow;
            _note.LastEditionDate = System.DateTime.UtcNow;

            var sb = new StringBuilder();

            foreach (var item in note.Hashtags)
            {
                sb.Append($"#{item}");
            }

            _note.Hashtags = sb.ToString();
            return _note;
        }
        public Note ConvertEntityToNote(Entites.Note note)
        {
            var _note = _mapper.Map<Note>(note);

            var hashtags = note.Hashtags.Split('#');

            _note.Hashtags.Clear();

            foreach (var hashtag in hashtags)
            {
                _note.Hashtags.Add(hashtag);
            }
            _note.Hashtags.Remove("");

            return _note;
        }

    }
}
