using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Class03.QueryParams.Models;

namespace SEDC.WebApi.Class03.QueryParams.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly List<Note> _notes = new List<Note>
    {
        new Note
        {
            Id = 1,
            Text = "Buy milk",
            Color = "Green",
            UserId = 1,
        },
        new Note
        {
            Id = 2,
            Text = "Walk dog",
            Color = "ORange",
            UserId= 2,

        },
        new Note
        {
            Id = 3,
            Text = "Clean floor",
            Color = "orange",
            UserId = 2

        }
    };

        [HttpGet("{Id}")]
        public ActionResult<Note> GetById(int id)
        {
            var note = _notes.FirstOrDefault(x => x.Id == id);

            if (note == null) 
            {
                return NotFound("Note doesnt exists");
            } 
            
            return Ok(note);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Note>> GetList([FromQuery] string? orderBy)
        {
            var notes = _notes;

            var req = Request;
            var res = Response;

            switch (orderBy)
            {
                case "Text":
                    notes = notes.OrderBy(x => x.Text).ToList();
                        break;
                case "Color":
                    notes = notes.OrderBy(x => x.Color).ToList();
                    break;        
            }

            return Ok(notes);
        }

        [HttpGet("user/{userId}/notes")]
        public ActionResult<IEnumerable<Note>> GetNotesForUser([FromRoute] int userId, [FromQuery]SearchNotesInput input)
        {
            var notes = _notes.Where(x => x.UserId == userId);
            if (!string.IsNullOrWhiteSpace(input.Color))
            {
                notes = notes.Where(x => x.Color == input.Color);
            }
            switch (input.OrderBy)
            {
                case "Text":
                    notes = notes.OrderBy(x => x.Text);
                    break;
                case "Color":
                    notes = notes.OrderBy(x => x.Color);
                    break;
            }

            return Ok(notes);
        }
        [HttpGet("user/{userId}/notesForUser")]
        public ActionResult<IEnumerable<Note>> GetNotesForLoggedUser([FromRoute] int userId, [FromHeader] int? authUser)
        {
            if(authUser is null)
            {
                return Unauthorized();
            }
            if(authUser != userId)
            {
                return Forbid();
            }
            var notes = _notes.Where(x => x.UserId == userId);
            return Ok(notes);
        }
    }
}
