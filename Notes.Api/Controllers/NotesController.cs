using Microsoft.AspNetCore.Mvc;
using Notes.Domian.Models;
using Notes.Domian.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(Note note)
        {
            var response = await _noteService.Create(note);

            if (response == false)
            {
                return BadRequest(new { message = "Didn`t added new note! " });
            }

            return Ok(response);
        }

        /// <summary>
        /// Get notes with title
        /// </summary>
        /// <param name="title"> Note title</param>
        /// <returns>Notes</returns>
        [HttpGet]
        [Route("Get/{title}")]
        public IActionResult GetByTitle(string title)
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
        public IActionResult GetById(uint id)
        {
            return Ok(_noteService.GetById(id));
        }

        /// <summary>
        /// Update note with id
        /// </summary>
        /// <param name="note">Note object</param>
        [HttpPut]
        [Route("Update")]
        public void Update(Note note)
        {
            _noteService.Update((uint)note.Id, note);
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
        public void Delete(uint id)
        {
            _noteService.Delete(id);
        }
    }
}
