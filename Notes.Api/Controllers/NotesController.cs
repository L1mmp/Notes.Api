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
        public ActionResult<Note[]> GetByTitle(string title)
        {
            return Ok(_noteService.GetByTitle(title));
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetById(int id)
        {
            return Ok(_noteService.GetById(id));
        }

        [HttpPut]
        public void Update(int id, Note note)
        {
            _noteService.Update(id, note);
        }

        [HttpGet]
        public ActionResult<Note[]> GetAllNotes()
        {
            return Ok(_noteService.GetAllNotes());
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _noteService.Delete(id);
        }
    }
}
