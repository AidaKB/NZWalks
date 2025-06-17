using Microsoft.AspNetCore.Mvc;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudets()
        {
            var students = new List<string> { "John Doe", "Jane Smith", "Alice Johnson" };
            return Ok(students);
        }
    }

}
