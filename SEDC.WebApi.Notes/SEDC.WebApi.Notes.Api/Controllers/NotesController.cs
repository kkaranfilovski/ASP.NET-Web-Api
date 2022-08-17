using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Notes.ServiceModels.NoteModels;
using SEDC.WebApi.Notes.Services.Interfaces;

namespace SEDC.WebApi.Notes.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet("/user/{userId}")]
        public ActionResult<IEnumerable<NoteDto>> GetUserNotes(int userId)
        {
            try
            {
                var note = _noteService.GetUserNotes(userId);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/user/{userId}")]
        public ActionResult<NoteDto> GetNote(int id, int userId)
        {
            try
            {
                var note = _noteService.GetNote(id, userId);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
