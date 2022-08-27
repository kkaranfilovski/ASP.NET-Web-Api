using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Class08.AdoNET.Models;
using SEDC.WebApi.Class08.AdoNET.Services;

namespace SEDC.WebApi.Class08.AdoNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            var noteService = new NoteService();

            //var note = noteService.GetNoteByUserId(1, 2);
            noteService.Add("NAUCI ADONET", "red", 5, 1);
            var notes = noteService.GetAllNotes();

            return Ok(notes);
        }

        [HttpGet("dapper")]
        public ActionResult<Note> GetAllDapper()
        {
            var noteService = new NoteDapperService();

            noteService.Add("dapper", "green", 5, 1);
            //var notes = noteService.GetAll();

            var note = noteService.GetByUserIdAndNoteId(1, 1);

            return Ok(note);
        }
    }
}
