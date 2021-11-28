using Microsoft.AspNetCore.Mvc;
using Notes.Domian.Models;
using Notes.Domian.Services.Interface;
using System;


namespace Notes.Api.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpPost]
        public ActionResult<bool> Create(Note note)
        {
            return Ok(_noteService.Create(note));
        }
        [HttpGet("{title}")]
        public ActionResult<Note[]> Get(string title)
        {
            return _noteService.Get(title);
        }

        [HttpPut]
        public ActionResult<string> Update(Guid id, string title, string text, string[] hashtags)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<Note[]> GetAllNotes()
        {
            return _noteService.GetAllNotes();
        }
    }
}
