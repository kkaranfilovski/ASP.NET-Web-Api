using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Notes.ServiceModels.NoteModels;
using SEDC.WebApi.Notes.Services.Interfaces;

namespace SEDC.WebApi.Notes.Api.Controllers
{
    [Authorize]
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

        [HttpGet("/{id}/user/{userId}")]
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

        [HttpPost("create-note")]
        public ActionResult CreateNote(CreateNoteDto request)
        {
            try
            {
                _noteService.AddNote(request);
                return StatusCode(StatusCodes.Status201Created, "ILIJA KE TE TEPA");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-note/{id}/user/{userId}")]
        public ActionResult DeleteNote(int id, int userId)
        {
            try
            {
                _noteService.DeleteNote(id, userId);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
