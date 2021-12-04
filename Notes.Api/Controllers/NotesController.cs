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

        /// <summary>
        /// Create note
        /// </summary>
        /// <param name="note">Note object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public ActionResult<bool> Create(Note note)
        {
            return Ok(_noteService.Create(note));
        }

        /// <summary>
        /// Get notes with title
        /// </summary>
        /// <param name="title"> Note title</param>
        /// <returns>Notes</returns>
        [HttpGet]
        [Route("Get/{title}")]
        public ActionResult<Note[]> GetByTitle(string title)
        {
            return Ok(_noteService.GetByTitle(title));
        }

        /// <summary>
        /// Get notes with id
        /// </summary>
        /// <param name="id">Note id</param>
        /// <returns>Note</returns>
        [HttpGet]
        [Route("Get/{id:int}")]
        public ActionResult<Note> GetById(int id)
        {
            return Ok(_noteService.GetById(id));
        }

        /// <summary>
        /// Update note with id
        /// </summary>
        /// <param name="id"> Note id</param>
        /// <param name="note">Note object</param>
        [HttpPut]
        [Route("Update")]
        public void Update(int id, Note note)
        {
            _noteService.Update(id, note);
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns>All notes</returns>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Note[]> GetAllNotes()
        {
            return Ok(_noteService.GetAllNotes());
        }

        /// <summary>
        /// Delete note with id 
        /// </summary>
        /// <param name="id">Note id</param>
        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            _noteService.Delete(id);
        }
    }
}
