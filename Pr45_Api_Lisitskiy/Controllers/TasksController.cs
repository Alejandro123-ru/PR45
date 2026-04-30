using Microsoft.AspNetCore.Mvc;
using Pr45_Api_Lisitskiy.Context;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TasksController : Controller
    {
        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                using var context = new TaskContext();  // ← используйте using
                IEnumerable<Tasks> Tasks = context.Tasks.ToList();
                return Json(Tasks);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Route("item")]
        [HttpGet]
        [ProducesResponseType(typeof(Tasks), 200)]  // ← Tasks, а не List<Tasks>
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                using var context = new TaskContext();
                Tasks Task = context.Tasks.FirstOrDefault(x => x.Id == Id);

                if (Task == null)
                    return NotFound();

                return Json(Task);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
