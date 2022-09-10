using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Workshop.Notes.Sevices.Interfaces;
using System.Diagnostics;

namespace SEDC.WebApi.Workshop.Notes.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly Stopwatch _stopwatch;

        public PerformanceController(INoteService noteService)
        {
            _noteService = noteService;
            _stopwatch = new Stopwatch();
        }

        [HttpGet("notes")]
        [AllowAnonymous]
        public ActionResult<long> GetNotesPerformance()
        {
            _stopwatch.Start();
            for(int i = 0; i < 1000; i++)
            {
                _noteService.GetNote(1, 1);
            }
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.ElapsedMilliseconds;
            return elapsedTime;
        }
    }
}
